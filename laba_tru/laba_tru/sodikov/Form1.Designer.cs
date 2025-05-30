namespace laba_tru.sodikov
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.runsDataGridView = new System.Windows.Forms.DataGridView();
            this.runningChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.comboBoxFirstParam = new System.Windows.Forms.ComboBox();
            this.comboBoxSecondParam = new System.Windows.Forms.ComboBox();
            this.labelFirstParam = new System.Windows.Forms.Label();
            this.labelSecondParam = new System.Windows.Forms.Label();
            this.numericWindowSize = new System.Windows.Forms.NumericUpDown();
            this.labelWindowSize = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.panelControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.runsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowSize)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();

            // runsDataGridView
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.runsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.runsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.runsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.runsDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.runsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.runsDataGridView.Name = "runsDataGridView";
            this.runsDataGridView.ReadOnly = true;
            this.runsDataGridView.Size = new System.Drawing.Size(884, 200);
            this.runsDataGridView.TabIndex = 0;

            // runningChart
            chartArea1.Name = "ChartArea1";
            this.runningChart.ChartAreas.Add(chartArea1);
            this.runningChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.runningChart.Legends.Add(legend1);
            this.runningChart.Location = new System.Drawing.Point(0, 250);
            this.runningChart.Name = "runningChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.runningChart.Series.Add(series1);
            this.runningChart.Size = new System.Drawing.Size(884, 411);
            this.runningChart.TabIndex = 1;
            this.runningChart.Text = "chart1";

            // btnLoadData
            this.btnLoadData.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLoadData.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.Location = new System.Drawing.Point(20, 15);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(120, 30);
            this.btnLoadData.TabIndex = 2;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = false;

            // btnAnalyze
            this.btnAnalyze.BackColor = System.Drawing.Color.LightGreen;
            this.btnAnalyze.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Location = new System.Drawing.Point(150, 15);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(120, 30);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Анализировать";
            this.btnAnalyze.UseVisualStyleBackColor = false;

            // comboBoxFirstParam
            this.comboBoxFirstParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFirstParam.FormattingEnabled = true;
            this.comboBoxFirstParam.Items.AddRange(new object[] {
                "Дистанция (км)",
                "Длительность (мин)",
                "Макс. скорость (км/ч)",
                "Мин. скорость (км/ч)",
                "Ср. скорость (км/ч)",
                "Ср. пульс (уд/мин)"});
            this.comboBoxFirstParam.Location = new System.Drawing.Point(300, 25);
            this.comboBoxFirstParam.Name = "comboBoxFirstParam";
            this.comboBoxFirstParam.Size = new System.Drawing.Size(150, 21);
            this.comboBoxFirstParam.TabIndex = 4;

            // comboBoxSecondParam
            this.comboBoxSecondParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecondParam.FormattingEnabled = true;
            this.comboBoxSecondParam.Items.AddRange(new object[] {
                "Дистанция (км)",
                "Длительность (мин)",
                "Макс. скорость (км/ч)",
                "Мин. скорость (км/ч)",
                "Ср. скорость (км/ч)",
                "Ср. пульс (уд/мин)"});
            this.comboBoxSecondParam.Location = new System.Drawing.Point(500, 25);
            this.comboBoxSecondParam.Name = "comboBoxSecondParam";
            this.comboBoxSecondParam.Size = new System.Drawing.Size(150, 21);
            this.comboBoxSecondParam.TabIndex = 5;

            // labelFirstParam
            this.labelFirstParam.AutoSize = true;
            this.labelFirstParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirstParam.Location = new System.Drawing.Point(300, 5);
            this.labelFirstParam.Name = "labelFirstParam";
            this.labelFirstParam.Size = new System.Drawing.Size(77, 13);
            this.labelFirstParam.TabIndex = 6;
            this.labelFirstParam.Text = "Параметр 1:";

            // labelSecondParam
            this.labelSecondParam.AutoSize = true;
            this.labelSecondParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSecondParam.Location = new System.Drawing.Point(500, 5);
            this.labelSecondParam.Name = "labelSecondParam";
            this.labelSecondParam.Size = new System.Drawing.Size(77, 13);
            this.labelSecondParam.TabIndex = 7;
            this.labelSecondParam.Text = "Параметр 2:";

            // numericWindowSize
            this.numericWindowSize.Location = new System.Drawing.Point(700, 25);
            this.numericWindowSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericWindowSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWindowSize.Name = "numericWindowSize";
            this.numericWindowSize.Size = new System.Drawing.Size(50, 20);
            this.numericWindowSize.TabIndex = 8;
            this.numericWindowSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});

            // labelWindowSize
            this.labelWindowSize.AutoSize = true;
            this.labelWindowSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWindowSize.Location = new System.Drawing.Point(660, 28);
            this.labelWindowSize.Name = "labelWindowSize";
            this.labelWindowSize.Size = new System.Drawing.Size(36, 13);
            this.labelWindowSize.TabIndex = 9;
            this.labelWindowSize.Text = "Окно:";

            // lblResults
            this.lblResults.BackColor = System.Drawing.Color.Lavender;
            this.lblResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResults.Location = new System.Drawing.Point(0, 200);
            this.lblResults.Name = "lblResults";
            this.lblResults.Padding = new System.Windows.Forms.Padding(5);
            this.lblResults.Size = new System.Drawing.Size(884, 50);
            this.lblResults.TabIndex = 10;
            this.lblResults.Text = "Загрузите данные для анализа";
            this.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // panelControls
            this.panelControls.Controls.Add(this.btnLoadData);
            this.panelControls.Controls.Add(this.btnAnalyze);
            this.panelControls.Controls.Add(this.comboBoxFirstParam);
            this.panelControls.Controls.Add(this.labelWindowSize);
            this.panelControls.Controls.Add(this.comboBoxSecondParam);
            this.panelControls.Controls.Add(this.numericWindowSize);
            this.panelControls.Controls.Add(this.labelFirstParam);
            this.panelControls.Controls.Add(this.labelSecondParam);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(884, 60);
            this.panelControls.TabIndex = 11;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.runningChart);
            this.Controls.Add(this.runsDataGridView);
            this.Controls.Add(this.panelControls);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализатор пробежек";
            ((System.ComponentModel.ISupportInitialize)(this.runsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowSize)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView runsDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart runningChart;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.ComboBox comboBoxFirstParam;
        private System.Windows.Forms.ComboBox comboBoxSecondParam;
        private System.Windows.Forms.Label labelFirstParam;
        private System.Windows.Forms.Label labelSecondParam;
        private System.Windows.Forms.NumericUpDown numericWindowSize;
        private System.Windows.Forms.Label labelWindowSize;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Panel panelControls;
    }
}