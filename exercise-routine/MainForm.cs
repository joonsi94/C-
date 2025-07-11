using ClosedXML.Excel;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercise_routine
{
    

    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        private List<Workout> workouts = new List<Workout>();
        private readonly string supabaseUrl = "https://knncxyddfucyzimwfkoj.supabase.co";
        private readonly string supabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImtubmN4eWRkZnVjeXppbXdma29qIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzk0MjQ3NzUsImV4cCI6MjA1NTAwMDc3NX0.Y4rkdOA3kidzoZgm-nxNfX2pHVAv74AautTtPhTmUdM";
        private readonly string table = "Excercise";
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{supabaseUrl}/rest/v1/");
            client.DefaultRequestHeaders.Add("apikey", supabaseApiKey);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {supabaseApiKey}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
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
        private void UpdateStatistics(List<Workout> filteredList)
        {
            int totalCount = filteredList.Count;
            int totalSets = filteredList.Sum(w => w.Sets);
            float totalWeight = filteredList.Sum(w => w.Sets * w.Weight);

            // 부위별 개수
            var partGroups = filteredList
                .GroupBy(w => w.Part)
                .Select(g => $"{g.Key}: {g.Count()}");

            string partText = string.Join(", ", partGroups);

            // Label 업데이트
            labelTotalCount.Text = $"오늘 루틴 수: {totalCount}개";
            labelTotalSets.Text = $"총 세트 수: {totalSets}세트";
            labelTotalWeight.Text = $"총 무게: {totalWeight}kg";
            labelPartCount.Text = $"운동 부위: {partText}";
        }
        private void RefreshGrid()
        {
            List<Workout> filtered;

            if (checkShowAll.Checked)
            {
                // 전체 보기
                filtered = workouts;
            }
            else
            {
                // 날짜 필터링
                var selectedDate = dateTimePicker1.Value.Date;
                filtered = workouts.Where(w => w.Date.Date == selectedDate).ToList();
            }

            routineList.DataSource = null;
            routineList.DataSource = filtered;
            UpdateStatistics(filtered);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void checkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (workouts.Count == 0)
            {
                MessageBox.Show("저장할 운동 기록이 없습니다.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV 파일 (*.csv)|*.csv";
                saveFileDialog.Title = "CSV로 내보내기";
                saveFileDialog.FileName = "운동기록.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                        {
                            // 헤더
                            writer.WriteLine("날짜,운동명,부위,세트수,반복수,무게,메모");

                            foreach (var w in workouts)
                            {
                                string line = $"{w.Date:yyyy-MM-dd},{w.ExerciseName},{w.Part},{w.Sets},{w.Reps},{w.Weight},{w.Memo}";
                                writer.WriteLine(line);
                            }
                        }

                        MessageBox.Show("CSV 파일로 저장되었습니다!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("저장 중 오류 발생: " + ex.Message);
                    }
                }
            }
        }
        private void ExportToExcel()
        {
            if (workouts.Count == 0)
            {
                MessageBox.Show("저장할 운동 기록이 없습니다.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel 파일 (*.xlsx)|*.xlsx";
                saveDialog.FileName = "운동기록.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("운동 기록");

                            // 헤더
                            ws.Cell(1, 1).Value = "날짜";
                            ws.Cell(1, 2).Value = "운동명";
                            ws.Cell(1, 3).Value = "부위";
                            ws.Cell(1, 4).Value = "세트수";
                            ws.Cell(1, 5).Value = "반복수";
                            ws.Cell(1, 6).Value = "무게";
                            ws.Cell(1, 7).Value = "메모";

                            for (int i = 0; i < workouts.Count; i++)
                            {
                                var w = workouts[i];
                                ws.Cell(i + 2, 1).Value = w.Date.ToString("yyyy-MM-dd");
                                ws.Cell(i + 2, 2).Value = w.ExerciseName;
                                ws.Cell(i + 2, 3).Value = w.Part;
                                ws.Cell(i + 2, 4).Value = w.Sets;
                                ws.Cell(i + 2, 5).Value = w.Reps;
                                ws.Cell(i + 2, 6).Value = w.Weight;
                                ws.Cell(i + 2, 7).Value = w.Memo;
                            }

                            // 🔥 자동 셀 너비 조절
                            ws.Rows().AdjustToContents();         // 행 높이 자동
                            ws.Columns().AdjustToContents();      // 열 너비 자동
                            ws.CellsUsed().Style.Alignment.WrapText = false;

                            workbook.SaveAs(saveDialog.FileName);
                        }

                        MessageBox.Show("엑셀 파일로 저장되었습니다!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("저장 중 오류 발생: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private async Task<List<Workout>> GetWorkoutsFromSupabaseAsync()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"{table}?select=*");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Workout>>(json) ?? new();
        }

        private async Task AddWorkoutToSupabaseAsync(Workout w)
        {
            var client = GetHttpClient();
            var json = JsonSerializer.Serialize(new[] {
        new {
            date = w.Date.ToString("yyyy-MM-dd"),
            exercisename = w.ExerciseName,
            part = w.Part,
            sets = w.Sets,
            reps = w.Reps,
            weight = w.Weight,
            memo = w.Memo
        }
    });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(table, content);
            response.EnsureSuccessStatusCode();
        }

        private async Task UpdateWorkoutToSupabaseAsync(Workout w)
        {
            var client = GetHttpClient();
            var json = JsonSerializer.Serialize(new
            {
                date = w.Date.ToString("yyyy-MM-dd"),
                exercisename = w.ExerciseName,
                part = w.Part,
                sets = w.Sets,
                reps = w.Reps,
                weight = w.Weight,
                memo = w.Memo
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PatchAsync($"{table}?id=eq.{w.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        private async Task DeleteWorkoutFromSupabaseAsync(long id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"{table}?id=eq.{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
