
namespace laba_tru
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_lav = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_pok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_sod = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_lav
            // 
            this.btn_lav.Location = new System.Drawing.Point(12, 25);
            this.btn_lav.Name = "btn_lav";
            this.btn_lav.Size = new System.Drawing.Size(150, 50);
            this.btn_lav.TabIndex = 0;
            this.btn_lav.Text = "Цены на жилье";
            this.btn_lav.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Лаврешин Илья";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Покало Ростислав";
            // 
            // btn_pok
            // 
            this.btn_pok.Location = new System.Drawing.Point(168, 25);
            this.btn_pok.Name = "btn_pok";
            this.btn_pok.Size = new System.Drawing.Size(150, 50);
            this.btn_pok.TabIndex = 2;
            this.btn_pok.Text = "Инфекционные заболевания";
            this.btn_pok.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Содиков Мага";
            // 
            // btn_sod
            // 
            this.btn_sod.Location = new System.Drawing.Point(324, 25);
            this.btn_sod.Name = "btn_sod";
            this.btn_sod.Size = new System.Drawing.Size(150, 50);
            this.btn_sod.TabIndex = 4;
            this.btn_sod.Text = "Пробежки";
            this.btn_sod.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(194, 81);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(100, 25);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "ВЫХОД";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 121);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_sod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_pok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_lav);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_lav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_pok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_sod;
        private System.Windows.Forms.Button btn_exit;
    }
}

