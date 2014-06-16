using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot
{
    public static class DBInit
    {
        private const string DB_CONN = "data source=.\\SQLEXPRESS;initial catalog=FistBot;integrated security=SSPI;User ID=fistbot;Password=jebise;";

        public static int InitFromDb(this BotBase bot)
        {
            DataTable tablica = PostSql_ReturnDataSet("exec [dbo].[TakeNextStrategy]").Tables[0];
            int id = (int)tablica.Rows[0][0];
            bot.DeserializeStrategies(tablica.Rows[0][1].ToString());
            return id;
        }

        public static int InitFromDb(this BotBase bot, int id)
        {
            DataTable tablica = PostSql_ReturnDataSet("exec [dbo].[TakeStrategy] " + id.ToString()).Tables[0];
            bot.DeserializeStrategies(tablica.Rows[0][1].ToString());
            return id;
        }

        private static DataSet PostSql_ReturnDataSet(string sqlString)
        {
            DataSet DS = new DataSet();

            SqlConnection conn = new SqlConnection(DB_CONN);
            SqlDataAdapter myDA = new SqlDataAdapter(sqlString, conn);
            try
            {
                myDA.Fill(DS);
            }
            catch (Exception er)
            {
                throw new Exception("PostSQL_ReturnDataSet - Error in: " + sqlString, er);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                conn = null;
                myDA = null;
            }
            return DS;
        }
    }
}