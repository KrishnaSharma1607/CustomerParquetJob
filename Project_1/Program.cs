using Project_1.Services;

DatabaseService databaseService = new DatabaseService();

var customers = databaseService.GetCustomers();

var eligibleCustomers = customers.Where(c =>
        c.LoanStatus == "Active"
        && c.CallsToday < 3)
    .ToList();

Console.WriteLine("Eligible Customers:\n");

foreach (var customer in eligibleCustomers)
{
    Console.WriteLine(
        $"{customer.CustomerName} | {customer.PhoneNumber}");
}

ParquetService parquetService =
    new ParquetService();

var parquetResult =
await parquetService
.CreateParquet(
eligibleCustomers);

BlobService blobService =
new BlobService();

await blobService.UploadFile(
parquetResult.Item1,
parquetResult.Item2);

Console.WriteLine(
"Done!");