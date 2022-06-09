
using Cushwake.Treasury.Application.Common.Interfaces;

namespace Cushwake.Treasury.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
