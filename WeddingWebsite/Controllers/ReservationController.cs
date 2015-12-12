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
    /// <summary>
    /// Message repository
    /// </summary>
    private ITwilioMessageRepository _repository {get; set;}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="repository"></param>
    public ReservationController(ITwilioMessageRepository repository)
    {
      _repository = repository;
    }

    // GET: Reservation
    [HttpGet]
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
      _repository.MaxRequestsNotReached("12345");
      return null;
    }


  }
}