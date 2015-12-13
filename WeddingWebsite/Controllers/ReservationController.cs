using Common.Logging;
using LinqToDB;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingWebsite.Models;
using WeddingWebsite.Models.DataObjects;
using WeddingWebsite.Models.DBConnectors;
using WeddingWebsite.Models.DomainModels;
using WeddingWebsite.Models.DTO;
using WeddingWebsite.Models.Helpers;
using WeddingWebsite.Models.Repository;

namespace WeddingWebsite.Controllers
{
  public class ReservationController : Controller
  {
    private ILog _log = LogManager.GetLogger<ReservationController>();

    /// <summary>
    /// Message repository
    /// </summary>
    private ITwilioMessageRepository _twilioRepository {get; set;}

    /// <summary>
    /// Person Repository
    /// </summary>
    private IPersonRepository _personRepository { get; set; }
    
    /// <summary>
    /// Message provider
    /// </summary>
    private IMessageProvider<TwilioMessage> _twilioMessageProvider {get; set;}

    /// <summary>
    /// Code Generator
    /// </summary>
    private ICodeGenerator _codeGenerator { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="repository"></param>
    [Inject]
    public ReservationController(ITwilioMessageRepository repository, IMessageProvider<TwilioMessage> twilioMessageProvider,
                                  IPersonRepository personRepository, ICodeGenerator codeGenerator)
    {
      _twilioRepository = repository;
      _personRepository = personRepository;
      _twilioMessageProvider = twilioMessageProvider;
      _codeGenerator = codeGenerator;
    }

    // GET: Reservation
    [HttpGet]
    public ActionResult Index()
    {
      var result = _twilioRepository.MaxRequestsNotReached("12345");
      return View();
    }

    /// <summary>
    /// Enter the number
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Number(Reservation model)
    {
      _log.InfoFormat("New request number: {0} attempting entry.", model.Number);


      if (!NumberValidator.IsPhoneNumber(model.Number))
        return View();

      if (_twilioRepository.MaxRequestsNotReached(model.Number) && 
          _personRepository.CheckPhoneNumberExists(model.Number))
      {

        TwilioMessage message = new TwilioMessage()
        {
          To = model.Number,
          Message = _codeGenerator.GenerateCode()
        };

        //Send Message to Phone Number
        _twilioMessageProvider.SendMessage(message);
        
        //Create the database object
        TwilioMessaging messageDB = new TwilioMessaging()
        {
          Code = _codeGenerator.HashCode(message.Message),
          Date = DateTime.Now,
          PhoneNumber = model.Number
        };

        //Log code
        _twilioRepository.AddRequest(messageDB);
      }
      return View();
    }


  }
}