﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Xunit;
using nRage.Clients;

namespace nRage.Tests.Unit.TVRage
{
    public class TVRageClientTestBase
    {        
        protected IKernel _ioc;

        protected TVRageClient client;        

        public virtual void InitialiseIOC(){
            _ioc = new StandardKernel();
            _ioc.Bind<IRetriever>().To<TVRageMockRetriever>();
        }

        public TVRageClientTestBase() { 
            InitialiseIOC();
            client = _ioc.Get<TVRageClient>();
        }       
    }
}
