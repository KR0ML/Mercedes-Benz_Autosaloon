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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            DB db = new DB();

            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `cars`", db.getConnection());

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
            }

            reader.Close();

            db.closeConnection();

            foreach (string[] s in data)
            {
                //dataGridViewMySql.Rows.Add(s);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewMySql_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void buttonAClass_Click(object sender, EventArgs e)
        {
            A_Class a_Class = new A_Class();
            this.Hide();
            a_Class.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void buttonSClass_Click(object sender, EventArgs e)
        {
            S_Class s_Class = new S_Class();
            this.Hide();
            s_Class.Show();
        }

        private void buttonGClass_Click(object sender, EventArgs e)
        {
            G_Class g_Class = new G_Class();
            this.Hide();
            g_Class.Show();
        }

        private void buttonMaybachSClass_Click(object sender, EventArgs e)
        {
            Maybach maybach = new Maybach();
            this.Hide();
            maybach.Show();
        }
    }
}
