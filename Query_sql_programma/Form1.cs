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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Query_sql_programma
{
    public partial class Database_film : Form
    {
        public Database_film()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabControl1.SelectedIndex = 2;
            /*
            
            // impostazioni datagridview 
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;



            // connessione 
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
            */


        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // connessione 
            String ConnectionString = "server=127.0.0.1;uid=Nicola;pwd=12345;database=film";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();


            String sql1 = "select * from sale;";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            String sql2 = "select * from cinema;";
            cmd1 = new MySqlCommand(sql2, conn);
            cmd1.ExecuteNonQuery();
            MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati2 = new DataTable();
            MyAdapter.Fill(dati2);

            dataGridView1.DataSource = dati;
            dataGridView2.DataSource = dati2;
            conn.Close();
        }
    }
}
