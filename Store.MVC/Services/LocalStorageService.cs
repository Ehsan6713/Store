using Hanssens.Net;
using Store.MVC.Contracts;

namespace Store.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage storage;
        public LocalStorageService()
        {
            var storageConfiguration = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "store.mvc"
            };
            storage = new LocalStorage(storageConfiguration);
        }
        public void ClearStorage(List<string> keys)
        {
            foreach(var key in keys)
                storage.Remove(key);
        }

        public bool Exists(string key)
        {
             return storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            storage.Store(key, value);
            storage.Persist();
        }
    }
}
