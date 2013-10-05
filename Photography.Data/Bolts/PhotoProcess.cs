using Photography.Core.Contracts.Process;
using Photography.Data.Contracts;

namespace Photography.Data.Bolts
{
    internal class PhotoProcess : BaseProcess, IPhotoProcess
    {
        public PhotoProcess(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
