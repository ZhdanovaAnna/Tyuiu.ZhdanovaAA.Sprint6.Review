using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tyuiu.ZhdanovaAA.Sprint6.TaskReview.V19.Lib;

namespace Tyuiu.ZhdanovaAA.Sprint6.TaskReview.V19
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDone_ZAA_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxColumns_ZAA.Text, out int rows) && int.TryParse(textBoxColumns_ZAA.Text, out int columns))
            {
                dataGridViewMatrix_ZAA.Columns.Clear();
                dataGridViewMatrix_ZAA.RowCount = rows;
                dataGridViewMatrix_ZAA.ColumnCount = columns;

                int[,] array = new int[rows, columns];
                Random random = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        array[i, j] = random.Next(Convert.ToInt32(textBoxStart_ZAA.Text), Convert.ToInt32(textBoxStop_ZAA.Text) + 1);
                        dataGridViewMatrix_ZAA.Rows[j].Cells[i].Value = array[i, j];
                        if (i > 2)
                        {
                            array[i, j] = array[i - 3, j] + (array[i - 3, j] - array[i - 2, j]);
                            dataGridViewMatrix_ZAA.Rows[j].Cells[i].Value = array[i, j];
                        }
                        dataGridViewMatrix_ZAA.Columns[i].Width = 45;
                        dataGridViewMatrix_ZAA.Rows[i].Height = 45;
                        array[i, j] = Convert.ToInt32(dataGridViewMatrix_ZAA.Rows[i].Cells[j].Value);
                    }
                }
                DataService ds = new DataService();
                try
                {
                    textBoxResult_ZAA.Text = Convert.ToString(ds.GetMatrix(array, Convert.ToInt32(textBoxStart_ZAA.Text),
                        Convert.ToInt32(textBoxStop_ZAA.Text), Convert.ToInt32(textBoxNumStr_ZAA.Text), Convert.ToInt32(textBoxFirstK_ZAA.Text),
                        Convert.ToInt32(textBoxSecondL_ZAA.Text)));
                }
                catch
                {
                    MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInfo_ZAA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ТаскReview выполнил студент группы ПКТб-23-1 Жданова Анна Александровна", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
