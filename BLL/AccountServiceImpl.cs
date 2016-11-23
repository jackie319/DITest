using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Model;
using JK.Framework.Core.Data;
using JK.Framework.Data;

namespace BLL
{
    public class AccountServiceImpl:IAccountService
    {
        private IRepository<UserAccount> UserAccountRepository;
        private IDbContext DbContext;

        //public AccountServiceImpl(string dbConnection)
        //{
        //    // DbContext=new AccountEntities();
           
        //      DbContext =new JKObjectContext(dbConnection);
        //    UserAccountRepository =new EfRepository<UserAccount>(DbContext);
        //}

        public AccountServiceImpl(IRepository<UserAccount> useraccountRepository, IDbContext dbContext)
        {
            UserAccountRepository = useraccountRepository;
            DbContext = dbContext;
        }
        public void Add(UserAccount account)
        {
           UserAccountRepository.Insert(account);
        }
    }
}
