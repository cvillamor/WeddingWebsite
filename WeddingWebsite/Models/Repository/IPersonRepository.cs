using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWebsite.Models.DTO;

namespace WeddingWebsite.Models.Repository
{
  public interface IPersonRepository
  {
    bool CheckPhoneNumberExists(string phoneNumber);
    int GetGroupIdByPhoneNumber(string phoneNumber);
    IEnumerable<Person> GetPersonListByGroupId(int groupId);
  }
}
