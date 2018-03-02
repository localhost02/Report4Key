namespace SearchKey
{
    partial class SearchKey
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_select_dir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_keys = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_result = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_single = new System.Windows.Forms.CheckBox();
            this.cb_multity = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_result)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_select_dir
            // 
            this.btn_select_dir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_select_dir.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_select_dir.Location = new System.Drawing.Point(188, 32);
            this.btn_select_dir.Name = "btn_select_dir";
            this.btn_select_dir.Size = new System.Drawing.Size(177, 23);
            this.btn_select_dir.TabIndex = 0;
            this.btn_select_dir.Text = "选择目录";
            this.btn_select_dir.UseVisualStyleBackColor = false;
            this.btn_select_dir.Click += new System.EventHandler(this.btn_select_dir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "1.选择目标文件所在的目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "2.输入需匹配计数的关键字：";
            // 
            // tb_keys
            // 
            this.tb_keys.Location = new System.Drawing.Point(671, 32);
            this.tb_keys.Multiline = true;
            this.tb_keys.Name = "tb_keys";
            this.tb_keys.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_keys.Size = new System.Drawing.Size(106, 84);
            this.tb_keys.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "结果图：";
            // 
            // chart_result
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.IsStaggered = true;
            chartArea1.Name = "ChartArea1";
            this.chart_result.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_result.Legends.Add(legend1);
            this.chart_result.Location = new System.Drawing.Point(33, 163);
            this.chart_result.Name = "chart_result";
            this.chart_result.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "出现次数";
            this.chart_result.Series.Add(series1);
            this.chart_result.Size = new System.Drawing.Size(744, 475);
            this.chart_result.TabIndex = 4;
            this.chart_result.Text = "chart_result";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "3.单文件中关键字多次出现：";
            // 
            // cb_single
            // 
            this.cb_single.AutoSize = true;
            this.cb_single.Checked = true;
            this.cb_single.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_single.Location = new System.Drawing.Point(199, 85);
            this.cb_single.Name = "cb_single";
            this.cb_single.Size = new System.Drawing.Size(72, 16);
            this.cb_single.TabIndex = 5;
            this.cb_single.Text = "算作一次";
            this.cb_single.UseVisualStyleBackColor = true;
            this.cb_single.CheckedChanged += new System.EventHandler(this.cb_single_CheckedChanged);
            // 
            // cb_multity
            // 
            this.cb_multity.AutoSize = true;
            this.cb_multity.Location = new System.Drawing.Point(293, 85);
            this.cb_multity.Name = "cb_multity";
            this.cb_multity.Size = new System.Drawing.Size(72, 16);
            this.cb_multity.TabIndex = 6;
            this.cb_multity.Text = "算作多次";
            this.cb_multity.UseVisualStyleBackColor = true;
            this.cb_multity.CheckedChanged += new System.EventHandler(this.cb_multity_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 1;
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_start.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_start.Location = new System.Drawing.Point(516, 82);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(136, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始查找匹配";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "4.";
            // 
            // SearchKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 651);
            this.Controls.Add(this.cb_multity);
            this.Controls.Add(this.cb_single);
            this.Controls.Add(this.chart_result);
            this.Controls.Add(this.tb_keys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_select_dir);
            this.Name = "SearchKey";
            this.Text = "SearchKey";
            ((System.ComponentModel.ISupportInitialize)(this.chart_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_select_dir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_keys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_single;
        private System.Windows.Forms.CheckBox cb_multity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label7;

    }
}

