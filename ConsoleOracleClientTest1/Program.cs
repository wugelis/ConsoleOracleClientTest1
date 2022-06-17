using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOracleClientTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnection oraConn = new OracleConnection("Data Source=192.168.137.128:1521/ORCL.MSHOME.NET;User Id=system;Password=GELISpass01;");

            try
            {
                oraConn.Open();

                string SqlStatement = @"SELECT 
	D.USERNAME,
	D.ACCOUNT_STATUS,
	D.DEFAULT_TABLESPACE,
	D.authentication_type,
	D.profile
FROM dba_users D
WHERE 
	
	D.DEFAULT_TABLESPACE='USERS'";
                OracleCommand cmd = new OracleCommand(SqlStatement, oraConn);
                OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                var result = from u in dt.AsEnumerable()
                             select new
                             {
                                 UserName = u["UserName"]?.ToString(),
                                 AccountStatus = u["ACCOUNT_STATUS"]?.ToString(),
                             };



                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    string userName = row["USERNAME"]?.ToString();
                    string accountStatus = row["ACCOUNT_STATUS"]?.ToString();

                    Console.WriteLine($"UserName={userName}");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
            finally
            {
                oraConn.Close();
            }
            Console.WriteLine("New oracle connection is Success!!..");
            Console.ReadLine();
        }
    }
}
