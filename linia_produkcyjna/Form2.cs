using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace linia_produkcyjna
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        bool przycisk3 = false; // wiatrak 
        bool przycisk4 = false; // wiatrak
        bool przyciskstart = false; //  start
        bool b = false;
        bool przycisk5 = false;//szybkosc
        bool przycisk6 = false;//szybkosc
        bool przycisk7 = false;//surowiec
        bool przycisk8 = false;//przytomnosc
        bool reakcja = false;
        bool awaria = false;
        Random rnd = new Random();
        SoundPlayer syrena = new SoundPlayer("C:\\Users\\Public\\syrena.wav");
        static int i = 27;
        int xb = 0;
        int p = 1;
        int s = 0;//surowiec
        int a = 0; //alarm
        int ladunek = 5;
        int ss= 0; //surowiec
        int aw = 0;
        int czas_a = 0;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            przyciskstart = true;
            textBox2.Text = 1.ToString(); 
            textBox3.Text = ladunek.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            przycisk3 = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            przycisk4 = true; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (przyciskstart == true)
            {
                i = i + 4;
                this.textBox1.Text = i + " C";
            }
            if (i ==83|i==81)
            {
                MessageBox.Show("Zbyt wysoka temperatura silnika !");

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (przycisk3 == true)
            {
                if (i < 80)
                {
                    this.timer1.Stop();
                    this.textBox1.Text = i + " C";
                    i = i + 2;
                }
               if (i > 80)
                {
                    this.timer1.Stop();
                    for (int k = 0; k < 4; k++)
                    {
                        i--;
                        this.textBox1.Text = i + "C";
                    }
                    if (i == 79) { this.timer3.Stop(); }
                }
            
            }
            

          


        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (przycisk4 == true)
            {
                if (i < 80)
                {
                    this.timer2.Stop();
                    this.textBox1.Text = i + " C";
                    i = i + 1;
                    if (i == 72)
                    {
                        this.timer3.Stop();
                        int stala_t = 72;
                        stala_t++;
                        this.textBox1.Text = stala_t + "C";

                    }
                }
                if (i > 80)
                {
                    this.timer1.Stop();
                    for (int k = 0; k < 4; k++)
                    {
                        i--;
                        this.textBox1.Text = i + "C";
                    }
                    if (i == 79) { this.timer3.Stop(); }
                }
            }
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = 0;
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer6.Stop();
            timer7.Stop();
            timer8.Stop();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            if (przyciskstart == true)
            {

                if (xb == 0)
                {
                    xb = 1;
                    this.pictureBox1.Load(@"1.png");
                }
                else if (xb == 1)
                {
                    xb = 2;
                    this.pictureBox1.Load(@"2.png");
                }
                else if (xb == 2)
                {
                    xb = 3;
                    this.pictureBox1.Load(@"3.png");
                }
                else if (xb == 3)
                {
                    xb = 4;
                    this.pictureBox1.Load(@"4.png");
                }
                else if (xb == 4)
                {
                    xb = 5;
                    this.pictureBox1.Load(@"5.png");
                }
                else if (xb == 5)
                {
                    xb = 6;
                    this.pictureBox1.Load(@"6.png");
                }
                else
                {
                    xb = 0;
                    this.pictureBox1.Load(@"7.png");
                }

                if (ladunek == 1)
                {

                    MessageBox.Show("Mało surowca !!");
                    this.timer4.Stop();

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            przycisk5 = true;
        
                int t = 1500;
                t = t - 500;
                p++;
                timer4.Interval = t;
                textBox2.Text = p.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            przycisk6 = true;
            int t = 1000;
            t = t + 500;
            p--;
            timer4.Interval = t;
            textBox2.Text = p.ToString();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (reakcja == true)
            {
                s++;

                if (s == 6 & reakcja==true)
                {
                    this.Close();
                    syrena.Stop();
                    
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            przycisk7 = true;
            s = s - 3;
            this.timer4.Start();

                ladunek++;
                textBox3.Text = ladunek.ToString();
           
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (przyciskstart == true)
            {
                a++;

                if (a ==15 & przycisk3 == false & przycisk4 == false & przycisk5 == false & przycisk6 == false & przycisk7 == false)
                {
                    reakcja = true;
                    syrena.Play();
                    MessageBox.Show("Potwierdz swoją obecność wciskająć 1");
                    a = 0;               
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            przycisk8 = true;
            syrena.Stop();
            reakcja = false;
            s = 0;
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (przyciskstart == true)
            {
                ss++;
                if (ss == 6)
                {             
                        ladunek--;
                        textBox3.Text = ladunek.ToString();
                        ss = 0;                 
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                this.button8.Focus();
                this.button8.PerformClick();
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            czas_a++;
            

                if (przyciskstart == true)
                {
                if (czas_a == 10)
                {
                    int wylosowana = rnd.Next(0, 9);
                    czas_a = 0;
                    switch (wylosowana)
                    {
                        case 1:
                            MessageBox.Show("Awaria silnika! Napraw");
                            this.timer4.Stop();
                            this.timer8.Stop();

                            break;


                        case 3:
                            MessageBox.Show("Awaria procesora! Napraw");
                            this.timer4.Stop();
                            this.timer8.Stop();

                            break;
                        case 2:
                            MessageBox.Show("Awaria podajnika! Napraw");
                            this.timer4.Stop();
                            this.timer8.Stop();
                            break;


                    }
                }

                
            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            awaria = true;
            this.timer4.Start();
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (przyciskstart == true)
            {
                if (awaria == true)
                {
                    aw++;
                    if (aw == 10)
                    {
                        timer8.Start();
                    }

                }
            }
        }
    }
}
