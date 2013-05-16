namespace BearDuino
{
    partial class BearDuinoMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BearDuinoMain));
            this.tedTweet = new System.Windows.Forms.Button();
            this.systemSettings = new System.Windows.Forms.GroupBox();
            this.voiceLabel = new System.Windows.Forms.Label();
            this.voiceNames = new System.Windows.Forms.ComboBox();
            this.comLabel = new System.Windows.Forms.Label();
            this.comPorts = new System.Windows.Forms.ComboBox();
            this.bearPositions = new System.Windows.Forms.GroupBox();
            this.mouthOpenedValue = new System.Windows.Forms.Label();
            this.MouthOpenedLable = new System.Windows.Forms.Label();
            this.eyesClosedValue = new System.Windows.Forms.Label();
            this.eyesClosedLable = new System.Windows.Forms.Label();
            this.eyesOpenValue = new System.Windows.Forms.Label();
            this.eyesOpenLable = new System.Windows.Forms.Label();
            this.mouthOpened = new System.Windows.Forms.TrackBar();
            this.eyesOpened = new System.Windows.Forms.TrackBar();
            this.eyesClosed = new System.Windows.Forms.TrackBar();
            this.close = new System.Windows.Forms.Button();
            this.tts = new System.Windows.Forms.Button();
            this.systemSettings.SuspendLayout();
            this.bearPositions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouthOpened)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesOpened)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesClosed)).BeginInit();
            this.SuspendLayout();
            // 
            // tedTweet
            // 
            this.tedTweet.Location = new System.Drawing.Point(384, 325);
            this.tedTweet.Name = "tedTweet";
            this.tedTweet.Size = new System.Drawing.Size(75, 23);
            this.tedTweet.TabIndex = 0;
            this.tedTweet.Text = "Ted Tweet";
            this.tedTweet.UseVisualStyleBackColor = true;
            this.tedTweet.Click += new System.EventHandler(this.tedTweet_Click);
            // 
            // systemSettings
            // 
            this.systemSettings.Controls.Add(this.voiceLabel);
            this.systemSettings.Controls.Add(this.voiceNames);
            this.systemSettings.Controls.Add(this.comLabel);
            this.systemSettings.Controls.Add(this.comPorts);
            this.systemSettings.Location = new System.Drawing.Point(12, 12);
            this.systemSettings.Name = "systemSettings";
            this.systemSettings.Size = new System.Drawing.Size(751, 94);
            this.systemSettings.TabIndex = 3;
            this.systemSettings.TabStop = false;
            this.systemSettings.Text = "Settings";
            // 
            // voiceLabel
            // 
            this.voiceLabel.AutoSize = true;
            this.voiceLabel.Location = new System.Drawing.Point(315, 25);
            this.voiceLabel.Name = "voiceLabel";
            this.voiceLabel.Size = new System.Drawing.Size(125, 13);
            this.voiceLabel.TabIndex = 3;
            this.voiceLabel.Text = "Select A Speaking Voice";
            // 
            // voiceNames
            // 
            this.voiceNames.FormattingEnabled = true;
            this.voiceNames.Location = new System.Drawing.Point(318, 41);
            this.voiceNames.Name = "voiceNames";
            this.voiceNames.Size = new System.Drawing.Size(405, 21);
            this.voiceNames.TabIndex = 2;
            this.voiceNames.SelectedIndexChanged += new System.EventHandler(this.voiceNames_SelectedIndexChanged);
            this.voiceNames.Click += new System.EventHandler(this.voiceNames_Click);
            // 
            // comLabel
            // 
            this.comLabel.AutoSize = true;
            this.comLabel.Location = new System.Drawing.Point(45, 25);
            this.comLabel.Name = "comLabel";
            this.comLabel.Size = new System.Drawing.Size(127, 13);
            this.comLabel.TabIndex = 1;
            this.comLabel.Text = "Select Arduino Serial Port";
            // 
            // comPorts
            // 
            this.comPorts.FormattingEnabled = true;
            this.comPorts.Location = new System.Drawing.Point(48, 41);
            this.comPorts.Name = "comPorts";
            this.comPorts.Size = new System.Drawing.Size(178, 21);
            this.comPorts.TabIndex = 0;
            this.comPorts.SelectedIndexChanged += new System.EventHandler(this.comPorts_SelectedIndexChanged);
            this.comPorts.Click += new System.EventHandler(this.comPorts_Click);
            // 
            // bearPositions
            // 
            this.bearPositions.Controls.Add(this.mouthOpenedValue);
            this.bearPositions.Controls.Add(this.MouthOpenedLable);
            this.bearPositions.Controls.Add(this.eyesClosedValue);
            this.bearPositions.Controls.Add(this.eyesClosedLable);
            this.bearPositions.Controls.Add(this.eyesOpenValue);
            this.bearPositions.Controls.Add(this.eyesOpenLable);
            this.bearPositions.Controls.Add(this.mouthOpened);
            this.bearPositions.Controls.Add(this.eyesOpened);
            this.bearPositions.Controls.Add(this.eyesClosed);
            this.bearPositions.Location = new System.Drawing.Point(12, 112);
            this.bearPositions.Name = "bearPositions";
            this.bearPositions.Size = new System.Drawing.Size(751, 190);
            this.bearPositions.TabIndex = 4;
            this.bearPositions.TabStop = false;
            this.bearPositions.Text = "Bear Positions";
            // 
            // mouthOpenedValue
            // 
            this.mouthOpenedValue.AutoSize = true;
            this.mouthOpenedValue.Location = new System.Drawing.Point(690, 142);
            this.mouthOpenedValue.Name = "mouthOpenedValue";
            this.mouthOpenedValue.Size = new System.Drawing.Size(33, 13);
            this.mouthOpenedValue.TabIndex = 8;
            this.mouthOpenedValue.Text = "value";
            this.mouthOpenedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MouthOpenedLable
            // 
            this.MouthOpenedLable.AutoSize = true;
            this.MouthOpenedLable.Location = new System.Drawing.Point(8, 142);
            this.MouthOpenedLable.Name = "MouthOpenedLable";
            this.MouthOpenedLable.Size = new System.Drawing.Size(88, 13);
            this.MouthOpenedLable.TabIndex = 7;
            this.MouthOpenedLable.Text = "Set Mouth Open:";
            // 
            // eyesClosedValue
            // 
            this.eyesClosedValue.AutoSize = true;
            this.eyesClosedValue.Location = new System.Drawing.Point(690, 34);
            this.eyesClosedValue.Name = "eyesClosedValue";
            this.eyesClosedValue.Size = new System.Drawing.Size(33, 13);
            this.eyesClosedValue.TabIndex = 6;
            this.eyesClosedValue.Text = "value";
            this.eyesClosedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eyesClosedLable
            // 
            this.eyesClosedLable.AutoSize = true;
            this.eyesClosedLable.Location = new System.Drawing.Point(12, 88);
            this.eyesClosedLable.Name = "eyesClosedLable";
            this.eyesClosedLable.Size = new System.Drawing.Size(81, 13);
            this.eyesClosedLable.TabIndex = 5;
            this.eyesClosedLable.Text = "Set Eyes Open:";
            // 
            // eyesOpenValue
            // 
            this.eyesOpenValue.AutoSize = true;
            this.eyesOpenValue.Location = new System.Drawing.Point(690, 88);
            this.eyesOpenValue.Name = "eyesOpenValue";
            this.eyesOpenValue.Size = new System.Drawing.Size(33, 13);
            this.eyesOpenValue.TabIndex = 4;
            this.eyesOpenValue.Text = "value";
            this.eyesOpenValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eyesOpenLable
            // 
            this.eyesOpenLable.AutoSize = true;
            this.eyesOpenLable.Location = new System.Drawing.Point(9, 34);
            this.eyesOpenLable.Name = "eyesOpenLable";
            this.eyesOpenLable.Size = new System.Drawing.Size(87, 13);
            this.eyesOpenLable.TabIndex = 3;
            this.eyesOpenLable.Text = "Set Eyes Closed:";
            // 
            // mouthOpened
            // 
            this.mouthOpened.Location = new System.Drawing.Point(100, 137);
            this.mouthOpened.Maximum = 100;
            this.mouthOpened.Name = "mouthOpened";
            this.mouthOpened.Size = new System.Drawing.Size(584, 45);
            this.mouthOpened.TabIndex = 2;
            this.mouthOpened.Value = 50;
            this.mouthOpened.Scroll += new System.EventHandler(this.mouthOpened_Scroll);
            // 
            // eyesOpened
            // 
            this.eyesOpened.Location = new System.Drawing.Point(100, 83);
            this.eyesOpened.Maximum = 100;
            this.eyesOpened.Name = "eyesOpened";
            this.eyesOpened.Size = new System.Drawing.Size(584, 45);
            this.eyesOpened.TabIndex = 1;
            this.eyesOpened.Value = 50;
            this.eyesOpened.Scroll += new System.EventHandler(this.eyesOpened_Scroll);
            // 
            // eyesClosed
            // 
            this.eyesClosed.Location = new System.Drawing.Point(100, 29);
            this.eyesClosed.Maximum = 100;
            this.eyesClosed.Name = "eyesClosed";
            this.eyesClosed.Size = new System.Drawing.Size(584, 45);
            this.eyesClosed.TabIndex = 0;
            this.eyesClosed.Value = 50;
            this.eyesClosed.Scroll += new System.EventHandler(this.eyesClosed_Scroll);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(688, 351);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 5;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // tts
            // 
            this.tts.Location = new System.Drawing.Point(259, 325);
            this.tts.Name = "tts";
            this.tts.Size = new System.Drawing.Size(119, 23);
            this.tts.TabIndex = 6;
            this.tts.Text = "Ted Text to Speech";
            this.tts.UseVisualStyleBackColor = true;
            this.tts.Click += new System.EventHandler(this.tts_Click);
            // 
            // BearDuinoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 386);
            this.Controls.Add(this.tts);
            this.Controls.Add(this.close);
            this.Controls.Add(this.bearPositions);
            this.Controls.Add(this.systemSettings);
            this.Controls.Add(this.tedTweet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BearDuinoMain";
            this.Text = "BearDuino Sample Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BearDuinoMain_FormClosing);
            this.systemSettings.ResumeLayout(false);
            this.systemSettings.PerformLayout();
            this.bearPositions.ResumeLayout(false);
            this.bearPositions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouthOpened)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesOpened)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyesClosed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tedTweet;
        private System.Windows.Forms.GroupBox systemSettings;
        private System.Windows.Forms.Label voiceLabel;
        private System.Windows.Forms.ComboBox voiceNames;
        private System.Windows.Forms.Label comLabel;
        private System.Windows.Forms.ComboBox comPorts;
        private System.Windows.Forms.GroupBox bearPositions;
        private System.Windows.Forms.Label mouthOpenedValue;
        private System.Windows.Forms.Label MouthOpenedLable;
        private System.Windows.Forms.Label eyesClosedValue;
        private System.Windows.Forms.Label eyesClosedLable;
        private System.Windows.Forms.Label eyesOpenValue;
        private System.Windows.Forms.Label eyesOpenLable;
        private System.Windows.Forms.TrackBar mouthOpened;
        private System.Windows.Forms.TrackBar eyesOpened;
        private System.Windows.Forms.TrackBar eyesClosed;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button tts;

    }
}

