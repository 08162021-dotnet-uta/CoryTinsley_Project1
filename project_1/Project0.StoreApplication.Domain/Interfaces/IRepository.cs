using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project0.StoreApplication.Domain.Interfaces
{

  public interface IRepository<T> where T : class
  {

    bool Delete(T entry);


    bool Insert(T entry);


    Task<List<T>> Select() 
    {
        throw new NotImplementedException(); 
    }


    T Update(T entry);
  }
}