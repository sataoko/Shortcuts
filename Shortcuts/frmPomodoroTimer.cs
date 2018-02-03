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

        private void SetTime(int timeInSeconds)
        {
            timer1.Enabled = false;
            _counter = timeInSeconds;
            sevenSegmentArray1.Value =  lblRemainingTime.Text =  ShowTime(timeInSeconds);
            timer1.Enabled = true;
        }

        private void ResetPomodore()
        {
            timer1.Enabled = false;
            _counter = 0;
        }

        private void TimeIsUpSound()
        {
            string filePath = Application.StartupPath + "\\timeisup.wav";
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
                _pomoCount++;
                lblPomoCount.Text = _pomoCount.ToString();
                lblTotal.Text =" Total Time: "+ShowTime(_pomoCount*_duration);
                LogStart();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _counter--;
            if (_counter < 0)
            {
                ResetPomodore();
                LogEnd();
                TimeIsUpSound();
            }
            else
            {
                lblRemainingTime.Text = ShowTime(_counter);
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

        private void LogStart()
        {
            using (var db = new LiteDatabase(Application.StartupPath + "\\ShortcutsData.db"))
            {
                var col = db.GetCollection<WorkBlock>("WorkBlock");
                var workBlock = new WorkBlock
                {
                    BlockStartTime = DateTime.Now,
                    BlockNo = _pomoCount,
                    BlockGroup = cbBlockGroup.Text
                };
                 _lastLogId =  col.Insert(workBlock);
            }
        }

        private void LogEnd()
        {
            if (_lastLogId != 0)
            {
                using (var db = new LiteDatabase(Application.StartupPath + "\\ShortcutsData.db"))
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
            Log("START");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TimeIsUpSound();
            if(_lastLogId==0)
            LogStart();
            else
                LogEnd();
        }

        private void frmPomodoroTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("STOP");
            LogEnd();
        }
    }
}
