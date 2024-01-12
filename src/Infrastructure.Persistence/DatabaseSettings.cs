using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistence;

internal class DatabaseSettings
{
    public const string SectionName = "DatabaseSettings";

    [Required]
    public string ConnectionString { get; init; } = null!;
}