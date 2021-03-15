namespace Q_Game
{
    partial class QGameForm
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
            this.txtRows = new System.Windows.Forms.TextBox();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblCols = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblToolbox = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsClose = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlButtons.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(224, 34);
            this.txtRows.MaxLength = 1;
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(28, 20);
            this.txtRows.TabIndex = 0;
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(360, 34);
            this.txtCols.MaxLength = 1;
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(28, 20);
            this.txtCols.TabIndex = 1;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(181, 37);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(37, 13);
            this.lblRows.TabIndex = 2;
            this.lblRows.Text = "Rows:";
            // 
            // lblCols
            // 
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(304, 37);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(50, 13);
            this.lblCols.TabIndex = 3;
            this.lblCols.Text = "Columns:";
            // 
            // pnlBoard
            // 
            this.pnlBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBoard.Location = new System.Drawing.Point(173, 63);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(690, 690);
            this.pnlBoard.TabIndex = 4;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(463, 29);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 28);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.lblToolbox);
            this.pnlButtons.Location = new System.Drawing.Point(13, 63);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(154, 503);
            this.pnlButtons.TabIndex = 6;
            // 
            // lblToolbox
            // 
            this.lblToolbox.AutoSize = true;
            this.lblToolbox.Font = new System.Drawing.Font("Calibri", 18F);
            this.lblToolbox.Location = new System.Drawing.Point(31, 9);
            this.lblToolbox.Name = "lblToolbox";
            this.lblToolbox.Size = new System.Drawing.Size(91, 29);
            this.lblToolbox.TabIndex = 0;
            this.lblToolbox.Text = "Toolbox";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(867, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnsFile
            // 
            this.mnsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsSave,
            this.returnToMenuToolStripMenuItem,
            this.mnsClose});
            this.mnsFile.Name = "mnsFile";
            this.mnsFile.Size = new System.Drawing.Size(37, 20);
            this.mnsFile.Text = "File";
            // 
            // mnsSave
            // 
            this.mnsSave.Name = "mnsSave";
            this.mnsSave.Size = new System.Drawing.Size(157, 22);
            this.mnsSave.Text = "Save";
            this.mnsSave.Click += new System.EventHandler(this.mnsSave_Click);
            // 
            // returnToMenuToolStripMenuItem
            // 
            this.returnToMenuToolStripMenuItem.Name = "returnToMenuToolStripMenuItem";
            this.returnToMenuToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.returnToMenuToolStripMenuItem.Text = "Return to Menu";
            this.returnToMenuToolStripMenuItem.Click += new System.EventHandler(this.returnToMenuToolStripMenuItem_Click);
            // 
            // mnsClose
            // 
            this.mnsClose.Name = "mnsClose";
            this.mnsClose.Size = new System.Drawing.Size(157, 22);
            this.mnsClose.Text = "Close";
            this.mnsClose.Click += new System.EventHandler(this.mnsClose_Click);
            // 
            // QGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 755);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.txtCols);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "QGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Q Game Level Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QGameForm_FormClosing);
            this.Load += new System.EventHandler(this.QGameForm_Load);
            this.Shown += new System.EventHandler(this.QGameForm_Shown);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnsFile;
        private System.Windows.Forms.ToolStripMenuItem mnsSave;
        private System.Windows.Forms.ToolStripMenuItem mnsClose;
        private System.Windows.Forms.Label lblToolbox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem returnToMenuToolStripMenuItem;
    }
}

