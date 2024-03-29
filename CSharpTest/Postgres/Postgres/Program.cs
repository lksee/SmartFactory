﻿using Npgsql;

var connString = "Host=localhost;Username=postgres;Password=postgres;Database=test";

await using var conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

// Insert some data
//await using (var cmd = new NpgsqlCommand("INSERT INTO data (some_field) VALUES (@p)", conn))
//{
//    cmd.Parameters.AddWithValue("p", "Hello world");
//    await cmd.ExecuteNonQueryAsync();
//}

// Retrieve all rows
await using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (await reader.ReadAsync())
        Console.WriteLine(reader.GetString(0));
}