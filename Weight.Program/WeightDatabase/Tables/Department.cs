using Microsoft.EntityFrameworkCore;
using Weight.Program.WeightDatabase.Configurations;

namespace Weight.Program.WeightDatabase.Tables;

[EntityTypeConfiguration(typeof(DepartmentConfiguration))]
public sealed class Department: BaseTable
{
    public string? Name { get; set; } = null;
    public int? ParentId { get; set; } = null;
    public string? ShortName { get; set; } = null;
    public int? DepartmentTypeId { get; set; } = null;
    public int? LocalizationId { get; set; } = null;
    public string? Code { get; set; } = null;
    public string? FactoryId { get; set; } = null;
    public string? ComplexId { get; set; } = null;
    public bool IsCustomer { get; set; } = false;
    public int? MasterDataCode { get; set;} = null;
    public bool IsMasterData {  get; set; } = false;
    public int? ShortLocalizationId { get; set; } = null;
    public string? SavedFullPathId { get; set; } = null;
    public string? SavedFullPathShortName { get; set; } = null;
    public string? SavedFullPathName { get; set; } = null;
    public int? SavedLevel { get; set; } = null;
    public int? LabWareCode { get; set; } = null;
}
