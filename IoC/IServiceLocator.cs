using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public interface IServiceLocator
    {
        //IMessageingService GetMessageingService();
        object GetService(Type serviceType);
        //TService GetService<TService>();
    }

    public static class ServiceLocatorExtensions
    {
        public static TService GetService<TService>(this IServiceLocator locator)
        {
            return (TService)locator.GetService(typeof(TService));
        }
    }
}
