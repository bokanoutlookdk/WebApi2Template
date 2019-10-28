using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2Template.Interfaces.Models
{
    public interface IEntity<T>
    {
        int ID { get; set; }
    }
}