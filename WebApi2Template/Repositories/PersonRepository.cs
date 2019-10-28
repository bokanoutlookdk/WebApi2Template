using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Template.Interfaces.Models;
using WebApi2Template.Interfaces.Persistence;
using WebApi2Template.Interfaces.Repositories;
using WebApi2Template.Models;
using WebApi2Template.Utils.ExceptionHandling;

namespace WebApi2Template.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IDataBaseConnection _dataBaseConnection;
        public PersonRepository(IDataBaseConnection dataBaseConnection)
        {
            _dataBaseConnection = dataBaseConnection;
        }
        public IPerson GetByID(object id)
        {
            try
            {
                //int ii = int.Parse("");
                return new Person()
                {
                    ID = 1,
                    FirstName = "bo",
                    LastName = "andersen"
                };
            }
            //catch (HoldKatalogIkkeFundetException ex) // HoldKatalogIkkeFundetException
            //{
            //    throw ex;
            //}
            catch (Exception ex)
            {
                if (ex.Message.Contains("Personen eksisterer ikke længere i databasen"))
                    return null;  // trigger 404 respnse
                else
                {
                    new WindowsHandledErrorEventlLogger().WriteErrorLog(ex.Message + " " + ex.StackTrace);

                    throw new APIException("My API Exception : " + ex.Message, ex.InnerException);
                }
            }
           
        }
    }
}