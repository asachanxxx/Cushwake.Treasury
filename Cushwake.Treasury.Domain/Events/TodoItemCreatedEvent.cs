using Cushwake.Treasury.Domain.Common;
using Cushwake.Treasury.Domain.Entities;

namespace Cushwake.Treasury.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
