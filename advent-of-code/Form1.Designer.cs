namespace advent_of_code
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.txtResultBox = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnSecondTask = new System.Windows.Forms.Button();
            this.btnThirdTask = new System.Windows.Forms.Button();
            this.btnFourthTask = new System.Windows.Forms.Button();
            this.btnFifthTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(29, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 65);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResultBox
            // 
            this.txtResultBox.Location = new System.Drawing.Point(200, 436);
            this.txtResultBox.Name = "txtResultBox";
            this.txtResultBox.Size = new System.Drawing.Size(207, 20);
            this.txtResultBox.TabIndex = 1;
            this.txtResultBox.TextChanged += new System.EventHandler(this.txtResultBox_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(114, 433);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(80, 26);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result";
            // 
            // btnSecondTask
            // 
            this.btnSecondTask.Image = ((System.Drawing.Image)(resources.GetObject("btnSecondTask.Image")));
            this.btnSecondTask.Location = new System.Drawing.Point(128, 12);
            this.btnSecondTask.Name = "btnSecondTask";
            this.btnSecondTask.Size = new System.Drawing.Size(66, 65);
            this.btnSecondTask.TabIndex = 3;
            this.btnSecondTask.UseVisualStyleBackColor = true;
            this.btnSecondTask.Click += new System.EventHandler(this.btnSecondTask_Click);
            // 
            // btnThirdTask
            // 
            this.btnThirdTask.Image = ((System.Drawing.Image)(resources.GetObject("btnThirdTask.Image")));
            this.btnThirdTask.Location = new System.Drawing.Point(223, 12);
            this.btnThirdTask.Name = "btnThirdTask";
            this.btnThirdTask.Size = new System.Drawing.Size(66, 65);
            this.btnThirdTask.TabIndex = 4;
            this.btnThirdTask.UseVisualStyleBackColor = true;
            this.btnThirdTask.Click += new System.EventHandler(this.btnThirdTask_Click);
            // 
            // btnFourthTask
            // 
            this.btnFourthTask.BackColor = System.Drawing.Color.White;
            this.btnFourthTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFourthTask.Image = ((System.Drawing.Image)(resources.GetObject("btnFourthTask.Image")));
            this.btnFourthTask.Location = new System.Drawing.Point(317, 12);
            this.btnFourthTask.Name = "btnFourthTask";
            this.btnFourthTask.Size = new System.Drawing.Size(70, 65);
            this.btnFourthTask.TabIndex = 7;
            this.btnFourthTask.UseVisualStyleBackColor = false;
            // 
            // btnFifthTask
            // 
            this.btnFifthTask.BackColor = System.Drawing.Color.White;
            this.btnFifthTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFifthTask.Image = ((System.Drawing.Image)(resources.GetObject("btnFifthTask.Image")));
            this.btnFifthTask.Location = new System.Drawing.Point(419, 12);
            this.btnFifthTask.Name = "btnFifthTask";
            this.btnFifthTask.Size = new System.Drawing.Size(70, 65);
            this.btnFifthTask.TabIndex = 8;
            this.btnFifthTask.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(519, 468);
            this.Controls.Add(this.btnFifthTask);
            this.Controls.Add(this.btnFourthTask);
            this.Controls.Add(this.btnThirdTask);
            this.Controls.Add(this.btnSecondTask);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResultBox);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advent Of Code";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtResultBox;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnSecondTask;
        private System.Windows.Forms.Button btnThirdTask;
        private System.Windows.Forms.Button btnFourthTask;
        private System.Windows.Forms.Button btnFifthTask;
    }
}

