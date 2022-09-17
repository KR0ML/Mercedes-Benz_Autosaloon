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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (checkUser())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`) VALUES (@login, @password);", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBoxLogin.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                if (textBoxLogin.Text == "")
                {
                    MessageBox.Show("Введите логин!");
                    return;
                }

                if (textBoxPassword.Text == "")
                {
                    MessageBox.Show("Введите пароль!");
                    return;
                }

                DialogResult result = MessageBox.Show("Аккаунт был успешно создан! \nПожалуйста, авторизируйтесь", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Login login = new Login();
                    this.Close();
                    login.Show();
                }
                else
                    MessageBox.Show("При создании аккаунта произошла ошибка!");
                db.closeConnection();
            }
        }

        public Boolean checkUser()
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @un", db.getConnection());

            //
            // ВМЕСТО ЗАГЛУШЕК УКАЗЫВАЮТСЯ ПЕРЕМЕННЫЕ
            //
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = textBoxLogin.Text;

            adapter.SelectCommand = command;

            //
            // ПОУЛЧЕННЫЕ ДАННЫЕ ПОМЕЩАЕМ В TABLE
            //
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким именем уже зарегистрирован!");
                return true;
            }

            else
                return false;
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}