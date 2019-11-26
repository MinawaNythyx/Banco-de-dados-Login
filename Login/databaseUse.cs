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
        private string dataFilePath;
        private string ConnectionString
        {
            get { return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dataFilePath + @";Integrated Security=True;Connect Timeout=30"; }
        }
        public databaseUse()
        {
            dataFilePath = Environment.CurrentDirectory + @"\DB\loginData.mdf";
        }
        SqlConnection cn;
        //Definindo variaveis
        SqlCommand command;
        SqlDataReader dataReader;
        private string User, Pass;
        string sql, Output = "";
        int repeatUser;


        //Ler as informações
        public void ReadDB()
        {
            //Criando o objeto da conexao
            cn = new SqlConnection(ConnectionString);
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
            Output = "";

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
            cn = new SqlConnection(ConnectionString);
            SqlCommand command;

            if (name != "")
            {
                sql = "Select loginID,username,password from login";

                command = new SqlCommand(sql, cn);

                cn.Open();

                command.ExecuteNonQuery();

                dataReader = command.ExecuteReader();

                repeatUser = 0;

                while (dataReader.Read())
                {
                    User = dataReader[1].ToString();
                    Pass = dataReader[2].ToString();

                    if (User != name)
                    {
                        repeatUser--;
                    }
                    else
                    {
                        repeatUser = 999999999;
                    }
                }

                if (repeatUser < 0)
                {
                    if (senha != "")
                    {

                        sql = "insert into login(username, password)";
                        sql += "values(@username, @password) ";

                        command = new SqlCommand(sql, cn);

                        command.Parameters.AddWithValue("@username", name);
                        command.Parameters.AddWithValue("@password", senha);

                        try
                        {
                            cn.Open();
                            MessageBox.Show("Connection Open");
                            int rows = command.ExecuteNonQuery();
                            MessageBox.Show("Rows affected: " + rows);
                        }
                        catch (Exception erro)
                        {
                            throw new Exception("Ocorreu um erro de insert " + erro.Message);
                        }
                        finally
                        {
                            command.Dispose();
                            cn.Close();
                            MessageBox.Show("Connection Close");
                        }
                        MessageBox.Show("Worked");
                    }
                    else
                    {
                        MessageBox.Show("O campo SENHA esta vazio");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario ja existe");
                }
                cn.Close();
            }
            else
            {
                MessageBox.Show("O campo USUARIO esta vazio");
            }
        }


        //Verificar as informações
        public void VerifyDB(string uSER, string pASS)
        {
            cn = new SqlConnection(ConnectionString);

            cn.Open();

            sql = "Select loginID,username,password from login";

            command = new SqlCommand(sql, cn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                User = dataReader[1].ToString();
                Pass = dataReader[2].ToString();
                

                if (uSER == User)
                {
                    MessageBox.Show("Usuario igual");   
                    if (pASS == Pass)
                    {
                        Main main = new Main();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario ou senha incorretos");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario ou senha incorretos");
                }
            }
            cn.Close();
        }


        //Deletar as informações
        public void DeleteDB()
        {

        }
    }
}



//Para estudo
//https://www.guru99.com/c-sharp-access-database.html
