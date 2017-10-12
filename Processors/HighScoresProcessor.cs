using System;
using System.Threading.Tasks;
using gameapi.Models;
using gameapi.Repositories;

namespace gameapi.Processors
{
    // Business logic (logic for verifying and updating the data) happens here
    public class HighScoresProcessor
    {
        private readonly IRepository _repository;
        public HighScoresProcessor(IRepository repository)
        {
            _repository = repository;
        }
        public Task<HighScore> Get(Guid id)
        {
            return _repository.GetHighScore(id);
        }

        public async Task<HighScore[]> GetTopTen()
        {
            return await _repository.GetTopTen();
        }
        public Task<HighScore> Create(NewHighScore newHighScore)
        {
            HighScore highScore = new HighScore()
            {
                Id = Guid.NewGuid(),
                Name = newHighScore.Name,
                Score = newHighScore.Score,

            };
            return _repository.CreateHighScore(highScore);
        }

        public Task<HighScore> Delete(Guid id)
        {
            return _repository.DeleteHighScore(id);
        }


        public async Task<HighScore> Update(Guid id, ModifiedHighScore modifiedHighScore)
        {
            HighScore highScore = await _repository.GetHighScore(id);
            highScore.Score = modifiedHighScore.Score;
            await _repository.UpdateHighScore(highScore);
            return highScore;
        }
    }
}