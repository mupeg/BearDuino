namespace BearDuino
{
    partial class BearDuinoTts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BearDuinoTts));
            this.speechText = new System.Windows.Forms.RichTextBox();
            this.speak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // speechText
            // 
            this.speechText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speechText.Location = new System.Drawing.Point(13, 13);
            this.speechText.Name = "speechText";
            this.speechText.Size = new System.Drawing.Size(909, 134);
            this.speechText.TabIndex = 0;
            this.speechText.Text = "";
            // 
            // speak
            // 
            this.speak.Location = new System.Drawing.Point(847, 153);
            this.speak.Name = "speak";
            this.speak.Size = new System.Drawing.Size(75, 23);
            this.speak.TabIndex = 1;
            this.speak.Text = "speak";
            this.speak.UseVisualStyleBackColor = true;
            this.speak.Click += new System.EventHandler(this.speak_Click);
            // 
            // BearDuinoTts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 187);
            this.Controls.Add(this.speak);
            this.Controls.Add(this.speechText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BearDuinoTts";
            this.Text = "BearDuino Text to Speech";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox speechText;
        private System.Windows.Forms.Button speak;
    }
}