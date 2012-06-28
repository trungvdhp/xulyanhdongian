using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XLAnhDonGian
{
    public partial class frmMain : Form
    {
        private Bitmap a, ax, ar, ag, ab, an;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                a = new Bitmap(openFileDialog1.FileName);
                ax = ar = ag = ab = an = a;
                picAG.Image = a;
            }
           
         }

        public Bitmap AnhXam(Bitmap ax)
        {
            ax = new Bitmap(openFileDialog1.FileName);
            for (int i = 0; i < ax.Width; i++)
            {
                for (int j = 0; j < ax.Height; j++)
                {
                    Color c = ax.GetPixel(i, j);
                    //cong thuc chuyen anh mau ve anh xam
                    int gray = (int)((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));
                    ax.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
                picKQ.Image = ax;
                
            }
            return ax;
        }
        public Bitmap AnhNhiPhan(Bitmap an, int NguongXam)
        {
            an = new Bitmap(openFileDialog1.FileName);
            for (int i = 0; i < an.Width; i++)
            {
                for (int j = 0; j < an.Height; j++)
                {
                    Color c = an.GetPixel(i, j);
                    //lay gia tri muc xam
                    int desColor = Convert.ToInt32((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));
                    //kiem tra gia tri mau voi nguong xam
                    if (desColor < NguongXam) desColor = 0;
                    else desColor = 255;
                    an.SetPixel(i, j, Color.FromArgb(255, desColor, desColor, desColor));
                }
                picKQ.Image = an;

            }
            return an;
        }
        public Bitmap AnhRed(Bitmap ar)
        {
            ar = new Bitmap(openFileDialog1.FileName);
            for (int i = 0; i < ar.Width; i++)
            {
                for (int j = 0; j < ar.Height; j++)
                {
                    Color c = ar.GetPixel(i, j);

                    int Red = (int)((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));
                    ar.SetPixel(i, j, Color.FromArgb(Red, 0, 0));
                }
                picKQ.Image = ar;
            }
            return ar;
        }
        public Bitmap AnhGreen(Bitmap ag)
        {
            ag = new Bitmap(openFileDialog1.FileName);
            for (int i = 0; i < ag.Width; i++)
            {
                for (int j = 0; j < ag.Height; j++)
                {
                    Color c = ag.GetPixel(i, j);

                    int Green = (int)((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));
                    ag.SetPixel(i, j, Color.FromArgb(0, Green, 0));
                }
                picKQ.Image = ag;
            }
            return ag;
        }
        public Bitmap AnhBlue(Bitmap ab)
        {
            ab = new Bitmap(openFileDialog1.FileName);
            for (int i = 0; i < ab.Width; i++)
            {
                for (int j = 0; j < ab.Height; j++)
                {
                    Color c = ab.GetPixel(i, j);

                    int Blue = (int)((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));
                    ab.SetPixel(i, j, Color.FromArgb(0, 0, Blue));
                }
                picKQ.Image = ab;
            }
            return ab;
        }
        private void btnGrey_Click(object sender, EventArgs e)
        {
            
            AnhXam(ax);
        }

        private void btnBinary_Click(object sender, EventArgs e)
        {
            
            AnhNhiPhan(an, 128);
        }

        private void btRed_Click(object sender, EventArgs e)
        {
            
            AnhRed(ar);
        }        

        private void btGreen_Click(object sender, EventArgs e)
        {
            
            AnhGreen(ag);
        }

        private void btBlue_Click(object sender, EventArgs e)
        {
            
            AnhBlue(ab);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = " Save file...";
            saveFileDialog1.InitialDirectory = "D:\\";
            saveFileDialog1.DefaultExt = "jpg";
            saveFileDialog1.Filter = " Image file (*.BMP,*.JPG,*.JPEG)|*.bmp;*.jpg;*.jpeg ";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                picKQ.Image.Save(saveFileDialog1.FileName);
        }
     }
}
