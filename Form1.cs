using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Imaging.Filters;
using Accord.Math.Wavelets;
using AForge.Imaging.Filters;

namespace Wavelet
{
    public partial class Form1 : Form
    {
        private IFilter grayscalefilter = new Grayscale(0.2125, 0.7154, 0.0721);
        IWavelet wavelet;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = new Bitmap(openFileDialog1.FileName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Wavelet Harris
            Bitmap temp = (Bitmap)pictureBox1.Image;

          temp = grayscalefilter.Apply(temp);

        
             wavelet = new Haar(1);

            WaveletTransform wt = new WaveletTransform(wavelet);
            // Apply forward transform
            Bitmap transformed = wt.Apply(temp);

            pictureBox2.Height = pictureBox1.Width;
            pictureBox2.Height = pictureBox1.Height;


            pictureBox2.Image = transformed;
            pictureBox2.Image = (Bitmap)transformed.Clone();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create inverse transform
            WaveletTransform wt = new WaveletTransform(wavelet, true);

            // Apply inverse transform
            Bitmap transformed = (Bitmap)pictureBox2.Image;

            pictureBox3.Image = wt.Apply(transformed);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
