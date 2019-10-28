using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Template.Interfaces.Models;

namespace WebApi2Template.Models
{
    public class Person : IPerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}