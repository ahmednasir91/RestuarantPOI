using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Raven.Client.Embedded;
using RestuarantPOI.Models;

namespace RestuarantPOI
{
    public class DataStorage : IDisposable
    {
        private readonly EmbeddableDocumentStore _documentStore;
        public DataStorage()
        {
            _documentStore = DocumentStore.DocumentStoreInstance;
        }

        public Item AddNewItem(Item item)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
                return item;
            }
        }

        public BindingList<Item> Items()
        {
            using (var session = _documentStore.OpenSession())
                return new BindingList<Item>(session.Query<Item>().ToList());
        }

        public IList<StockItem> StockItems()
        {
            using (var session = _documentStore.OpenSession())
                return new BindingList<StockItem>(session.Query<StockItem>().ToList());
        }

        public StockItem StockItem(string itemName)
        {
            var list = StockItems();
            return list.SingleOrDefault(s => s.ItemName.Equals(itemName));
        }

        public void Dispose()
        {

        }

        public void SaveStock(BindingList<StockItem> stockItems)
        {
            using (var session = _documentStore.OpenSession())
            {
                foreach (var stockItem in stockItems)
                    session.Store(stockItem);
                session.SaveChanges();
            }
        }

        public void SaveItem(Item item)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
            }
        }
    }
}
