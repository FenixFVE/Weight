using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestDb.Database.Tables;

public class BaseTable
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
}
