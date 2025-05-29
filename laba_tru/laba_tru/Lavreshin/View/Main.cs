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

        
        private void SetupChart() // Настройка внешнего вида графика
        {
            chartPrices.Series.Clear();
            chartPrices.ChartAreas[0].AxisX.Title = "Год";
            chartPrices.ChartAreas[0].AxisY.Title = "Цена (млн руб.)";
            chartPrices.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartPrices.Legends[0].Docking = Docking.Bottom;

            chartPrices.Legends[0].Enabled = false;
        }
        private void btnLoadData_Click(object sender, EventArgs e) // Загрузка данных из JSON
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
        private void UpdateDataGrid() // Заполнение таблицы
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

        private void UpdateChart() // Обновление графика
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

        private void CalculateStats() // Расчет статистики
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

        private void btnForecast_Click(object sender, EventArgs e) // Расчет прогноза
        {
            if (!int.TryParse(txtForecastYears.Text, out int years) || years <= 0)
            {
                MessageBox.Show("Введите корректное число лет");
                return;
            }

            string selectedType = comboBoxApartment.SelectedItem?.ToString() ?? "1-комн.";
            AddForecastToChart(selectedType, years);
        }
        private void AddForecastToChart(string apartmentType, int forecastYears) // Добавление прогноза на график
        {
            // Удаление старого прогноза
            if (chartPrices.Series.Any(s => s.Name == "Прогноз"))
            {
                chartPrices.Series.Remove(chartPrices.Series["Прогноз"]);
            }

            // Получаем данные
            List<double> historicalData = new List<double>();
            List<int> years = new List<int>();

            foreach (var price in prices)
            {
                years.Add(price.Year);
                switch (apartmentType)
                {
                    case "1-комн.": historicalData.Add(price.OneRoomPrice); break;
                    case "2-комн.": historicalData.Add(price.TwoRoomPrice); break;
                    case "3-комн.": historicalData.Add(price.ThreeRoomPrice); break;
                }
            }

            // Рассчет линейного тренда (y = a*x + b)
            double xAvg = years.Average();
            double yAvg = historicalData.Average();

            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < years.Count; i++)
            {
                numerator += (years[i] - xAvg) * (historicalData[i] - yAvg);
                denominator += Math.Pow(years[i] - xAvg, 2);
            }

            double a = numerator / denominator; // Коэффициент наклона
            double b = yAvg - a * xAvg;       // Свободный член

            // Прогноз на основе тренда + последних колебаний
            List<double> forecast = new List<double>();
            int lastYear = years.Last();
            double lastValue = historicalData.Last();
            double windowSize = 3;

            // Коэффициент влияния колебаний (0.3 = 30% влияния последних изменений)
            double fluctuationFactor = 0.3;

            for (int i = 1; i <= forecastYears; i++)
            {
                // Базовое значение по тренду
                double trendValue = a * (lastYear + i) + b;

                // Корректировка на основе последних колебаний
                double fluctuation = 0;
                int count = 0;

                for (int j = historicalData.Count - (int)windowSize; j < historicalData.Count; j++)
                {
                    if (j >= 1)
                    {
                        fluctuation += historicalData[j] - historicalData[j - 1];
                        count++;
                    }
                }

                if (count > 0)
                {
                    fluctuation /= count;
                }

                // Комбинированный прогноз
                double predictedValue = trendValue + fluctuationFactor * fluctuation;
                forecast.Add(predictedValue);
            }

            // Прогноз на график
            var forecastSeries = new Series("Прогноз")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2,
                BorderDashStyle = ChartDashStyle.Dash
            };

            for (int i = 0; i < forecast.Count; i++)
            {
                forecastSeries.Points.AddXY(lastYear + i + 1, forecast[i]);
            }

            chartPrices.Series.Add(forecastSeries);
        }

        private void comboBoxApartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }
    }
}
