using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack {
    public class Hand {
        private readonly List<Card> cards = new List<Card>(); 

        public int NumberInHand {
            get { return cards.Count; }
        }

        public void PutInHand(Card card) {
            cards.Add(card);
        }

        public int Total {
            get {
                var total = 0;

                foreach (var card in cards) {
                    if (card.Value() == 1 && total + card.Value() > 21) {
                        total += 1;
                    } else if (card.Value() == 1 && total + card.Value() < 21) {
                        total += 11;
                    } else {
                        total += Math.Min(card.Value(), 10);
                    }

                    if (total <= 21) continue;
                    //if over 21, recalculate total with any aces as 1 instead of 11.
                    var aceTotal = cards.Sum(c => (Math.Min(c.Value(), 10)));

                    if (aceTotal < 21) {
                        return aceTotal;
                    }
                }
                return total;
            }
        }
    }
}
