
namespace Chess
{
    partial class Menu
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
            this.Background = new System.Windows.Forms.PictureBox();
            this.Multiplayer = new System.Windows.Forms.Button();
            this.Singleplayer = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Location = new System.Drawing.Point(-12, -12);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(1620, 887);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // Multiplayer
            // 
            this.Multiplayer.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Multiplayer.Location = new System.Drawing.Point(43, 73);
            this.Multiplayer.Name = "Multiplayer";
            this.Multiplayer.Size = new System.Drawing.Size(441, 119);
            this.Multiplayer.TabIndex = 1;
            this.Multiplayer.Text = "Multiplayer";
            this.Multiplayer.UseVisualStyleBackColor = true;
            this.Multiplayer.Click += new System.EventHandler(this.Multiplayer_Click);
            // 
            // Singleplayer
            // 
            this.Singleplayer.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Singleplayer.Location = new System.Drawing.Point(43, 198);
            this.Singleplayer.Name = "Singleplayer";
            this.Singleplayer.Size = new System.Drawing.Size(441, 119);
            this.Singleplayer.TabIndex = 2;
            this.Singleplayer.Text = "Singleplayer";
            this.Singleplayer.UseVisualStyleBackColor = true;
            this.Singleplayer.Click += new System.EventHandler(this.Singleplayer_Click);
            // 
            // Settings
            // 
            this.Settings.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.Location = new System.Drawing.Point(43, 323);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(441, 119);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1578, 844);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Singleplayer);
            this.Controls.Add(this.Multiplayer);
            this.Controls.Add(this.Background);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Button Multiplayer;
        private System.Windows.Forms.Button Singleplayer;
        private System.Windows.Forms.Button Settings;
    }
}