using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Project0.StoreApplication.Storage.Models.Mapping;

namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreRepository : IRepository<Store_D>
  {
    private const string _path = @"/home/clypto/revature/training_code/projects/data/stores.xml";
    //private static readonly FileAdapter _fileAdapter = new FileAdapter();
        private static readonly StoreMapper _storeMapper = StoreMapper.Instance;
        private static readonly StoreApplicationDBContext _saDBContext = StoreApplicationDBContext.Instance;


    private StoreRepository()
    {
      //if (_fileAdapter.ReadFromFile<Store_D>(_path) == null)
      //{
      //  _fileAdapter.WriteToFile<Store_D>(_path, new List<Store_D>()
      //  {
      //    //new ComputerStore(),
      //    //new PenStore(),
      //    //new MusicStore()
      //  });
      //}
    }



    private static StoreRepository _storeRepository;

    public static StoreRepository GetInstance()
    {

      if (_storeRepository == null)
      {
        _storeRepository = new StoreRepository();
      }

      return _storeRepository;
    }


        public async Task<List<Store_D>> GetStores()
        {


            List<Store> s1 = await Select();
            List<Store_D> s2 = new List<Store_D>();

            foreach(Store s in s1)
            {
               Store_D index = _storeMapper.ModelToViewModel(s);
                s2.Add(index);
            }
            //check if null
            if (s2 == null) return null;

            //set information from db customer to local customer
            return s2;
        }



        public bool Delete(Store_D entry)
    {
      throw new System.NotImplementedException();
    }


    public bool Insert(Store_D entry)
    {
      //_fileAdapter.WriteToFile<Store_D>(_path, new List<Store_D> { entry });

      return true;
    }


    public async Task<List<Store>> Select()
    {
            //return _fileAdapter.ReadFromFile<Store_D>(_path);
            List<Store> stores = await _saDBContext.Stores.FromSqlRaw("Select * from Store;").ToListAsync();
            return stores;
    }


    public Store_D Update(Store_D entry)
    {
      throw new System.NotImplementedException();
    }
  }
}