using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization;

namespace laba_tru.Pokalo
{
    public partial class Form3 : Form
    {
        private List<DiseaseData> _diseaseData;
        private Dictionary<string, Color> _diseaseColors;

        public Form3()
        {
            InitializeComponent();
            InitializeChart();
            InitializeDiseaseColors();
        }

        private void InitializeChart()
        {
            chart1.Titles.Add("Динамика инфекционных заболеваний в России");
            chart1.ChartAreas[0].AxisX.Title = "Год";
            chart1.ChartAreas[0].AxisY.Title = "Количество случаев";
            chart1.ChartAreas[0].AxisX.Interval = 1;

            // Удаляем существующую легенду (если есть)
            if (chart1.Legends.Count > 0)
            {
                chart1.Legends.Clear();
            }

            // Создаем новую легенду
            Legend legend = new Legend();
            legend.Name = "MainLegend";
            legend.Docking = Docking.Bottom;
            chart1.Legends.Add(legend);
        }

        private void InitializeDiseaseColors()
        {
            _diseaseColors = new Dictionary<string, Color>
            {
                { "Грипп", Color.Blue },
                { "Корь", Color.Green },
                { "Туберкулез", Color.Orange },
                { "Ветряная оспа", Color.Purple },
                { "Коклюш", Color.Brown }
            };
        }

        private void DisplayDataInGrid()
        {
            dataGridView1.DataSource = _diseaseData
                .OrderBy(d => d.DiseaseName)
                .ThenBy(d => d.Year)
                .ToList();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BuildInitialCharts()
        {
            chart1.Series.Clear();

            foreach (var disease in _diseaseData.Select(d => d.DiseaseName).Distinct())
            {
                var series = new Series(disease)
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    Color = _diseaseColors.ContainsKey(disease) ? _diseaseColors[disease] : Color.Gray
                };

                foreach (var point in _diseaseData.Where(d => d.DiseaseName == disease).OrderBy(d => d.Year))
                {
                    series.Points.AddXY(point.Year, point.CasesCount);
                }

                chart1.Series.Add(series);
            }
        }

        private void AnalyzeData()
        {
            // Пример простого анализа - можно расширить
            var maxCases = _diseaseData.OrderByDescending(d => d.CasesCount).First();
            label1.Text = $"Макс. случаев: {maxCases.DiseaseName} ({maxCases.CasesCount} в {maxCases.Year} г.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON files (*.json)|*.json",
                    Title = "Выберите файл с данными"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _diseaseData = DataLoader.LoadData(openFileDialog.FileName);
                    DisplayDataInGrid();
                    BuildInitialCharts();
                    AnalyzeData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int windowSize = (int)numericUpDown1.Value;
                int forecastYears = (int)numericUpDown2.Value;
                int lastYear = _diseaseData.Max(d => d.Year);

                foreach (var disease in _diseaseData.Select(d => d.DiseaseName).Distinct())
                {
                    var diseaseData = _diseaseData
                        .Where(d => d.DiseaseName == disease)
                        .OrderBy(d => d.Year)
                        .Select(d => (double)d.CasesCount)
                        .ToList();

                    var forecast = MovingAverageCalculator.Forecast(diseaseData, windowSize, forecastYears);
                    var series = chart1.Series.FindByName(disease);

                    for (int i = 0; i < forecast.Count; i++)
                    {
                        DataPoint point = new DataPoint(lastYear + i + 1, forecast[i])
                        {
                            Color = Color.Red,
                            BorderWidth = 2,
                            MarkerStyle = MarkerStyle.Circle,
                            MarkerSize = 8
                        };
                        series.Points.Add(point);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка прогнозирования: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Остальные методы-заглушки
        private void label1_Click(object sender, EventArgs e) { }
        private void chart1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
    }
}