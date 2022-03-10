namespace Lab1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GridAthlete = new System.Windows.Forms.DataGridView();
            this.GridParticipations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridAthlete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridParticipations)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2064, 693);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 77);
            this.button1.TabIndex = 0;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2064, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 76);
            this.button2.TabIndex = 1;
            this.button2.Text = "CONNECT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GridAthlete
            // 
            this.GridAthlete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAthlete.Location = new System.Drawing.Point(64, 61);
            this.GridAthlete.Name = "GridAthlete";
            this.GridAthlete.RowHeadersWidth = 62;
            this.GridAthlete.RowTemplate.Height = 28;
            this.GridAthlete.Size = new System.Drawing.Size(1793, 472);
            this.GridAthlete.TabIndex = 2;
            // 
            // GridParticipations
            // 
            this.GridParticipations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridParticipations.Location = new System.Drawing.Point(64, 601);
            this.GridParticipations.Name = "GridParticipations";
            this.GridParticipations.RowHeadersWidth = 62;
            this.GridParticipations.RowTemplate.Height = 28;
            this.GridParticipations.Size = new System.Drawing.Size(1793, 399);
            this.GridParticipations.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2610, 1088);
            this.Controls.Add(this.GridParticipations);
            this.Controls.Add(this.GridAthlete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridAthlete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridParticipations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView GridAthlete;
        private System.Windows.Forms.DataGridView GridParticipations;
    }
}

