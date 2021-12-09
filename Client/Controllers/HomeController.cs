using SignalRDbUpdates.Hubs;
using SignalRDbUpdates.Models;
using SignalRDbUpdates.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace SignalRDbUpdates.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;
        public HomeController()
        {
            _uow = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }        
        public ActionResult UpdateMessages([FromUri] string userid)
        {

            // se esiste la userid ricerca la connectionid e se esiste
            // spinge il messaggio verso questo utente o a tutti
            string connectionId = "";

            IEnumerable<AspUsersHubConnection> connections = _uow.GetUserHubConnections(userid);
            if(connections != null)
            {

                foreach(var connId in connections)
                {
                    connectionId = connId.ConnectionID;
                    MessagesHub.RequestToMessages(connectionId);                    
                }
            }
            else
            {
                MessagesHub.RequestToMessages(connectionId);
            }
            return default;
        }
        public ActionResult GetMessages([FromUri] string userid, string connectioId)
        {
            // se esiste la connectioId ricerca la userid e se esiste
            // spinge i messaggi trovati verso questo utente o a tutti
            // per visualizzarli.
            var messages = _uow.GetMessagesToNotify(userid);
            /*
             * ora può aggiornare i messaggi catturati e mettere lo statusID maggiore di 2000 
            */
            var rows = _uow.SetMessageReceived(userid);
            if(rows > 0) 
                return PartialView("_MessagesList", messages);
            
            return PartialView("_MessagesList", new List<AspNetUsersNot>());

        }
    }
}