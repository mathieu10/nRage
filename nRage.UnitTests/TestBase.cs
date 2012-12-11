using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;

namespace nRage.Tests.Unit
{
    // http://services.tvrage.com/feeds/full_show_info.php?sid=20260 - show without specific episodes (Kenny's World)
    //http://services.tvrage.com/feeds/full_show_info.php?sid=32517 - HOWZAT


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
