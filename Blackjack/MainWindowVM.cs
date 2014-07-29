
using System.Windows.Input;

namespace Blackjack {
    public class MainWindowVM : INPCBase {

        private Deck deck;
        private Hand playerHand;
        private Hand dealerHand;
        
        private string _playerCount;
        public string PlayerCount {
            get { return _playerCount; }
            set { _playerCount = value; RaisePropertyChanged(); }}
        
        private string _dealerCount;
        public string DealerCount {
            get { return _dealerCount; }
            set { _dealerCount = value; RaisePropertyChanged(); }}

        private string _message;
        public string Message {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }}

        private bool _buttonsEnabled;
        public bool ButtonsEnabled {
            get { return _buttonsEnabled; }
            set { _buttonsEnabled = value; RaisePropertyChanged(); }}


        #region command
        public ICommand NewGameCommand { get { return new RelayCommand(o => NewGame(), o => true);}}

        private void NewGame() {
            ButtonsEnabled = true;
            Message = "A new game has started!";
            deck = new Deck();
            playerHand = new Hand();
            dealerHand = new Hand();
            dealerHand.PutInHand(deck.Deal());
            dealerHand.PutInHand(deck.Deal());
            DealerCount = dealerHand.Total.ToString("G");
            playerHand.PutInHand(deck.Deal());
            playerHand.PutInHand(deck.Deal());
            PlayerCount = playerHand.Total.ToString("G");
        }


        public ICommand HitCommand {get {return new RelayCommand(o => Hit(), o => true);}}

        private void Hit() {
            var numCards = playerHand.NumberInHand;
            if (numCards <= 5) {
                playerHand.PutInHand(deck.Deal());
            }
            Message = "Player hit!";

            PlayerCount = playerHand.Total.ToString("G");
            if (playerHand.Total <= 21) return;
            Message = "Busted!";
            ButtonsEnabled = false;
        }
        

        public ICommand StandCommand { get {return new RelayCommand(o => Stand(), o => true);}}

        private void Stand() {
            var p = playerHand.Total;
            var d = dealerHand.Total;

            while (d < 17 && d <= p) {
                dealerHand.PutInHand(deck.Deal());
                if (dealerHand.NumberInHand <= 6) continue;
                Message = "Dealer busted";
                ButtonsEnabled = false;
                break;
            }

            if ((dealerHand.Total >= 17 && playerHand.Total > dealerHand.Total)
                || dealerHand.Total > 21) {
                Message = "You win";
                ButtonsEnabled = false;
            }
            else {
                Message = "You lose";
                ButtonsEnabled = false;
            }
        }

        #endregion





    }
}
