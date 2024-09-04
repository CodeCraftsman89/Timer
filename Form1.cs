using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Timer
{
    public partial class Form1 : Form
    {
        private int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 60000; // 1 секунда
            labelStatus.Text = "Enter the time in minutes";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxTime.Text, out timeLeft))
            {
                buttonStart.Enabled = false;
                textBoxTime.Enabled = false;
                timer1.Start();
                labelStatus.Text = "The timer has started!";
            }
            else
            {
                MessageBox.Show("Please enter a valid time.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                labelStatus.Text = $"Time remaining: {timeLeft} minutes.";
            }
            else
            {
                timer1.Stop();
                Notification();
                labelStatus.Text = "The timer has expired.";
                buttonStart.Enabled = true;
                textBoxTime.Enabled = true;
            }
        }
        public void Notification()
        {
            // Инициализация NotifyIcon
            notifyIcon1.Icon = SystemIcons.Information; // Установите иконку для уведомления
            notifyIcon1.Visible = true;

            // Показать всплывающее уведомление
            notifyIcon1.ShowBalloonTip(3000, "Time's up", $"{textBoxTime.Text} minutes has passed", ToolTipIcon.Info);

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/CodeCraftsman89");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
