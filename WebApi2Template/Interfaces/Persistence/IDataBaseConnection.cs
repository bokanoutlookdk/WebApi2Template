using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2Template.Interfaces.Persistence
{
    public interface IDataBaseConnection
    {
        IDbConnection CreateConnection();
    }
}