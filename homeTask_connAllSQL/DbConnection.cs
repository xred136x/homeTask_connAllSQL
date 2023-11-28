using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using Microsoft.Identity.Client;
using System.Data;
using System.Drawing;

namespace homeTask_connAllSQL
{
    
    public abstract class DbConnect
    {
        public DbConnection conn;
        public DbDataAdapter da;
        //public string connectionString = "";
        public string connString { get; set; }
        public abstract DbConnection GetDataSourse();
        public abstract DbDataAdapter DbDataAdapter(string sqltxt);
    }
   
    class connSQLite : DbConnect 
    {
        private SQLiteConnection _conn;
        private SQLiteDataAdapter _dataAdapter;
        public connSQLite (string connstr)
        {
            connString = "DataSource=" + connstr;
            _conn = new SQLiteConnection(connString);
            conn = _conn;
            
        }
        public override DbConnection GetDataSourse()
        {
            _conn = new SQLiteConnection(connString);
            conn = _conn;
            return conn;

        }
        public override DbDataAdapter DbDataAdapter(string sqltxt)
        {
            _dataAdapter = new SQLiteDataAdapter(sqltxt, _conn);
            da = _dataAdapter;
            return _dataAdapter;
        }
    }

    class connMSSQL : DbConnect
    {
        private SqlConnection _conn;
        private SqlDataAdapter _dataAdapter;
        //public string connectionString = "";
        public connMSSQL (string connstr)
        {
            connString = "DataSource=" + connstr;
            _conn = new SqlConnection(connString);
            conn = _conn;
        }
        public override DbConnection GetDataSourse()
        {
            _conn = new SqlConnection(connString);
            conn = _conn;
            return conn;
        }
        public override DbDataAdapter DbDataAdapter(string sqltxt)
        {
            _dataAdapter = new SqlDataAdapter(sqltxt, _conn);
            da = _dataAdapter;
            return _dataAdapter;
        }
    }
}
