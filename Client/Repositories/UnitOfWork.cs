using SignalRDbUpdates.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SignalRDbUpdates.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["CRMSSOEntities"].ConnectionString;
        public UnitOfWork()
        {
        }
        public int SetMessageReceived(string userid)
        {
            var messages = new List<AspNetUsersNot>();
            using (var connection = new SqlConnection(_connString))
            {
                string sql = "UPDATE dbo.AspNetUsersNot SET " +
                             "[StatusID] = 2005, " +
                             "[NotifiedDateTimeUtc] = GETUTCDATE() " +
                            "WHERE StatusID = 2000 " +
                            "AND NotificationDateTimeUtc BETWEEN DATEADD(minute, -111112, GETUTCDATE()) " +
                            "AND dateadd(minute, 111113, GETUTCDATE()) " +
                            "AND UserID in(select id from CRMSSO.dbo.AspNetUsers where StatusID = 31) " +
                            $"AND UserID = CASE WHEN UserID = '{userid}' THEN UserID ELSE '{userid}' END";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Notification = null;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    return command.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<AspNetUsersNot> GetMessagesToNotify(string userid)
        {
            var messages = new List<AspNetUsersNot>();
            using (var connection = new SqlConnection(_connString))
            {
                string sql = "SELECT [UserID], " +
                                "[LeadPlanActivityID], " +
                                "[NotificationDateTimeUtc], " +
                                "[StatusID], " +
                                "[NotifiedDateTimeUtc] " +
                            "FROM dbo.AspNetUsersNot " +
                            "WHERE StatusID = 2000 " +
                            "AND NotificationDateTimeUtc BETWEEN DATEADD(minute, -111112, GETUTCDATE()) " +
                            "AND dateadd(minute, 111113, GETUTCDATE()) " +
                            "AND UserID in(select id from CRMSSO.dbo.AspNetUsers where StatusID = 31) " +
                            $"AND UserID = CASE WHEN UserID = '{userid}' THEN UserID ELSE '{userid}' END " +
                            "ORDER BY NotificationDateTimeUtc";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Notification = null;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item: new AspNetUsersNot
                        {
                            UserID = (string)reader["UserID"],
                            LeadPlanActivityID = Int32.Parse(reader["LeadPlanActivityID"].ToString()),
                            NotificationDateTimeUtc = reader["NotificationDateTimeUtc"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(reader["NotificationDateTimeUtc"].ToString()),
                            NotifiedDateTimeUtc = reader["NotifiedDateTimeUtc"].ToString() == "" ? DateTime.MinValue : DateTime.Parse(reader["NotifiedDateTimeUtc"].ToString()),
                            StatusID = Int16.Parse(reader["StatusID"].ToString())
                        });
                    }
                }

            }
            return messages;
        }        
        public bool SubscribeUserHubConnectionId(string userid, string connectionId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                //connection.Open();

                string sql = "INSERT INTO [dbo].[AspUsersHubConnection] (" +
                                    "[UserID], " +
                                    "[ConnectionId]" +
                                ") " +
                                "VALUES (" +
                                    $"'{userid}', " +
                                    $"'{connectionId}' " +
                                $")";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Notification = null;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    try
                    {
                        var row = command.ExecuteNonQuery();

                        if (row > 0)
                        {
                            return true;
                        }

                    }
                    catch(Exception e)
                    {
                        string error = e.Message;
                    }
                }

            }
            return false;
        }
        public IEnumerable<AspUsersHubConnection> GetUserHubConnections(string userid)
        {
            var connectionIds = new List<AspUsersHubConnection>();
            using (var connection = new SqlConnection(_connString))
            {

                string sql = "SELECT  " +
                                "[Id], " +
                                "[UserID], " +
                                "[ConnectionId] " +
                            "FROM [dbo].[AspUsersHubConnection] " +
                            $"WHERE UserID = CASE WHEN UserID = {userid} THEN UserID ELSE {userid} END " +
                            "ORDER BY ConnectionId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Notification = null;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        connectionIds.Add(item: new AspUsersHubConnection
                        {
                            Id = (int)reader["Id"],
                            UserID = (string)reader["UserID"],
                            ConnectionID = (string)reader["ConnectionID"]
                        });
                    }
                }

            }
            return connectionIds;
        }
        public bool UnSubscribeUserHubConnectionId(string userid, string connectionid)
        {
            using (var connection = new SqlConnection(_connString))
            {

                string sql = "DELETE " +
                             "FROM [dbo].[AspUsersHubConnection] " +
                             $"WHERE UserID = CASE WHEN UserID = {userid} THEN UserID ELSE {userid} END " +
                             $"AND ConnectionId = CASE WHEN ConnectionId = {connectionid} THEN ConnectionId ELSE {connectionid} END ";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Notification = null;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    var row = command.ExecuteNonQuery();

                    if(row > 0)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
