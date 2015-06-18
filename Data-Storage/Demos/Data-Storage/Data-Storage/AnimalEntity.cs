namespace Data_Storage
{
    using Microsoft.WindowsAzure.Storage.Table;

    public class AnimalEntity : TableEntity
    {
        public const string AnimalPartition = "Animals";

        public AnimalEntity(string name)
        {
            PartitionKey = AnimalPartition;
            RowKey = name;
        }

        public AnimalEntity() { }

        public string Color { get; set; }
    }
}