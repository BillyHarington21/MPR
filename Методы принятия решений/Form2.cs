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
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGenerateTable_Click_1(object sender, EventArgs e)
        {
            int criteriaCount, alternativesCount;

            // Проверяем ввод
            if (!int.TryParse(txtCriteria.Text, out criteriaCount) || criteriaCount < 2 || criteriaCount > 10)
            {
                MessageBox.Show("Введите количество критериев от 2 до 10.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAlternatives.Text, out alternativesCount) || alternativesCount < 2 || alternativesCount > 10)
            {
                MessageBox.Show("Введите количество альтернатив от 2 до 10.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (double.TryParse(dataGridViewComparison.Rows[rowIdx].Cells[colIdx].Value?.ToString(), out double value) && value > 0)
                    {
                        //НЕ ЗАБЫВАЕМ ЧТО ЗДЕСЬ СОЗДАЕМ СТРОКУ, А ЧИСЛОВОЕ ЗНАЧЕНИЕ !!!!
                        dataGridViewComparison.Rows[colIdx - 1].Cells[rowIdx + 1].Value = $"1/{value}";
                    }
                    else
                    {
                        dataGridViewComparison.Rows[rowIdx].Cells[colIdx].Value = "";
                        MessageBox.Show("Введите корректное положительное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
