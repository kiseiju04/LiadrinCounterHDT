using System.ComponentModel;

namespace LiadrinCounterHDT
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerCounterMarginScroll = new System.Windows.Forms.HScrollBar();
            this.PlayerEnableButton = new System.Windows.Forms.Button();
            this.EnemyEnableButton = new System.Windows.Forms.Button();
            this.EnemyCounterMarginScroll = new System.Windows.Forms.HScrollBar();
            this.PlayerSettingsText = new System.Windows.Forms.Label();
            this.PlayerCounterMargin = new System.Windows.Forms.Label();
            this.EnemySettingsText = new System.Windows.Forms.Label();
            this.EnemyCounterMarginText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayerCounterMarginScroll
            // 
            this.PlayerCounterMarginScroll.Location = new System.Drawing.Point(318, 89);
            this.PlayerCounterMarginScroll.Name = "PlayerCounterMarginScroll";
            this.PlayerCounterMarginScroll.Size = new System.Drawing.Size(297, 21);
            this.PlayerCounterMarginScroll.TabIndex = 0;
            this.PlayerCounterMarginScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PlayerCounterMarginScroll_Scroll);
            // 
            // PlayerEnableButton
            // 
            this.PlayerEnableButton.Location = new System.Drawing.Point(61, 49);
            this.PlayerEnableButton.Name = "PlayerEnableButton";
            this.PlayerEnableButton.Size = new System.Drawing.Size(101, 35);
            this.PlayerEnableButton.TabIndex = 3;
            this.PlayerEnableButton.Text = "Enable";
            this.PlayerEnableButton.UseVisualStyleBackColor = true;
            this.PlayerEnableButton.Click += new System.EventHandler(this.PlayerEnableButton_Click);
            // 
            // EnemyEnableButton
            // 
            this.EnemyEnableButton.Location = new System.Drawing.Point(61, 186);
            this.EnemyEnableButton.Name = "EnemyEnableButton";
            this.EnemyEnableButton.Size = new System.Drawing.Size(101, 35);
            this.EnemyEnableButton.TabIndex = 7;
            this.EnemyEnableButton.Text = "Enable";
            this.EnemyEnableButton.UseVisualStyleBackColor = true;
            this.EnemyEnableButton.Click += new System.EventHandler(this.EnemyEnableButton_Click);
            // 
            // EnemyCounterMarginScroll
            // 
            this.EnemyCounterMarginScroll.Location = new System.Drawing.Point(318, 244);
            this.EnemyCounterMarginScroll.Name = "EnemyCounterMarginScroll";
            this.EnemyCounterMarginScroll.Size = new System.Drawing.Size(297, 21);
            this.EnemyCounterMarginScroll.TabIndex = 4;
            this.EnemyCounterMarginScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.EnemyCounterMarginScroll_Scroll);
            // 
            // PlayerSettingsText
            // 
            this.PlayerSettingsText.Location = new System.Drawing.Point(31, 24);
            this.PlayerSettingsText.Name = "PlayerSettingsText";
            this.PlayerSettingsText.Size = new System.Drawing.Size(98, 19);
            this.PlayerSettingsText.TabIndex = 8;
            this.PlayerSettingsText.Text = "Player Settings";
            this.PlayerSettingsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerCounterMargin
            // 
            this.PlayerCounterMargin.Location = new System.Drawing.Point(64, 91);
            this.PlayerCounterMargin.Name = "PlayerCounterMargin";
            this.PlayerCounterMargin.Size = new System.Drawing.Size(98, 19);
            this.PlayerCounterMargin.TabIndex = 9;
            this.PlayerCounterMargin.Text = "Counter margin";
            this.PlayerCounterMargin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemySettingsText
            // 
            this.EnemySettingsText.Location = new System.Drawing.Point(31, 160);
            this.EnemySettingsText.Name = "EnemySettingsText";
            this.EnemySettingsText.Size = new System.Drawing.Size(98, 19);
            this.EnemySettingsText.TabIndex = 10;
            this.EnemySettingsText.Text = "Enemy Settings\r\n";
            this.EnemySettingsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnemyCounterMarginText
            // 
            this.EnemyCounterMarginText.Location = new System.Drawing.Point(64, 244);
            this.EnemyCounterMarginText.Name = "EnemyCounterMarginText";
            this.EnemyCounterMarginText.Size = new System.Drawing.Size(98, 28);
            this.EnemyCounterMarginText.TabIndex = 11;
            this.EnemyCounterMarginText.Text = "Counter margin\r\n\r\n";
            this.EnemyCounterMarginText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 454);
            this.Controls.Add(this.EnemyCounterMarginText);
            this.Controls.Add(this.EnemySettingsText);
            this.Controls.Add(this.PlayerCounterMargin);
            this.Controls.Add(this.PlayerSettingsText);
            this.Controls.Add(this.EnemyEnableButton);
            this.Controls.Add(this.EnemyCounterMarginScroll);
            this.Controls.Add(this.PlayerEnableButton);
            this.Controls.Add(this.PlayerCounterMarginScroll);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.Label EnemyCounterMarginText;

        private System.Windows.Forms.Label EnemySettingsText;

        private System.Windows.Forms.Label PlayerCounterMargin;

        private System.Windows.Forms.Label PlayerSettingsText;

        private System.Windows.Forms.Button PlayerEnableButton;
        private System.Windows.Forms.Button EnemyEnableButton;
        private System.Windows.Forms.HScrollBar EnemyCounterMarginScroll;

        private System.Windows.Forms.HScrollBar PlayerCounterMarginScroll;

        #endregion
    }
}