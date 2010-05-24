using System;

namespace Serendipity.Miner
{
    public interface IParallelisedWork
    {
        void DoWork(params Action[] work);
    }

    public class ParallelisedWork : IParallelisedWork
    {
        public void DoWork(params Action[] work)
        {
            foreach (var action in work)
            {
                action();
            }
        }
    }
}
