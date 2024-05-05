using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваяСП
{
    public partial class RegesterForm : Form
    {
        public RegesterForm()
        {
            InitializeComponent();

            userNameField.Text = "Введите Имя";
            userNameField.ForeColor = Color.Gray;

            userPostField.Text = "Введите Дожность";
            userNameField.ForeColor = Color.Gray;

            emailField.Text = "Введите email";
            emailField.ForeColor = Color.Gray;

        }

        private void closeButtonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.Show();
        }

        private void closeButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            closeButtonLogin.ForeColor = Color.Red;
        }

        private void closeButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            closeButtonLogin.ForeColor = Color.White;
        }

        Point lastPoint;
        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите Имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }

        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите Имя";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void userPostField_Enter(object sender, EventArgs e)
        {
            if (userPostField.Text == "Введите Дожность")
            {
                userPostField.Text = "";
                userPostField.ForeColor = Color.Black;
            }
   
            
        }

        private void userPostField_Leave(object sender, EventArgs e)
        {
            if (userPostField.Text == "")
            {
                userPostField.Text = "Введите Дожность";
                userPostField.ForeColor = Color.Gray;
            }

        }

        private void emailField_Enter(object sender, EventArgs e)
        {
            if (emailField.Text == "Введите email")
            {
                emailField.Text = "";
                emailField.ForeColor = Color.Black;
            }

        }

        private void emailField_Leave(object sender, EventArgs e)
        {
            if (emailField.Text == "")
            {
                emailField.Text = "Введите email";
                emailField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegester_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите Имя")
            {
                MessageBox.Show("Введите Имя");
                return;
            }

            if (userPostField.Text == "Введите Должность")
            {
                MessageBox.Show("Введите Должность");
                return;
            }

            if (isUserExist())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `name`, `position`, `email`, `password`) VALUES (NULL, @name, @position, @email, @password)", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@position", MySqlDbType.VarChar).Value = userPostField.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailField.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passwordField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }


            db.closeConnection();
        }

        public Boolean isUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @uE", db.getConnection());
            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = emailField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой email уже есть, введите другой");
                return true;
            }
            else
                return false;
        }
    }
}
