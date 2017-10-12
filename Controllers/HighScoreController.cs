using System;
using System.Threading.Tasks;
using gameapi.Exceptions;
using gameapi.Models;
using gameapi.ModelValidation;
using gameapi.Processors;
using Microsoft.AspNetCore.Mvc;

namespace gameapi.Controllers{

    [Route("api/highscores")]
    public class HighScoresController : Controller    {
        private HighScoresProcessor _processor;
        public HighScoresController(HighScoresProcessor processor)        {
            _processor = processor;
        }

        

        [HttpGet("{id:guid}")]
        public Task<HighScore> Get(Guid id)        {
            return _processor.Get(id);
        }

        [HttpPost]
        [ValidateModel]
        public Task<HighScore> Create(NewHighScore highScore)        {
            return _processor.Create(highScore);
        }


        [HttpGet("{asd:bool}")]
        public Task<HighScore[]> GetTopTen()
        {
            return _processor.GetTopTen();
        }

        [HttpDelete("{id}")]
        public Task<HighScore> Delete(Guid id)        {
            return _processor.Delete(id);
        }
        [HttpPut("{id:guid}")]
        public Task<HighScore> Update(Guid id, ModifiedHighScore highScore)        {
            return _processor.Update(id, highScore);
        }
    }
}