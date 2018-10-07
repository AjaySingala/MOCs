using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Contoso.Storage.Table
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudTableClient tableClient = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("roster");
            // Ensure that the table is created.
            table.CreateIfNotExists();

            // Create 3 Employee instances.
            Employee first = new Employee
            {
                PartitionKey = "IT",
                RowKey = "ibahena",
                YearsAtCompany = 7
            };
            Employee second = new Employee
            {
                PartitionKey = "HR",
                RowKey = "rreeves",
                YearsAtCompany = 12
            };
            Employee third = new Employee
            {
                PartitionKey = "HR",
                RowKey = "rromani",
                YearsAtCompany = 3
            };

            // Insert the employee with the IT partition key to the table.
            // POST
            TableOperation insertOperation = TableOperation.InsertOrReplace(first);
            table.Execute(insertOperation);

            // Batch insert the employees with the HR partition key to the table.
            // Batch operations can be used to insert multiple entities into an Azure Storage table.
            // The entities must all have the same PartitionKey in order to be inserted as a single batch.
            // POST
            TableBatchOperation batchOperation = new TableBatchOperation();
            batchOperation.InsertOrReplace(second);
            batchOperation.InsertOrReplace(third);
            table.ExecuteBatch(batchOperation);

            // GET
            // Query the table for employees with a partition key equal to HR.
            TableQuery<Employee> query = new TableQuery<Employee>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "HR"));

            Console.WriteLine("HR Employees\n");
            foreach (Employee hrEmployee in table.ExecuteQuery<Employee>(query))
            {
                Console.WriteLine(hrEmployee);
            }

            // GET
            // Retrieve the single employee with a partition key of IT, and a row key of ibahena.
            Console.WriteLine("\n\n\n\nIT Employee\n");
            TableOperation retrieveOperation = TableOperation.Retrieve<Employee>("IT", "ibahena");
            TableResult result = table.Execute(retrieveOperation);
            Employee itEmployee = result.Result as Employee;
            Console.WriteLine(itEmployee);


        }
    }
}
