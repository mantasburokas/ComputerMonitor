using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;

namespace Database
{
    public class MetricsContext : DbContext
    {

        public DbSet<ComputerDetail> ComputerDetails { get; set; }
        public DbSet<UsageData> UsageDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "metrics.db" };
            SqliteConnection connection = new SqliteConnection(connectionStringBuilder.ToString());
            optionsBuilder.UseSqlite(connection);
        }
    }
}
