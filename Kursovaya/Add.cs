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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string model = textBox1.Text;
            string power = textBox2.Text;
            string max_speed = textBox3.Text;
            string color = textBox4.Text;
            string price = textBox5.Text;

            if (model == "" || power == "" || max_speed == "" || color == "" || price == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {

                //
                // ПРОВЕРКА НА ОТКРЫТОЕ ОКНО
                //

                if (Application.OpenForms["A_Class"] != null)
                {
                    DB db = new DB();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `a-class` (`id`, `model`, `power`, `max_speed`, `color`, `price`) VALUES (NULL, @model, @power, @max_speed, @color, @price)", db.getConnection());

                    command.Parameters.Add("@model", MySqlDbType.VarChar).Value = model;
                    command.Parameters.Add("@power", MySqlDbType.Float).Value = power;
                    command.Parameters.Add("@max_speed", MySqlDbType.Int32).Value = max_speed;
                    command.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
                    command.Parameters.Add("@price", MySqlDbType.Float).Value = price;

                    db.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно добавлены!");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные!");
                    }

                    db.closeConnection();
                }
                else if (Application.OpenForms["S_Class"] != null)
                {
                    DB db = new DB();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `s-class` (`id`, `model`, `power`, `max_speed`, `color`, `price`) VALUES (NULL, @model, @power, @max_speed, @color, @price)", db.getConnection());

                    command.Parameters.Add("@model", MySqlDbType.VarChar).Value = model;
                    command.Parameters.Add("@power", MySqlDbType.Float).Value = power;
                    command.Parameters.Add("@max_speed", MySqlDbType.Int32).Value = max_speed;
                    command.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
                    command.Parameters.Add("@price", MySqlDbType.Float).Value = price;

                    db.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно добавлены!");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные!");
                    }

                    db.closeConnection();
                }
                else if (Application.OpenForms["G_Class"] != null)
                {
                    DB db = new DB();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `g-class` (`id`, `model`, `power`, `max_speed`, `color`, `price`) VALUES (NULL, @model, @power, @max_speed, @color, @price)", db.getConnection());

                    command.Parameters.Add("@model", MySqlDbType.VarChar).Value = model;
                    command.Parameters.Add("@power", MySqlDbType.Float).Value = power;
                    command.Parameters.Add("@max_speed", MySqlDbType.Int32).Value = max_speed;
                    command.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
                    command.Parameters.Add("@price", MySqlDbType.Float).Value = price;

                    db.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно добавлены!");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные!");
                    }

                    db.closeConnection();
                }
                else if (Application.OpenForms["Maybach"] != null)
                {
                    DB db = new DB();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `maybach` (`id`, `model`, `power`, `max_speed`, `color`, `price`) VALUES (NULL, @model, @power, @max_speed, @color, @price)", db.getConnection());

                    command.Parameters.Add("@model", MySqlDbType.VarChar).Value = model;
                    command.Parameters.Add("@power", MySqlDbType.Float).Value = power;
                    command.Parameters.Add("@max_speed", MySqlDbType.Int32).Value = max_speed;
                    command.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
                    command.Parameters.Add("@price", MySqlDbType.Float).Value = price;

                    db.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно добавлены!");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные!");
                    }

                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
