using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;
using ApiFrame.Common;

namespace ApiFrame.DataAccess
{
    public class DS_TimeKeeping
    {
        //public static int LogRequest(NpgsqlConnection conn, SeabReq request)
        //{
        //    try
        //    {
        //        if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
        //        NpgsqlDataReader reader = null;
        //        string cmdText = "INSERT INTO tbl_request (request_msg, command_name, priority, channel, subchannel, location, userid, dn, requestapi, requestnode)";
        //        cmdText += " values (:request_msg, :command_name, :priority, :channel, :subchannel, :location, :userid, :dn, :requestapi, :requestnode)  returning id";
        //        NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);

        //        cmd.Parameters.Add("request_msg", NpgsqlTypes.NpgsqlDbType.Json).Value = Newtonsoft.Json.JsonConvert.SerializeObject(request);
        //        cmd.Parameters.Add("command_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.body.command;
        //        cmd.Parameters.Add("priority", NpgsqlTypes.NpgsqlDbType.Integer).Value = int.Parse(request.header.priority);
        //        cmd.Parameters.Add("channel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.channel;
        //        cmd.Parameters.Add("subchannel", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.subChannel;
        //        cmd.Parameters.Add("location", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.location;
        //        cmd.Parameters.Add("userid", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.userID;
        //        cmd.Parameters.Add("dn", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.dn;
        //        cmd.Parameters.Add("requestapi", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.requestAPI;
        //        cmd.Parameters.Add("requestnode", NpgsqlTypes.NpgsqlDbType.Varchar).Value = request.header.requestNode;

        //        cmd.CommandTimeout = 60;
        //        reader = cmd.ExecuteReader();
        //        reader.Read();
        //        if (reader.HasRows)
        //        {
        //            return int.Parse(reader["id"].ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log file và gửi mail
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (conn.State == System.Data.ConnectionState.Open) conn.Close();
        //    }
        //    return -1;

        //}

        public static void LogResponse(NpgsqlConnection conn, SeabRes response)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //Do chưa làm được transacion và singleton
                string cmdText = "INSERT INTO tbl_response (id, response_msg, res_code, res_desc)";
                cmdText += " values (:id, :response_msg, :res_code, :res_desc)";
                NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);

                cmd.Parameters.Add("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = response.header.requestID;
                cmd.Parameters.Add("response_msg", NpgsqlTypes.NpgsqlDbType.Json).Value = Newtonsoft.Json.JsonConvert.SerializeObject(response);
                cmd.Parameters.Add("res_code", NpgsqlTypes.NpgsqlDbType.Varchar).Value = response.header.res_code;
                cmd.Parameters.Add("res_desc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = response.header.res_desc;

                cmd.CommandTimeout = 60;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Log file và gửi mail
                throw ex;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }

        }

    }
}
