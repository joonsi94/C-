using ClosedXML.Excel;
using MaterialSkin;
using Newtonsoft.Json;
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
using System.Data.SqlClient;

namespace exercise_routine
{


    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        private List<Workout> workouts = new List<Workout>();
        private readonly ExerciseRepository _repo;
        private readonly string _cs = "Server=DESKTOP-6VSVCKC\\JSTESTSERVER;Database=exercise;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public class ExerciseRepository
        {
            private readonly string _cs;
            public ExerciseRepository(string connectionString) => _cs = connectionString;

            public List<Workout> GetAll()
            {
                var list = new List<Workout>();
                using (var con = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(@"
                SELECT Id, [Date], ExerciseName, Part, Sets, Reps, Weight, Memo
                FROM dbo.Exercise
                ORDER BY [Date] DESC, Id DESC", con))
                {
                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new Workout
                            {
                                Id = rd.GetInt64(0),
                                Date = rd.GetDateTime(1),
                                ExerciseName = rd.IsDBNull(2) ? "" : rd.GetString(2),
                                Part = rd.IsDBNull(3) ? "" : rd.GetString(3),
                                Sets = rd.IsDBNull(4) ? 0 : rd.GetInt32(4),
                                Reps = rd.IsDBNull(5) ? 0 : rd.GetInt32(5),
                                Weight = rd.IsDBNull(6) ? 0f : Convert.ToSingle(rd.GetDouble(6)),
                                Memo = rd.IsDBNull(7) ? "" : rd.GetString(7)
                            });
                        }
                    }
                }
                return list;
            }

            public long Insert(Workout w)
            {
                using (var con = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(@"
                INSERT INTO dbo.Exercise([Date], ExerciseName, Part, Sets, Reps, Weight, Memo)
                OUTPUT INSERTED.Id
                VALUES(@Date, @ExerciseName, @Part, @Sets, @Reps, @Weight, @Memo)", con))
                {
                    cmd.Parameters.AddWithValue("@Date", w.Date.Date);
                    cmd.Parameters.AddWithValue("@ExerciseName", (object)w.ExerciseName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Part", (object)w.Part ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sets", w.Sets);
                    cmd.Parameters.AddWithValue("@Reps", w.Reps);
                    cmd.Parameters.AddWithValue("@Weight", w.Weight);
                    cmd.Parameters.AddWithValue("@Memo", (object)w.Memo ?? DBNull.Value);

                    con.Open();
                    return (long)cmd.ExecuteScalar();
                }
            }

            public void Update(Workout w)
            {
                using (var con = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(@"
                UPDATE dbo.Exercise
                SET [Date]=@Date, ExerciseName=@ExerciseName, Part=@Part, Sets=@Sets, Reps=@Reps, Weight=@Weight, Memo=@Memo
                WHERE Id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", w.Id);
                    cmd.Parameters.AddWithValue("@Date", w.Date.Date);
                    cmd.Parameters.AddWithValue("@ExerciseName", (object)w.ExerciseName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Part", (object)w.Part ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sets", w.Sets);
                    cmd.Parameters.AddWithValue("@Reps", w.Reps);
                    cmd.Parameters.AddWithValue("@Weight", w.Weight);
                    cmd.Parameters.AddWithValue("@Memo", (object)w.Memo ?? DBNull.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            public void Delete(long id)
            {
                using (var con = new SqlConnection(_cs))
                using (var cmd = new SqlCommand("DELETE FROM dbo.Exercise WHERE Id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //class DbConnector
        //{
        //    public static string ConnectionString = "Server=localhost;Database=DESKTOP-6VSVCKC\\JSTESTSERVER;";
        //    public void Connect()
        //    {
        //        using (SqlConnection connection = new SqlConnection(ConnectionString))
        //        {
        //            try
        //            {
        //                //DB 서버 접속 시작
        //                connection.Open();
        //                MessageBox.Show("DB 연결 성공!");
        //            }
        //            catch (Exception ex) //DB 서버 접속 실패
        //            {
        //                MessageBox.Show("DB 연결 실패: " + ex.Message);
        //            }

        //            //DB 서버 접속 종료
        //            connection.Close();
        //        }
        //    }
        //}

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

            _repo = new ExerciseRepository(_cs);
            workouts = _repo.GetAll(); // 최초 로드
            RefreshGrid();             // 그리드 최신화
        }

        private void UpdateStatistics(List<Workout> filteredList)
        {
            int totalCount = filteredList.Count;
            int totalSets = filteredList.Sum(w => w.Sets);
            float totalWeight = filteredList.Sum(w => w.Sets * w.Weight);

            // 부위별 개수
            var partGroups = filteredList
                .GroupBy(w => w.Part)
                .Select(g => $"{g.Key}");

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

        private void btnCreate_Click(object sender, EventArgs e) //추가
        {
            using (var form = new AddEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // DB 저장
                    var id = _repo.Insert(form.WorkoutResult);
                    // 메모리 갱신 (전체 다시 로드 또는 단건 추가)
                    workouts = _repo.GetAll();
                    RefreshGrid();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // 수정
        {
            if (routineList.SelectedRows.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택하세요.");
                return;
            }

            var selected = routineList.SelectedRows[0].DataBoundItem as Workout;
            if (selected == null) return;

            using (var form = new AddEditForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var edited = form.WorkoutResult;
                    edited.Id = selected.Id; // 기존 Id 유지
                    _repo.Update(edited);

                    // 다시 로드
                    workouts = _repo.GetAll();
                    RefreshGrid();
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (routineList.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택하세요.");
                return;
            }

            var selected = routineList.SelectedRows[0].DataBoundItem as Workout;
            if (selected == null) return;

            var result = MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _repo.Delete(selected.Id);
                workouts = _repo.GetAll();
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
    }
        public static class HttpClientExtensions
        {
            public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
            {
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
                {
                    Content = content
                };
                return await client.SendAsync(request);
            }
        }
}
