using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoTwo.Model;

namespace BLL
{
    public interface IFunction
    {
        void Add(Function  model);
    }

}
