using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingWebsite.Models.DBConnectors;
using WeddingWebsite.Models.DTO;
using WeddingWebsite.Models.Repository;

namespace WeddingWebsite.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
      public ActionResult Index()
      {
        return View();
      }

      /// <summary>
      /// Enter the number
      /// </summary>
      /// <returns></returns>
      [HttpPost]
      public ActionResult Number(string id)
      {
        using(IDataContext db = new WeddingDb())
        {
          var respository = new TwilioMessageRepository(db);
        }
        return null;
      }

       
    }
}