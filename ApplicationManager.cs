using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using Discord;

namespace Epsilon_Csharp
{
    class ApplicationManager
    {
        String song = "";

        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        public const int VK_MEDIA_VOLUME_UP = 0xAF;
        public const int VK_MEDIA_VOLUME_DOWN = 0xAE;

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        private Timer timer1;
        int timerCheck = 0;


        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(int hwnd);


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);


        public ApplicationManager()
        {

        }

        public void chrome()
        {
            try
            {
                Process.Start("chrome.exe");
            } catch (Exception e)
            {
                Console.WriteLine("Chrome not installed");
            }
        }

        public void notepad()
        {
            Process.Start("notepad.exe");
        }

        public void word()
        {
            try
            {
                Process.Start("winword.exe");
            }catch (Exception e)
            {
                Console.WriteLine("Word not installed");
            }
        }

        public void skype()
        {
            try
            {
                Process.Start("skype.exe");
            } catch (Exception e)
            {
                Console.WriteLine("Skype not installed");
            }
        }

        public void excel()
        {
            try
            {
                Process.Start("excel.exe");
            } catch (Exception e)
            {
                Console.WriteLine("Excel not installed");
            }
        }

        public void firefox()
        {
            try
            {
                Process.Start("firefox.exe");
            }catch (Exception e)
            {
                Console.WriteLine("Firefox not installed");
            }
        }

        public void GetProcessesDebug()
        {
            Process[] p = Process.GetProcesses();
            Console.WriteLine("Count: {0}", p.Length);
            foreach(Process pr in p)
            {
                Console.WriteLine(pr.ProcessName);
            }
        }

        public void photoshop()
        {
            try
            {
                Process.Start("photoshop.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine("Photoshop not installed");
            }
        }

        public void nextApp()
        {
            SendKeys.Send("%{Tab}");
        }

        public String DiscordCurrentGame()
        {
            return null;
        }

        public void discord()
        {
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Process.Start(System.IO.Path.Combine(path, @"Discord\\app-0.0.300\\discord.exe"));
            }catch (Exception e)
            {
                Console.WriteLine("File not found");
            }

        }

        public void youtube()
        {
            Process.Start("https://www.youtube.com/");
        }

        public void cmdStart()
        {
            Process.Start("cmd.exe");
        }

        public void NotepadPlus()
        {
            try
            {
                Process.Start("notepad++.exe");
            }catch (Exception e)
            {
                Console.WriteLine("Notepad++ not installed");
            }
        }

        public String CurrentSong()
        {
            var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));

            if (proc == null)
            {
                return "Spotify is not running!";
            }

            if (string.Equals(proc.MainWindowTitle, "Spotify", StringComparison.InvariantCultureIgnoreCase))
            {
                return "No track is playing";
            }

            return "the current song is " + proc.MainWindowTitle;
        }

        public void nextSong()
        {
            try
            {
                keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }catch (Exception e)
            {
                Console.WriteLine("Next song not available");
            }
        }


        private void vu(object sender, EventArgs e)
        {
            if (timerCheck < 10)
            {
                timerCheck++;
                keybd_event(VK_MEDIA_VOLUME_UP, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }
            else
            {
                timer1.Stop();
                timerCheck = 0;
            }
        }

        public void VolmUp()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(vu);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }
        
        private void vd(object sender, EventArgs e)
        {
            if (timerCheck < 10)
            {
                timerCheck++;
                keybd_event(VK_MEDIA_VOLUME_DOWN, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }
            else
            {
                timer1.Stop();
                timerCheck = 0;
            }
        }

        public void VolmDown()
        {

            timer1 = new Timer();
            timer1.Tick += new EventHandler(vd);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        private void prevSongDouble()
        {
            if (timerCheck < 3)
            {
                keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
                timerCheck++;
                prevSongDouble();
            }
            else
            {
                timerCheck = 0;
            }
        }

        public void prevSong()
        {
            prevSongDouble();
        }

        public void PausePlay()
        {
            try
            {
                keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }catch (Exception e)
            {
                Console.WriteLine("Action not available");
            }
        }

        public void PPoint()
        {
            try
            {
                Process.Start("powerpnt.exe");
            }catch(Exception e)
            {
                Console.WriteLine("Power point not installed");
            }
        }

        public void PShell()
        {
            try
            {
                Process.Start("powershell.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine("Power Shell not installed");
            }
        }

        public void DXDiag()
        {
            try
            {
                Process.Start("dxdiag.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine("DXDIAG not installed");
            }
        }

        public void CClean()
        {
            try
            {
                Process.Start("ccleaner.exe");
            }
            catch (Exception e)
            {
                Console.WriteLine("CCleaner not installed");
            }
        }

        public void DefaultBrowser()
        {
            Process.Start("www.google.com");
        }

        public void spotify()
        {
            try
            {
                Process.Start("spotify.exe");
            }catch (Exception e)
            {
                Console.WriteLine("Spotify not installed");
            }
        }

        public void steam()
        {
            try
            {
                Process.Start("C:\\Program Files (x86)\\Steam\\Steam.exe");
            }catch (Exception e)
            {
                Console.WriteLine("Steam not installed");
            }
        }

        public void messenger()
        {
            Process.Start("https://www.facebook.com/messages");
        }

        public void explorer()
        {
            Process.Start("explorer.exe");
        }

        public void amazon()
        {
            Process.Start("https://www.amazon.co.uk/");
        }

        public void weather()
        {
            Process.Start("https://www.google.com/search?q=weather");
        }

        public void shutdown()
        {
            Process.Start("shutdown", "/s /t 0");

        }

        public String googSearch(String input)
        {
            String output;
            if(input.Contains("search google for"))
            {
                input = input.Substring(input.IndexOf("for") + 3);
            }else if(input.Contains("google"))
            {
                input = input.Replace("google", "");
            }
            else if (input.Contains("what is"))
            {
                input = input.Substring(input.IndexOf("is") + 2);
            }
            else if (input.Contains("search"))
            {
                input = input.Replace("search", "");
            }


            Process.Start("https://www.google.com/search?q=" + input);

            output = input;
            return output;
        }
    }
}
