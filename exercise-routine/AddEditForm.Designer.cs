namespace exercise_routine
{
    partial class AddEditForm
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
            this.exerciseName = new System.Windows.Forms.TextBox();
            this.sets = new System.Windows.Forms.TextBox();
            this.reps = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.TextBox();
            this.cmbPart = new System.Windows.Forms.ComboBox();
            this.todayDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.memo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exerciseName
            // 
            this.exerciseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.exerciseName.Location = new System.Drawing.Point(108, 8);
            this.exerciseName.Name = "exerciseName";
            this.exerciseName.Size = new System.Drawing.Size(132, 21);
            this.exerciseName.TabIndex = 0;
            // 
            // sets
            // 
            this.sets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sets.Location = new System.Drawing.Point(108, 61);
            this.sets.Name = "sets";
            this.sets.Size = new System.Drawing.Size(132, 21);
            this.sets.TabIndex = 1;
            // 
            // reps
            // 
            this.reps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.reps.Location = new System.Drawing.Point(108, 88);
            this.reps.Name = "reps";
            this.reps.Size = new System.Drawing.Size(132, 21);
            this.reps.TabIndex = 2;
            // 
            // weight
            // 
            this.weight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.weight.Location = new System.Drawing.Point(108, 115);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(132, 21);
            this.weight.TabIndex = 3;
            // 
            // cmbPart
            // 
            this.cmbPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cmbPart.FormattingEnabled = true;
            this.cmbPart.Location = new System.Drawing.Point(108, 35);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(132, 20);
            this.cmbPart.TabIndex = 4;
            // 
            // todayDate
            // 
            this.todayDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.todayDate.Location = new System.Drawing.Point(108, 142);
            this.todayDate.Name = "todayDate";
            this.todayDate.Size = new System.Drawing.Size(174, 21);
            this.todayDate.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(120, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "추가";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // memo
            // 
            this.memo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.memo.Location = new System.Drawing.Point(108, 169);
            this.memo.Multiline = true;
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(132, 50);
            this.memo.TabIndex = 7;
            this.memo.Text = "추가메모";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.memo);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.todayDate);
            this.panel1.Controls.Add(this.cmbPart);
            this.panel1.Controls.Add(this.weight);
            this.panel1.Controls.Add(this.reps);
            this.panel1.Controls.Add(this.sets);
            this.panel1.Controls.Add(this.exerciseName);
            this.panel1.Location = new System.Drawing.Point(6, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 262);
            this.panel1.TabIndex = 8;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 332);
            this.Controls.Add(this.panel1);
            this.Name = "AddEditForm";
            this.Text = "추가 기록";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox exerciseName;
        private System.Windows.Forms.TextBox sets;
        private System.Windows.Forms.TextBox reps;
        private System.Windows.Forms.TextBox weight;
        private System.Windows.Forms.ComboBox cmbPart;
        private System.Windows.Forms.DateTimePicker todayDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.Panel panel1;
    }
}