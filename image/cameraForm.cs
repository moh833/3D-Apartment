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
    public partial class cameraForm : Form
    {
        
        private bool isCaptured = false;

        public cameraForm()
        {
            InitializeComponent();
            Globals.stream = new MJPEGStream("http://192.168.1.6:8080/video");
            Globals.stream.NewFrame += stream_Newframe;
            Globals.stream.Start();

        }
        void stream_Newframe(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap btp = (Bitmap)eventArgs.Frame.Clone();
            pBCapture.Image = btp;
        }

        private void pBCapture_Click(object sender, EventArgs e)
        {

        }
        private void plCapture_Paint(object sender, PaintEventArgs e)
        {
          
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Globals.stream.Start();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (pBCapture.Image != null)
            {
                if (isCaptured)
                {
                    Image copy = pBCapture.Image;
                    copy.Save("C:/Users/Baraa/source/repos/image/saved.png");
                    Globals.stream.Stop();
                    this.Close();
                    Globals.haveInput = true;

                }
                else
                {
                    MessageBox.Show("Please capture image first");
                }
            }
            else
            { MessageBox.Show("null exception"); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FmCapture_Load(object sender, EventArgs e)
        {
            Globals.stream.Start();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            pBCapture.Image = (Bitmap)pBCapture.Image.Clone();
            isCaptured = true;
            Globals.stream.Stop();
        }

        
    }

}
