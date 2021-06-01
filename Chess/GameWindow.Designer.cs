
namespace Chess
{
    partial class GameWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.wCaptureLabel = new System.Windows.Forms.Label();
            this.bCaptureLabel = new System.Windows.Forms.Label();
            this.wPawns = new System.Windows.Forms.Label();
            this.wKnights = new System.Windows.Forms.Label();
            this.wBishops = new System.Windows.Forms.Label();
            this.wRooks = new System.Windows.Forms.Label();
            this.wQueens = new System.Windows.Forms.Label();
            this.bPawns = new System.Windows.Forms.Label();
            this.bKnights = new System.Windows.Forms.Label();
            this.bBishops = new System.Windows.Forms.Label();
            this.bRooks = new System.Windows.Forms.Label();
            this.bQueens = new System.Windows.Forms.Label();
            this.tmLabel = new System.Windows.Forms.Label();
            this.turnHistoryTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // wCaptureLabel
            // 
            this.wCaptureLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wCaptureLabel.Location = new System.Drawing.Point(624, 12);
            this.wCaptureLabel.Name = "wCaptureLabel";
            this.wCaptureLabel.Size = new System.Drawing.Size(202, 32);
            this.wCaptureLabel.TabIndex = 0;
            this.wCaptureLabel.Text = "White Captures";
            // 
            // bCaptureLabel
            // 
            this.bCaptureLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCaptureLabel.Location = new System.Drawing.Point(961, 12);
            this.bCaptureLabel.Name = "bCaptureLabel";
            this.bCaptureLabel.Size = new System.Drawing.Size(202, 32);
            this.bCaptureLabel.TabIndex = 1;
            this.bCaptureLabel.Text = "Black Captures";
            // 
            // wPawns
            // 
            this.wPawns.AutoSize = true;
            this.wPawns.Location = new System.Drawing.Point(625, 44);
            this.wPawns.Name = "wPawns";
            this.wPawns.Size = new System.Drawing.Size(56, 20);
            this.wPawns.TabIndex = 2;
            this.wPawns.Text = "Pawns";
            // 
            // wKnights
            // 
            this.wKnights.AutoSize = true;
            this.wKnights.Location = new System.Drawing.Point(625, 64);
            this.wKnights.Name = "wKnights";
            this.wKnights.Size = new System.Drawing.Size(62, 20);
            this.wKnights.TabIndex = 3;
            this.wKnights.Text = "Knights";
            // 
            // wBishops
            // 
            this.wBishops.AutoSize = true;
            this.wBishops.Location = new System.Drawing.Point(625, 84);
            this.wBishops.Name = "wBishops";
            this.wBishops.Size = new System.Drawing.Size(66, 20);
            this.wBishops.TabIndex = 4;
            this.wBishops.Text = "Bishops";
            // 
            // wRooks
            // 
            this.wRooks.AutoSize = true;
            this.wRooks.Location = new System.Drawing.Point(625, 104);
            this.wRooks.Name = "wRooks";
            this.wRooks.Size = new System.Drawing.Size(55, 20);
            this.wRooks.TabIndex = 5;
            this.wRooks.Text = "Rooks";
            // 
            // wQueens
            // 
            this.wQueens.AutoSize = true;
            this.wQueens.Location = new System.Drawing.Point(625, 124);
            this.wQueens.Name = "wQueens";
            this.wQueens.Size = new System.Drawing.Size(65, 20);
            this.wQueens.TabIndex = 6;
            this.wQueens.Text = "Queens";
            // 
            // bPawns
            // 
            this.bPawns.AutoSize = true;
            this.bPawns.Location = new System.Drawing.Point(962, 44);
            this.bPawns.Name = "bPawns";
            this.bPawns.Size = new System.Drawing.Size(56, 20);
            this.bPawns.TabIndex = 7;
            this.bPawns.Text = "Pawns";
            // 
            // bKnights
            // 
            this.bKnights.AutoSize = true;
            this.bKnights.Location = new System.Drawing.Point(962, 64);
            this.bKnights.Name = "bKnights";
            this.bKnights.Size = new System.Drawing.Size(62, 20);
            this.bKnights.TabIndex = 8;
            this.bKnights.Text = "Knights";
            // 
            // bBishops
            // 
            this.bBishops.AutoSize = true;
            this.bBishops.Location = new System.Drawing.Point(962, 84);
            this.bBishops.Name = "bBishops";
            this.bBishops.Size = new System.Drawing.Size(66, 20);
            this.bBishops.TabIndex = 9;
            this.bBishops.Text = "Bishops";
            // 
            // bRooks
            // 
            this.bRooks.AutoSize = true;
            this.bRooks.Location = new System.Drawing.Point(962, 104);
            this.bRooks.Name = "bRooks";
            this.bRooks.Size = new System.Drawing.Size(55, 20);
            this.bRooks.TabIndex = 10;
            this.bRooks.Text = "Rooks";
            // 
            // bQueens
            // 
            this.bQueens.AutoSize = true;
            this.bQueens.Location = new System.Drawing.Point(962, 124);
            this.bQueens.Name = "bQueens";
            this.bQueens.Size = new System.Drawing.Size(65, 20);
            this.bQueens.TabIndex = 11;
            this.bQueens.Text = "Queens";
            // 
            // tmLabel
            // 
            this.tmLabel.AutoSize = true;
            this.tmLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmLabel.Location = new System.Drawing.Point(12, 624);
            this.tmLabel.Name = "tmLabel";
            this.tmLabel.Size = new System.Drawing.Size(240, 44);
            this.tmLabel.TabIndex = 12;
            this.tmLabel.Text = "White to Move";
            // 
            // turnHistoryTB
            // 
            this.turnHistoryTB.Cursor = System.Windows.Forms.Cursors.Default;
            this.turnHistoryTB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnHistoryTB.Location = new System.Drawing.Point(1187, 12);
            this.turnHistoryTB.Name = "turnHistoryTB";
            this.turnHistoryTB.ReadOnly = true;
            this.turnHistoryTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.turnHistoryTB.Size = new System.Drawing.Size(379, 810);
            this.turnHistoryTB.TabIndex = 13;
            this.turnHistoryTB.Text = "";
            // 
            // GameWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1578, 844);
            this.Controls.Add(this.turnHistoryTB);
            this.Controls.Add(this.tmLabel);
            this.Controls.Add(this.bQueens);
            this.Controls.Add(this.bRooks);
            this.Controls.Add(this.bBishops);
            this.Controls.Add(this.bKnights);
            this.Controls.Add(this.bPawns);
            this.Controls.Add(this.wQueens);
            this.Controls.Add(this.wRooks);
            this.Controls.Add(this.wBishops);
            this.Controls.Add(this.wKnights);
            this.Controls.Add(this.wPawns);
            this.Controls.Add(this.bCaptureLabel);
            this.Controls.Add(this.wCaptureLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameWindow";
            this.Text = "Chess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wCaptureLabel;
        private System.Windows.Forms.Label bCaptureLabel;
        private System.Windows.Forms.Label wPawns;
        private System.Windows.Forms.Label wKnights;
        private System.Windows.Forms.Label wBishops;
        private System.Windows.Forms.Label wRooks;
        private System.Windows.Forms.Label wQueens;
        private System.Windows.Forms.Label bPawns;
        private System.Windows.Forms.Label bKnights;
        private System.Windows.Forms.Label bBishops;
        private System.Windows.Forms.Label bRooks;
        private System.Windows.Forms.Label bQueens;
        private System.Windows.Forms.Label tmLabel;
        private System.Windows.Forms.RichTextBox turnHistoryTB;
    }
}

