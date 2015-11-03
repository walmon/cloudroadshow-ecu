using System;
using System.Collections.Generic;
// DocumentDB
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;
using System.Linq;

namespace CloudRoadshow.Web.Models
{
    public class InvoiceDS : IInvoiceDS
    {
        private static string endpointUrl =
            "https://cloudroadshow-ecu.documents.azure.com:443/";
        private static string authorizationKey =
            "hVARJ7G6fxCVgYbVIvTd27mb09KNoKQbdd5fuc2+thUa8+9q9M9pGJ/kQ6fMbO1JOHkMUBbZO2XIpr4nqc3Gyw==";

        private static DocumentClient client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
        const string DbName = "Invoices";
        const string InvoicesCol = "InvoicesCollection";

        public void AddNew(Invoice invoice)
        {
            invoice.id = Guid.NewGuid();
            Database database = GetOrCreateDatabaseAsync(DbName).Result;
            //Create a document collection
            DocumentCollection documentCollection = GetOrCreateCollectionAsync(database.SelfLink,
                InvoicesCol).Result;

            client.CreateDocumentAsync(
                documentCollection.DocumentsLink, 
                invoice);
        }

        public IEnumerable<Invoice> GetAll()
        {
            Database database = GetOrCreateDatabaseAsync(DbName).Result;

            //Create a document collection
            DocumentCollection documentCollection = GetOrCreateCollectionAsync(database.SelfLink,
                InvoicesCol).Result;

            var bornDate = DateTime.Today.AddYears(-20);

            foreach (var person in client.CreateDocumentQuery(documentCollection.DocumentsLink,
                $"SELECT * FROM {InvoicesCol} f "))
            {
                yield return person;
            }
        }

        public Invoice GetById(Guid id)
        {
            Database database = GetOrCreateDatabaseAsync(DbName).Result;

            //Create a document collection
            DocumentCollection documentCollection = GetOrCreateCollectionAsync(database.SelfLink,
                InvoicesCol).Result;

            foreach (var person in client.CreateDocumentQuery(documentCollection.DocumentsLink,
                $"SELECT * FROM {InvoicesCol} f WHERE f.id = \"{id}\" "))
            {
                return person;
            }
            return null;
        }
        #region Propios de DocumentDB

        async Task<Database> GetOrCreateDatabaseAsync(string id)
        {
            Database database = client.CreateDatabaseQuery().Where(db => db.Id == id).ToArray().FirstOrDefault();
            if (database == null)
            {
                database = await client.CreateDatabaseAsync(new Database { Id = id });
            }

            return database;
        }
        async Task<DocumentCollection> GetOrCreateCollectionAsync(string dbLink, string id)
        {
            DocumentCollection collection = client.CreateDocumentCollectionQuery(dbLink).Where(c => c.Id == id).ToArray().FirstOrDefault();
            if (collection == null)
            {
                collection = await client.CreateDocumentCollectionAsync(dbLink, new DocumentCollection { Id = id });
            }

            return collection;
        }
        #endregion
    }
}
