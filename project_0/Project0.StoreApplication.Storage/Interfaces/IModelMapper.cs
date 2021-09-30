using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0.StoreApplication.Storage.Interfaces
{
    /// <summary>
    /// Interface uses generics to pass through the DB Model and View Model
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface IModelMapper<T1, T2>
    {
        /// <summary>
        /// DB to View
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        T2 ModelToViewModel(T1 entry);

        /// <summary>
        /// View to DB
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        T1 ViewModelToModel(T2 entry);

    }//EOI
}//EON
