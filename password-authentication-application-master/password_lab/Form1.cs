using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace password_lab
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=1111;database=pasWORD");

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button_login_Click(object sender, EventArgs e)
        {

            
            conn.Open();
            

            string query = "SELECT * FROM users WHERE login =@login AND pass =@pass  ";
            
            string login = textBox_login.Text;
            string pass = textBox1.Text;

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@login",login);
            cmd.Parameters.AddWithValue("@pass",pass);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else if (textBox_login.Text == "" && textBox1.Text =="") 
            {
                MessageBox.Show("Пусто"); 
            }
            else 
            {
                MessageBox.Show("Не верный логин или пароль");    
            }

            conn.Close();


            //Form_Pass FormP = new Form_Pass();
            //FormP.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Change_Pass formCH = new Form_Change_Pass();
            formCH.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Pass form_Pass = new Form_Pass();
            form_Pass.ShowDialog();
        }
    }
}
