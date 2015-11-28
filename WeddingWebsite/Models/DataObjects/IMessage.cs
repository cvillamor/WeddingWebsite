using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
  public interface IMessage
  {
    string NumberTo { get; set; }
    string NumberFrom { get; set; }
    string Message { get; set; }
  }
}
