
using Cushwake.Treasury.Application.Common.Mappings;
using Cushwake.Treasury.Domain.Entities;

namespace Cushwake.Treasury.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
