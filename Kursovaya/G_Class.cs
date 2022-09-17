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
    public partial class G_Class : Form
    {
        public G_Class()
        {
            InitializeComponent();

            DB db = new DB();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `g-class`", db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[10]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }

            reader.Close();

            db.closeConnection();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void buttonDoDelete_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `g-class`", db.getConnection());
            command.Parameters.Add("Nid", MySqlDbType.VarChar).Value = id;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM `g-class` WHERE `g-class`.`id` = @Nid", db.getConnection());
                command1.Parameters.Add("Nid", MySqlDbType.VarChar).Value = id;
                adapter1.SelectCommand = command1;
                adapter1.Fill(table);

                MessageBox.Show("Машина под номером " + id + " удалена");
            }
            else
            {
                MessageBox.Show(table.Rows.Count + "");
                MessageBox.Show("Такой машины нет в базе!");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Close();
            main.Show();
        }

        private void G_Class_Load(object sender, EventArgs e)
        {
            panelDelete.Hide();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (panelDelete.Visible == true)
            {
                panelDelete.Hide();
            }
            else
                panelDelete.Show();
        }
    }
}
