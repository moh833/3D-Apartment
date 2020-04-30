﻿using System;
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
            Globals.haveInput = false;
        }

        OpenFileDialog ofd = new OpenFileDialog();


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //System.Windows.Forms.Application.Exit();
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            ofd.Filter="GPD|*.png";
            this.plPhotos.Visible = false;
            if (ofd.ShowDialog() ==DialogResult.OK)
            {
                laodedimage_location = ofd.SafeFileName;
                Globals.haveInput = true;

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
            this.plPhotos.Visible = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileLoaded_location = ofd.SafeFileName;
                Globals.haveInput = true;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    static class Globals
    {
        public static bool haveInput;
        public static MJPEGStream stream;

    }
}
