using exercise_routine;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercise_routine
{
    public partial class AddEditForm : MaterialSkin.Controls.MaterialForm
    {
        public Workout WorkoutResult { get; private set; }
        public AddEditForm()
        {
            InitializeComponent();

            cmbPart.Items.AddRange(new string[] { "가슴", "등", "하체", "어깨", "팔", "복근" });
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.Orange700,
                TextShade.WHITE
            );


            // Placeholder 초기값 설정
            exerciseName.Text = "운동명을 입력하세요";
            exerciseName.ForeColor = Color.Gray;

            sets.Text = "세트 수";
            sets.ForeColor = Color.Gray;

            reps.Text = "반복 수";
            reps.ForeColor = Color.Gray;

            weight.Text = "무게 (kg)";
            weight.ForeColor = Color.Gray;

            // ComboBox 항목 세팅
            cmbPart.Items.AddRange(new string[] { "가슴", "등", "하체", "어깨", "팔", "복근" });
            cmbPart.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPart.SelectedIndex = 0;

            // TabIndex 순서 설정
            exerciseName.TabIndex = 0;
            cmbPart.TabIndex = 1;
            sets.TabIndex = 2;
            reps.TabIndex = 3;
            weight.TabIndex = 4;
            todayDate.TabIndex = 5;
            memo.TabIndex = 6;
            btnSave.TabIndex = 7;

            // 날짜 선택 자동 드롭다운
            todayDate.Enter += (s, e) => SendKeys.Send("%{DOWN}");

            // Placeholder 관련 이벤트
            SetPlaceholderEvents(exerciseName, "운동명을 입력하세요");
            SetPlaceholderEvents(sets, "세트 수");
            SetPlaceholderEvents(reps, "반복 수");
            SetPlaceholderEvents(weight, "무게 (kg)");
        }
        private void SetPlaceholderEvents(TextBox textbox, string placeholder)
        {
            textbox.Enter += (s, e) =>
            {
                if (textbox.Text == placeholder)
                {
                    textbox.Text = "";
                    textbox.ForeColor = Color.Black;
                }
            };

            textbox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textbox.Text))
                {
                    textbox.Text = placeholder;
                    textbox.ForeColor = Color.Gray;
                }
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(sets.Text, out int parsedsets) || parsedsets <= 0)
            {
                MessageBox.Show("세트 수를 올바르게 입력하세요.");
                return;
            }

            if (!int.TryParse(reps.Text, out int parsedreps) || parsedreps <= 0)
            {
                MessageBox.Show("반복 수를 올바르게 입력하세요.");
                return;
            }

            if (!float.TryParse(weight.Text, out float parsedweight) || parsedweight < 0)
            {
                MessageBox.Show("무게를 올바르게 입력하세요.");
                return;
            }

            WorkoutResult = new Workout
            {
                Date = todayDate.Value,
                ExerciseName = exerciseName.Text,
                Part = cmbPart.Text,
                Sets = int.Parse(sets.Text),
                Reps = int.Parse(reps.Text),
                Weight = float.Parse(weight.Text),
                Memo = memo.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public AddEditForm(Workout workoutToEdit) : this()
        {
            // 기존 운동 정보로 폼 초기화
            exerciseName.Text = workoutToEdit.ExerciseName;
            exerciseName.ForeColor = Color.Black; // 기존 운동명은 회색이 아니므로 검정색으로 설정

            cmbPart.SelectedItem = workoutToEdit.Part;

            sets.Text = workoutToEdit.Sets.ToString();
            sets.ForeColor = Color.Black; // 기존 세트 수는 회색이 아니므로 검정색으로 설정

            reps.Text = workoutToEdit.Reps.ToString();
            reps.ForeColor = Color.Black; // 기존 반복 수는 회색이 아니므로 검정색으로 설정

            weight.Text = workoutToEdit.Weight.ToString();
            weight.ForeColor = Color.Black; // 기존 무게는 회색이 아니므로 검정색으로 설정

            todayDate.Value = workoutToEdit.Date;

            memo.Text = workoutToEdit.Memo;
            memo.ForeColor = Color.Black; // 기존 메모는 회색이 아니므로 검정색으로 설정
            // 버튼 텍스트 변경
            btnSave.Text = "수정";
        }
    }
}
