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
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        private List<Workout> workouts = new List<Workout>();
        public MainForm()
        {
            InitializeComponent(); 

            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.Orange700,
                TextShade.WHITE
            );

            routineList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            routineList.MultiSelect = false;
        }
        private void RefreshGrid()
        {
            routineList.DataSource = null;
            routineList.DataSource = workouts;
        }


        private void routineList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                workouts.Add(form.WorkoutResult);
                RefreshGrid();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (routineList.SelectedRows.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택하세요.");
                return;
            }

            int selectedIndex = routineList.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= workouts.Count) return;

            Workout selectedWorkout = workouts[selectedIndex];

            // 수정용 생성자 호출
            AddEditForm form = new AddEditForm(selectedWorkout);
            if (form.ShowDialog() == DialogResult.OK)
            {
                workouts[selectedIndex] = form.WorkoutResult;
                RefreshGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (routineList.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택하세요.");
                return;
            }

            int selectedIndex = routineList.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= workouts.Count) return;

            // 사용자에게 확인받기
            var result = MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                workouts.RemoveAt(selectedIndex);
                RefreshGrid();
                MessageBox.Show("삭제되었습니다.");
            }
        }
    }
}
