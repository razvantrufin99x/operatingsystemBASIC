using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace operatingsystemBASIC
{
    public partial class Form1 : Form
    {
        public Graphics g;
        public Pen pen0 = new Pen(Color.White);
        public Pen pen1 = new Pen(Color.Black);
        public Brush brush0 = new SolidBrush(Color.White);
        public Brush brush1 = new SolidBrush(Color.Black);
        public Font font0;
        public float posstrx = 0.0f;
        public float posstry = 0.0f;
        public int posx = 1;
        public int posy = 1;
        public string cmd;
        public Form1()
        {
            InitializeComponent();
        }

       
       

        public void runOS()
        {
            
                g.Clear(Color.Black);
                cmd = "Hello world! > _ ";
                posstry = posx * font0.Size;
                g.DrawString(cmd, font0, brush0, posstrx, posstry);
                posstrx += cmd.Length*9;

                Thread.Sleep(1000);
           
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            font0 = this.Font;

            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            runOS();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (posstrx >= Width - 20)
            {
                posstrx = 0;
                posx++;
                posstry += (15);
            }
            if (posstrx < 0)
            {
                posstrx = Width - 20;
                posx--; 
                posstry -= (15);
            }


            if (e.KeyCode.ToString().Length == 1)
            {
                g.DrawString(e.KeyCode.ToString(), font0, brush0, 0 + posstrx, posstry);
                posstrx += 12;
            }
            else if (e.KeyCode.ToString() == "SPACE")
            {
                g.DrawString(" ", font0, brush0, 0 + posstrx, posstry);
                posstrx += 12;
            }
            else if (e.KeyCode.ToString() == "Return")
            {
                posstrx = 0;
                posx++;
                posstry += (15);

            }
            else if (e.KeyCode.ToString() == "Back")
            {
                posstrx -= 12;
                //g.DrawString(" ", font0, brush0, 0 + posstrx, posstry);
                g.FillRectangle(brush1, posstrx, posstry, 15, 15);
                posx--;
              

            }
             

             Text = e.KeyCode.ToString();
             Text += " ";
             Text += posstrx.ToString() + " : " + posstry.ToString();
        }
    }
}
