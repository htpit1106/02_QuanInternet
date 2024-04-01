using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanInternet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string chuoiketnoi = "Data Source=DESKTOP-GE1C4PK\\SQLEXPRESS;Initial Catalog=QuanInternet;Integrated Security=True";

        void loadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Internet";
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void runcommand(string query)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            loadData();
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red)
            {
                button1.BackColor = Color.Transparent;
                string query = "insert into Internet values ('May 1', '" + giovao_may1.Text + "', '" + giora_may1.Text + "', '" + tongtien_may1.Text + "')";
                runcommand(query);
            }
           
        }

        void checkfomat(string x)
            
        {
            int n;
            if(!int.TryParse(x, out  n))
            {
                MessageBox.Show("Nhap gio chua dung");
                return;

            }
        }

        private void giovao_may1_Leave(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if(bt != null )
            {
                checkfomat(bt.Text);
            }
        }
        int tongtien(int giovao, int giora)
        {
            return (giora - giovao) * 5000;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            loadData();
        }

        private void giora_may1_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                checkfomat(tb.Text);
            }
            
            tongtien_may1.Text = (int.Parse(giora_may1.Text) - int.Parse(giovao_may1.Text)).ToString();

        }

        private void giora__Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                checkfomat(tb.Text);
            }

            tongtien_may2.Text = (int.Parse(giora_may2.Text) - int.Parse(giovao_may2.Text)).ToString();

        }

        private void giora_may3_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                checkfomat(tb.Text);
            }

            tongtien_may3.Text = (int.Parse(giora_may3.Text) - int.Parse(giovao_may3.Text)).ToString();

        }

        private void giora_may4_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                checkfomat(tb.Text);
            }

            tongtien_may4.Text = (int.Parse(giora_may4.Text) - int.Parse(giovao_may4.Text)).ToString();

        }

        private void giora_may5_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                checkfomat(tb.Text);
            }

            tongtien_may5.Text = (int.Parse(giora_may5.Text) - int.Parse(giovao_may5.Text)).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            
            if (bt != null)
            {
                if(bt.BackColor == Color.Red)
                {
                    MessageBox.Show("May dang duoc su dung! Moi chon may khac");
                    return;
                }
                else
                   bt.BackColor = Color.Red;
            }
            
        }
    }
}
