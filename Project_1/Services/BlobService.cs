using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace Project_1.Services
{
    public class BlobService
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public BlobService()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString =
                config["BlobStorage:ConnectionString"];

            _containerName =
                config["BlobStorage:ContainerName"];
        }

        public async Task UploadFile(
    MemoryStream stream,
    string fileName)
        {
            BlobServiceClient blobServiceClient =
                new BlobServiceClient(_connectionString);

            BlobContainerClient containerClient =
                blobServiceClient.GetBlobContainerClient(_containerName);

            BlobClient blobClient =
                containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(
                stream,
                overwrite: true);

            Console.WriteLine(
                "Uploaded to Blob Storage!");
        }
    }
}