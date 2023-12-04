using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Options
{
    [ExcludeFromCodeCoverage]
    public class PostGresOptions
    {
        public string? ConnectionString { get; set; }
    }
}
