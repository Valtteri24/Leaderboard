using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gameapi.Models;
using gameapi.mongodb;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace gameapi.Repositories
{
    //Gets from and updates data to MongoDb 
    public class MongoDbRepository : IRepository
    {
        private IMongoCollection<HighScore> _collection;
        public MongoDbRepository(MongoDBClient client)
        {
            //Getting the database with name "game"
            IMongoDatabase database = client.GetDatabase("game");

            //Getting collection with name "highscores"
            _collection = database.GetCollection<HighScore>("highscores");
        }

        

        public async Task<HighScore> CreateHighScore(HighScore highScore)
        {
            await _collection.InsertOneAsync(highScore);
            return highScore;
        }

        

        public async Task<HighScore> DeleteHighScore(Guid highScoreId)
        {
            var result = await _collection.FindAsync(a => a.Id == highScoreId);
            await _collection.DeleteOneAsync(a => a.Id == highScoreId);
            return null;
        }

        public async Task<HighScore[]> GetTopTen()
        {

            var filter = Builders<HighScore>.Filter.Empty;
            var list = await _collection.Find(filter).Sort(Builders<HighScore>.Sort.Descending("Score")).ToListAsync();
            HighScore[] highScore = new HighScore[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                highScore[i] = list[i];
                if (i == 9)
                    break;
            }
            return highScore;


        }


        public async Task<HighScore> GetHighScore(Guid highScoreId)
        {
            var filter = Builders<HighScore>.Filter.Eq(p => p.Id, highScoreId);
            var cursor = await _collection.FindAsync(filter);
            var highScore = await cursor.FirstAsync();
            return highScore;
        }



        public async Task<HighScore> UpdateHighScore(HighScore highScore)
        {
            var filter = Builders<HighScore>.Filter.Eq(p => p.Id, highScore.Id);
            await _collection.ReplaceOneAsync(filter, highScore);
            return highScore;
        }
    }
}
