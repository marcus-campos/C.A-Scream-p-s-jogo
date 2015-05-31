using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Ca
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        bool initialized;
        bool played;
        string PlayCommand, sCommand, spath;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            wb.Navigate("www.google.com.br");
        }

        public void PlayMusic()
        {
            spath = GetExecPath() + "\\MCA.mp3";
            sCommand = "open \"" + spath + "\" type mpegvideo alias MediaFile";
            mciSendString(sCommand, null, 0, IntPtr.Zero);
            PlayCommand = "Play MediaFile";
            mciSendString(PlayCommand, null, 0, IntPtr.Zero);
        }

        public string GetExecPath()
        {
            string s = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            return s;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlayMusic();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"C:\Windows\System32\shutdown.exe");
            }

            catch
            {


            }
        }

        

        
    }
}
