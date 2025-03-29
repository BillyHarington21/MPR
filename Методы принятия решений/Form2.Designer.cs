using Методы_принятия_решений.Utils;
namespace Методы_принятия_решений
{
    partial class Form2 : Form
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
            btnGenerateTable = new Button();
            dataGridView = new DataGridView();
            dataGridViewComparison = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComparison).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnGenerateTable
            // 
            btnGenerateTable.Location = new Point(742, 285);
            btnGenerateTable.Name = "btnGenerateTable";
            btnGenerateTable.Size = new Size(94, 48);
            btnGenerateTable.TabIndex = 2;
            btnGenerateTable.Text = "Создать таблицы";
            btnGenerateTable.UseVisualStyleBackColor = true;
            btnGenerateTable.Click += btnGenerateTable_Click_1;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(352, 47);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(384, 231);
            dataGridView.TabIndex = 3;
            
            // 
            // dataGridViewComparison
            // 
            dataGridViewComparison.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComparison.Location = new Point(352, 335);
            dataGridViewComparison.Name = "dataGridViewComparison";
            dataGridViewComparison.RowHeadersWidth = 51;
            dataGridViewComparison.Size = new Size(393, 243);
            dataGridViewComparison.TabIndex = 6;
            
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(388, 4);
            label3.Name = "label3";
            label3.Size = new Size(321, 40);
            label3.TabIndex = 7;
            label3.Text = "Значение критериев для альтернатив в виде\r\n              оценки по шкале Саате\r\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(388, 299);
            label4.Name = "label4";
            label4.Size = new Size(303, 20);
            label4.TabIndex = 8;
            label4.Text = "Матрица попарных сравнений критериев";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(825, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(389, 231);
            dataGridView1.TabIndex = 9;
            
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(858, 4);
            label5.Name = "label5";
            label5.Size = new Size(325, 40);
            label5.TabIndex = 10;
            label5.Text = "Значение критериев для альтернатив в виде \r\n                    словесного описания";
            // 
            // button1
            // 
            button1.Location = new Point(76, 217);
            button1.Name = "button1";
            button1.Size = new Size(80, 61);
            button1.TabIndex = 11;
            button1.Text = " Ввод\r\nданных";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 631);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridViewComparison);
            Controls.Add(dataGridView);
            Controls.Add(btnGenerateTable);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComparison).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnGenerateTable;
        private DataGridView dataGridView;
        private DataGridView dataGridViewComparison;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
        private Label label5;
        private Button button1;
    }
}