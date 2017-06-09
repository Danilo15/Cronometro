using System;
using System.Windows.Forms;

namespace Cronometro
{
    public partial class Form1 : Form
    {
        private int seconds = 0;
        private int minutes = 0;
        private int hours = 0;
        private int qtdCronometrada = 0;
        private bool descanso = true;
        private int tempo = 25;
        private int tempoPadrao = 25;
        private int tempoExtendido = 30;
        private int tempoDescanso = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop!")
            {
                timer1.Stop();
                button1.Text = "Start";
                SomarCronometrada();
                tempo = tempoPadrao;
                return;
            }

            button1.Enabled = false;
            Start(tempo);
        }

        private void Start(int startMinutes)
        {
            if(tempo == tempoExtendido)
            {
                BotaoParar();
            }

            timer1 = new Timer();
            timer1.Interval = 1000;

            timer1.Tick += OnTick;

            minutes = startMinutes;
            ApplyOnLabel();

            timer1.Start();
        }


        private void SomarCronometrada()
        {
            qtdCronometrada++;
            lblTotal.Text = qtdCronometrada.ToString();
        }
        private void OnLimit()
        {
            Stop();

            bool isDescanso = descanso && tempo != tempoExtendido;

            if (isDescanso)
                MessageBox.Show("Descanso");

            if (isDescanso)
            {
                Start(tempoDescanso);
            }
            else
            {
                SomarCronometrada();
                button1.Enabled = true;
            }

            if (tempo == tempoExtendido)
            {
                tempo = tempoPadrao;
                button1.Text = "Start";
            }

            if (qtdCronometrada % 4 == 0)
            {
                tempo = tempoExtendido;
            }

            descanso = !descanso;
        }

        private void BotaoParar()
        {
            button1.Enabled = true;
            button1.Text = "Stop!";
        }

        private void Stop()
        {
            timer1.Stop();
        }

        private void ApplyOnLabel()
        {
            lblCronometro.Text = string.Format("{0}:{1}:{2}", hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00"));
        }

        private void OnTick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;

            Timer send = (Timer)sender;

            if (seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }

            ApplyOnLabel();

            if (minutes == 0 && seconds == 0)
            {
                OnLimit();
            }
        }
    }
}