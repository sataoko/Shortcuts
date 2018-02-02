using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts
{
   


    public partial class frmPomodoroTimer : FormBase
    {
        int _counter = 0;
        int _pomoCount = 0;

        private void ShowTime(int timeInSeconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(timeInSeconds);
            string str = string.Format("{1:D2}:{2:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            lblRemainingTime.Text = str;
            this.Text = str;
        }

        private void SetTime(int timeInSeconds)
        {
            timer1.Enabled = false;
            _counter = timeInSeconds;
            ShowTime(timeInSeconds);
            timer1.Enabled = true;

        }

        private void ResetPomodore()
        {
            timer1.Enabled = false;
            _counter = 0;
        }

        private void TimeIsUpSound()
        {
            // string filePath = System.IO.Path.GetPathRoot(Environment.SystemDirectory) + @"\Windows\Media\windows proximity notification.wav";
            string filePath = Application.StartupPath + "\\timeisup.wav";
            if (System.IO.File.Exists(filePath))
            {
                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(filePath);
                simpleSound.Play();
                /* System.Threading.Thread.Sleep(1500);
                 simpleSound.Play();
                 System.Threading.Thread.Sleep(1500);
                 simpleSound.Play();
                 System.Threading.Thread.Sleep(1500);*/
            }
        }


        public frmPomodoroTimer()
        {
            InitializeComponent();
        }

        private void btnPomodoro_Click(object sender, EventArgs e)
        {
            if (_counter == 0)
            {
                SetTime(1500);
                _pomoCount++;
                lblPomoCount.Text = _pomoCount.ToString();
            }
        }

        private void Log(string message)
        {
            string path = Application.StartupPath + "\\PomodoreLogs.txt";
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString() + "," + message + ", pomo count:" + _pomoCount.ToString());
            }
        }

        private void btnShortBreak_Click(object sender, EventArgs e)
        {
            if (_counter == 0) SetTime(300);
        }

        private void btnLongBreak_Click(object sender, EventArgs e)
        {
            if (_counter == 0) SetTime(600);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _counter--;
            if (_counter < 0)
            {
                ResetPomodore();
                TimeIsUpSound();
            }
            else ShowTime(_counter);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetPomodore();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPomodoroTimer_Load(object sender, EventArgs e)
        {
            Log("START");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TimeIsUpSound();

            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                col.Update(customer);

                // Index document using document Name property
                col.EnsureIndex(x => x.Name);

                // Use LINQ to query documents
                var results = col.Find(x => x.Name.StartsWith("Jo"));

                
                // Let's create an index in phone numbers (using expression). It's a multikey index
                col.EnsureIndex(x => x.Phones, "$.Phones[*]");

                // and now we can query phones
                var r = col.FindOne(x => x.Phones.Contains("8888-5555"));
            }


        }

        private void frmPomodoroTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("STOP");
        }
    }
}
