using Crosscutting.Util.Extension;

namespace Core.Entities
{
    public enum CardType
    {
        [StringValue("A")]
        Ace = 1,
        [StringValue("2")]
        Two = 2,
        [StringValue("3")]
        Three = 3,
        [StringValue("4")]
        Four = 4,
        [StringValue("5")]
        Five = 5,
        [StringValue("6")]
        Six = 6, 
        [StringValue("7")]
        Seven = 7, 
        [StringValue("8")]
        Eight = 8, 
        [StringValue("9")]
        Nine = 9,
        [StringValue("T")]
        Ten = 10, 
        [StringValue("J")]
        Jack = 11, 
        [StringValue("Q")]
        Queen = 12,
        [StringValue("K")]
        King = 13,
    }
}
