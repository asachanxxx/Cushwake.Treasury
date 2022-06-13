using Cushwake.Treasury.Domain.Common;
using Cushwake.Treasury.Domain.Entities;

namespace Cushwake.Treasury.Domain.Events;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
