using Ninject.Modules;
using Photography.Core.Contracts.Service;
using Photography.Service.Bolts;

namespace Photography.Service.Bootstrap
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumService>().To<AlbumService>();
            Bind<IPhotoService>().To<PhotoService>();
            Bind<ITagService>().To<TagService>();

            Bind<IRoleService>().To<RoleService>();
            Bind<ISessionService>().To<SessionService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
