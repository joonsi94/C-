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
        }
        private void RefreshGrid()
        {
            routineList.DataSource = null;
            routineList.DataSource = workouts;
        }
        private void button2_Click(object sender, EventArgs e)
        {
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

    }
}
