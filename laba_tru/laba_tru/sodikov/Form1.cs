using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace laba_tru.sodikov
{
    public partial class Form1 : Form
    {
        private List<RunningRecord> runningRecords = new List<RunningRecord>();

        public Form1()
        {
            InitializeComponent();
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            // Заполнение комбобоксов
            comboBoxFirstParam.Items.AddRange(new string[] {
                "Дистанция (км)", "Длительность (мин)",
                "Макс. скорость (км/ч)", "Мин. скорость (км/ч)",
                "Ср. скорость (км/ч)", "Ср. пульс (уд/мин)"
            });
            comboBoxSecondParam.Items.AddRange(new string[] {
                "Дистанция (км)", "Длительность (мин)",
                "Макс. скорость (км/ч)", "Мин. скорость (км/ч)",
                "Ср. скорость (км/ч)", "Ср. пульс (уд/мин)"
            });

            comboBoxFirstParam.SelectedIndex = 0;
            comboBoxSecondParam.SelectedIndex = 1;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "JSON files (*.json)|*.json";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string json = File.ReadAllText(openDialog.FileName);
                        runningRecords = JsonConvert.DeserializeObject<List<RunningRecord>>(json);

                        DisplayRunningData();
                        UpdateCharts();
                        btnAnalyze.Enabled = true;
                        lblResults.Text = $"Загружено {runningRecords.Count} записей";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DisplayRunningData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Дата", typeof(string));
            table.Columns.Add("Время старта", typeof(string));
            table.Columns.Add("Длительность (мин)", typeof(int));
            table.Columns.Add("Дистанция (км)", typeof(double));
            table.Columns.Add("Макс. скорость", typeof(double));
            table.Columns.Add("Ср. скорость", typeof(double));
            table.Columns.Add("Пульс", typeof(int));
            table.Columns.Add("Выходной", typeof(bool));

            foreach (var record in runningRecords.OrderBy(r => r.RunDate))
            {
                table.Rows.Add(
                    record.RunDate.ToString("dd.MM.yyyy"),
                    record.StartTime.ToString(@"hh\:mm"),
                    record.DurationMinutes,
                    Math.Round(record.DistanceKm, 2),
                    Math.Round(record.MaxSpeedKmh, 1),
                    Math.Round(record.AvgSpeedKmh, 1),
                    record.AvgPulseBpm,
                    record.IsWeekend
                );
            }

            runsDataGridView.DataSource = table;
        }

        private void UpdateCharts()
        {
            runningChart.Series.Clear();

            var orderedData = runningRecords.OrderBy(r => r.RunDate).ToList();
            AddChartSeries(orderedData, comboBoxFirstParam.SelectedIndex, comboBoxFirstParam.Text, Color.Blue);
            AddChartSeries(orderedData, comboBoxSecondParam.SelectedIndex, comboBoxSecondParam.Text, Color.Green);
        }

        private void AddChartSeries(List<RunningRecord> data, int paramIndex, string seriesName, Color color)
        {
            Series series = new Series
            {
                Name = seriesName,
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = color
            };

            for (int i = 0; i < data.Count; i++)
            {
                double value = GetParameterValue(data[i], paramIndex);
                series.Points.AddXY(i + 1, value);
                series.Points[i].AxisLabel = data[i].RunDate.Day.ToString();
                series.Points[i].ToolTip = $"{data[i].RunDate:dd.MM}: {value:F1}";
            }

            runningChart.Series.Add(series);
        }

        private double GetParameterValue(RunningRecord record, int paramIndex)
        {
            switch (paramIndex)
            {
                case 0: return record.DistanceKm;
                case 1: return record.DurationMinutes;
                case 2: return record.MaxSpeedKmh;
                case 3: return record.MinSpeedKmh;
                case 4: return record.AvgSpeedKmh;
                case 5: return record.AvgPulseBpm;
                default: return 0;
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (runningRecords.Count == 0) return;

            double weekendDistance = CalculateWeekendDistance();
            double[] predictions = CalculateDistancePredictions();

            DisplayAnalysisResults(weekendDistance, predictions);
            ShowPredictionsOnChart(predictions);
        }

        private double CalculateWeekendDistance()
        {
            return runningRecords
                .Where(r => r.IsWeekend)
                .Sum(r => r.DistanceKm);
        }

        private double[] CalculateDistancePredictions()
        {
            int windowSize = (int)numericWindowSize.Value;
            int forecastDays = 5;

            var distances = runningRecords
                .OrderBy(r => r.RunDate)
                .Select(r => r.DistanceKm)
                .ToArray();

            return CalculateMovingAverage(distances, windowSize, forecastDays);
        }

        private double[] CalculateMovingAverage(double[] data, int windowSize, int forecastDays)
        {
            double[] predictions = new double[forecastDays];

            for (int i = 0; i < forecastDays; i++)
            {
                double sum = 0;
                int count = 0;

                for (int j = data.Length - windowSize + i; j < data.Length + i; j++)
                {
                    sum += (j < data.Length) ? data[j] : predictions[j - data.Length];
                    count++;
                }

                predictions[i] = sum / count;
            }

            return predictions;
        }

        private void DisplayAnalysisResults(double weekendDistance, double[] predictions)
        {
            string resultText = $"Суммарная дистанция в выходные: {weekendDistance:F2} км\n\n";
            resultText += "Прогноз дистанции на 5 дней:\n";

            for (int i = 0; i < predictions.Length; i++)
            {
                resultText += $"{i + 1}-й день: {predictions[i]:F1} км\n";
            }

            lblResults.Text = resultText;
        }

        private void ShowPredictionsOnChart(double[] predictions)
        {
            if (runningChart.Series.IndexOf("Прогноз") >= 0)
                runningChart.Series.RemoveAt(runningChart.Series.IndexOf("Прогноз"));

            var lastRecord = runningRecords.OrderBy(r => r.RunDate).Last();
            int lastDay = runningRecords.Count;
            double lastValue = GetParameterValue(lastRecord, comboBoxFirstParam.SelectedIndex);

            Series forecastSeries = new Series
            {
                Name = "Прогноз",
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                BorderDashStyle = ChartDashStyle.Dash,
                Color = Color.Red
            };

            forecastSeries.Points.AddXY(lastDay, lastValue);
            forecastSeries.Points.AddXY(lastDay + 1, predictions[0]);

            for (int i = 1; i < predictions.Length; i++)
            {
                forecastSeries.Points.AddXY(lastDay + 1 + i, predictions[i]);
            }

            runningChart.Series.Add(forecastSeries);
        }

        private void comboBoxFirstParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runningRecords.Count > 0) UpdateCharts();
        }

        private void comboBoxSecondParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runningRecords.Count > 0) UpdateCharts();
        }
    }
}