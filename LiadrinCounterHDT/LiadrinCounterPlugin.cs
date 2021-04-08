using System;
using System.Reflection;
using Hearthstone_Deck_Tracker.Plugins;
using System.Windows.Controls;

namespace LiadrinCounterHDT
{
    public class LiadrinCounterPlugin : IPlugin
    {
        public LiadrinCounter instance;
        
        public void OnLoad()
        {
            instance = new LiadrinCounter();
        }

        public void OnUnload()
        {
            instance.Dispose();
            instance = null;
        }

        public void OnButtonPress()
        {
            var form = new SettingsForm();
            form.Show();
        }

        public void OnUpdate()
        {
            
        }

        public string Name => "Liadrin Counter";
        public string Description => "a simple plugin";
        public string ButtonText => "settings";
        public string Author => "Kiseiju";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
        public MenuItem MenuItem => null;
    }
}