using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using WineS.Models.Repositories;
using WineS.Entities;
using WineS.Models.Context;

namespace WineS.IoC
{
    public class NinjectDependency : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependency(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}