using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;


namespace image
{
    public partial class FmCapture : Form
    {
        MJPEGStream stream;
        private bool isCaptured = false;

        public FmCapture()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.1.6:8080/video");
            stream.NewFrame += stream_Newframe;
        }
        void stream_Newframe(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap btp = (Bitmap)eventArgs.Frame.Clone();
            pBCapture.Image = btp;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            pBCapture.Image = (Bitmap)pBCapture.Image.Clone();
            stream.Stop();
            isCaptured = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            stream.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pBCapture.Image != null)
            {
                if (isCaptured)
                {
                    Image copy = pBCapture.Image;
                    copy.Save("C:/Users/Baraa/source/repos/image/saved.png");
                    stream.Stop();
                    this.Close();
                    Globals.haveImage = true;

                }
                else
                {
                    MessageBox.Show("Please capture image first");
                }
            }
            else
            { MessageBox.Show("null exception"); }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FmCapture_Load(object sender, EventArgs e)
        {
            stream.Start();
        }
    }
}
