using BanconChinautla.DbConnection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BanconChinautla.Repository
{
    public class BancoRepository : IBancoRepository
    {
        //Template de un Data Source para el connection string
        //<hostname or IP address>:<listener port>/<database service name>
        //ConnectionString completo de ejemplo: User Id=hr;Password=<password>;Data Source=localhost:1521/orcl

        const string connectionString = "ORACLE connectionString here";
        private OracleConnection _conexion;

        public BancoRepository()
        {
            
        }

        public bool CrearCuenta()
        {
            var queryString = "";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

            //Retornar si fue exitoso o no... si se desea mensaje de excepción, retornar un string
            return true;
        }

        public bool login(int username, string password)
        {
            return true;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                OracleCommand command = new OracleCommand("FN_Login", connection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("returnVal", OracleDbType.Int32, 1000);
                command.Parameters["returnVal"].Direction = ParameterDirection.ReturnValue;

                command.Parameters.Add("P_COD_USUARIO", OracleDbType.Int32);
                command.Parameters["P_COD_USUARIO"].Value = username;

                command.Parameters.Add("P_PASSWORD", OracleDbType.Varchar2);
                command.Parameters["P_PASSWORD"].Value = password;

                command.ExecuteNonQuery();
                int bval = int.Parse(command.Parameters["returnVal"].Value.ToString());
                return bval>0;
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
