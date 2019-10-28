using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Template.Interfaces.Persistence;

namespace WebApi2Template.Utils.Database
{
    public class MyDatabase : IDataBaseConnection
    {
        public IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}