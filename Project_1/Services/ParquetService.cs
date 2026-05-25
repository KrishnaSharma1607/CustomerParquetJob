using Parquet;
using Parquet.Data;
using Parquet.Schema;
using Project_1.Models;

namespace Project_1.Services
{
    public class ParquetService
    {
        public async Task<(MemoryStream, string)>
        CreateParquet(List<Customer> customers)
        {
            string fileName =
            $"EligibleCustomers_{DateTime.Now:yyyyMMdd_HHmmss}.parquet";

            MemoryStream stream =
            new MemoryStream();

            DataField<string> customerField =
            new DataField<string>("CustomerName");

            DataField<string> phoneField =
            new DataField<string>("PhoneNumber");

            DataField<string> cityField =
            new DataField<string>("City");

            var schema =
            new ParquetSchema(
                customerField,
                phoneField,
                cityField);

            using (
                ParquetWriter writer =
                await ParquetWriter.CreateAsync(
                    schema,
                    stream))
            {
                using (
                    ParquetRowGroupWriter group =
                    writer.CreateRowGroup())
                {
                    await group.WriteColumnAsync(
                        new DataColumn(
                            customerField,
                            customers.Select(
                                x => x.CustomerName)
                            .ToArray()));

                    await group.WriteColumnAsync(
                        new DataColumn(
                            phoneField,
                            customers.Select(
                                x => x.PhoneNumber)
                            .ToArray()));

                    await group.WriteColumnAsync(
                        new DataColumn(
                            cityField,
                            customers.Select(
                                x => x.City)
                            .ToArray()));
                }
            }

            stream.Position = 0;

            return (stream, fileName);
        }
    }
}