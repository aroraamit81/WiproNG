using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wipro.BO;
using Wipro.DAL;

namespace Wipro.Api.Models
{
    public interface ITrainingService
    {
        Training AddNewTraining(Training t);
        IEnumerable<Training> GetAllTrainings();
    }
}
