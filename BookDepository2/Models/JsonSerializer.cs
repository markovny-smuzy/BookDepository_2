﻿using Newtonsoft.Json;
using BookDepository2.Interfaces;

namespace BookDepository2.Models;

public class JsonSerializer : ISerializer
{
    public async Task SerializeAsync<T>(T data, string filePath)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task<T?> DeserializeAsync<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default;

        var json = await File.ReadAllTextAsync(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }
}