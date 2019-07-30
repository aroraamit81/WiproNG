using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wipro.BO;
using Wipro.DAL;

namespace Wipro.Api.Models
{
    public class TrainingService : ITrainingService
    {
        private readonly AppDbContext _dbContext;
        public TrainingService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Training AddNewTraining(Training t)
        {
            _dbContext.Trainings.Add(t);
            _dbContext.SaveChanges();
            return t; 
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            return _dbContext.Trainings;
        }
    }
}
