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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Password.AutoSize = false;
            this.Password.Size = new Size(this.Password.Size.Width, 73);
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void closebut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void closebut_MouseEnter(object sender, EventArgs e)
        {
            closebut.ForeColor = Color.Red;
        }

        private void closebut_MouseLeave(object sender, EventArgs e)
        {
            closebut.ForeColor = Color.Blue;
        }
        Point lastpoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Point pi;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - pi.X;
                this.Top += e.Y - pi.Y;
            }
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
        }
        Point ip;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - ip.X;
                this.Top += e.Y - ip.Y;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ip = new Point(e.X, e.Y);
        }
        Point lol;
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lol.X;
                this.Top += e.Y - lol.Y;
            }
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lol = new Point(e.X, e.Y);
        }

        private void butLog_Click(object sender, EventArgs e)
        {
            String LoginUser = LoginField.Text;
            String PassUser = Password.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @ul AND `password` = @up", db.getConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = PassUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                MessageBox.Show("Yes");
            else 
                MessageBox.Show("No");
        }
    }
}
