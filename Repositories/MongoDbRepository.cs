using System;
using System.Threading.Tasks;
using gameapi.Models;
using gameapi.mongodb;
using MongoDB.Driver;

namespace gameapi.Repositories
{
  //Gets from and updates data to MongoDb 
  public class MongoDbRepository : IRepository
  {
    private IMongoCollection<Player> _collection;
    public MongoDbRepository(MongoDBClient client)
    {
      //Getting the database with name "game"
      IMongoDatabase database = client.GetDatabase("game");

      //Getting collection with name "players"
      _collection = database.GetCollection<Player>("players");
    }

    public Task<Item> CreateItem(Guid playerId, Item item)
    {
      throw new NotImplementedException();
    }

    public async Task<Player> CreatePlayer(Player player)
    {
      await _collection.InsertOneAsync(player);
      return player;
    }

    public Task<Item> DeleteItem(Guid playerId, Item item)
    {
      throw new NotImplementedException();
    }

    public Task<Player> DeletePlayer(Guid playerId)
    {
      throw new NotImplementedException();
    }

    public Task<Item[]> GetAllItems(Guid playerId)
    {
      throw new NotImplementedException();
    }

    public Task<Player[]> GetAllPlayers()
    {
      throw new NotImplementedException();
    }

    public Task<Item> GetItem(Guid playerId, Guid itemId)
    {
      throw new NotImplementedException();
    }

    public async Task<Player> GetPlayer(Guid playerId)
    {
        //Builders<T> static class is where the filters are to be found 
        //We use filters to create queries
        //Eq means Equals
        var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
        var cursor = await _collection.FindAsync(filter);
        var player = await cursor.FirstAsync();
        return player;
    }

    public Task<Item> UpdateItem(Guid playerId, Item item)
    {
      throw new NotImplementedException();
    }

    public async Task<Player> UpdatePlayer(Player player)
    {
      var filter = Builders<Player>.Filter.Eq(p => p.Id, player.Id);
      await _collection.ReplaceOneAsync(filter, player);
      return player;
    }
  }
}