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

namespace example
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();

            namebox.Text = "Введите имя";
            namebox.ForeColor = Color.Gray;

            surnamebox.Text = "Введите фамилию";
            surnamebox.ForeColor = Color.Gray;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }
        Point lastpoint;
        private void RegForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Blue;
        }

        private void namebox_Enter(object sender, EventArgs e)
        {
            if (namebox.Text == "Введите имя")
            {
                namebox.Text = " ";
               
            }
        }

        private void surnamebox_Enter(object sender, EventArgs e)
        {
            if (surnamebox.Text == "Введите фамилию")
            {
                surnamebox.Text = " ";
               
            }
        }

        private void namebox_Leave(object sender, EventArgs e)
        {
            if (namebox.Text == " ")
            {
                namebox.Text = "Введите имя";
            }
        }

        private void surnamebox_Leave(object sender, EventArgs e)
        {
            if (surnamebox.Text == " ")
            {
                surnamebox.Text = "Введите фамилию";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (namebox.Text == "Введите имя" || namebox.Text == " " || surnamebox.Text == " " || surnamebox.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите данные!");
                return;
            }

            if (checkName())
                return;
            
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `surname`) VALUES (@login, @pass, @name, @surname);", db.getConnection());
            command.Parameters.Add ("@login", MySqlDbType.VarChar).Value = rfLogin.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = rfPass.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = namebox.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnamebox.Text;

            db.openCon();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт зарегестрирован");
            else MessageBox.Show("Ошибка.Аккаунт не зарегестрирован");

            db.closeCon();
        }
        public Boolean checkName()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @ul ", db.getConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = rfLogin.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой пользователь существует");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
