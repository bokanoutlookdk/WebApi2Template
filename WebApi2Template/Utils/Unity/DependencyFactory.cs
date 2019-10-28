using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Template.Interfaces.Authentication;

namespace DoCAS.Service.Katalog.Utils.Unity
{
    public static class DependencyFactory
    {            /// <summary>
                 /// The factory used to create an instance
                 /// </summary>
        static Func<IAuthService> factory;
        /// <summary>
        /// Initializes the specified creation factory.
        /// </summary>
        /// <param name="creationFactory">The creation factory.</param>
        public static void SetFactory(Func<IAuthService> creationFactory)
        {
            factory = creationFactory;
        }
        /// <summary>
        /// Creates a new IMyDataContext instance.
        /// </summary>
        /// <returns>Returns an instance of an IMyDataContext </returns>
        public static IAuthService CreateIAuthServiceContext()
        {
            if (factory == null) throw new InvalidOperationException("You can not create a context without first building the factory.");

            return factory();
        }


    }
}