
namespace laba_tru.Lavreshin
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPrices = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxApartment = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnForecast = new System.Windows.Forms.Button();
            this.txtForecastYears = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridPrices = new System.Windows.Forms.DataGridView();
            this.lblResults = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPrices
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPrices.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPrices.Legends.Add(legend1);
            this.chartPrices.Location = new System.Drawing.Point(12, 208);
            this.chartPrices.Name = "chartPrices";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPrices.Series.Add(series1);
            this.chartPrices.Size = new System.Drawing.Size(446, 189);
            this.chartPrices.TabIndex = 0;
            this.chartPrices.Text = "chart1";
            // 
            // comboBoxApartment
            // 
            this.comboBoxApartment.FormattingEnabled = true;
            this.comboBoxApartment.Items.AddRange(new object[] {
            "1-комн.",
            "2-комн.",
            "3-комн."});
            this.comboBoxApartment.Location = new System.Drawing.Point(150, 12);
            this.comboBoxApartment.Name = "comboBoxApartment";
            this.comboBoxApartment.Size = new System.Drawing.Size(121, 21);
            this.comboBoxApartment.TabIndex = 1;
            this.comboBoxApartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxApartment_SelectedIndexChanged);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(277, 10);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(121, 23);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnForecast
            // 
            this.btnForecast.Location = new System.Drawing.Point(277, 403);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(121, 23);
            this.btnForecast.TabIndex = 3;
            this.btnForecast.Text = "Рассчитать прогноз";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // txtForecastYears
            // 
            this.txtForecastYears.Location = new System.Drawing.Point(137, 405);
            this.txtForecastYears.Name = "txtForecastYears";
            this.txtForecastYears.Size = new System.Drawing.Size(134, 20);
            this.txtForecastYears.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите число лет (n):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выберите тип квартиры:";
            // 
            // dataGridPrices
            // 
            this.dataGridPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPrices.Location = new System.Drawing.Point(12, 39);
            this.dataGridPrices.Name = "dataGridPrices";
            this.dataGridPrices.Size = new System.Drawing.Size(446, 163);
            this.dataGridPrices.TabIndex = 7;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 434);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(82, 13);
            this.lblResults.TabIndex = 8;
            this.lblResults.Text = "РЕЗУЛЬТАТЫ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 489);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.dataGridPrices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtForecastYears);
            this.Controls.Add(this.btnForecast);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.comboBoxApartment);
            this.Controls.Add(this.chartPrices);
            this.Name = "Main";
            this.Text = "Цены на жильё";
            ((System.ComponentModel.ISupportInitialize)(this.chartPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrices;
        private System.Windows.Forms.ComboBox comboBoxApartment;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.TextBox txtForecastYears;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridPrices;
        private System.Windows.Forms.Label lblResults;
    }
}