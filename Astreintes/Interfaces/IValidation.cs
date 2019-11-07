using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IValidation<T>
    {
        /// <summary>
        /// Check to see if the class tested is valid
        /// </summary>
        /// <param name="testObject">object to test</param>
        /// <returns>Is the object valid ?</returns>
        bool CheckValidation(T testObject);
    }
}
