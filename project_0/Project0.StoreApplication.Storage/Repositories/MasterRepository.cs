
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Storage.Repositories
{

  public abstract class MasterRepository<T> : IRepository<T> where T : class
  {


    public bool Delete(T entry)
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(T entry)
    {
      throw new System.NotImplementedException();
    }

    public System.Collections.Generic.List<T> Select()
    {
      throw new System.NotImplementedException();
    }

    public T Update(T entry)
    {
      throw new System.NotImplementedException();
    }
  }
}