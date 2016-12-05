using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoTwo.Model;
using JK.Framework.Core.Data;
using JK.Framework.Data;

namespace BLL
{
    public class FunctionImpl:IFunction
    {
        private IRepository<Function> FunctionRepository;
        private IDbContext DbContext;
        public FunctionImpl(IRepository<Function> functionRepository, IDbContextGetter dbContext )
        {
            FunctionRepository = functionRepository;
            DbContext = dbContext.GetByName<IDbContext>("authorityEntity");
        } 
        public void Add(Function model)
        {
           FunctionRepository.Insert(model);
        }
    }
}
