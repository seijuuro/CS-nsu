using System.Text;
using Core.Interfaces;
using Core.Models;
using Core.Models.Cards;
using Core.Players;
using Newtonsoft.Json;

namespace Core.Services;

public class Sandbox
{
    private Deck _deck;
    private readonly IDeckShuffler _shuffler;
    private readonly ElonPlayer _elon;
    private readonly MarkPlayer _mark;
    
    public Sandbox(Deck deck, IDeckShuffler deckShuffler, ElonPlayer elon, MarkPlayer mark)
    {
        _deck = deck;
        _shuffler = deckShuffler;
        _elon = elon;
        _mark = mark;
        
    }

    public bool RunRandomExperiment()
    {
        _deck = _shuffler.Shuffle(_deck);
        
        return CardsDraft();
    }
    
    public bool RunExperiment(string cardsOrder)
    {
        _deck.SetCards(cardsOrder);
        
        return CardsDraft();
    }
    
    public async Task<bool> RunExperimentUsingHttp(string elonUrl, string markUrl)
    {
        _deck = _shuffler.Shuffle(_deck);

        await SendDeckPartsToWebServices(elonUrl, markUrl);
        var numbers = await GetCardNumbersFromWebServices(elonUrl, markUrl);

        return CheckCardsColor(numbers.Item1, numbers.Item2);
    }
    
    public string GetElonStrategyName()
    {
        return _elon.GetStrategyName();
    }

    public string GetMarkStrategyName()
    {
        return _mark.GetStrategyName();
    }

    private bool CardsDraft()
    {
        _elon.ReceiveCards(_deck.GetFirstHalf());
        _mark.ReceiveCards(_deck.GetSecondHalf());
        
        var elonNumber = _elon.PickCard();
        var markNumber = _mark.PickCard();

        return CheckCardsColor(elonNumber, markNumber);
    }
    
    private bool CheckCardsColor(int elonNumber, int markNumber)
    {
        var cards = _deck.GetCards();
        
        return cards.ElementAt(elonNumber + cards.Count / 2).Color == cards.ElementAt(markNumber).Color;
    }
    
    private async Task SendDeckPartsToWebServices(string elonUrl, string markUrl)
    {
        var firstHalf = _deck.GetFirstHalf();
        var secondHalf = _deck.GetSecondHalf(); 
        
        var elonTask = SendDeckPartToWebService(firstHalf, elonUrl + "/player/receive-cards");
        var markTask = SendDeckPartToWebService(secondHalf, markUrl + "/player/receive-cards");

        await Task.WhenAll(elonTask, markTask);
    }
    
    private async Task<(int, int)> GetCardNumbersFromWebServices(string elonUrl, string markUrl)
    {
        var elonTask = GetCardNumberFromWebService(elonUrl + "/player/pick-card");
        var markTask = GetCardNumberFromWebService(markUrl + "/player/pick-card");

        await Task.WhenAll(elonTask, markTask);

        return (elonTask.Result, markTask.Result);
    }
        
    private async Task<int> GetCardNumberFromWebService(string url)
    {
        var client = new HttpClient();

        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(responseContent);
        }
        else
            throw new HttpRequestException($"GET request error. Server responded with status code: " +
                                           $"{response.StatusCode}");
    }

    private async Task SendDeckPartToWebService(List<Card> deckPart, string url)
    {
        var json = JsonConvert.SerializeObject(deckPart);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var client = new HttpClient();
        var response = await client.PostAsync(url, data);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"POST request error. Server responded with status code: " +
                                           $"{response.StatusCode}");
        }
    }
}