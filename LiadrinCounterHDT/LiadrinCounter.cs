using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Configuration;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Core = Hearthstone_Deck_Tracker.API.Core;
using Card = Hearthstone_Deck_Tracker.Hearthstone.Card;
using GameMode = Hearthstone_Deck_Tracker.Enums.GameMode;

namespace LiadrinCounterHDT
{
    public class LiadrinCounter
    {
        private static LiadrinCounter _instance;

        public static LiadrinCounter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LiadrinCounter();
                }
                return _instance;
            }
        }

        private StackPanel _friendlyPanel;
        private StackPanel _enemyPanel;

        private bool opponentCounterFreezed = false;
        private bool playerCounterFreezed = false;

        public NormalView normal;
        public NormalView enemy;

        public LiadrinCounter()
        {
            _instance = this;
            Settings.Load();
            
            //call the setting instance, to make sure that exist
            var settingsInstance = Settings.Instance;

            // Create container
            _enemyPanel = new StackPanel();
            _enemyPanel.Orientation = Orientation.Vertical; 
            Core.OverlayCanvas.Children.Add(_enemyPanel);
            Canvas.SetTop(_enemyPanel, Settings.EnemyTopOffset);
            Canvas.SetLeft(_enemyPanel, Settings.EnemyLeftOffset);
            
            // Create container
            _friendlyPanel = new StackPanel();
            _friendlyPanel.Orientation = Orientation.Vertical;
            Core.OverlayCanvas.Children.Add(_friendlyPanel);
            Canvas.SetTop(_friendlyPanel, Settings.PlayerTopOffset);
            Canvas.SetLeft(_friendlyPanel, Settings.PlayerLeftOffset);
            
            GameEvents.OnGameStart.Add(Reset);
            GameEvents.OnGameEnd.Add(Reset);
            
            GameEvents.OnOpponentPlay.Add(UpdateEnemyCounter);
            GameEvents.OnPlayerPlay.Add(UpdatePlayerCounter);
        }

        public void SettingChanged()
        {
            _enemyPanel.Opacity = Settings.OpponentCounterEnabled ? 1 : 0;

            _friendlyPanel.Opacity = Settings.PlayerCounterEnabled ? 1 : 0;
            
            Canvas.SetTop(_friendlyPanel, Settings.PlayerTopOffset);
            Canvas.SetLeft(_friendlyPanel, Settings.PlayerLeftOffset);

            Canvas.SetTop(_enemyPanel, Settings.EnemyTopOffset);
            Canvas.SetLeft(_enemyPanel, Settings.EnemyLeftOffset);
        }

        public void UpdatePlayerCounter(Card card)
        {
            if (playerCounterFreezed)
            { 
                return;
            }
            
            var rightCards = Settings.CardsToCheck;
            
            if (card.Equals(new Card(HearthDb.Cards.GetFromName("Lady Liadrin", Locale.enUS))))
            {
                playerCounterFreezed = true;
                return;
            }
            
            foreach (var check in rightCards)
            {
                if (card.Id == check.Id)
                {
                    normal.Update(card, true);
                    break;
                }
            }
        }

        public void UpdateEnemyCounter(Card card)
        {
            if (opponentCounterFreezed)
            {
                return;
            }

            if (card.Equals(new Card(HearthDb.Cards.GetFromName("Lady Liadrin", Locale.enUS))))
            {
                opponentCounterFreezed = true;
                return;
            }
            
            var rightCards = Settings.CardsToCheck;
            foreach (var check in rightCards)
            {
                if (card.Id == check.Id)
                {
                    enemy.Update(card, true);
                }
            }
        }
        
        public void Reset()
		{
			_friendlyPanel.Children.Clear();
            _enemyPanel.Children.Clear();
            
            opponentCounterFreezed = false;
            playerCounterFreezed = false;
            
            if (Core.Game.CurrentGameMode == GameMode.Battlegrounds)
            {
                // don't show graveyard for Battlegrounds
                return;
            }
            
            if (Settings.OpponentCounterEnabled)
            {
                enemy = new NormalView();
                _enemyPanel.Children.Add(enemy);
            }
            else
            {
                enemy = null;
            }

            if (Settings.PlayerCounterEnabled)
            {
                normal = new NormalView();
                _friendlyPanel.Children.Add(normal);
            }
            else
            {
                normal = null;
            }
		}

        public void Dispose()
        {
            _friendlyPanel.Children.Remove(normal);
            _enemyPanel.Children.Remove(enemy);
        }
    }
}