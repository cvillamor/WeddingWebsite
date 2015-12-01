﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
  public interface IMessageProvider
  {
    bool SendMessage(IMessage message);
  }
}