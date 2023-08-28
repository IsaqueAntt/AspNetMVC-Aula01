using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace AspNetMVC_Aula01.Models
{
    public class Conexao : IDisposable
    {
        //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;

        public MySqlConnection conn;
        private readonly string _server = "localhost";
        private readonly string _port = "3306";
        private readonly string _database = "bd_aula";
        private readonly string _uid = "root";
        private readonly string _pwd = "cursoads";

        public Conexao()
        {
            Conectar();
        }
        private void Conectar()
        {
            string _strConn = "server=" + _server;
            _strConn += "; Port=" + _port;
            _strConn += "; Database=" + _database;
            _strConn += "; Uid=" + _uid;
            _strConn += "; Pwd=" + _pwd;

            conn = new MySqlConnection(_strConn);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}