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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace password_lab
{
    public partial class Form_Change_Pass : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=1111;database=pasWORD");
        public Form_Change_Pass()
        {
            InitializeComponent();

        }

        private void button_ChangePass_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM users WHERE login =@login AND email =@pass  ";
           // string query2 = "Updat  ";
            
            string login = textBox1.Text;
            string email = textBox_OldPass.Text;


            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@login",login);
            cmd.Parameters.AddWithValue("@pass",email);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (textBox_NewPass.Text ==textBox_CopyNewPass.Text ) 
                {
                    int id = Convert.ToInt32(dt.Rows[0]["id_u"]);
                    string newPASS = textBox_NewPass.Text;

                    string query2 = "Update users set pass = @NewPass where id_u=@ID ";

                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    cmd2.Parameters.AddWithValue("@NewPass",newPASS);
                    cmd2.Parameters.AddWithValue("@ID",id);

                    MySqlDataAdapter ad = new MySqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    ad.Fill(dt2);
                    MessageBox.Show("Поменяли пароль"); 
                }
                else if(textBox_NewPass.Text =="" && textBox_CopyNewPass.Text =="") 
                {
                    MessageBox.Show("Пусто"); 
                }
                else
                {
                    MessageBox.Show("пароли не совпадают"); 
                }

            }
            else if (textBox_OldPass.Text == "" && textBox1.Text =="") 
            {
                MessageBox.Show("Пусто"); 
            }
            else 
            {
                MessageBox.Show("Не верный логин или пароль");    
            }
            conn.Close();
        }
    }
}
