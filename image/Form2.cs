﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string path)
        {
            InitializeComponent();
            this.userControl11.LoadModel(path);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            main frm = new main();
            frm.Show();
            Globals.haveInput = false;
            this.Close();
           
        }
    }
}
