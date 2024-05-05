using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace КурсоваяСП
{
    public partial class RedaktForm : Form
    {
        private readonly DB db = new DB();

        public RedaktForm()
        {
            InitializeComponent();
            LoadDataFromMySQL();
        }

        private void LoadDataFromMySQL()
        {
            try
            {
                string query = "SELECT * FROM combined_table";
                MySqlCommand command = new MySqlCommand(query, db.getConnection());

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;

                    // Устанавливаем свойства для растягивания ячеек по содержимому
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных из базы данных: " + ex.Message);
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        private void buttonRegS_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegesterForm RegesterForm = new RegesterForm();
            RegesterForm.Show();
        }

        private void buttonRegS_MouseEnter(object sender, EventArgs e)
        {
            buttonRegS.ForeColor = Color.Blue;
        }

        private void buttonRegS_MouseLeave(object sender, EventArgs e)
        {
            buttonRegS.ForeColor = Color.White;
        }

        
    }

}

