using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваяСП
{
    public partial class SotrudForm : Form
    {
        public SotrudForm()
        {
            InitializeComponent();
            titulField.Text = "Введите Название статьи";
            titulField.ForeColor = Color.Gray;

            contentField.Text = "Введите текст статьи";
            contentField.ForeColor = Color.Gray;

            dataField.Text = "Введите дату публикации";
            dataField.ForeColor = Color.Gray;
        }

        private void titulField_Enter_1(object sender, EventArgs e)
        {
            if (titulField.Text == "Введите Название статьи")
            {
                titulField.Text = "";
                titulField.ForeColor = Color.Black;
            }
        }

        private void titulField_Leave(object sender, EventArgs e)
        {
            if (titulField.Text == "")
            {
                titulField.Text = "Введите Название статьи";
                titulField.ForeColor = Color.Gray;
            }
        }

        private void contentField_Enter(object sender, EventArgs e)
        {
            if (contentField.Text == "Введите текст статьи")
            {
                contentField.Text = "";
                contentField.ForeColor = Color.Black;
            }
        }

        private void contentField_Leave(object sender, EventArgs e)
        {
            if (contentField.Text == "")
            {
                contentField.Text = "Введите текст статьи";
                contentField.ForeColor = Color.Gray;
            }
        }

        private void dataField_Enter(object sender, EventArgs e)
        {
            if (dataField.Text == "Введите дату публикации")
            {
                dataField.Text = "";
                dataField.ForeColor = Color.Gray;
            }
        }

        private void dataField_Leave(object sender, EventArgs e)
        {

        }

        private void closeButtonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlavForm GlavForm = new GlavForm();
            GlavForm.Show();
        }

        private void closeButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            closeButtonLogin.ForeColor = Color.Red;
        }

        private void closeButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            closeButtonLogin.ForeColor = Color.White;
        }

        private void titulField_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (titulField.Text == "Введите Название статьи")
            {
                MessageBox.Show("Введите Название статьи");
                return;
            }

            if (contentField.Text == "Введите текст статьи")
            {
                MessageBox.Show("Введите текст статьи");
                return;
            }

            if (dataField.Text == "Введите дату публикации")
            {
                MessageBox.Show("Введите дату публикации");
                return;
            }

            if (isUserExist())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `combined_table` (`id`, `title`, `content`, `puplished_date`, `views`) VALUES (NULL, @title, @content, @puplish, NULL)", db.getConnection());

            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = titulField.Text;
            command.Parameters.Add("@contetnt", MySqlDbType.VarChar).Value = contentField.Text;
            command.Parameters.Add("@publish", MySqlDbType.VarChar).Value = dataField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Статья отправлена");
            }
            else
            {
                MessageBox.Show("Статья не отправлена");
            }


            db.closeConnection();
        }

        public Boolean isUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `combined_table` WHERE `title` = @title", db.getConnection()); 
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = titulField.Text; 

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой название уже есть, введите другое");
                return true;
            }
            else
                return false;
        }


    }
}
