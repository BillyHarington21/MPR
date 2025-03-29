using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Методы_принятия_решений
{
    public partial class Form2 : Form
    {
        private int criteriaCount;
        private int alternativesCount;



        public Form2()
        {
            InitializeComponent();
            Utils.Utils.EnableResizing(dataGridView);
            Utils.Utils.EnableResizing(dataGridView1);
            Utils.Utils.EnableResizing(dataGridViewComparison);           
        }
        public void button1_Click(object sender, EventArgs e)
        {
            using InputForm inputForm = new InputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                criteriaCount = inputForm.CriteriaCount;
                alternativesCount = inputForm.AlternativesCount;

                MessageBox.Show($"Введено {criteriaCount} критериев и {alternativesCount} альтернатив", "Успех");
            }
        }

        private void btnGenerateTable_Click_1(object sender, EventArgs e)
        {

            if (criteriaCount == 0 || alternativesCount == 0)
            {
                MessageBox.Show("Сначала введите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем двумерный массив для хранения данных
            string[,] tableData = new string[criteriaCount + 1, alternativesCount + 1];

            // Запрашиваем названия альтернатив у пользователя
            for (int i = 0; i < alternativesCount; i++)
            {
                tableData[0, i + 1] = Interaction.InputBox($"Введите название для альтернативы {i + 1}:", "Название альтернативы", $"Альтернатива {i + 1}");
            }

            // Запрашиваем названия критериев у пользователя
            for (int i = 0; i < criteriaCount; i++)
            {
                tableData[i + 1, 0] = Interaction.InputBox($"Введите название для критерия {i + 1}:", "Название критерия", $"Критерий {i + 1}");
            }

            // Очищаем таблицы перед заполнением
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Заполняем обе таблицы
            FillDataGridView(dataGridView, tableData, alternativesCount, criteriaCount);
            FillDataGridView(dataGridView1, tableData, alternativesCount, criteriaCount);

            // Передаем критерии в GenerateComparisonMatrix
            GenerateComparisonMatrix(tableData);
        }

                     

        private void GenerateComparisonMatrix(string[,] tableData)
        {
            int criteriaCount = tableData.GetLength(0) - 1; // Количество критериев

            // Очищаем таблицу сравнений
            dataGridViewComparison.Rows.Clear();
            dataGridViewComparison.Columns.Clear();

            dataGridViewComparison.AllowUserToAddRows = false;

            // Добавляем заголовки столбцов
            dataGridViewComparison.Columns.Add("Criteria", ""); // Первый столбец с названиями критериев
            for (int i = 1; i <= criteriaCount; i++)
            {
                dataGridViewComparison.Columns.Add($"C{i}", tableData[i, 0]); // Названия критериев
            }

            // Заполняем таблицу
            for (int i = 1; i <= criteriaCount; i++)
            {
                object[] row = new object[criteriaCount + 1];
                row[0] = tableData[i, 0]; // Название критерия в первом столбце

                for (int j = 1; j <= criteriaCount; j++)
                {
                    if (i == j)
                    {
                        row[j] = 1; // Главная диагональ = 1
                    }
                    else
                    {
                        row[j] = ""; // Оставляем пустым для ввода пользователем
                    }
                }

                dataGridViewComparison.Rows.Add(row);
            }

            // Добавляем обработчик изменения ячеек для симметричного заполнения
            dataGridViewComparison.CellEndEdit += (sender, e) =>
            {
                int rowIdx = e.RowIndex;
                int colIdx = e.ColumnIndex;

                // Проверяем, что редактируется верхняя часть матрицы
                if (rowIdx >= 0 && colIdx > 0 && rowIdx != colIdx)
                {
                    string? inputValue = dataGridViewComparison.Rows[rowIdx].Cells[colIdx].Value?.ToString();

                    if (double.TryParse(inputValue, out double value) && value > 0)
                    {
                        // Если введено обычное число, записываем обратное значение в зеркальную ячейку
                        dataGridViewComparison.Rows[colIdx - 1].Cells[rowIdx + 1].Value = $"1/{value}";
                    }
                    else if (inputValue?.StartsWith("1/") == true && double.TryParse(inputValue.Substring(2), out double fractionValue) && fractionValue > 0)
                    {
                        // Если введена дробь в формате "1/n", записываем её обратное значение (n)
                        dataGridViewComparison.Rows[colIdx - 1].Cells[rowIdx + 1].Value = fractionValue.ToString();
                    }
                    else
                    {
                        dataGridViewComparison.Rows[rowIdx].Cells[colIdx].Value = "";
                        MessageBox.Show("Введите корректное положительное число или дробь в формате 1/n!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            };
        }


        private void FillDataGridView(DataGridView grid, string[,] tableData, int alternativesCount, int criteriaCount)
        {
            // Добавляем столбцы
            grid.Columns.Add("Criteria", ""); // Первый столбец для критериев
            for (int j = 1; j <= alternativesCount; j++)
            {
                grid.Columns.Add($"Alt{j}", tableData[0, j]); // Названия альтернатив
            }

            // Заполняем строки
            for (int i = 1; i <= criteriaCount; i++)
            {
                object[] row = new object[alternativesCount + 1];
                row[0] = tableData[i, 0]; // Название критерия
                grid.Rows.Add(row);
            }
        }
                
    }
}
