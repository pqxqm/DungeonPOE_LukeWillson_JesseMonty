namespace DungeonPOE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDisplay = new Label();
            lblTitle = new Label();
            lblControls = new Label();
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDisplay.Location = new Point(12, 9);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(776, 432);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "lblDisplay";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(163, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(122, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "DUNGEON EXPLORER";
            // 
            // lblControls
            // 
            lblControls.AutoSize = true;
            lblControls.Location = new Point(208, 69);
            lblControls.Name = "lblControls";
            lblControls.Size = new Size(38, 15);
            lblControls.TabIndex = 2;
            lblControls.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblControls);
            Controls.Add(lblTitle);
            Controls.Add(lblDisplay);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDisplay;
        private Label lblTitle;
        private Label lblControls;
    }
}
