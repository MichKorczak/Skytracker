using CommandLine;

namespace Skytracker.Db.Migrations;

public class Options
{
    [Option('c', "connectionString", Required = false, HelpText = "Database connection string")]
    public string ConnectionString { get; set; }
}
