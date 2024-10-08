using Eticaret.Domain.Entities.Common;

namespace Eticaret.Domain.Entities;

public class Customer : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}
