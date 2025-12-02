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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace password_lab
{
    public partial class Form2 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=1111;database=pasWORD");
        public Form2()
        {
            InitializeComponent();
            shema();
        }

        private void shema() 
        {
             conn.Open();
            

            string query = "SELECT * FROM users";
            MySqlDataAdapter ad = new MySqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);


            dataGridView1.DataSource = dt;

            conn.Close();
        }
    }
}
