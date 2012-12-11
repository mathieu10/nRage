using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{

    public class TestBase
    {        
        protected IKernel _ioc;

        public virtual void InitialiseIOC(){
            _ioc = new StandardKernel();
            _ioc.Bind<IRetriever>().To<MockRetriever>();
        }

        public TestBase() { 
            InitialiseIOC();
        }       
    }
}
