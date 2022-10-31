using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Armstrong.WinServer
{
    public partial class ChannelStateReport : Form
    {
        public ChannelStateReport()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null,
                dataGridView1,
                new object[] { true });
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckResult_Shown(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                // Отключили сортировку_по_клику_на_хедер колонок в таблице
                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

                dataGridView1.Columns[3].HeaderText = "C/з от источника";
                dataGridView1.Columns[3].MinimumWidth = 120;
                dataGridView1.Columns[3].Width = 130;
                dataGridView1.Columns[3].DefaultCellStyle.Format = "E3";

                dataGridView1.Columns[4].HeaderText = "Значение выч. фон";
                dataGridView1.Columns[4].MinimumWidth = 120;
                dataGridView1.Columns[4].Width = 130;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "E3";

                dataGridView1.Columns[5].HeaderText = "Результат";
                dataGridView1.Columns[5].MinimumWidth = 120;
                dataGridView1.Columns[5].Width = 130;
            });

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[1].Value) == true)
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = ColorTranslator.FromHtml("#58ACFA");
                else
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = ColorTranslator.FromHtml("#B40404");

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value) == true)
                    dataGridView1.Rows[i].Cells[2].Style.ForeColor = ColorTranslator.FromHtml("#58ACFA");
                else
                    dataGridView1.Rows[i].Cells[2].Style.ForeColor = ColorTranslator.FromHtml("#B40404");
            }
        }
    }
}