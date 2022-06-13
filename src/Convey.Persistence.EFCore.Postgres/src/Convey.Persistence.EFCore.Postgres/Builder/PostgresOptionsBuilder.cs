using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convey.Persistence.EFCore.Postgres.Builder
{
    internal sealed class PostgresOptionsBuilder : IPostgresOptionsBuilder
    {
        private readonly PostgresOptions _options = new();

        public IPostgresOptionsBuilder WithConnectionString(string connectionString)
        {
            _options.ConnectionString = connectionString;
            return this;
        }
        public PostgresOptions Build()
            => _options;
    }
}
