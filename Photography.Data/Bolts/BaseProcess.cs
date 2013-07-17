using Photography.Data.Contracts;

namespace Photography.Data.Bolts
{
    internal class BaseProcess
    {
        internal readonly IUnitOfWork UnitOfWork;

        public BaseProcess(IUnitOfWork unitOfWork)
         {
             UnitOfWork = unitOfWork;
         }
    }
}