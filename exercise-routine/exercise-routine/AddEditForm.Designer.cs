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
            this.SuspendLayout();
            // 
            // exerciseName
            // 
            this.exerciseName.Location = new System.Drawing.Point(97, 53);
            this.exerciseName.Name = "exerciseName";
            this.exerciseName.Size = new System.Drawing.Size(121, 21);
            this.exerciseName.TabIndex = 0;
            // 
            // sets
            // 
            this.sets.Location = new System.Drawing.Point(97, 106);
            this.sets.Name = "sets";
            this.sets.Size = new System.Drawing.Size(121, 21);
            this.sets.TabIndex = 1;
            // 
            // reps
            // 
            this.reps.Location = new System.Drawing.Point(97, 133);
            this.reps.Name = "reps";
            this.reps.Size = new System.Drawing.Size(121, 21);
            this.reps.TabIndex = 2;
            // 
            // weight
            // 
            this.weight.Location = new System.Drawing.Point(97, 160);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(121, 21);
            this.weight.TabIndex = 3;
            // 
            // cmbPart
            // 
            this.cmbPart.FormattingEnabled = true;
            this.cmbPart.Location = new System.Drawing.Point(97, 80);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(121, 20);
            this.cmbPart.TabIndex = 4;
            // 
            // todayDate
            // 
            this.todayDate.Location = new System.Drawing.Point(97, 187);
            this.todayDate.Name = "todayDate";
            this.todayDate.Size = new System.Drawing.Size(163, 21);
            this.todayDate.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(97, 214);
            this.memo.Multiline = true;
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(121, 21);
            this.memo.TabIndex = 7;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 310);
            this.Controls.Add(this.memo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.todayDate);
            this.Controls.Add(this.cmbPart);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.reps);
            this.Controls.Add(this.sets);
            this.Controls.Add(this.exerciseName);
            this.Name = "AddEditForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}