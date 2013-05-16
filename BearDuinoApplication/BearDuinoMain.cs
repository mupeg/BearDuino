using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;


namespace BearDuino
{
    public partial class BearDuinoMain : Form
    {
        private int _eyesClosed;
        private int _eyesOpened;
        private int _mouthOpened;
        private int _baudRate;
        private ReadOnlyCollection<InstalledVoice> _voiceList;
        private static readonly object SyncRoot = new Object();

        public BearDuinoMain()
        {
            InitializeComponent();

            //get current saved application settings for specific bear head positions
            _eyesClosed = eyesClosed.Value = Properties.Settings.Default.EyesClosed;
            _eyesOpened = eyesOpened.Value = Properties.Settings.Default.EyesOpened;
            _mouthOpened = mouthOpened.Value = Properties.Settings.Default.MouthOpened;
            _baudRate = Properties.Settings.Default.BuadRate;

            eyesClosedValue.Text = _eyesClosed.ToString(CultureInfo.InvariantCulture);
            eyesOpenValue.Text = _eyesOpened.ToString(CultureInfo.InvariantCulture);
            mouthOpenedValue.Text = _mouthOpened.ToString(CultureInfo.InvariantCulture);

            //save settings to bear object
            BearDuino.Bear.SetBearConstants(_eyesClosed, _eyesOpened, _mouthOpened);
        }

        private void BearDuinoMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BearDuino.Bear != null)
                BearDuino.Bear.Dispose();

            //save any updated bear facial positions
            Properties.Settings.Default.EyesClosed = _eyesClosed;
            Properties.Settings.Default.EyesOpened = _eyesOpened;
            Properties.Settings.Default.MouthOpened = _mouthOpened;
            Properties.Settings.Default.Save();
        }

        private void comPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comPorts.SelectedItem == null) return;
            var port = new SerialPort(comPorts.SelectedItem.ToString()) {BaudRate = _baudRate};
            BearDuino.Bear.SetPort(port);
        }

        private void voiceNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (voiceNames.SelectedItem == null) return;
            BearDuino.Bear.SetVoiceName(voiceNames.SelectedItem.ToString());
        }

        private void eyesClosed_Scroll(object sender, EventArgs e)
        {
            _eyesClosed = eyesClosed.Value;
            eyesClosedValue.Text = eyesClosed.Value.ToString(CultureInfo.InvariantCulture);
            BearDuino.Bear.SendPosition(_eyesClosed);
            BearDuino.Bear.SetBearConstants(_eyesClosed, _eyesOpened, _mouthOpened);  
        }

        private void eyesOpened_Scroll(object sender, EventArgs e)
        {
            _eyesOpened = eyesOpened.Value;
            eyesOpenValue.Text = _eyesOpened.ToString(CultureInfo.InvariantCulture);
            BearDuino.Bear.SendPosition(_eyesOpened);
            BearDuino.Bear.SetBearConstants(_eyesClosed, _eyesOpened, _mouthOpened); 
        }

        private void mouthOpened_Scroll(object sender, EventArgs e)
        {
            _mouthOpened = mouthOpened.Value;
            mouthOpenedValue.Text = _mouthOpened.ToString(CultureInfo.InvariantCulture);
            BearDuino.Bear.SendPosition(_mouthOpened);
            BearDuino.Bear.SetBearConstants(_eyesClosed, _eyesOpened, _mouthOpened); 
        }

        private void comPorts_Click(object sender, EventArgs e)
        {
            //get list of active serial com ports
            var ports = SerialPort.GetPortNames();
            comPorts.DataSource = ports;
            comPorts.SelectedIndex = -1;
        }

        private void voiceNames_Click(object sender, EventArgs e)
        {
            //get list of installed SAPI voices
            using (var speech = new SpeechSynthesizer())
            {
                _voiceList = speech.GetInstalledVoices();
                var voices = _voiceList.Select(voice => voice.VoiceInfo.Name).ToList();
                voiceNames.DataSource = voices;
                voiceNames.SelectedIndex = -1;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tedTweet_Click(object sender, EventArgs e)
        {
            var tweetSpeak = new TweetSpeak();
            tweetSpeak.Show();
        }

        private void tts_Click(object sender, EventArgs e)
        {
            var BearDuinoTts = new BearDuinoTts();
            BearDuinoTts.Show();
        }
    }
}
