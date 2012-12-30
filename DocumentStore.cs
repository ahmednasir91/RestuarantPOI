using Raven.Client.Embedded;

namespace RestuarantPOI
{
    public class DocumentStore
    {
        private static DocumentStore _instance;
        private static readonly EmbeddableDocumentStore documentStore;

        static DocumentStore()
        {
            documentStore = new EmbeddableDocumentStore { DataDirectory = "~/Data" };
            documentStore.Initialize();
        }

        public static EmbeddableDocumentStore DocumentStoreInstance
        {
            get { 
                if (_instance == null) _instance = new DocumentStore();
                return documentStore;
            }
        }


    }
}
