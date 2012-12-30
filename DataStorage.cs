using System;
using System.ComponentModel;
using System.Linq;
using Raven.Client.Embedded;
using RestuarantPOI.Models;

namespace RestuarantPOI
{
    public class DataStorage : IDisposable
    {
        private readonly EmbeddableDocumentStore documentStore;
        public DataStorage()
        {
            documentStore = DocumentStore.DocumentStoreInstance;

        }

        public Item AddNewItem(Item item)
        {
            using (var session = documentStore.OpenSession())
            {
                session.Store(item);
                session.SaveChanges();
                return item;
            }
        }

        public BindingList<Item> Items()
        {
            using (var session = documentStore.OpenSession())
            {
                return new BindingList<Item>(session.Query<Item>().ToList());
            }
        }

        public BindingList<StockItem> StockItems()
        {
            using (var session = documentStore.OpenSession())
            {
                return new BindingList<StockItem>(session.Query<StockItem>().ToList());
            }
        }

        public void Dispose()
        {

        }

        public void SaveStock(BindingList<StockItem> stockItems)
        {
            using (var session = documentStore.OpenSession())
            {
                foreach (var stockItem in stockItems)
                    session.Store(stockItem);
                session.SaveChanges();
            }
        }
    }
}
