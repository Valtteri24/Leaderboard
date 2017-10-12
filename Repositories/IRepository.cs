using System;
using System.Threading.Tasks;
using gameapi.Models;

namespace gameapi.Repositories
{
    //All logic related to data-access happens on the classes that implement this
    public interface IRepository
    {


        Task<HighScore> CreateHighScore(HighScore highScore);
        Task<HighScore> GetHighScore(Guid highScoreId);
        Task<HighScore[]> GetTopTen();
        Task<HighScore> UpdateHighScore(HighScore highScore);
        Task<HighScore> DeleteHighScore(Guid highScoreId);
    }
}