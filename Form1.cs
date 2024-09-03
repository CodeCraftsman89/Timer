using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            timer1.Interval = 1000; // 1 секунда
            labelStatus.Text = "Введите время в секундах и нажмите 'Старт'.";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxTime.Text, out timeLeft))
            {
                buttonStart.Enabled = false;
                textBoxTime.Enabled = false;
                timer1.Start();
                labelStatus.Text = "Таймер запущен!";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное время.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                labelStatus.Text = $"Оставшееся время: {timeLeft} секунд.";
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Время вышло!");
                labelStatus.Text = "Таймер завершен.";
                buttonStart.Enabled = true;
                textBoxTime.Enabled = true;
            }
        }
    }
}
