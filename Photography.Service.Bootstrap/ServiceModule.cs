using Ninject.Modules;
using Photography.Core.Contracts.Service;
using Photography.Service.Bolts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Service.Bootstrap
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<ISessionService>().To<SessionService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
