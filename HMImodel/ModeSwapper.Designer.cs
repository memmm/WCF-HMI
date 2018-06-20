namespace model
{
    partial class ModeSwapper
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbStandby = new System.Windows.Forms.RadioButton();
            this.rbUnscheduled = new System.Windows.Forms.RadioButton();
            this.rbScheduled = new System.Windows.Forms.RadioButton();
            this.rbProductive = new System.Windows.Forms.RadioButton();
            this.rbEngineering = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbStandby);
            this.groupBox1.Controls.Add(this.rbUnscheduled);
            this.groupBox1.Controls.Add(this.rbScheduled);
            this.groupBox1.Controls.Add(this.rbProductive);
            this.groupBox1.Controls.Add(this.rbEngineering);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 192);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode:";
            // 
            // rbStandby
            // 
            this.rbStandby.AutoSize = true;
            this.rbStandby.Location = new System.Drawing.Point(24, 96);
            this.rbStandby.Name = "rbStandby";
            this.rbStandby.Size = new System.Drawing.Size(111, 21);
            this.rbStandby.TabIndex = 4;
            this.rbStandby.TabStop = true;
            this.rbStandby.Text = "Standby time";
            this.rbStandby.UseVisualStyleBackColor = true;
            // 
            // rbUnscheduled
            // 
            this.rbUnscheduled.AutoSize = true;
            this.rbUnscheduled.Location = new System.Drawing.Point(24, 150);
            this.rbUnscheduled.Name = "rbUnscheduled";
            this.rbUnscheduled.Size = new System.Drawing.Size(175, 21);
            this.rbUnscheduled.TabIndex = 3;
            this.rbUnscheduled.TabStop = true;
            this.rbUnscheduled.Text = "Unscheduled downtime";
            this.rbUnscheduled.UseVisualStyleBackColor = true;
            // 
            // rbScheduled
            // 
            this.rbScheduled.AutoSize = true;
            this.rbScheduled.Location = new System.Drawing.Point(24, 123);
            this.rbScheduled.Name = "rbScheduled";
            this.rbScheduled.Size = new System.Drawing.Size(159, 21);
            this.rbScheduled.TabIndex = 2;
            this.rbScheduled.TabStop = true;
            this.rbScheduled.Text = "Scheduled downtime";
            this.rbScheduled.UseVisualStyleBackColor = true;
            // 
            // rbProductive
            // 
            this.rbProductive.AutoSize = true;
            this.rbProductive.Location = new System.Drawing.Point(24, 67);
            this.rbProductive.Name = "rbProductive";
            this.rbProductive.Size = new System.Drawing.Size(126, 21);
            this.rbProductive.TabIndex = 1;
            this.rbProductive.TabStop = true;
            this.rbProductive.Text = "Productive time";
            this.rbProductive.UseVisualStyleBackColor = true;
            // 
            // rbEngineering
            // 
            this.rbEngineering.AutoSize = true;
            this.rbEngineering.Location = new System.Drawing.Point(24, 40);
            this.rbEngineering.Name = "rbEngineering";
            this.rbEngineering.Size = new System.Drawing.Size(135, 21);
            this.rbEngineering.TabIndex = 0;
            this.rbEngineering.TabStop = true;
            this.rbEngineering.Text = "Engineering time";
            this.rbEngineering.UseVisualStyleBackColor = true;
            // 
            // ModeSwapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModeSwapper";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbStandby;
        private System.Windows.Forms.RadioButton rbUnscheduled;
        private System.Windows.Forms.RadioButton rbScheduled;
        private System.Windows.Forms.RadioButton rbProductive;
        private System.Windows.Forms.RadioButton rbEngineering;
    }
}

