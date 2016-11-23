using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dao.Model;

namespace BLL
{
     public interface IAccountService
     {
         void Add(UserAccount account);
     }
}
