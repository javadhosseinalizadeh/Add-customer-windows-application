using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace ADD_CUSTOMER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public bool flag=false;
        public int id;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                customer c = new customer();
                c.name = guna2TextBox1.Text;
                c.family = guna2TextBox2.Text;
                c.customer_id = guna2TextBox3.Text;
                c.product_name=guna2TextBox4.Text;
                c.product_model=guna2TextBox5.Text;
                c.description=guna2TextBox6.Text;
                c = c.read(c);
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = c.read();
            }
            else
            {
                customer c = new customer();
                c.name = guna2TextBox1.Text;
                c.family = guna2TextBox2.Text;
                c.customer_id = guna2TextBox3.Text;
                c.update(id, c);
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.DataSource = c.read();
                guna2Button1.Text = "ثبت شد";
                flag = false;
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            customer c = new customer();
            c = c.read(id);
            c.name = guna2TextBox1.Text;
            c.family = guna2TextBox2.Text;
            c.customer_id = guna2TextBox3.Text;
            c.product_name = guna2TextBox4.Text;
            c.product_model = guna2TextBox5.Text;
            c.description = guna2TextBox6.Text;
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.delete(id);
            guna2DataGridView1.DataSource=null;
            guna2DataGridView1.DataSource = c.read();
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            customer c = new customer();
            guna2DataGridView1.DataSource = c.read(guna2TextBox7.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
