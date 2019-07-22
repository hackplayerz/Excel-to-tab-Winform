namespace ExcelToTab
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_loadExcelFile = new System.Windows.Forms.Button();
            this.panel_exportOption = new System.Windows.Forms.Panel();
            this.panel_selectSheet = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_exportSheet = new System.Windows.Forms.TextBox();
            this.radioButton_selectSheet = new System.Windows.Forms.RadioButton();
            this.radioButton_allData = new System.Windows.Forms.RadioButton();
            this.panel_exportOption.SuspendLayout();
            this.panel_selectSheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel To Tab";
            // 
            // button_loadExcelFile
            // 
            this.button_loadExcelFile.Location = new System.Drawing.Point(15, 370);
            this.button_loadExcelFile.Name = "button_loadExcelFile";
            this.button_loadExcelFile.Size = new System.Drawing.Size(392, 47);
            this.button_loadExcelFile.TabIndex = 1;
            this.button_loadExcelFile.Text = "Load Excel File";
            this.button_loadExcelFile.UseVisualStyleBackColor = true;
            this.button_loadExcelFile.Click += new System.EventHandler(this.Button_loadExcelFile_Click);
            // 
            // panel_exportOption
            // 
            this.panel_exportOption.Controls.Add(this.panel_selectSheet);
            this.panel_exportOption.Controls.Add(this.radioButton_selectSheet);
            this.panel_exportOption.Controls.Add(this.radioButton_allData);
            this.panel_exportOption.Location = new System.Drawing.Point(15, 50);
            this.panel_exportOption.Name = "panel_exportOption";
            this.panel_exportOption.Size = new System.Drawing.Size(392, 300);
            this.panel_exportOption.TabIndex = 4;
            // 
            // panel_selectSheet
            // 
            this.panel_selectSheet.Controls.Add(this.label2);
            this.panel_selectSheet.Controls.Add(this.textBox_exportSheet);
            this.panel_selectSheet.Location = new System.Drawing.Point(14, 109);
            this.panel_selectSheet.Name = "panel_selectSheet";
            this.panel_selectSheet.Size = new System.Drawing.Size(342, 145);
            this.panel_selectSheet.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "To export sheet name";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // textBox_exportSheet
            // 
            this.textBox_exportSheet.Location = new System.Drawing.Point(15, 87);
            this.textBox_exportSheet.Name = "textBox_exportSheet";
            this.textBox_exportSheet.Size = new System.Drawing.Size(295, 25);
            this.textBox_exportSheet.TabIndex = 4;
            // 
            // radioButton_selectSheet
            // 
            this.radioButton_selectSheet.AutoSize = true;
            this.radioButton_selectSheet.Location = new System.Drawing.Point(14, 60);
            this.radioButton_selectSheet.Name = "radioButton_selectSheet";
            this.radioButton_selectSheet.Size = new System.Drawing.Size(112, 19);
            this.radioButton_selectSheet.TabIndex = 3;
            this.radioButton_selectSheet.TabStop = true;
            this.radioButton_selectSheet.Text = "Select Sheet";
            this.radioButton_selectSheet.UseVisualStyleBackColor = true;
            // 
            // radioButton_allData
            // 
            this.radioButton_allData.AutoSize = true;
            this.radioButton_allData.Checked = true;
            this.radioButton_allData.Location = new System.Drawing.Point(14, 20);
            this.radioButton_allData.Name = "radioButton_allData";
            this.radioButton_allData.Size = new System.Drawing.Size(126, 19);
            this.radioButton_allData.TabIndex = 2;
            this.radioButton_allData.TabStop = true;
            this.radioButton_allData.Text = "Export All Data";
            this.radioButton_allData.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.Controls.Add(this.panel_exportOption);
            this.Controls.Add(this.button_loadExcelFile);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Excel Data Pacer";
            this.panel_exportOption.ResumeLayout(false);
            this.panel_exportOption.PerformLayout();
            this.panel_selectSheet.ResumeLayout(false);
            this.panel_selectSheet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_loadExcelFile;
        private System.Windows.Forms.Panel panel_exportOption;
        private System.Windows.Forms.RadioButton radioButton_selectSheet;
        private System.Windows.Forms.RadioButton radioButton_allData;
        private System.Windows.Forms.Panel panel_selectSheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_exportSheet;
    }
}

