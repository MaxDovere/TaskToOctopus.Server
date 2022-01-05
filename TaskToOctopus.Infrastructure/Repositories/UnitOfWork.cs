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
        
        public IEnumerable<DealerInfoModel> GetActiveDealerInfo()
        {
            
            /* Massimo Dovere 26.12.2021
             * ricerca messaggi per utenti senza controllare chi è attivo.
             * Lo scopo è notificare i messaggi e il clients web si occuperò di sapere chi è attivo in quel momento.
             */

            string sql = "SP_GetPendingNotifications";
            
            List<DealerInfoModel> dealers = new List<DealerInfoModel>();

            try
            {
                dealers = _context.DealerInfo.FromSqlRaw<DealerInfoModel>(sql).AsNoTracking().ToList();
                return dealers;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return default;
        }
        public bool IsThereNotifications()
        {
            
            string sql = "SP_GetPendingNotifications";
            try
            {

                var workers = _context.DealerInfo.FromSqlRaw<DealerInfoModel>(sql).AsNoTracking().ToList();
                //var workers = _context.AspNetUsersNots.FromSqlRaw(sql).AsNoTracking().FirstOrDefault();
                if (workers == null)
                    return false;
                return workers.Any();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
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
        //public SSODealer GetActiveDealerInfo(string userid)
        //{
        //    AspNetUser user = new AspNetUser();
        //    SSODealer info = new SSODealer();

        //    try
        //    {
        //        user = _context.AspNetUsers.Where(x => x.Id == userid).FirstOrDefault();
        //        if (user != null)
        //            info = _context.SSODealers.Where(x => x.Id == user.DealerKey).FirstOrDefault();
        //        return info;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, e.Message);
        //    }
        //    return default;
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
                _logger.LogError(e, e.Message);
                return false;
            }
        }
    }
}
