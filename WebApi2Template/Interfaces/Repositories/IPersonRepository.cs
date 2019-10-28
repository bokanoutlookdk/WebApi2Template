using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Template.Interfaces.Models;

namespace WebApi2Template.Interfaces.Repositories
{
    public interface IPersonRepository
    {
         IPerson GetByID(object id);
    }
}