using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Options
{
    [ExcludeFromCodeCoverage]
    public class DbContextOptions
    {
        public required string ConnectionString { get; set; }
    }
}
