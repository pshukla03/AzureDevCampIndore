namespace Data_Storage
{
    using System;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Table;

    class Program
    {
        private const string BLOB_CONTAINER = "imagecontainer";
        private const string BLOB_TEXT_CONTAINER = "textcontainer";
        private const string BLOB = "AzureLogo";

        private const string QUEUE_NAME = "devcampqueue";
        private const string READ_FILE_FULL_PATH = @"..\..\azure-logo.jpg";
        private const string WRITE_FILE_FULL_PATH = @"..\..\azure-logo1.jpg";

        private const string BLOB_TEXT = "testblob.txt";
        const string SAMPLE_BLOB_CONTENT = "This is the sample text which will be uploaded to our SAS blob!";
        private const string STORED_POLICY_KEY = "demostoredpolicy";

        static void Main(string[] args)
        {


            //BlobDemo();

            //BlobDemo_With_SAS();

            //QueueDemo();

            //TableDemo();

            Console.ReadLine();
        }

        private static void TableDemo()
        {

            //----------Create table and insert single data -----------

            // Create Storage account.
            

            // Create the table client.
            
            // Create the table if it doesn't exist.
            
            // create table if not exists
            
            // Create a new customer entity.
            
            // Create the TableOperation that inserts the customer entity.
            
            // Execute the insert operation.
            
            // ---------- Add Different entity
            

            // ---------------- Batch Operation ----------------

            // Create the batch operation.

            // Create a customer entity and add it to the table.

            // Create another customer entity and add it to the table.

            // Add both customer entities to the batch insert operation.

            // Execute the batch operation.

            // ----------------- Query Operation---------------------


            //--------------- Update Operation---------------------------


            //----------------- Delete Operation----------------------------


            // Delete the table it if exists.

        }

        private static void QueueDemo()
        {
            // Get Storage account

            // Create the queue client

            // Retrieve a reference to a queue

            // Create the queue if it doesn't already exist

            // Create a message and add it to the queue.

            // Peek at the next message

            // Display message.

            // Get Message - remove from queue

            // Display message.

            //queue.Delete();

        }

        private static void BlobDemo()
        {
            // Get storage account.

            // Create the blob client.

            // Retrieve a reference to a container.

            // Create the container if it doesn't already exist.

            // Set permission.

            // Retrieve reference to a blob named BLOB.

            // Create or overwrite the BLOB blob with contents from a local file.

            // Retrieve reference to a blob named "photo1.jpg".

            // Save blob contents to a file.

            // Delete the blob.


        }

        public static void BlobDemo_With_SAS()
        {

            // ----------Upload blob using SAS-----------------

            // Get storage account.
            
            // Create the blob client.
            
            // Retrieve a reference to a container.
            
            // Create container if not exists.
            
            // Get blob reference
            
            // Delete if exists
            
            // blob GetSharedAccessSignature
            
            // Here we are write only accessing the blob based on a SAS uri only!
            
            
            // -------------Check access using policy-------------
        }
    }
}
