using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Interfaces;



namespace Project0.StoreApplication.Storage.Models.Mapping
{
    class StoreMapper : IModelMapper<Store, Store_D>
    {
        public static StoreMapper _storeMapper;
        public static StoreMapper Instance
        {
            get
            {
                if (_storeMapper == null)
                {
                    _storeMapper = new StoreMapper();
                }


                return _storeMapper;
            }
        }
        public Store_D ModelToViewModel(Store entry)
        {
            //TODO find out how to use generics with abstract store 
            switch(entry.StoreId)
            {
                case 1:
                    ComputerStore s1 = new ComputerStore() { Name = entry.Name, StoreID = entry.StoreId };
                    return s1;
                case 2:
                    PenStore s2 = new PenStore() { Name = entry.Name, StoreID = entry.StoreId };
                    return s2;
                case 3:
                    MusicStore s3 = new MusicStore() { Name = entry.Name, StoreID = entry.StoreId };
                    return s3;
                default:
                    return null;


            }
            //c.StoreID = entry.StoreId;
            //c.Name = entry.Name;
        }

        public Store ViewModelToModel(Store_D entry)
        {
            Store c = new Store();
            c.Name = entry.Name;
            return c;
        }
    }
}

