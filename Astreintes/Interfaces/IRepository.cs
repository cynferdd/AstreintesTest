using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// generic interface for repositories
    /// </summary>
    /// <typeparam name="T">Class processed by the repository</typeparam>
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T obj);

        Task<bool> Delete(T obj);
    }
}
