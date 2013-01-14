using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;
using nRage.Clients;

namespace nRage.Tests.Unit.TheTVDB
{
    public class TestBase
    {        
        protected IKernel _ioc;

        protected TvdbClient client;        

        public virtual void InitialiseIOC(){
            _ioc = new StandardKernel();
            _ioc.Bind<IRetriever>().To<TheTVDBMockRetriever>();
        }

        public TestBase() { 
            InitialiseIOC();
            client = _ioc.Get<TvdbClient>();
        }       
    }
}
