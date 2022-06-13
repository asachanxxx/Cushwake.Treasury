using Cushwake.Treasury.Domain.Common;
using Cushwake.Treasury.Domain.ValueObjects;

namespace Cushwake.Treasury.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
