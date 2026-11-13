using System.Runtime.CompilerServices;
using GameOfWar;

//Set up
GameState gameState = new GameState();
gameState.CardDeck.Shuffle();

gameState.PlayerDeck.PushCards(gameState.CardDeck.Deal(26));
gameState.ComputerDeck.PushCards(gameState.CardDeck.Deal(26));


// Play Cards Function
static bool PlayCards(GameState state, int playerCardIndex)
{
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    if (playerCard.Rank > computerCard.Rank)
    {
        state.PlayerDeck.PushCard(playerCard);
        state.PlayerDeck.PushCard(computerCard);
        state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    else if (computerCard.Rank > playerCard.Rank)
    {
        state.ComputerDeck.PushCard(playerCard);
        state.ComputerDeck.PushCard(computerCard);
        state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    else
    {
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
    }

    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    else if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }
    return true;
}  

// Begin Game
Lib.RunGame(gameState, PlayCards);


namespace GameOfWar
{
    public class GameState
    {
       public Deck CardDeck {get; set;}
       public Deck PlayerDeck {get; set;}
       public Deck ComputerDeck {get; set;}
       public Deck TableDeck {get; set;}
      
       public string Winner {get; set;}
       public GameState()
        {
            Winner = string.Empty;
            CardDeck = new Deck(new List<Card>(), false);
            PlayerDeck = new Deck(new List<Card>(), true);
            ComputerDeck = new Deck(new List<Card>(), true);
            TableDeck = new Deck(new List<Card>(), true);
        }
    }
}