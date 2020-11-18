﻿using MongoDB.Driver;

namespace Bookeasy.Data.Services
{
    public abstract class CollectionBase
    {
        protected readonly IMongoDatabase _database;

        protected CollectionBase(IMongoDatabase database)
        {
            _database = database;
        }
    }
}