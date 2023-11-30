using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Options
{
    [ExcludeFromCodeCoverage]
    public class PostGresOptions
    {
        public required string ConnectionString { get; set; }
    }
}
