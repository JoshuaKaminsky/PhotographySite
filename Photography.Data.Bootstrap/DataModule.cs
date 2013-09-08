using Ninject.Modules;
using Photography.Core.Contracts.Process;
using Photography.Data.Bolts;
using Photography.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Bootstrap
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleProcess>().To<RoleProcess>();
            Bind<ISessionProcess>().To<SessionProcess>();
            Bind<IUserProcess>().To<UserProcess>();
            Bind<IUnitOfWork>().To<BaseUnitOfWork>();
        }
    }
}
