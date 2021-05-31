
namespace Chess
{
    partial class SettingsMenu
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorButtonL = new System.Windows.Forms.Button();
            this.colorButtonD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorButtonL
            // 
            this.colorButtonL.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorButtonL.Location = new System.Drawing.Point(12, 12);
            this.colorButtonL.Name = "colorButtonL";
            this.colorButtonL.Size = new System.Drawing.Size(854, 139);
            this.colorButtonL.TabIndex = 0;
            this.colorButtonL.Text = "Pick Light Color";
            this.colorButtonL.UseVisualStyleBackColor = true;
            this.colorButtonL.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // colorButtonD
            // 
            this.colorButtonD.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorButtonD.Location = new System.Drawing.Point(12, 157);
            this.colorButtonD.Name = "colorButtonD";
            this.colorButtonD.Size = new System.Drawing.Size(854, 139);
            this.colorButtonD.TabIndex = 1;
            this.colorButtonD.Text = "Pick Dark Color";
            this.colorButtonD.UseVisualStyleBackColor = true;
            this.colorButtonD.Click += new System.EventHandler(this.colorButtonD_Click);
            // 
            // SettingsMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(878, 1144);
            this.Controls.Add(this.colorButtonD);
            this.Controls.Add(this.colorButtonL);
            this.Name = "SettingsMenu";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorButtonL;
        private System.Windows.Forms.Button colorButtonD;
    }
}