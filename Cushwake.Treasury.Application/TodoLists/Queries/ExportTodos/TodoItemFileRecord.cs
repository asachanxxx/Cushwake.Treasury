
using Cushwake.Treasury.Application.Common.Mappings;
using Cushwake.Treasury.Domain.Entities;

namespace Cushwake.Treasury.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
