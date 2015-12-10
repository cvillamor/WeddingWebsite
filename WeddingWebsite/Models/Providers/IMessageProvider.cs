using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWebsite.Models
{
  public interface IMessageProvider<T> where T : IMessage
  {
    bool SendMessage(T message);
  }
}
