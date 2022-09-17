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

namespace Kursovaya
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //
            // ПОЛУЧАЕМ ДАННЫЕ ОТ ПОЛЬЗОВАТЕЛЯ
            //
            String login = textBoxLogin.Text;
            String password = textBoxPassword.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //
            // КОМАНДА ВЫПОЛНЯЕТСЯ ПО ОТНОШЕНИЮ К БАЗЕ ДАННЫХ
            //
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @un and `password`= @up", db.getConnection());

            //
            // ВМЕСТО ЗАГЛУШЕК УКАЗЫВАЮТСЯ ПЕРЕМЕННЫЕ
            //
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            //
            // ПОУЛЧЕННЫЕ ДАННЫЕ ПОМЕЩАЕМ В TABLE
            //
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                MessageBox.Show("Добро пожаловать!");
                Main main = new Main();
                main.Show();
            }

            else
                MessageBox.Show("Где-то допущена ошибка!");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
