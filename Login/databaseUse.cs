using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login
{
    class databaseUse
    {
        public void connect()
        {
            //Primeiro passo colocar o endereço do banco de dados
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victor.lima\source\repos\Login\Login\DB\DatabaseLogin.mdf;Integrated Security=True;Connect Timeout=30";
            //Criando o objeto da conexao
            SqlConnection cn = new SqlConnection(connection);
            //abrindo a conexao com o banco de dados
            cn.Open();
            //verificando se a conexao foi aberta
            MessageBox.Show("Connection Open");

            //Defububdi variaveus
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, Output = "";




            //fechando a conexao
            cn.Close();
            //verificando se a conexao foi fechada
            MessageBox.Show("Connection Close");

            //string query = "SELECT loginID"
        }
    }
}



//Para estudo
//https://www.guru99.com/c-sharp-access-database.html
