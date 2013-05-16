using System;
using System.Threading;
using System.Windows.Forms;
using BearDuino;
using TweetClean;

namespace BearDuino
{
    //TODO - make multi threaded like the twitter part so you can cancel
    //TODO - add right click past functionality to textbox

    public partial class BearDuinoTts : Form
    {
        public BearDuinoTts()
        {
            InitializeComponent();
        }

        private void speak_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(speechText.Text)) return;
            speak.Enabled = false;
            var text = speechText.Text;
            text = text.TedClean();
            BearDuino.Bear.CloseEyes(false);
            Thread.Sleep(300);
            BearDuino.Bear.Speak(text);
            BearDuino.Bear.CloseEyes(true);
            speechText.Clear();
            speak.Enabled = true;
        }
    }
}
