using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TeamManager.Domain.Interfaces
{
    public interface IBackgroundJob
    {
        string Schedule(Expression<Func<Task>> func, TimeSpan delay);
        bool Delete(string jobId);
    }
}
