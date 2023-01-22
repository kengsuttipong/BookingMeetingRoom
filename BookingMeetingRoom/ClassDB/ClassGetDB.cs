using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BookingMeetingRoom.ClassDB
{
    public class ClassGetDB
    {
        
        public async Task<DataTable> GetSqlRecord(string sprocName, IConfiguration _configuration, SortedList _param)
        {
            DataTable table = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("BookingMeetingRoomDB")))
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sprocName, sqlConnection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (_param != null)
                {
                    foreach (DictionaryEntry item in _param)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    }
                }

                await Task.Run(() => adapter.Fill(table));

                sqlConnection.Close();
            }

            return table;
        }

        public async Task<Int64> InsertUpdateRecord(string sprocName, IConfiguration _configuration, SortedList _param)
        {
            Int64 _result = -1;

            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BookingMeetingRoomDB")))
                {
                    using (SqlCommand cmd = new SqlCommand(sprocName))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        if (_param.Count > 0)
                        {
                            foreach (DictionaryEntry dPara in _param)
                            {
                                cmd.Parameters.AddWithValue(dPara.Key.ToString(), dPara.Value);
                            }
                        }
                        
                        con.Open();

                        DbParameter myReturnValue = null;
                        myReturnValue = cmd.CreateParameter();
                        myReturnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(myReturnValue);

                        await Task.Run(() => cmd.ExecuteNonQuery());
                        _result = Convert.ToInt64(myReturnValue.Value);

                        con.Close();
                    }
                }

                return _result;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return -1;
            }
        }
    }
}
