
namespace Chess
{
    partial class PromotionInterface
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
            this.queenImage = new System.Windows.Forms.PictureBox();
            this.rookImage = new System.Windows.Forms.PictureBox();
            this.knightImage = new System.Windows.Forms.PictureBox();
            this.bishopImage = new System.Windows.Forms.PictureBox();
            this.queenButton = new System.Windows.Forms.Button();
            this.rookButton = new System.Windows.Forms.Button();
            this.knightButton = new System.Windows.Forms.Button();
            this.bishopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.queenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rookImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knightImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bishopImage)).BeginInit();
            this.SuspendLayout();
            // 
            // queenImage
            // 
            this.queenImage.Location = new System.Drawing.Point(13, 13);
            this.queenImage.Name = "queenImage";
            this.queenImage.Size = new System.Drawing.Size(75, 75);
            this.queenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.queenImage.TabIndex = 0;
            this.queenImage.TabStop = false;
            // 
            // rookImage
            // 
            this.rookImage.Location = new System.Drawing.Point(13, 94);
            this.rookImage.Name = "rookImage";
            this.rookImage.Size = new System.Drawing.Size(75, 75);
            this.rookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rookImage.TabIndex = 1;
            this.rookImage.TabStop = false;
            // 
            // knightImage
            // 
            this.knightImage.Location = new System.Drawing.Point(13, 175);
            this.knightImage.Name = "knightImage";
            this.knightImage.Size = new System.Drawing.Size(75, 75);
            this.knightImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.knightImage.TabIndex = 2;
            this.knightImage.TabStop = false;
            // 
            // bishopImage
            // 
            this.bishopImage.Location = new System.Drawing.Point(13, 256);
            this.bishopImage.Name = "bishopImage";
            this.bishopImage.Size = new System.Drawing.Size(75, 75);
            this.bishopImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bishopImage.TabIndex = 3;
            this.bishopImage.TabStop = false;
            // 
            // queenButton
            // 
            this.queenButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queenButton.Location = new System.Drawing.Point(94, 13);
            this.queenButton.Name = "queenButton";
            this.queenButton.Size = new System.Drawing.Size(352, 75);
            this.queenButton.TabIndex = 4;
            this.queenButton.Text = "Promote to Queen";
            this.queenButton.UseVisualStyleBackColor = true;
            this.queenButton.Click += new System.EventHandler(this.queenButton_Click);
            // 
            // rookButton
            // 
            this.rookButton.Font = new System.Drawing.Font("Calibri", 14F);
            this.rookButton.Location = new System.Drawing.Point(94, 94);
            this.rookButton.Name = "rookButton";
            this.rookButton.Size = new System.Drawing.Size(352, 75);
            this.rookButton.TabIndex = 5;
            this.rookButton.Text = "Promote to Rook";
            this.rookButton.UseVisualStyleBackColor = true;
            this.rookButton.Click += new System.EventHandler(this.rookButton_Click);
            // 
            // knightButton
            // 
            this.knightButton.Font = new System.Drawing.Font("Calibri", 14F);
            this.knightButton.Location = new System.Drawing.Point(94, 175);
            this.knightButton.Name = "knightButton";
            this.knightButton.Size = new System.Drawing.Size(352, 75);
            this.knightButton.TabIndex = 6;
            this.knightButton.Text = "Promote to Knight";
            this.knightButton.UseVisualStyleBackColor = true;
            this.knightButton.Click += new System.EventHandler(this.knightButton_Click);
            // 
            // bishopButton
            // 
            this.bishopButton.Font = new System.Drawing.Font("Calibri", 14F);
            this.bishopButton.Location = new System.Drawing.Point(94, 256);
            this.bishopButton.Name = "bishopButton";
            this.bishopButton.Size = new System.Drawing.Size(352, 75);
            this.bishopButton.TabIndex = 7;
            this.bishopButton.Text = "Promote to Bishop";
            this.bishopButton.UseVisualStyleBackColor = true;
            this.bishopButton.Click += new System.EventHandler(this.bishopButton_Click);
            // 
            // PromotionInterface
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(458, 360);
            this.Controls.Add(this.bishopButton);
            this.Controls.Add(this.knightButton);
            this.Controls.Add(this.rookButton);
            this.Controls.Add(this.queenButton);
            this.Controls.Add(this.bishopImage);
            this.Controls.Add(this.knightImage);
            this.Controls.Add(this.rookImage);
            this.Controls.Add(this.queenImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PromotionInterface";
            this.Text = "Promotion";
            ((System.ComponentModel.ISupportInitialize)(this.queenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rookImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knightImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bishopImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox queenImage;
        private System.Windows.Forms.PictureBox rookImage;
        private System.Windows.Forms.PictureBox knightImage;
        private System.Windows.Forms.PictureBox bishopImage;
        private System.Windows.Forms.Button queenButton;
        private System.Windows.Forms.Button rookButton;
        private System.Windows.Forms.Button knightButton;
        private System.Windows.Forms.Button bishopButton;
    }
}