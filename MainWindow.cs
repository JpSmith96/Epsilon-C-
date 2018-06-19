using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;


namespace Epsilon_Csharp
{


    public partial class EpsilonWindow : Form
    {

        private String input, confidence;
        NameHandler nh = new NameHandler();
        GramWordDec gw = new GramWordDec();
        MathTimeHandler mt = new MathTimeHandler();
        ApplicationManager am = new ApplicationManager();
        String output;
        int nameSet = 0;
        Boolean speechActive = false;
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        SpeechSynthesizer ss = new SpeechSynthesizer();
        Boolean awake = false;
        int timerDuration = 0;
        Boolean isTimerRunning = false;
        



        public EpsilonWindow()
        {
            String myName = nh.GetName();
            InitializeComponent();
            if (myName.Equals("none"))
            {
                label1.Text = "Hi There! Enter your name to get started.";
            }
            else
            {
                label1.Text = "Welcome back " + myName + "!";
            }

            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EpsilonWindow_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(gw.myGrammar());
            GrammarBuilder gb = new GrammarBuilder();
            DictationGrammar dg = new DictationGrammar();
            gb.Append(commands, 1, 5);
            Grammar gram = new Grammar(gb);
            sre.LoadGrammarAsync(gram);
            sre.LoadGrammarAsync(dg);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;
        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            input = e.Result.Text.ToLower().ToString();
            confidence = e.Result.Confidence.ToString();
            Console.WriteLine(input);


            if ((input.Equals("hey epsilon") || input.Equals("epsilon")) && !(awake))
            {
                ArrayList ar = new ArrayList();
                ar.Add("Yes " + nh.GetName() + "?");
                ar.Add("What's up?");
                ar.Add("How can I help?");
                ar.Add("Whaddya need?");
                Random rnd = new Random();
                int r = rnd.Next(0, ar.Count-1);
                label1.Text = ar[r].ToString();
                ss.SpeakAsync(ar[r].ToString());
                awake = true;

            }
            if (!(nh.GetName().Equals("none")) && awake)
            {
                Console.WriteLine(confidence);
                Analyse(input);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            input = textBox1.Text.ToLower().ToString();
            textBox1.Text = "";
            if (nh.GetName().Equals("none"))
            {
                SetName(input);
            }
            else
            {
                Analyse(input);
            }


        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void EpsilonWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                input = textBox1.Text.ToLower().ToString();
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                input = textBox1.Text.ToLower().ToString();
                textBox1.Text = "";
                if (nh.GetName().Equals("none"))
                {
                    SetName(input);
                }
                else
                {
                    Analyse(input);
                }
            }
        }





        private void SetName(String input)
        {
            nh.ChangeName(input);
            label1.Text = "Nice to meet you " + nh.GetName() + "!";    
        }

        private void Analyse(String input)
        {
            if(input.Equals("hey epsilon") || input.Equals("epsilon"))
            {

            }

            else if (input.Contains("close app"))
            {
                Application.Exit();
            }
            else if (input.Contains("what is my name") || input.Contains("what's my name"))
            {
                //ArrayList output = [ "What's up?", "How can I help?", "Yes " + nh.GetName() ];
                label1.Text = "Your name is " + nh.GetName();
                ss.SpeakAsync("Your name is " + nh.GetName());
                awake = false;
            }


            else if (input.Contains("who are you"))
            {
                label1.Text = "My name is Epsilon, I am your virtual assistant";
                ss.SpeakAsync("My name is Epsilon, I am your virtual assistant");
                awake = false;

            }

            else if (input.Equals("nevermind"))
            {
                label1.Text = "";
                awake = false;
            }
            else if (input.Equals("what is the time") || input.Equals("what time is it"))
            {
                label1.Text = "The time is " + mt.CurrentTime();
                ss.SpeakAsync("The time is " + mt.CurrentTime());
                awake = false;

            }
            else if (input.Contains("chrome"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Chrome");
                am.chrome();
                awake = false;

            }

            else if (input.Equals("open photoshop"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening photoshop");
                am.photoshop();
                awake = false;

            }


            else if (input.Equals("open firefox"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening firefox");
                am.firefox();
                awake = false;

            }
            else if (input.Contains("messenger"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Messenger");
                am.messenger();
                awake = false;

            }
            else if (input.Contains("amazon"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Amazon");
                am.amazon();
                awake = false;

            }
            else if (input.Equals("open notepad"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Notepad");
                am.notepad();
                awake = false;

            }

            else if (input.Equals("open discord"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Discord");
                am.discord();
                awake = false;

            }

            else if (input.Equals("open youtube"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Youtube");
                am.youtube();
                awake = false;

            }

            else if (input.Equals("open c cleaner"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening C-Cleaner");
                am.CClean();
                awake = false;

            }

            else if (input.Equals("open powershell"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening PowerShell");
                am.PShell();
                awake = false;

            }

            else if (input.Equals("open dx diag"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening DX-DIAG");
                am.DXDiag();
                awake = false;

            }

            else if (input.Equals("open cmd") || input.Equals("open command prompt"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening CMD");
                am.cmdStart();
                awake = false;

            }

            else if (input.Contains("notepad plus plus"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Notepad Plus-Plus");
                am.NotepadPlus();
                awake = false;

            }
            else if (input.Contains("internet") || input.Contains("browser"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening your default browser");
                am.DefaultBrowser();
                awake = false;

            }
            else if (input.Equals("open word"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Microsoft Word");
                am.word();
                awake = false;

            }

            else if (input.Equals("hello there"))
            {
                label1.Text = "";
                ss.SpeakAsync("General Kenoh-beee!");
                awake = false;

            }
            else if (input.Equals("open excel"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Microsoft Excel");
                am.excel();
                awake = false;

            }
            else if (input.Equals("open powerpoint"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening Microsoft PowerPoint");
                am.PPoint();
                awake = false;

            }
            else if (input.Contains("current song") || input.Contains("this song"))
            {
                String song = am.CurrentSong();
                ss.SpeakAsync(song);
                label1.Text = song;

                awake = false;

            }

            else if (input.Contains("next song") || input.Contains("next track"))
            {
                ss.SpeakAsync("playing next song");
                am.nextSong();
                awake = false;

            }

            else if (input.Contains("volume up"))
            {
                am.VolmUp();
                awake = false;

            }

            else if (input.Contains("volume down"))
            {
                am.VolmDown();
                awake = false;

            }

            else if (input.Contains("file explorer"))
            {
                ss.SpeakAsync("Opening File Explorer");
                am.explorer();
                awake = false;

            }

            else if (input.Contains("the date"))
            {
                label1.Text = mt.CurrentDate();
                ss.SpeakAsync("It is "+ mt.CurrentDate());
                awake = false;

            }

            else if (input.Contains("last song") || input.Contains("previous song") || input.Contains("last track") || input.Contains("previous track"))
            {
                ss.SpeakAsync("playing previous song");
                am.prevSong();
                System.Threading.Thread.Sleep(1000);
                am.prevSong();
                awake = false;

            }

            else if (input.Contains("pause song") || input.Contains("play song") || input.Contains("start song") || input.Contains("stop song") || input.Contains("pause music") || input.Contains("play music") || input.Contains("start music") || input.Contains("stop music"))
            {
                //ss.SpeakAsync("Pausing Spotify");
                am.PausePlay();
                awake = false;

            }
            else if (input.Contains("weather"))
            {
                label1.Text = "Weather provided by Google";
                ss.SpeakAsync("Here is the weather for your current location");
                am.weather();
                awake = false;

            }
            else if (input.Equals("next app") || input.Equals("alt tab"))
            {
                label1.Text = "";
                ss.SpeakAsync("Alt-Tabbing");
                am.nextApp();
                awake = false;

            }
            else if (input.Equals("how much wood could a wood chuck chuck if a wood chuck could chuck wood"))
            {
                label1.Text = "Really " + nh.GetName() + "?";
                ss.SpeakAsync("Really "+ nh.GetName()+"?");
                am.nextApp();
                awake = false;

            }
            else if (input.Contains("spotify"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening spotify");
                am.spotify();
                awake = false;

            }

            else if (input.Contains("open skype"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening skype");
                am.skype();
                awake = false;

            }

            else if (input.Contains("steam"))
            {
                label1.Text = "";
                ss.SpeakAsync("Opening steam");
                am.steam();
                awake = false;

            }

            else if (input.Contains("timer for"))
            {
                label1.Text = "";
                int timeGrabbed = mt.TimerParser(input);
                timerDuration = timeGrabbed * 60;
                ss.SpeakAsync("Setting a timer for " + timeGrabbed.ToString() + " minutes");

                isTimerRunning = true;
                timer1.Start();
                timer1.Interval = 1000; // in miliseconds

                awake = false;

            }

            else if (input.Contains("stop timer"))
            {
                if (isTimerRunning)
                {
                    label1.Text = "Timer Stopped";
                    ss.SpeakAsync("Timer Stopped");
                    stopTimer();
                }
                else
                {
                    label1.Text = "No Timer Running";
                    ss.SpeakAsync("No Timer Running");
                }
                awake = false;

            }

            else if (input.Equals("shutdown pc"))
            {
                label1.Text = "";
                ss.SpeakAsync("Goodbye");
                am.shutdown();
                awake = false;

            }

            else if (input.Contains("plus") || input.Contains("add") || input.Contains("minus") || input.Contains("subtract") || input.Contains("multiply") || input.Contains("times") || input.Contains("divide"))
            {
                label1.Text = mt.Calc(input);
                ss.SpeakAsync(mt.Calc(input));
                awake = false;

            }
            else if (input.Contains("google") || input.Contains("what is") || input.Contains("search") || input.Contains("how do i"))
            {
                label1.Text = "";
                ss.SpeakAsync("searching google for " + am.googSearch(input));
                awake = false;

            }
            else if (input.Equals("debug all apps"))
            {
                am.GetProcessesDebug();
            }
            else
            {
                label1.Text = "Sorry, I'm afraid I can't help with that";
                ss.SpeakAsync("Sorry, I'm afraid I can't help with that");
                awake = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timerDuration > 0)
            {
                timerDuration--;
                label2.Text = timerDuration / 60 + ":" + ((timerDuration % 60) >= 10 ? (timerDuration % 60).ToString(): "0" + timerDuration%60);
            }
            else
            {
                isTimerRunning = false;
                timer1.Stop();
                label2.Text = "";
                ss.SpeakAsync("Your Timer Has Finished");

            }
        }

        private void stopTimer()
        {
            timer1.Stop();
            label2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(speechActive))
            {

                button2.Text = "Disable Speech Recognition";
                speechActive = true;
                sre.RecognizeAsync(RecognizeMode.Multiple);



            }
            else
            {
                button2.Text = "Enable Speech Recognition";
                sre.RecognizeAsyncStop();
                speechActive = false;
            }
        }
    }
}
