using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace Query_sql_programma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=Nicola;pwd=12345;database=film";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();


            String sql1 = "select * from ifilm;";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);
            dataGridView1.DataSource = dati;
            conn.Close();



        }

    }
}
