using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convey.Persistence.EFCore.Postgres
{
    public interface IPostgresOptionsBuilder
    {
        IPostgresOptionsBuilder WithConnectionString(string connectionString);
        PostgresOptions Build();
    }
}
