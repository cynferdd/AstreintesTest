using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// Mapping interface
    /// </summary>
    /// <typeparam name="TIn">"In" entity</typeparam>
    /// <typeparam name="TOut">"Out" entity</typeparam>
    public interface IMapper<TIn, TOut>
    {
        /// <summary>
        /// Mapping <typeparamref name="TIn"/> into <typeparamref name="TOut"/>
        /// </summary>
        /// <param name="obj">object to map</param>
        /// <returns>mapping result</returns>
        TOut Map(TIn obj);

        /// <summary>
        /// Mapping <typeparamref name="TOut"/> into <typeparamref name="TIn"/>
        /// </summary>
        /// <param name="obj">object to map</param>
        /// <returns>mapping result</returns>
        TIn Map(TOut obj);

        /// <summary>
        /// Mapping a list of <typeparamref name="TIn"/> into <typeparamref name="TOut"/>
        /// </summary>
        /// <param name="listObj">List of objects to map</param>
        /// <returns>mapped list</returns>
        IEnumerable<TOut> Map(IEnumerable<TIn> listObj);
    }
}
