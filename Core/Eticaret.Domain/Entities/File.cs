using System.ComponentModel.DataAnnotations.Schema;
using Eticaret.Domain.Entities.Common;

namespace Eticaret.Domain.Entities;

public class File : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    [NotMapped]
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}