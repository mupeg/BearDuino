using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TweetClean;

namespace BearDuino
{
    public partial class TweetSpeak : Form
    {
        private static readonly object SyncRoot = new Object();
        private Thread _tweetThread;
        private bool _isRunning;

        public TweetSpeak()
        {
            InitializeComponent();
        }

        private static void SpeakTweets(object terms)
        {
            lock (SyncRoot)
            {
                //Get list of tweets
                var t = terms as List<string>;
                if (t == null) return;
                var temp = new List<string>();
           
                foreach (var term in t)
                {
                    var list = TwitterSearch.GetSearchResults(term, 1);
                    temp.AddRange(list.Select(tweet => tweet.Title).ToList());
                }

                //only add unique tweets to the list
                var tweets = new List<string>();
                foreach (var tweet in temp)
                {
                    if (!tweets.Contains(tweet))
                    {
                        tweets.Add(tweet);
                    }
                }

                tweets.Shuffle();
                var random = new Random(DateTime.Now.Millisecond);
                foreach (var tweet in tweets)
                {
                    var ts = tweet;
                    //tweet clean
                    ts = ts.CleanTweet();
                    //TED clean
                    ts = ts.TedClean();
                    BearDuino.Bear.CloseEyes(false);
                    Thread.Sleep(300);
                    BearDuino.Bear.Speak(ts);
                    if(random.NextDouble() > 0.8)
                        BearDuino.Bear.CloseEyes(true);
                    Thread.Sleep(1000);
                }
            }
        }

        private void TweetSpeak_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isRunning) return;
            _tweetThread.Abort();
            _tweetThread.Join();
        }

        private void start_Click(object sender, EventArgs e)
        {
            //create a list of terms to pass
            var terms = (from ListViewItem term in searchTermListBox.Items select term.Text.ToLower()).ToList();

            if (_isRunning)
            {
                _tweetThread.Abort();
                _tweetThread.Join();
            }
            else
            {
                if (terms.Count == 0) return;
                _tweetThread = new Thread(SpeakTweets);
                _tweetThread.Start(terms);
            }
            _isRunning = !_isRunning;
        }

        private void addTerm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchTerm.Text)) return;
            var item = new ListViewItem(searchTerm.Text);
            searchTermListBox.Items.Add(item);
            searchTerm.Clear();
        }

        private void searchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                addTerm_Click(this, new EventArgs());
            }
        }

        private void clearTerms_Click(object sender, EventArgs e)
        {
            searchTermListBox.Clear();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void removeTerm_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in searchTermListBox.SelectedItems)
            {
                searchTermListBox.Items.Remove(item);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                _tweetThread.Abort();
                _tweetThread.Join();
            }
            _isRunning = false;
        }
    }
}
