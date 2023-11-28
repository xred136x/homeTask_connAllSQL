using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace homeTask_connAllSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbConnect dbconn;
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string namedb = textBox1.Text;
            string sqltext = $"select * from Склад";
            if (rbSQLite.Checked)
            {                               
                dbconn = new connSQLite(namedb);                
            }

            if (rbMSSQL.Checked)
            {
                dbconn = new connMSSQL(namedb);
            }
            dbconn.GetDataSourse().Open();
            //dbconn.conn.Open();
            //MessageBox.Show("Is Open");
            dbconn.DbDataAdapter(sqltext);
            //SQLiteCommandBuilder cb = new SQLiteCommandBuilder(dbconn.da);
            dbconn.da.SelectCommand = new SQLiteCommand(sqltext, dbconn);//не понимаю, что не так? 
            DataTable dt = new DataTable();
            dbconn.da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbconn.conn.Close();
            
           
            
           

        }
    }
}
