using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{
    public class TVRageClientTestBase
    {        
        protected IKernel _ioc;

        protected TVRageClient client;        

        public virtual void InitialiseIOC(){
            _ioc = new StandardKernel();
            _ioc.Bind<IRetriever>().To<MockRetriever>();
        }

        public TVRageClientTestBase() { 
            InitialiseIOC();
            client = _ioc.Get<TVRageClient>();
        }       
    }
}
