﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWebsite.Models.Repository
{
  public interface IPersonRepository
  {
    bool CheckPhoneNumberExists(string phoneNumber);
  }
}
