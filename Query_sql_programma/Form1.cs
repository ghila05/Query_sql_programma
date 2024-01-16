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
using Org.BouncyCastle.Asn1.X509;
using System.Diagnostics.Metrics;

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
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                dataGridView1.DataSource = Query("SELECT nome, Fornitori, Prezzo FROM oggetti;");
                dataGridView2.DataSource = Query("select * from scaffali;");
                dataGridView3.DataSource = Query("SELECT nome, altezza, larghezza, peso, rif_scaffale, Fornitori, Prezzo, categoria FROM oggetti JOIN scaffali ON rif_scaffale = scaffali.id;");
            }
            catch
            {
                throw new Exception("Connessione persa");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)// scaffali 
        {

            //string selected = comboBox1.SelectedItem.ToString();

            switch(comboBox1.SelectedIndex)
            {
                case 0: // Ordina in modo crescente l'id
                    dataGridView2.DataSource = Query("SELECT * FROM scaffali ORDER BY scaffali.id ASC");
                    break;
                case 1: // Ordina in modo decrescente l'id 

                    dataGridView2.DataSource = Query("SELECT * FROM scaffali ORDER BY scaffali.id DESC");
                    break; 
                case 2: // Ordina categorie in modo Alfabetico
                    dataGridView2.DataSource = Query("SELECT * FROM scaffali ORDER BY scaffali.categoria ASC");
                    break;

                case 3: // Ordina cateforie secondo l'inserimento nel database
                    dataGridView2.DataSource = Query("select * from scaffali;");
                    break;
            }
        }
        private DataTable Query(string query)
        {
            try
            {
                String ConnectionString = "server=127.0.0.1;uid=Nicola;pwd=12345;database=magazzino";
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();

                String sql1 = query;
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd1;
                DataTable dati = new DataTable();
                MyAdapter.Fill(dati);

                conn.Close();

                return dati;
            }
            catch { throw new Exception("Connessione persa"); }
        }
        public static string[] QueryToStringArray(DataTable dt) //da query ad array di stringhe
        {
            string[] str = new string[dt.Rows.Count];
            int indice = 0;
            foreach (DataRow row in dt.Rows)
            {
                str[indice] = string.Join(" ", row.ItemArray);
                indice++;
            }

            return str;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // double click per vedere più info
        {
            dataGridView1.DataSource = Query("SELECT * FROM oggetti;");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // oggetti 
        {
            string selected = comboBox2.SelectedItem.ToString();

            switch(comboBox2.SelectedIndex)
            {
                case 0: // prezzo crescente
                    dataGridView1.DataSource = Query("SELECT nome, Fornitori, Prezzo FROM oggetti ORDER BY Prezzo ASC;");
                    break;

                case 1: // prezzo decrescente
                    dataGridView1.DataSource = Query("SELECT nome, Fornitori, Prezzo FROM oggetti ORDER BY Prezzo DESC;");
                    break;

                case 2: // riempi combobox fornitori
                    comboBox3_oggetti_fornitori.Visible = true;
                    comboBox3_oggetti_fornitori.Items.Clear();
                    comboBox3_oggetti_fornitori.Items.AddRange(QueryToStringArray(Query("SELECT Fornitori FROM oggetti;")).Distinct().ToArray());
                    break;
            }
        }
        private void comboBox3_oggetti_fornitori_SelectedIndexChanged(object sender, EventArgs e) //filtra secondo il fornitore scelto
        {
            string selected = comboBox3_oggetti_fornitori.SelectedItem.ToString();
            dataGridView1.DataSource = Query($"SELECT nome, Fornitori, Prezzo FROM oggetti WHERE Fornitori = \"{selected}\";");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
