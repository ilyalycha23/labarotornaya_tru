using laba_tru.Lavreshin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace laba_tru.Lavreshin
{
    public partial class Main : Form
    {
        private List<HousingPrice> prices = new List<HousingPrice>();
        public Main()
        {
            InitializeComponent();
            SetupChart();
        }

        // Настройка внешнего вида графика
        private void SetupChart()
        {
            chartPrices.Series.Clear();
            chartPrices.ChartAreas[0].AxisX.Title = "Год";
            chartPrices.ChartAreas[0].AxisY.Title = "Цена (млн руб.)";
            chartPrices.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartPrices.Legends[0].Docking = Docking.Bottom;
        }
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON files (*.json)|*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(ofd.FileName);
                    prices = JsonConvert.DeserializeObject<List<HousingPrice>>(json);
                    UpdateDataGrid();
                    UpdateChart();
                    CalculateStats();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        private void UpdateDataGrid()
        {
            dataGridPrices.AutoGenerateColumns = false;
            dataGridPrices.Columns.Clear();

            dataGridPrices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Year",
                HeaderText = "Год"
            });
            dataGridPrices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OneRoomPrice",
                HeaderText = "1-комн. (млн руб.)"
            });
            dataGridPrices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TwoRoomPrice",
                HeaderText = "2-комн. (млн руб.)"
            });
            dataGridPrices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ThreeRoomPrice",
                HeaderText = "3-комн. (млн руб.)"
            });

            dataGridPrices.DataSource = prices;
        }
        // Обновление графика
        private void UpdateChart()
        {
            if (prices == null || prices.Count == 0) return;

            chartPrices.Series.Clear();
            string selectedType = comboBoxApartment.SelectedItem?.ToString() ?? "1-комн.";

            var series = new Series(selectedType)
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue,
                BorderWidth = 2
            };

            foreach (var price in prices)
            {
                double value;
                switch (selectedType)
                {
                    case "1-комн.":
                        value = price.OneRoomPrice;
                        break;
                    case "2-комн.":
                        value = price.TwoRoomPrice;
                        break;
                    case "3-комн.":
                        value = price.ThreeRoomPrice;
                        break;
                    default:
                        value = 0;
                        break;
                }
                series.Points.AddXY(price.Year, value);
            }

            chartPrices.Series.Add(series);
        }

        // Расчет статистики
        private void CalculateStats()
        {
            if (prices.Count < 2) return;

            var first = prices.First();
            var last = prices.Last();

            double oneRoomChange = (last.OneRoomPrice - first.OneRoomPrice) / first.OneRoomPrice * 100;
            double twoRoomChange = (last.TwoRoomPrice - first.TwoRoomPrice) / first.TwoRoomPrice * 100;
            double threeRoomChange = (last.ThreeRoomPrice - first.ThreeRoomPrice) / first.ThreeRoomPrice * 100;

            lblResults.Text = string.Format(
                "Изменение цен за период:\n" +
                "1-комн.: {0:F1}%\n" +
                "2-комн.: {1:F1}%\n" +
                "3-комн.: {2:F1}%",
                oneRoomChange, twoRoomChange, threeRoomChange);
        }

        private void btnForecast_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtForecastYears.Text, out int years) || years <= 0)
            {
                MessageBox.Show("Введите корректное число лет");
                return;
            }

            string selectedType = comboBoxApartment.SelectedItem?.ToString() ?? "1-комн.";
            AddForecastToChart(selectedType, years);
        }
        private void AddForecastToChart(string apartmentType, int forecastYears)
        {
            List<double> historicalData;
            switch (apartmentType)
            {
                case "1-комн.":
                    historicalData = prices.Select(p => p.OneRoomPrice).ToList();
                    break;
                case "2-комн.":
                    historicalData = prices.Select(p => p.TwoRoomPrice).ToList();
                    break;
                case "3-комн.":
                    historicalData = prices.Select(p => p.ThreeRoomPrice).ToList();
                    break;
                default:
                    historicalData = new List<double>();
                    break;
            }

            List<double> forecast = new List<double>();
            int windowSize = 3;

            for (int i = 0; i < forecastYears; i++)
            {
                double sum = 0;
                int count = 0;
                for (int j = historicalData.Count - windowSize; j < historicalData.Count; j++)
                {
                    if (j >= 0)
                    {
                        sum += historicalData[j];
                        count++;
                    }
                }
                forecast.Add(sum / count);
                historicalData.Add(sum / count);
            }

            var forecastSeries = new Series("Прогноз")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderDashStyle = ChartDashStyle.Dash
            };

            int startYear = prices[prices.Count - 1].Year + 1;
            for (int i = 0; i < forecast.Count; i++)
            {
                forecastSeries.Points.AddXY(startYear + i, forecast[i]);
            }

            chartPrices.Series.Add(forecastSeries);
        }

        private void comboBoxApartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }
    }
}
