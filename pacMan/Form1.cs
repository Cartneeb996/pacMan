using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace pacMan
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer(Properties.Resources.vista);
            player.Play();
        }

        public void myMethod()
        {
            this.BackColor = Color.Red;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Visible = false;

            SolidBrush pacMan = new SolidBrush(Color.Black);
            Pen drawPen = new Pen(Color.Black, 10);
            Pen eraser = new Pen(Color.White, 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Graphics formGraphics = this.CreateGraphics();
            Bitmap bm = new Bitmap(this.Width, this.Height);
            Graphics offScreen = Graphics.FromImage(bm);

            SoundPlayer player = new SoundPlayer(Properties.Resources.vista);
            int x = 5;
            int y = 7;
            int xx = 30;
            int yy = 300;
            while(x < 55)
            {
                
                player.Play();
                Thread.Sleep(400);
                
                offScreen.Clear(Color.White);
                Refresh();

                offScreen.DrawLine(drawPen, 0, 0, 75, 0);
                offScreen.DrawLine(drawPen, 75, 0, 75, 75);
                offScreen.DrawLine(drawPen, 0, 30, 50, 30);
                offScreen.DrawLine(drawPen, 50, 25, 50, 75);
                offScreen.FillPie(pacMan, x, y, 15, 15, xx, yy);
                formGraphics.DrawImage(bm, 0, 0);



                    x = x + 5;
                    xx = xx - 5;
                    yy = yy + 10;
                
            }

            
            xx = 160;
            while (y != 55)
            {
                formGraphics.FillPie(pacMan, x, y, 15, 15, xx, yy); 
                if(xx == 160)
                {
                    formGraphics.RotateTransform(90);
                }
                offScreen.DrawLine(drawPen, 0, 0, 75, 0);
                offScreen.DrawLine(drawPen, 75, 0, 75, 75);
                offScreen.DrawLine(drawPen, 0, 30, 50, 30);
                offScreen.DrawLine(drawPen, 50, 25, 50, 75);
                
                formGraphics.DrawImage(bm, 0, 0);

                
                player.Play();
                Thread.Sleep(400);
                Refresh();
                offScreen.Clear(Color.White);
                Refresh();
                y = y + 5;
                xx = xx + 10;
                yy = yy - 20;
            }

            
            Graphics string2Text = this.CreateGraphics();
            Font reward = new Font("Arial", 16);
            string2Text.DrawString("congratz!", reward, drawBrush, 150, 75);
            Thread.Sleep(3000);
            formGraphics.Clear(Color.Transparent);
            Refresh();

            runButton.Visible = true;
            
        }
    }
}
