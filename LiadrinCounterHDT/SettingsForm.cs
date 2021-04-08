using System;
using System.Windows.Forms;

namespace LiadrinCounterHDT
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            EnemyCounterMarginScroll.Maximum = 100;
            EnemyCounterMarginScroll.Minimum = 0;
            
            PlayerCounterMarginScroll.Maximum = 100;
            PlayerCounterMarginScroll.Minimum = 0;
            
            EnemyCounterMarginScroll.Value = (int) Settings.EnemyLeftOffset / 1800 * 100;
            PlayerCounterMarginScroll.Value = (int) Settings.PlayerLeftOffset / 1800 * 100;
            
            EnemyEnableButton.Text = Settings.OpponentCounterEnabled ? "disable" : "enable";
            PlayerEnableButton.Text = Settings.PlayerCounterEnabled ? "disable" : "enable";
        }

        private void PlayerEnableButton_Click(object sender, EventArgs e)
        {
            Settings.SetPlayerCounterEnabled();

            PlayerEnableButton.Text = Settings.PlayerCounterEnabled ? "disable" : "enable";
            
            SettingsChanged();
        }

        private void PlayerCounterMarginScroll_Scroll(object sender, ScrollEventArgs e)
        {
            var value = e.NewValue;
            Settings.SetPlayerLeftMargin(value * 1800 / 100);
            
            SettingsChanged();
        }

        private void EnemyEnableButton_Click(object sender, EventArgs e)
        {
            Settings.SetOpponentCounterEnabled();
            
            EnemyEnableButton.Text = Settings.OpponentCounterEnabled ? "disable" : "enable";
            
            SettingsChanged();
        }

        private void EnemyCounterMarginScroll_Scroll(object sender, ScrollEventArgs e)
        {
            var value = e.NewValue;
            Settings.SetOpponentLeftMargin(value * 1800 / 100);
            SettingsChanged();
        }

        private void SettingsChanged()
        {
            Settings.Save();
            LiadrinCounter.Instance.SettingChanged();
        }
    }
}