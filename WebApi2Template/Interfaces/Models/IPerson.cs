using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2Template.Interfaces.Models
{
    public interface IPerson : IEntity<IPerson>
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string GetFullName();
    }
}