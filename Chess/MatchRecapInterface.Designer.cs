
namespace Chess
{
    partial class MatchRecapInterface
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
            this.winnerPB = new System.Windows.Forms.PictureBox();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.moveHistory = new System.Windows.Forms.RichTextBox();
            this.backToMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.winnerPB)).BeginInit();
            this.SuspendLayout();
            // 
            // winnerPB
            // 
            this.winnerPB.Location = new System.Drawing.Point(565, 37);
            this.winnerPB.Name = "winnerPB";
            this.winnerPB.Size = new System.Drawing.Size(375, 375);
            this.winnerPB.TabIndex = 0;
            this.winnerPB.TabStop = false;
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Font = new System.Drawing.Font("Tempus Sans ITC", 34F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerLabel.Location = new System.Drawing.Point(560, 426);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(394, 89);
            this.winnerLabel.TabIndex = 1;
            this.winnerLabel.Text = "Is Victorious";
            // 
            // moveHistory
            // 
            this.moveHistory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveHistory.Location = new System.Drawing.Point(1118, 37);
            this.moveHistory.Name = "moveHistory";
            this.moveHistory.ReadOnly = true;
            this.moveHistory.Size = new System.Drawing.Size(385, 819);
            this.moveHistory.TabIndex = 2;
            this.moveHistory.Text = "These moves were played:";
            // 
            // backToMenu
            // 
            this.backToMenu.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToMenu.Location = new System.Drawing.Point(540, 618);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(435, 116);
            this.backToMenu.TabIndex = 3;
            this.backToMenu.Text = "Back to Menu";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // MatchRecapInterface
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1538, 915);
            this.Controls.Add(this.backToMenu);
            this.Controls.Add(this.moveHistory);
            this.Controls.Add(this.winnerLabel);
            this.Controls.Add(this.winnerPB);
            this.Name = "MatchRecapInterface";
            this.Text = "Match Recap";
            ((System.ComponentModel.ISupportInitialize)(this.winnerPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox winnerPB;
        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.RichTextBox moveHistory;
        private System.Windows.Forms.Button backToMenu;
    }
}