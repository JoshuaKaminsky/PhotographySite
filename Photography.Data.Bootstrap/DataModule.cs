using Ninject.Modules;
using Photography.Core.Contracts.Process;
using Photography.Data.Bolts;
using Photography.Data.Contracts;
using Photography.Data.Core;

namespace Photography.Data.Bootstrap
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumProcess>().To<AlbumProcess>();
            Bind<ICategoryProcess>().To<CategoryProcess>();
            Bind<IPhotoProcess>().To<PhotoProcess>();
            Bind<ITagProcess>().To<TagProcess>();

            Bind<IRoleProcess>().To<RoleProcess>();
            Bind<ISessionProcess>().To<SessionProcess>();
            Bind<IUserProcess>().To<UserProcess>();

            Bind<IUnitOfWork>().To<BaseUnitOfWork>();
            Bind<IRepositoryProvider>().To<RepositoryProvider>();
        }
    }
}
