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
        /// <summary>
        /// Get a list of all T
        /// </summary>
        /// <returns>list of T</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Create a T
        /// </summary>
        /// <param name="obj">T to create</param>
        /// <returns>created T</returns>
        Task<T> Create(T obj);

        /// <summary>
        /// Delete a T
        /// </summary>
        /// <param name="obj">T to delete</param>
        /// <returns>was the deletion complete ?</returns>
        Task<bool> Delete(T obj);
    }
}
