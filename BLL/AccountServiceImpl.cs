using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Model;
using JK.Framework.Core.Caching;
using JK.Framework.Core.Data;
using JK.Framework.Data;

namespace BLL
{
    public class AccountServiceImpl : IAccountService
    {
        private IRepository<UserAccount> UserAccountRepository;
        private IDbContext DbContext;
        private ICacheManager CacheManager;
        //public AccountServiceImpl(string dbConnection)
        //{
        //    // DbContext=new AccountEntities();

        //      DbContext =new JKObjectContext(dbConnection);
        //    UserAccountRepository =new EfRepository<UserAccount>(DbContext);
        //}
        private const string PRODUCTS_BY_ID_KEY = "Nop.product.id-{0}";
        public AccountServiceImpl(IRepository<UserAccount> useraccountRepository, IDbContext dbContext,ICacheManager cacheManager)
        {
            UserAccountRepository = useraccountRepository;
            DbContext = dbContext;
            CacheManager = cacheManager;
        }
        public void Add(UserAccount account)
        {
            UserAccountRepository.Insert(account);
        }

        public IList<UserAccount> GetList()
        {
            throw new NotImplementedException();
        }

        public UserAccount Find(Guid uid)
        {
            string key = String.Format(PRODUCTS_BY_ID_KEY, uid);
            return CacheManager.Get(key, () => UserAccountRepository.Table.FirstOrDefault(q => q.Guid == uid));
        }

        public UserAccount FindNoCache(Guid uid)
        {
            return UserAccountRepository.Table.FirstOrDefault(q => q.Guid == uid);
        }
    }
}
