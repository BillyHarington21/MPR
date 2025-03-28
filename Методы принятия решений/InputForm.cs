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
    public partial class InputForm: Form
    {
        public int CriteriaCount { get; private set; }
        public int AlternativesCount { get; private set; }

        public InputForm()
        {
            this.Text = "Введите данные";
            this.Size = new System.Drawing.Size(300, 180);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblCriteria = new Label() { Text = "Критерии (2-10):", Left = 10, Top = 20 };
            textBox2 = new TextBox() { Left = 150, Top = 20, Width = 100 };

            Label lblAlternatives = new Label() { Text = "Альтернативы (2-10):", Left = 10, Top = 50 };
            textBox1 = new TextBox() { Left = 150, Top = 50, Width = 100 };

            button1 = new Button() { Text = "OK", Left = 40, Width = 80, Top = 100 };
            button1.Click += BtnOK_Click;

            button2 = new Button() { Text = "Отмена", Left = 150, Width = 80, Top = 100 };
            button2.Click += (sender, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(lblCriteria);
            this.Controls.Add(textBox2);
            this.Controls.Add(lblAlternatives);
            this.Controls.Add(textBox1);
            this.Controls.Add(button1);
            this.Controls.Add(button2);
        }    



        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int criteria) && criteria >= 2 && criteria <= 10 &&
                int.TryParse(textBox1.Text, out int alternatives) && alternatives >= 2 && alternatives <= 10)
            {
                CriteriaCount = criteria;
                AlternativesCount = alternatives;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите числа от 2 до 10!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
