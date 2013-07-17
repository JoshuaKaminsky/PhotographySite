using Photography.Core.Contracts.Process;

namespace Photography.Service.Bolts
{
    internal class BaseService<TProcess> where TProcess : IProcess
    {
        internal readonly TProcess Process;

        public BaseService(TProcess process)
        {
            Process = process;
        } 
    }
}
