namespace GameOfWar
{
    public class Card
    {
        private int _rank;
        public string Suit {get; private set;}
        public int Rank
        {
            get => _rank;
            private set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid");
                }
                _rank = value;
            }
        }
       
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static bool operator >(Card left, Card right)
        {
            if (left is null || right is null) return false;
            return left.Rank > right.Rank;
        }

        public static bool operator <(Card left, Card right)
        {
            if (left is null || right is null) return false;
            return left.Rank < right.Rank;
        }

        public string RankString()
        {
            return Rank switch
            {
                0 => "2",
                1 => "3",
                2 => "4",
                3 => "5",
                4 => "6",
                5 => "7",
                6 => "8",
                7 => "9",
                8 => "10",
                9 => "Jack",
                10 => "Queen",
                11 => "King",
                12 => "Ace",
                _ => throw new InvalidOperationException("Invalid Value")
            };
        }
    }
}