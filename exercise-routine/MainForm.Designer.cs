namespace exercise_routine
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.routineList = new System.Windows.Forms.DataGridView();
            this.routineName = new System.Windows.Forms.Label();
            this.labelTotalCount = new MaterialSkin.Controls.MaterialLabel();
            this.labelTotalSets = new MaterialSkin.Controls.MaterialLabel();
            this.labelTotalWeight = new MaterialSkin.Controls.MaterialLabel();
            this.labelPartCount = new MaterialSkin.Controls.MaterialLabel();
            this.checkShowAll = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.routineList)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(160, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.Location = new System.Drawing.Point(56, 297);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "추가";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(160, 297);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(258, 297);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // routineList
            // 
            this.routineList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routineList.Location = new System.Drawing.Point(56, 105);
            this.routineList.Name = "routineList";
            this.routineList.RowTemplate.Height = 23;
            this.routineList.Size = new System.Drawing.Size(277, 172);
            this.routineList.TabIndex = 4;
            // 
            // routineName
            // 
            this.routineName.AutoSize = true;
            this.routineName.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.routineName.Location = new System.Drawing.Point(57, 77);
            this.routineName.Name = "routineName";
            this.routineName.Size = new System.Drawing.Size(74, 17);
            this.routineName.TabIndex = 5;
            this.routineName.Text = "운동루틴목록";
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Depth = 0;
            this.labelTotalCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTotalCount.Location = new System.Drawing.Point(345, 105);
            this.labelTotalCount.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(81, 19);
            this.labelTotalCount.TabIndex = 6;
            this.labelTotalCount.Text = "오늘 루틴 수 : ";
            // 
            // labelTotalSets
            // 
            this.labelTotalSets.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTotalSets.AutoSize = true;
            this.labelTotalSets.Depth = 0;
            this.labelTotalSets.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTotalSets.Location = new System.Drawing.Point(345, 156);
            this.labelTotalSets.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelTotalSets.Name = "labelTotalSets";
            this.labelTotalSets.Size = new System.Drawing.Size(69, 19);
            this.labelTotalSets.TabIndex = 7;
            this.labelTotalSets.Text = "총 세트 수 : ";
            // 
            // labelTotalWeight
            // 
            this.labelTotalWeight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTotalWeight.AutoSize = true;
            this.labelTotalWeight.Depth = 0;
            this.labelTotalWeight.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTotalWeight.Location = new System.Drawing.Point(345, 209);
            this.labelTotalWeight.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelTotalWeight.Name = "labelTotalWeight";
            this.labelTotalWeight.Size = new System.Drawing.Size(53, 19);
            this.labelTotalWeight.TabIndex = 8;
            this.labelTotalWeight.Text = "총 무게 : ";
            // 
            // labelPartCount
            // 
            this.labelPartCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPartCount.AutoSize = true;
            this.labelPartCount.Depth = 0;
            this.labelPartCount.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPartCount.Location = new System.Drawing.Point(345, 258);
            this.labelPartCount.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPartCount.Name = "labelPartCount";
            this.labelPartCount.Size = new System.Drawing.Size(65, 19);
            this.labelPartCount.TabIndex = 9;
            this.labelPartCount.Text = "운동 부위 : ";
            // 
            // checkShowAll
            // 
            this.checkShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkShowAll.AutoSize = true;
            this.checkShowAll.Location = new System.Drawing.Point(348, 80);
            this.checkShowAll.Name = "checkShowAll";
            this.checkShowAll.Size = new System.Drawing.Size(72, 16);
            this.checkShowAll.TabIndex = 10;
            this.checkShowAll.Text = "전체보기";
            this.checkShowAll.UseVisualStyleBackColor = true;
            this.checkShowAll.CheckedChanged += new System.EventHandler(this.checkShowAll_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(339, 281);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "CSV 저장";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Excel 저장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.checkShowAll);
            this.Controls.Add(this.labelPartCount);
            this.Controls.Add(this.labelTotalWeight);
            this.Controls.Add(this.labelTotalSets);
            this.Controls.Add(this.labelTotalCount);
            this.Controls.Add(this.routineName);
            this.Controls.Add(this.routineList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "MainForm";
            this.Text = "홈";
            ((System.ComponentModel.ISupportInitialize)(this.routineList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView routineList;
        private System.Windows.Forms.Label routineName;
        private MaterialSkin.Controls.MaterialLabel labelTotalCount;
        private MaterialSkin.Controls.MaterialLabel labelTotalSets;
        private MaterialSkin.Controls.MaterialLabel labelTotalWeight;
        private MaterialSkin.Controls.MaterialLabel labelPartCount;
        private System.Windows.Forms.CheckBox checkShowAll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button1;
    }
}

