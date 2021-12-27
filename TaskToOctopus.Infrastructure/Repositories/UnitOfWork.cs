using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Persistence.Context;
using TaskToOctopus.Persistence.Logging;

namespace TaskToOctopus.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly INLogger<UnitOfWork> _logger = new NLogger<UnitOfWork>();

        private readonly CRMSSODbContext _context;
        public UnitOfWork(ILogger<UnitOfWork> logger, CRMSSODbContext context)
        {
            _context = context;
        }
        //private void GetStatudDefinitions()
        //{
        //    string sql = "SELECT " +
        //        "[StatusID], " +
        //        "[StatusKey], " +
        //        "[Description], " +
        //        "[IsNew], " +
        //        "[IsOpen], " +
        //        "[IsClosed], " +
        //        "[IsSuccess], " +
        //        "[IsFail] " +
        //        "FROM [CRMTables].[dbo].[T_StatusDef] " +
        //        "WHERE Statuskey = 'UserNotify'";

        //    //_statusDefinitions = _context.StatusDefModel.(sql).ToList();
        //}
        //private bool UpdateMessage(AspNetUsersNot message)
        //{
        //    try
        //    {
        //        //_context.AspNetUsersNots.Update(message);
        //        _context.Attach(message).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogWarning(e.Message);
        //        return false;
        //    }
        //}
        //public bool SetMessageReader(AspNetUsersNot message)
        //{
        //    message.StatusID = 2005;
        //    return UpdateMessage(message);
        //}
        public IEnumerable<AspNetUsersNot> GetMessagesToNotifiction()
        {
            //string sql = "SELECT [UserID], " +
            //    "[LeadPlanActivityID], " +
            //    "[NotificationDateTimeUtc], " +
            //    "[StatusID], " +
            //    "[NotifiedDateTimeUtc] " +
            //    "FROM AspNetUsersNot WHERE StatusID = 2000 " +
            //    "AND NotificationDateTimeUtc " +
            //    "BETWEEN GETUTCDATE() " +
            //    "AND DATEADD(minute, 5, GETUTCDATE()) " +
            //    "ORDER BY NotificationDateTimeUtc";


            //string sql2 = "SELECT [UserID], " +
            //    "[LeadPlanActivityID], " +
            //    "[NotificationDateTimeUtc], " +
            //    "[StatusID], " +
            //    "[NotifiedDateTimeUtc] " +
            //"FROM CRMSSO.dbo.AspNetUsersNot " +
            //"WHERE StatusID = 2000 " +
            //"AND NotificationDateTimeUtc BETWEEN DATEADD(minute, -111112, GETUTCDATE()) " +
            //"AND dateadd(minute, 111113, GETUTCDATE()) " +
            //"AND UserID in(select id from CRMSSO.dbo.AspNetUsers where StatusID = 31) " +
            //"ORDER BY NotificationDateTimeUtc";
            
            /* Massimo Dovere 26.12.2021
             * ricerca messaggi per utenti senza controllare chi è attivo.
             * Lo scopo è notificare i messaggi e il clients web si occuperò di sapere chi è attivo in quel momento.
             */

            string sql2 = "SP_GetPendingNotifications";
            
            List<AspNetUsersNot> messages = new List<AspNetUsersNot>();

            try
            {
                messages = _context.AspNetUsersNots.FromSqlRaw(sql2).AsNoTracking().ToList();
                return messages;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return default;
        }
        public bool IsThereNotifications()
        {
            //string sqlCount = "SELECT DISTINCT TOP 1 COUNT(*) as StatusID" +
            //            "FROM CRMSSO.dbo.AspNetUsersNot " +
            //            "WHERE StatusID = 2000 " +
            //            "AND NotificationDateTimeUtc BETWEEN DATEADD(minute, -112, GETUTCDATE()) " +
            //            "AND dateadd(minute, 113, GETUTCDATE()) " +
            //            "AND UserID in(select id from CRMSSO.dbo.AspNetUsers where StatusID = 31) " +
            //            "GROUP BY [UserID]";
            string sql = "SP_GetPendingNotifications";
            try
            {


                var workers = _context.AspNetUsersNots.FromSqlRaw(sql).AsNoTracking().FirstOrDefault();
                if (workers == null)
                    return false;
                return workers.StatusID == 0 ? false : true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            //    /*
            //     * Per ora recupero i messaggi ma non li mando al controller perchè una volta chiamato
            //     * si occupera da solo nel recuperare i messaggi associati al proprio utente loggato.
            //    */
            //    var messages = await _uow.GetMessagesToNotifiction().ConfigureAwait(false);
            //    string json = JsonConvert.SerializeObject(messages);

            //    if(messages.Count > 0)
            //        return await Task.FromResult(true);
            return false;
        }
        //public bool SubscribeUserHubConnectionId(string userid, string connectionid)
        //{
        //    if (userid != "" && connectionid != "")
        //    {
        //        var connections = GetUserHubConnections(userid)?
        //                .Where(x => x.ConnectionID == connectionid)
        //                .FirstOrDefault();

        //        if (connections == null)
        //        {
        //            try
        //            {
        //                _context.AspUsersHubConnections.Add(new AspUsersHubConnection()
        //                {
        //                    UserID = userid,
        //                    ConnectionID = connectionid
        //                });
        //                _context.SaveChanges();
        //                return true;
        //            }
        //            catch (Exception e)
        //            {
        //                _logger.LogWarning(e.Message);
        //            }

        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public bool UnSubscribeUserHubConnectionId(string userid, string connectionid)
        //{
        //    if (userid != "" && connectionid != "")
        //    {
        //        var connections = GetUserHubConnections(userid)?
        //                .Where(x => x.ConnectionID == connectionid)
        //                .FirstOrDefault(); /// prendo la prima

        //        if (connections != null)
        //        {
        //            try
        //            {
        //                _context.AspUsersHubConnections.Remove(connections);

        //                //_context.AspUsersHubConnections.Remove(new AspUsersHubConnection()
        //                //{
        //                //    UserID = userid,
        //                //    ConnectionID = connectionid
        //                //});
        //                _context.SaveChanges();
        //                return true;
        //            }
        //            catch (Exception e)
        //            {
        //                _logger.LogWarning(e.Message);
        //            }
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public IEnumerable<AspUsersHubConnection> GetUserHubConnections(string userid)
        //{
        //    if (userid != "")
        //    {
        //        var connections = _context.AspUsersHubConnections
        //                .Where(x => x.UserID == userid)
        //                .ToList();

        //        if (connections != null)
        //        {
        //            try
        //            {
        //                return connections;
        //            }
        //            catch (Exception e)
        //            {
        //                _logger.LogWarning(e.Message);
        //            }
        //        }
        //    }
        //    return new List<AspUsersHubConnection>();
        //}

        public bool IsValidateDB()
        {
            try
            {
                var test = _context.AspNetUsersNots.FirstOrDefault();
                if (test == null)
                    return false;
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}
