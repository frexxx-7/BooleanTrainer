namespace BooleanTrainer.UserControls
{
    partial class TheoryControlForTest
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TheoryControlPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.ContentLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.TheoryControlPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TheoryControlPanel
            // 
            this.TheoryControlPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(255)))));
            this.TheoryControlPanel.BorderRadius = 15;
            this.TheoryControlPanel.BorderThickness = 2;
            this.TheoryControlPanel.Controls.Add(this.CheckBox1);
            this.TheoryControlPanel.Controls.Add(this.flowLayoutPanel2);
            this.TheoryControlPanel.Controls.Add(this.pictureBox);
            this.TheoryControlPanel.Controls.Add(this.flowLayoutPanel1);
            this.TheoryControlPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.TheoryControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TheoryControlPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.TheoryControlPanel.Location = new System.Drawing.Point(0, 0);
            this.TheoryControlPanel.Name = "TheoryControlPanel";
            this.TheoryControlPanel.Size = new System.Drawing.Size(600, 190);
            this.TheoryControlPanel.TabIndex = 6;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.ContentLabel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(157, 85);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(430, 88);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));
            this.ContentLabel.Location = new System.Drawing.Point(3, 0);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(52, 16);
            this.ContentLabel.TabIndex = 2;
            this.ContentLabel.Text = "Content";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox.Location = new System.Drawing.Point(16, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(122, 122);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.HeaderLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(157, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(430, 38);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));
            this.HeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(107, 25);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Название";
            // 
            // CheckBox1
            // 
            this.CheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));
            this.CheckBox1.CheckedState.BorderRadius = 0;
            this.CheckBox1.CheckedState.BorderThickness = 0;
            this.CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));
            this.CheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.CheckBox1.Location = new System.Drawing.Point(569, 12);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(18, 17);
            this.CheckBox1.TabIndex = 5;
            this.CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));
            this.CheckBox1.UncheckedState.BorderRadius = 0;
            this.CheckBox1.UncheckedState.BorderThickness = 0;
            this.CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(255)))));
            // 
            // TheoryControlForTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TheoryControlPanel);
            this.Name = "TheoryControlForTest";
            this.Size = new System.Drawing.Size(600, 190);
            this.Load += new System.EventHandler(this.TheoryControlForTest_Load);
            this.TheoryControlPanel.ResumeLayout(false);
            this.TheoryControlPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel TheoryControlPanel;
        private Guna.UI2.WinForms.Guna2CheckBox CheckBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label HeaderLabel;
    }
}
