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
        //Primeiro passo colocar o endereço do banco de dados
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\victor.etlima\source\repos\MinawaNythyx\Banco-de-dados-Login\Login\DB\loginData.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection cn;
        //Definindo variaveis
        SqlCommand command;
        SqlDataReader dataReader;
        string sql, Output = "";



        //Ler as informações
        public void ReadDB()
        {
            //Criando o objeto da conexao
            cn = new SqlConnection(connection);
            //abrindo a conexao com o banco de dados
            cn.Open();
            //verificando se a conexao foi aberta
            MessageBox.Show("Connection Open");

            sql = "Select loginID,username,password from login";

            command = new SqlCommand(sql, cn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            MessageBox.Show(Output);

            dataReader.Close();
            command.Dispose();
            //fechando a conexao
            cn.Close();
            //verificando se a conexao foi fechada
            MessageBox.Show("Connection Close");
        }


        //Inserir as informações
        public void InsertDB(string name, string senha)
        {
            cn = new SqlConnection(connection);
            cn.Open();
            MessageBox.Show("Connection Open");
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "Insert into login (username,password) values('" + name + "',"+ senha +")";

            command = new SqlCommand(sql, cn);

            adapter.InsertCommand = new SqlCommand(sql, cn);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cn.Close();
            MessageBox.Show("Connection Close");
        }


        //Atualizar as informações
        public void UpdateDB()
        {

        }


        //Deletar as informações
        public void DeleteDB()
        {

        }
    }
}



//Para estudo
//https://www.guru99.com/c-sharp-access-database.html
