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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace КурсоваяСП
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String emailUser = emailField.Text;
            String passwordUser = passwordField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @uE AND `password` = @uP", db.getConnection());

            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = emailUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passwordUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (emailUser == "dailpriva@mail.ru" && passwordUser == "12345")
            {
                this.Hide();
                RedaktForm redaktForm = new RedaktForm();
                redaktForm.Show();
            }
            else if(table.Rows.Count > 0)
            {

                this.Hide();
                SotrudForm SotrudForm = new SotrudForm();
                SotrudForm.Show();
            }  
            else
                MessageBox.Show("Такого пользователя нет, зарегестрируйтесь");

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

        private void buttonReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegesterForm RegesterForm = new RegesterForm();
            RegesterForm.Show();
        }

        private void buttonReg_MouseEnter(object sender, EventArgs e)
        {
            buttonReg.ForeColor = Color.Blue;
        }

        private void buttonReg_MouseLeave(object sender, EventArgs e)
        {
            buttonReg.ForeColor= Color.Black;
        }
    }
}


