using System.Globalization;
using CsvHelper;
using Cushwake.Treasury.Application.Common.Interfaces;
using Cushwake.Treasury.Application.TodoLists.Queries.ExportTodos;

namespace Cushwake.Treasury.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            //csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
