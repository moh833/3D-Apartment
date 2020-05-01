using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


namespace image
{
    public partial class main : Form
    {
        private bool isPushed = true;
       
        string laodedimage_location;
        string fileLoaded_location;
        public main()
        {
            InitializeComponent();
            this.plPhotos.Visible = false;
            Globals.haveImage = false;
        }

        OpenFileDialog ofd = new OpenFileDialog();


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            ofd.Filter="GPD|*.png";
            this.plPhotos.Visible = false;
            if (ofd.ShowDialog() ==DialogResult.OK)
            {
                laodedimage_location = ofd.SafeFileName;
                this.btnRun.Visible = true;

            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (isPushed)
            {
                plPhotos.Visible=true;
                isPushed = false;
            }
            else
            {
                plPhotos.Visible = false;
                isPushed = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            plPhotos.Visible = false;
            cameraForm newForm = new cameraForm();
            newForm.Show();
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void btnOpen_Click(object sender, EventArgs e)
        {

         //   ofd.Filter = "GPD|*.2s2li mo";
            this.plPhotos.Visible = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileLoaded_location = ofd.SafeFileName;
            }
        }


        private static void doPython()
        {
            
            ScriptEngine engine = Python.CreateEngine();
            engine.ExecuteFile(@"C:\Users\Baraa\Desktop\mohamed\3D-Apartment-master\hello.py");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRun_Click_1(object sender, EventArgs e)
        {
            //_3DForm frm2 = new _3DForm();
            //this.Hide();
            //frm2.Show();
            doPython();

        }
    }
    static class Globals
    {
        public static bool haveImage;

    }
}
