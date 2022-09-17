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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
            DB db = new DB();

            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `a-class`", db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }

            reader.Close();

            db.closeConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM 'a-class' WHERE 'id' = @nId", db.getConnection());
            command.Parameters.Add("@nId", MySqlDbType.VarChar).Value = id;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM 'a-class' WHERE 'id' = @nId", db.getConnection());
                command1.Parameters.Add("@nId", MySqlDbType.VarChar).Value = id;
                adapter1.SelectCommand = command1;
                adapter1.Fill(table);

                MessageBox.Show("Машина под номером " + id + " удалена");

                Main main = new Main();
                main.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Такой машины нет в базе!");
            }
        }
    }
}
