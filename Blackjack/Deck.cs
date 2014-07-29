using System;
using System.Collections.Generic;

namespace Blackjack {
    public class Deck : INPCBase {
        private readonly List<Card> cards = new List<Card>();
        private readonly Random rand;


        public Card Deal() {
            var card = cards[rand.Next(1, cards.Count)];
            cards.Remove(card);
            RaisePropertyChanged();
            return card;
        }

        public int RemainingCards {
            get { return cards.Count; }
        }

        public Deck() {
            rand = new Random();

            //create a deck of 52 cards
            for (var i = 1; i < 14; i++) {
                cards.Add(new Card(i, "diamonds"));
                cards.Add(new Card(i, "hearts"));
                cards.Add(new Card(i, "spades"));
                cards.Add(new Card(i, "clubs"));
            } 
        }
    }
}
