using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace password_lab
{
    public partial class Form_Pass : Form
    {
                
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=1111;database=pasWORD");
        public Form_Pass()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
               
            conn.Open();
            

            string query = "select Count(*) from users where login = @login or email = @email";
            
            string login = textBox1.Text;
            string email = textBox2.Text;
            string pass = textBox3.Text;

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@email", email);
    

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            int col = Convert.ToInt32(dt.Rows[0]["Count(*)"]);
            if (dt.Rows.Count > 0 && col>0 )
            {
                 MessageBox.Show("логин или почта заняты"); 
            }
            else if (textBox1.Text == "" && textBox2.Text =="" && textBox3.Text =="") 
            {
                MessageBox.Show("Пусто"); 
            }
            else 
            {
                string upd = "Insert Into users(login,pass,email) values (@login,@email,@pass)";
                
                MySqlCommand cmdup = new MySqlCommand (upd,conn);

                cmdup.Parameters.AddWithValue("@login",login);
                cmdup.Parameters.AddWithValue("@email",email);
                cmdup.Parameters.AddWithValue("@pass",pass);
                
                cmdup.ExecuteNonQuery();

                MessageBox.Show("добавлен!"); 
            }

            conn.Close();
        }
    }
}
