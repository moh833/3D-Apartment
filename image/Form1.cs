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
using AForge.Video;
using System.Windows.Forms.Integration;
using System.IO;
using System.Diagnostics;
namespace image
{
    public partial class main : Form
    {
        private bool isPushed = true;
        string project_path = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "../../../"));

        string laodedimage_location;
        string fileLoaded_location;
        public main()
        {
            InitializeComponent();
            this.plPhotos.Visible = false;
            Globals.haveInput = false;
        }

        OpenFileDialog ofd = new OpenFileDialog();


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            //System.Windows.Forms.Application.Exit();
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            // ofd.Filter="GPD|*.png";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            this.plPhotos.Visible = false;
            if (ofd.ShowDialog() ==DialogResult.OK)
            {
                laodedimage_location = ofd.FileName;

                Bitmap original_image = new Bitmap(laodedimage_location);
                original_image.Save(project_path + "scripts\\images\\original_layout" + Path.GetExtension(laodedimage_location));
                Globals.haveInput = true;

                doPython();

                System.IO.File.Copy(project_path + "scripts\\model\\model.stl", project_path + "models\\" + Path.GetFileNameWithoutExtension(laodedimage_location) + ".stl", true);

                /*
                WpfUserControl.UserControl1 uc = new WpfUserControl.UserControl1();
                // this.Controls.Clear();
                ElementHost host = new ElementHost();
                host.Dock = DockStyle.Fill;
                host.Child = uc;
                //host.Location = new Point(0,0);
                this.Controls.Add(host);*/

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
            isPushed = true;
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
            ofd.Filter = "GPD|*.stl";
            this.plPhotos.Visible = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileLoaded_location = ofd.FileName;
                Globals.haveInput = true;
                Form2 frm = new Form2(fileLoaded_location);
                this.Hide();
                frm.Show();


                /*  WpfUserControl.UserControl1 uc = new WpfUserControl.UserControl1(fileLoaded_location);
                 // this.Controls.Clear();
                  ElementHost host = new ElementHost();
                  host.Dock = DockStyle.Fill;
                  host.Child = uc;
                  //host.Location = new Point(0,0);
                  this.Controls.Add(host);*/




            }
        }

        // private static void doPython()
        private void doPython()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("python " + project_path +  "scripts\\main.py");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();



        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRun_Click_1(object sender, EventArgs e)
        {
            if (Globals.haveInput)
            {
                //doPython();
                Form2 frm = new Form2();
                this.Hide();
                frm.Show();

            }
            else
            {
                panel3.Visible = true;
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1500;
                timer.Tick += (source, d) => { panel3.Visible = false; timer.Stop(); };
                timer.Start();

            }

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

     
        private void main_Load(object sender, EventArgs e)
        {

        }
    }
    static class Globals
    {
        public static bool haveInput;
        public static MJPEGStream stream;

    }
}
