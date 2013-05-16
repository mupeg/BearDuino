/* 
* The MIT License (MIT)
*
* Copyright (c) 2013 Sean Hathaway
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/




/*  NOTES:   
 *      This is a simple thread safe (so far as I can tell) singleton class that contains all of the functionality needed to
 * incorporate a speaking teddy bear with proper lip-synching into whatever sort of project you desire.
 * When called from your application you will only need to set a couple of values up front and the bear will speak (through your computer speakers that is) 
 * by calling the Speak method while passing a string of text to be spoken...pretty simple huh?
 * 
 * Need to setup - Before you call the Speak method you will need to:
 *      - Pass a SerialPort into the method. This will be a Serial Port based on the on the COM that your Arduino is attached to and 
 *      should reflect the settings of port with respect to baud rate, parity, start and end bits etc. *Note: should also be the same
 *      Baud rate as the serial port that is created in your Arduino Sketch. By default I am using 9600 for my Examples.
 *      - Pass in the variables for the positions of your particular bears 'standard' mouth and eye positions with the SetBearConstants
 *      method. All bears are not quite created equal and you will therefore need to find and set these positions for proper 
 *      lip-synching to look as good as possible. *Note: you can use the example application to find these values with your bear, write them down
 *      and pass them in as constants in your application.
 *      
 *      Some notes on voices: There is a method for setting your voice and this may be changed at any time and will be reflected the next text that is spoken.
 * The voice name is not necessary and if it is left empty or cannot be resolved your systems default SAPI voice engine will be chosen.
 * When you have other engines installed on your machine you can get the names my looking at my sample applications voice drop down to see how to get a
 * list of these or simply go to the Control Panel and in the 'Accessibility' section there is a place for setting your default voice. The names in 
 * the dropdown would be what you would use there. 
 * 
 *      Some SAPI voices are much better than others but few are as bad as the one provide with Windows XP...do yourself a favor and find another free or cheap one
 * somewhere and try it out instead. The one that comes with Vista, 7 and 8 is much better and works well with the lip-syncing. Some voices that sound really
 * good are still bad for the lip-synching because it relies on the SAPI voice engine developers implementation of the "VisemeReached" event which is what
 * triggers the mouth motion in real time.
 * 
 * Note also there is a method called 'CloseEyes' that can be used to blink the eyes or so forth. Send this method a 'true' and the eyes will close and 'false' will open them.
 * 
 * Have fun and please post cool things that you have done with it!
 * 
 * Cheers!
 * Sean Hathaway
 * Sean@AFRUGAllery.com
 *      
 */

using System;
using System.IO.Ports;
using System.Speech.Synthesis;
using System.Threading;

namespace BearDuino
{
    public sealed class BearDuino : IDisposable
    {
        private static volatile BearDuino _instance;
        private static readonly object SyncRoot = new Object();
        private static SerialPort _port;
        private static string _voiceName;
        private static int _eyesClosed;
        private static int _eyesOpened;
        private static int _mouthOpened;
        private static int[] _mouthMap;

        public void SetVoiceName(string voiceName)
        {
            _voiceName = voiceName;
        }

        //the port should be fully setup to match the settings of the port in 'Manage hardware'
        public void SetPort(SerialPort port)
        {
            if (_port != null)
            {
                if (_port.IsOpen) _port.Close();
                _port.Dispose();
            }
            _port = port;
            port.Open();
        }

        //the basic values needed for good lip-synching of a particular bear
        public void SetBearConstants(int eyesClosed, int eyesOpened, int mouthOpened)
        {
            _eyesClosed = eyesClosed;
            _eyesOpened = eyesOpened;
            _mouthOpened = mouthOpened;
        }

        private BearDuino()
        {
            InitializeMouthMap();
            _eyesClosed = _eyesOpened = _mouthOpened = 50;
        }

        public static BearDuino Bear
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new BearDuino();
                    }
                }
                return _instance;
            }
        }

        //sends normalized (for your particular bear) positions to the Arduino attached to port
        public void SendPosition(int position)
        {
            lock (SyncRoot)
            {
                if (_port == null) return;
                if (!_port.IsOpen)
                    _port.Open();

                if (position < 0) position = 0;
                if (position > 100) position = 100;

                var val = new char[3];
                val[0] = (char)127;
                val[1] = (char)(position + 26);
                val[2] = (char)10;
                _port.Write(val, 0, 3);
            }
        }

        //this is all that is needed to make your bear speak in your application - It is thread safe blocking call
        public void Speak(string textToSpeak)
        {
            lock (SyncRoot)
            {
                using (var synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SetOutputToDefaultAudioDevice();
                    synthesizer.VisemeReached += _synthesizer_VisemeReached;

                    if (!string.IsNullOrEmpty(_voiceName))
                    {
                        try
                        {
                            synthesizer.SelectVoice(_voiceName);
                        }
                        catch
                        { }
                    }
                    synthesizer.Speak(textToSpeak);
                }
            }
        }

        //event for triggering lip-synching
        private void _synthesizer_VisemeReached(object sender, VisemeReachedEventArgs e)
        {
            var valueToSend = ConvertViseme(_mouthMap[e.Viseme]);
            SendPosition(valueToSend);
        }

        //to open or close the eyes
        public void CloseEyes(bool close)
        {
            SendPosition(close ? _eyesClosed : _eyesOpened);
        }

        //normalizes the raw lip-synching possitions to your particualr bear
        private static int ConvertViseme(int viseme)
        {
            var y1 = (float)_mouthOpened;
            var y2 = (float)_eyesOpened;
            var x = (float)viseme;
            var y = y1 - .01f * (y1 - y2) * x;
            return (int)y;
        }

        //sets up a lookup table of absolute mouth positions for each viseme reached (100% is fully closed, 0% is fully open).
        private static void InitializeMouthMap()
        {
            //set up viseme map - relative Percentages of mouth closed (100% =  full closed, 0% = full open)
            _mouthMap = new[]
            {
                100, // SP_VISEME_0  // 0  // Silence
                0,   // SP_VISEME_1  // 11 // AE, AX, A
                4,   // SP_VISEME_2  // 11 // AA
                7,   // SP_VISEME_3  // 11 // AO
                27,  // SP_VISEME_4  // 10 // EY, EH, U
                30,  // SP_VISEME_5  // 11 // ER 
                0,   // SP_VISEME_6  // 9  // y, IY, IH
                33,  // SP_VISEME_7  // 2  // w, UW
                50,  // SP_VISEME_8  // 13 // OW  
                4,   // SP_VISEME_9  // 9  // AW
                10,  // SP_VISEME_10 // 12 // OY
                0,   // SP_VISEME_11 // 11 // AY
                37,  // SP_VISEME_12 // 9  // h
                70,  // SP_VISEME_13 // 3  // r 
                73,  // SP_VISEME_14 // 6  // l
                80,  // SP_VISEME_15 // 7  // s, z   
                23,  // SP_VISEME_16 // 8  // SH, CH, J
                40,  // SP_VISEME_17 // 5  // TH, DH
                67,  // SP_VISEME_18 // 4  // f, v
                73,  // SP_VISEME_19 // 7  // d, t, n
                20,  // SP_VISEME_20 // 9  // k, g, NG
                100 // SP_VISEME_21 // 1  // p, b, m 
            };
        }

        public void Dispose()
        {
            if (_port == null) return;
            if (_port.IsOpen) _port.Close();
            _port.Dispose();
        }
    }
}

