using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// generic interface for repositories
    /// </summary>
    /// <typeparam name="T">Class processed by the repository</typeparam>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Create(T obj);

        T Update(T obj);

        bool Delete(T obj);
    }
}
