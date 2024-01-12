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
using System.IO;

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
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // connessione 

            try
            {
                String ConnectionString = "server=127.0.0.1;uid=Nicola;pwd=12345;database=magazzino";
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();

                String sql1 = "select * from oggetti;";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd1;
                DataTable dati = new DataTable();
                MyAdapter.Fill(dati);

                String sql2 = "select * from scaffali;";
                cmd1 = new MySqlCommand(sql2, conn);
                cmd1.ExecuteNonQuery();
                MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd1;
                DataTable dati2 = new DataTable();
                MyAdapter.Fill(dati2);

                dataGridView1.DataSource = dati;
                dataGridView2.DataSource = dati2;
                conn.Close();
            }catch
            {
                throw new Exception("Connessione persa");
            }




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // applica filtri scaffali
        {
            string filtri = comboBox1.SelectedItem.ToString();
            if(filtri == "id")
            {
                string ordine  = comboBox_id_scaff.SelectedItem.ToString();
                if (ordine == "crescente")
                {
                    String ConnectionString = "server=127.0.0.1;uid=Nicola;pwd=12345;database=magazzino";
                    MySqlConnection conn = new MySqlConnection(ConnectionString);
                    conn.Open();

                    String sql1 = "SELECT * FROM scaffali ORDER BY scaffali.id ASC";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = cmd1;
                    DataTable dati = new DataTable();
                    MyAdapter.Fill(dati);
                    dataGridView2.DataSource = dati;
                }
                else if (ordine == "decrescente")
                {
                    String ConnectionString = "server=127.0.0.1;uid=Nicola;pwd=12345;database=magazzino";
                    MySqlConnection conn = new MySqlConnection(ConnectionString);
                    conn.Open();

                    String sql1 = "SELECT * FROM scaffali ORDER BY scaffali.id DESC";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = cmd1;
                    DataTable dati = new DataTable();
                    MyAdapter.Fill(dati);
                    dataGridView2.DataSource = dati;
                }
                else throw new Exception("seleziona filtri");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selected = comboBox1.SelectedItem.ToString();

            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    if(selected == "id")
                    {
                        comboBox_id_scaff.Visible = true;
                    }
                    break;
                case 1:
                    if(selected == "categoria")
                    {

                    }
                    break;

            }
        }


    }
}
