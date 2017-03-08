﻿using System.Threading.Tasks;

namespace CoffeeShop.Inventory.dao
{
    public partial class InventoryDao
    {
        static private Task _SingletonTask;
        static private InventoryDao _Singleton;
        static public InventoryDao Singleton
        {
            get
            {
                if (_Singleton == null)
                {
                    if (_SingletonTask == null)
                    {
                        _SingletonTask = new Task(() => { _Singleton = new InventoryDao(); });
                        _SingletonTask.Start();
                    }
                    _SingletonTask.Wait();
                }
                return _Singleton;
            }
        }

        static private string _Path = "Inventory.xml";
        static public void SetPath(string Path)
        {
            if(_Path == Path)
            {
                return;
            }

            if(_SingletonTask != null)
            {
                _SingletonTask.Wait();
            }

            _Path = Path;
            _Singleton = null;
            _SingletonTask = null;
        }
    }
}
