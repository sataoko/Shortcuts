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
        int _blockCount = 0;
        BsonValue _lastLogId = 0;

        int _duration = 1800;

        private string ShowTime(int timeInSeconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(timeInSeconds);

            sevenSegmentArray1.Value = string.Format("{0:D2}",t.Minutes);
            sevenSegmentArray2.Value = string.Format("{0:D2}", t.Seconds);
            string str = string.Format("{1:D2}:{2:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
            return str;
        }

        private void ShowTotalTime()
        {
            TimeSpan t= TimeSpan.FromSeconds(_blockCount * _duration);
            txtTotalTime.Text = " Total Time: " + string.Format("{0:D2}:{1:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);
        }

        private void SetTime(int timeInSeconds)
        {
            timer1.Enabled = false;
            _counter = timeInSeconds;
            sevenSegmentArray1.Value = ShowTime(timeInSeconds);
            timer1.Enabled = true;
        }

        private void ResetPomodore()
        {
            timer1.Enabled = false;
            _counter = 0;
        }

        private void TimeIsUpSound()
        {
            Random r = new Random();
            int i = r.Next(16);
            string filePath = Application.StartupPath + "\\sounds\\timeisup"+i.ToString()+".wav";
            if (System.IO.File.Exists(filePath))
            {
                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(filePath);
                simpleSound.Play();
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
                SetTime(_duration);
                _blockCount++;
                lblPomoCount.Text = _blockCount.ToString();
                LogStart();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _counter--;
            if (_counter < 0)
            {
                ShowTotalTime();
                ResetPomodore();
                LogEnd();
                TimeIsUpSound();
            }
            else
            {
                this.Text = ShowTime(_counter);
            }
        }

        private void Log(string message)
        {
            string path = Application.StartupPath + "\\PomodoreLogs.txt";
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString() + "," + message + ", pomo count:" + _blockCount.ToString());
            }
        }

        private void LogStart()
        {
            using (var db = new LiteDatabase(Application.StartupPath + "\\Data.db"))
            {
                var col = db.GetCollection<WorkBlock>("WorkBlock");
                var workBlock = new WorkBlock
                {
                    BlockStartTime = DateTime.Now,
                    BlockNo = _blockCount,
                    BlockGroup = cbBlockGroup.Text
                };
                 _lastLogId =  col.Insert(workBlock);
            }
        }

        private void LogEnd()
        {
            if (_lastLogId != 0)
            {
                using (var db = new LiteDatabase(Application.StartupPath + "\\Data.db"))
                {
                    // Get a collection (or create, if doesn't exist)
                    var col = db.GetCollection<WorkBlock>("WorkBlock");
                    var workBlock = col.FindById(_lastLogId);
                    workBlock.BlockNote = txtBlockNote.Text;
                    workBlock.BlockEndTime = DateTime.Now;
                    col.Update(workBlock);
                    _lastLogId = 0;
                }
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
            string path = Application.StartupPath + "\\Works.txt";
            if (System.IO.File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path, Encoding.UTF8);
                cbBlockGroup.Items.Clear();
                foreach (string line in lines)
                    cbBlockGroup.Items.Add(line);
            }

            Log("START");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TimeIsUpSound();
            _blockCount = 5;
            ShowTotalTime();
        }

        private void frmPomodoroTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("STOP");
            LogEnd();
        }

        private void lblShowWorkHours_Click(object sender, EventArgs e)
        {
            WorkHours.frmWorkHours x = new WorkHours.frmWorkHours();
            x.Show();
        }
    }
}
