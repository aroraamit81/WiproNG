using System;
using System.Collections.Generic;
using System.Text;
using Wipro.Api.Models;
using Wipro.BO;

namespace Wipro.XUnit
{
    public class TrainingServiceFake : ITrainingService
    {
        private readonly List<Training> _trainings;
        public TrainingServiceFake()
        {
            _trainings = new List<Training>()
            {


                new Training(){ Id=1, Name="C#", StartDate=new DateTime(2019,01,01), EndDate=new DateTime(2019,01,02)   },
                new Training(){ Id=2, Name="SQL", StartDate=new DateTime(2019,01,01), EndDate=new DateTime(2019,01,02)   },
                new Training(){ Id=3, Name="NG7", StartDate=new DateTime(2019,01,01), EndDate=new DateTime(2019,01,02)   },

            };

        }

        public Training AddNewTraining(Training t)
        {
            _trainings.Add(t);
            return t;
        }

        public IEnumerable<Training> GetAllTrainings()
        {
            return _trainings;
        }
    }
}
