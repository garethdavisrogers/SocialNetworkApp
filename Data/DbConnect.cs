// Data/DbConnect.cs
using Npgsql;

namespace SocialNetworkApp.Data;

public class DbConnect
{
    private readonly string _cs;

    public DbConnect(IConfiguration config)
    {
        _cs = config.GetConnectionString("Default")
             ?? "Host=localhost;Port=5432;Database=socialnet;Username=postgres;Password=postgres";
    }

    public async Task CreateUserAsync(string name, CancellationToken ct = default)
    {
        await using var conn = new NpgsqlConnection(_cs);
        await conn.OpenAsync(ct);

        const string sql = "INSERT INTO users (id, name) VALUES (@id, @name)";
        await using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("id", Guid.NewGuid());
        cmd.Parameters.AddWithValue("name", name);
        await cmd.ExecuteNonQueryAsync(ct);
    }

    public async Task<List<(Guid Id, string Name)>> ListUsersAsync(CancellationToken ct = default)
    {
        var result = new List<(Guid, string)>();

        await using var conn = new NpgsqlConnection(_cs);
        await conn.OpenAsync(ct);

        const string sql = "SELECT id, name FROM users ORDER BY name";
        await using var cmd = new NpgsqlCommand(sql, conn);
        await using var rdr = await cmd.ExecuteReaderAsync(ct);
        while (await rdr.ReadAsync(ct))
            result.Add((rdr.GetGuid(0), rdr.GetString(1)));

        return result;
    }
}
