using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Hearthstone_Deck_Tracker.Hearthstone;
using HearthDb;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Card = Hearthstone_Deck_Tracker.Hearthstone.Card;

namespace LiadrinCounterHDT
{
    public class Settings
    {
        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Settings();
                }
                return _instance;
            }
        }
        
        private static List<Card> _cardsToCheck = new List<Card>();
        public static List<Card> CardsToCheck => _cardsToCheck;

        private static bool _opponentCounterEnabled = true;
        public static bool OpponentCounterEnabled => _opponentCounterEnabled;

        private static bool _playerCounterEnabled = true;
        public static bool PlayerCounterEnabled => _playerCounterEnabled;

        private static double _enemyLeftOffset = 250;
        public static double EnemyLeftOffset => _enemyLeftOffset;

        private static double _enemyTopOffset = 0;
        public static double EnemyTopOffset => _enemyTopOffset;

        private static double _playerLeftOffset = 1650;
        public static double PlayerLeftOffset => _playerLeftOffset;

        private static double _playerTopOffset = 0;
        public static double PlayerTopOffset => _playerTopOffset;

        private Settings()
        {
            SetCardToCheck();
        }
        
        public static void Save()
        {
            XmlManager<Settings>.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml"), _instance);
        }
        
        public static void Load()
        {
            var settings = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.xml");
            var found = false;

            if (File.Exists(settings))
            {
                _instance = XmlManager<Settings>.Load(settings);
                found = true;
            }
            else if (File.Exists("settings.xml"))
            {
                _instance = XmlManager<Settings>.Load("settings.xml");
                found = true;
            }

            if (!found)
            {
                SetCardToCheck();
                Save();
            }
        }

        public static void SetOpponentCounterEnabled()
        {
            _opponentCounterEnabled = !_opponentCounterEnabled;
        }

        public static void SetPlayerCounterEnabled()
        {
            _playerCounterEnabled = !_playerCounterEnabled;
        }
        
        public static void SetCardToCheck()
        {
            List<Card> cards = new List<Card>();
            var cardsName = new[]
            {
                "Hand of A'dal",
                "Libram of Wisdom",
                "Libram of Hope",
                "Adaptation",
                "Blessing of Might",
                "Blessing of Wisdom",
                "Divine Strength",
                "Hand of Protection",
                "Sand Breath",
                "Lightforged Blessing",
                "Potion of Heroism",
                "Sound the Bells!",
                "Gift of Luminance",
                "Seal of Champions",
                "Blessing of Kings",
                "Silvermoon Portal",
                "Blessed Champion",
                "Blessing of Authority",
                "Pharaoh's Blessing"
            };

            foreach (var cardName in cardsName)
            {
                var card = new Card(Cards.GetFromName(cardName, Locale.enUS));
                cards.Add(card);
            }

            _cardsToCheck = cards;
        }
        
        public static void SetCardToCheck(List<string> names)
        {
            List<Card> cards = new List<Card>();

            foreach (var cardName in names)
            {
                var card = new Card(Cards.GetFromName(cardName, Locale.enUS));
                cards.Add(card);
            }

            _cardsToCheck = cards;
        }

        public static void SetPlayerLeftMargin(double value)
        {
            _playerLeftOffset = value;
        }
        
        public static void SetOpponentLeftMargin(double value)
        {
            _enemyLeftOffset = value;
        }
    }
}