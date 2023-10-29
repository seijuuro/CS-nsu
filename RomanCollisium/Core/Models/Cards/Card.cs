namespace CollisiumCore.Models.Cards;

public record Card(CardColor Color)
{
    public override string ToString()
    {
        return Color == CardColor.Black ? "1 " : "0 ";
        //return Color == CardColor.Black ? "♠️ " : "♦️ ";
    }
    
    
}