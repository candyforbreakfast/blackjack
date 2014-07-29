using System;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace Blackjack {
    public class Card {
        int Rank { set; get; }
        string Suit { set; get; }

        public Card(int rank, string suit) {
            Rank = rank;
            Suit = suit;
        }

        public int Value() {
            return Math.Min(Rank, 10);
        }

        public BitmapImage BackOfCard() {
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(String.Format("/BlackjackGame;component/images/red_joker.png"), UriKind.RelativeOrAbsolute);
            bi.EndInit();
            return bi;
        }

        public BitmapImage SourceImage() {
            string name;

            switch (Rank) {
                case 1:
                    name = "ace";
                    break;
                case 11:
                    name = "jack";
                    break;
                case 12:
                    name = "queen";
                    break;
                case 13:
                    name = "king";
                    break;
                default:
                    name = Rank.ToString(CultureInfo.InvariantCulture);
                    break;
            }

            var bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(String.Format("/BlackjackGame;component/images/{0}_of_{1}.png", name, Suit), UriKind.RelativeOrAbsolute);
            bi.EndInit();
            return bi;
        }

    }
}
