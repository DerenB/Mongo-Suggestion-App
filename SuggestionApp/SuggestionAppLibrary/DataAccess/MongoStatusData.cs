﻿using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoStatusData : IStatusData
{
    private readonly IMongoCollection<StatusModel> _statuses;
    private readonly Microsoft.Extensions.Caching.Memory.IMemoryCache _cache;
    private const string CacheName = "StatusData";

    public MongoStatusData(IDbConnection db, Microsoft.Extensions.Caching.Memory.IMemoryCache cache)
    {
        _cache = cache;
        _statuses = db.StatusCollection;
    }

    public async Task<List<StatusModel>> GetAllStatuses()
    {
        var output = _cache.Get<List<StatusModel>>(CacheName);
        if (output is null)
        {
            var results = await _statuses.FindAsync(_ => true);
            output = results.ToList();

            _cache.Set(CacheName, output, TimeSpan.FromDays(1));
        }
        return output;
    }

    public Task CreationStatus(StatusModel status)
    {
        return _statuses.InsertOneAsync(status);
    }
}
