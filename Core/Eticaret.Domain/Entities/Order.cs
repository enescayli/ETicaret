using Eticaret.Domain.Entities.Common;

namespace Eticaret.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; } = string.Empty;
    
    public ICollection<Product> Products { get; set; }
    public Customer? Customer { get; set; }
}