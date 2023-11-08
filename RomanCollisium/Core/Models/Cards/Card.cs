namespace Core.Models.Cards;

public record Card(CardColor Color)
{
    public override string ToString()
    {
        return Color switch
        {
            CardColor.Black => "B",
            CardColor.Red => "R",
            _ => "?"
        };
    }
}