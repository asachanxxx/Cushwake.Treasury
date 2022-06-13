using System.Globalization;
using CsvHelper.Configuration;
using Cushwake.Treasury.Application.TodoLists.Queries.ExportTodos;

namespace Cushwake.Treasury.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
