namespace image
{
    partial class cameraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cameraForm));
            this.plCapture = new System.Windows.Forms.Panel();
            this.plclose2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pBCapture = new System.Windows.Forms.PictureBox();
            this.plCapture.SuspendLayout();
            this.plclose2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // plCapture
            // 
            this.plCapture.BackColor = System.Drawing.Color.White;
            this.plCapture.Controls.Add(this.plclose2);
            this.plCapture.Controls.Add(this.btnSave);
            this.plCapture.Controls.Add(this.btnClear);
            this.plCapture.Controls.Add(this.btnCapture);
            this.plCapture.Controls.Add(this.pBCapture);
            resources.ApplyResources(this.plCapture, "plCapture");
            this.plCapture.ForeColor = System.Drawing.Color.White;
            this.plCapture.Name = "plCapture";
            this.plCapture.Paint += new System.Windows.Forms.PaintEventHandler(this.plCapture_Paint);
            // 
            // plclose2
            // 
            this.plclose2.BackColor = System.Drawing.Color.White;
            this.plclose2.Controls.Add(this.btnClose);
            resources.ApplyResources(this.plclose2, "plclose2");
            this.plclose2.Name = "plclose2";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(193)))));
            this.btnCapture.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCapture, "btnCapture");
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pBCapture
            // 
            this.pBCapture.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pBCapture, "pBCapture");
            this.pBCapture.Name = "pBCapture";
            this.pBCapture.TabStop = false;
            // 
            // cameraForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cameraForm";
            this.plCapture.ResumeLayout(false);
            this.plclose2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plCapture;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox pBCapture;
        private System.Windows.Forms.Panel plclose2;
        private System.Windows.Forms.Button btnClose;
    }
}