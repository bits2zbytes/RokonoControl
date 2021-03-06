using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Platform.Models;
using Rokono_Control.DatabaseHandlers;
using Rokono_Control.Models;

namespace Platform.Controllers
{
    public class NotificationController :Controller
    {

        RokonoControlContext Context;
        IConfiguration Configuration;

        public NotificationController(RokonoControlContext context, IConfiguration config)
        {
            Context = context;
            Configuration = config;
        }
        

        [HttpPost]
        public JsonResult GenerateBacklogReport([FromBody] IncomingEmailReportRequest request)
        {
            var currentUser = this.User;
            var id = int.Parse(currentUser.Claims.ElementAt(1).Value);
            var account = default(UserAccounts);
            using(var context = new DatabaseController(Context, Configuration))
            {
                account = context.GetUserAccount(id);
                var getBacklogWorkItems = context.BackgroundWorkItems(request.Items);
                using(var notificationManager = new DataHandlers.NotificationHandler(Configuration))
                {
                    notificationManager.GeneraBacklogReport(getBacklogWorkItems, account);
                }
            }
           
            return Json(new object{});
        }
    }
}