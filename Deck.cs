namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };

        private List<Card> _cards;
        public int Count => _cards.Count;
        public Deck(List<Card> cards, bool isEmptyDeck)
        {
            if (cards != null && cards.Count > 0)
            {
                _cards = cards;
                return;
            }
            
            _cards = new List<Card>();
            if (!isEmptyDeck)
            {
                initializeDeck();
            }
        }
      
        private void initializeDeck()
        {
            foreach (string suit in Suits)
            {
                for (int i = 0; i < RankNames.Length; i++)
                {
                    _cards.Add(new Card(suit, i));
                }
            }
        }

        // I had to look up a better way to do this part, I was struggling lol

        public void Shuffle()
        {
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int RSN = Random.Shared.Next(0, i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[RSN];
                _cards[RSN] = temp;
            }
        }

        public Card CardAtIndex(int index)
        {
            if (index < 0 || index >= _cards.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return _cards[index];
        }

        public Card PullCardAtIndex(int index)
        {
            if (index <0 || index >= _cards.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Card pulledCard = _cards[index];
            _cards.RemoveAt(index);
            return pulledCard;
        }

      
        public List<Card> PullAllCards()
        {
            List<Card> pulledCards = new List<Card>(_cards);
            _cards.Clear();
            return pulledCards;
        }

        public void PushCard(Card card)
        {
            if (card != null)
            {
                _cards.Add(card);
            }
        }

        public void PushCards(List<Card> cards)
        {
            if (cards != null)
            {
                _cards.AddRange(cards);
            }
        }
    
        public List<Card> Deal(int count)
        {
            if (count < 0 || count > _cards.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Invalid number");
            }

            List<Card> dealtCards = _cards.GetRange(0, count);
            _cards.RemoveRange(0, count);

            return dealtCards;
        }
    }
}
