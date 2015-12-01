﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingWebsite.Models.DataObjects
{
  public class Email : IMessage
  {
    public string To { get; set; }
    public string From { get; set; }
    public string Message { get; set; }
  }
}