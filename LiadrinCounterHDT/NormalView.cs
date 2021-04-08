using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Controls;
using Hearthstone_Deck_Tracker.Properties;
using Card = Hearthstone_Deck_Tracker.Hearthstone.Card;

namespace LiadrinCounterHDT
{
    public class NormalView : StackPanel
    {
        public List<Card> Cards;
        public HearthstoneTextBlock Label;
        public AnimatedCardList View;

        public NormalView()
        {
            Orientation = Orientation.Vertical;

            // Section Label
            Label = new HearthstoneTextBlock();
            Label.FontSize = 16;
            Label.TextAlignment = TextAlignment.Center;
            Label.Text = "Liadrin Counter";
            var margin = Label.Margin;
            margin.Top = 20;
            Label.Margin = margin;
            Children.Add(Label);
            Label.Visibility = Visibility.Hidden;

            // Card View
            View = new AnimatedCardList();
            Children.Add(View);
            Cards = new List<Card>();
        }

        public bool Update(Card card, bool isSpell = false)
        {
            if (card.Type != "Minion" && !isSpell)
            {
                return false;
            }

            // Increment
            var match = Cards.FirstOrDefault(c => c.Name == card.Name);
            if (match != null)
            {
                Cards.Remove(match);
                card = match.Clone() as Card;
                card.Count++;
            }

            // Update View
            Cards.Add(card);
            View.Update(Cards, false);

            Label.Visibility = Visibility.Visible;

            return true;
        }
    }
}