namespace BearDuino
{
    partial class TweetSpeak
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TweetSpeak));
            this.start = new System.Windows.Forms.Button();
            this.searchTermListBox = new System.Windows.Forms.ListView();
            this.searchTerms = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchTerm = new System.Windows.Forms.TextBox();
            this.addTerm = new System.Windows.Forms.Button();
            this.removeTerm = new System.Windows.Forms.Button();
            this.clearTerms = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(35, 172);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // searchTermListBox
            // 
            this.searchTermListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.searchTerms});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.searchTermListBox.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.searchTermListBox.Location = new System.Drawing.Point(35, 43);
            this.searchTermListBox.Name = "searchTermListBox";
            this.searchTermListBox.Size = new System.Drawing.Size(412, 97);
            this.searchTermListBox.TabIndex = 1;
            this.searchTermListBox.UseCompatibleStateImageBehavior = false;
            this.searchTermListBox.View = System.Windows.Forms.View.List;
            // 
            // searchTerms
            // 
            this.searchTerms.Text = "Twitter Search Terms";
            this.searchTerms.Width = 255;
            // 
            // searchTerm
            // 
            this.searchTerm.Location = new System.Drawing.Point(35, 146);
            this.searchTerm.Name = "searchTerm";
            this.searchTerm.Size = new System.Drawing.Size(412, 20);
            this.searchTerm.TabIndex = 0;
            this.searchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTerm_KeyPress);
            // 
            // addTerm
            // 
            this.addTerm.Location = new System.Drawing.Point(457, 144);
            this.addTerm.Name = "addTerm";
            this.addTerm.Size = new System.Drawing.Size(75, 23);
            this.addTerm.TabIndex = 3;
            this.addTerm.Text = "add";
            this.addTerm.UseVisualStyleBackColor = true;
            this.addTerm.Click += new System.EventHandler(this.addTerm_Click);
            // 
            // removeTerm
            // 
            this.removeTerm.Location = new System.Drawing.Point(457, 43);
            this.removeTerm.Name = "removeTerm";
            this.removeTerm.Size = new System.Drawing.Size(75, 23);
            this.removeTerm.TabIndex = 4;
            this.removeTerm.Text = "remove";
            this.removeTerm.UseVisualStyleBackColor = true;
            this.removeTerm.Click += new System.EventHandler(this.removeTerm_Click);
            // 
            // clearTerms
            // 
            this.clearTerms.Location = new System.Drawing.Point(457, 72);
            this.clearTerms.Name = "clearTerms";
            this.clearTerms.Size = new System.Drawing.Size(75, 23);
            this.clearTerms.TabIndex = 5;
            this.clearTerms.Text = "clear";
            this.clearTerms.UseVisualStyleBackColor = true;
            this.clearTerms.Click += new System.EventHandler(this.clearTerms_Click);
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(457, 172);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(75, 23);
            this.quit.TabIndex = 6;
            this.quit.Text = "quit";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(116, 172);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 7;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Enter some tweet serch terms below and press start:";
            // 
            // TweetSpeak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 224);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.clearTerms);
            this.Controls.Add(this.removeTerm);
            this.Controls.Add(this.addTerm);
            this.Controls.Add(this.searchTerm);
            this.Controls.Add(this.searchTermListBox);
            this.Controls.Add(this.start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TweetSpeak";
            this.Text = "BearDuino Tweet Speak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TweetSpeak_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ListView searchTermListBox;
        private System.Windows.Forms.ColumnHeader searchTerms;
        private System.Windows.Forms.TextBox searchTerm;
        private System.Windows.Forms.Button addTerm;
        private System.Windows.Forms.Button removeTerm;
        private System.Windows.Forms.Button clearTerms;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label1;
    }
}