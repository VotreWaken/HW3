using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp28.Models;

namespace WindowsFormsApp28
{
    public partial class Form1 : Form
    {
        static public DataBase Db_ = new DataBase();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Db_.SearchByName(textBox1.Text);
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Db_.SearchByAuthor(textBox1.Text);
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Db_.SearchByCategories(textBox1.Text);
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
        }
    }
}
