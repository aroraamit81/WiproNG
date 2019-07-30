using Microsoft.AspNetCore.Mvc;
using System;
using Wipro.Api.Controllers;
using Wipro.Api.Models;
using Wipro.BO;
using Xunit;

namespace Wipro.XUnit
{
    public class TrainingTest
    {
        TrainingController controller;
        ITrainingService service;
        public TrainingTest()
        {
            service = new TrainingServiceFake();
            controller = new TrainingController(service);
        }

        [Fact]
        public void Get_All_Trainings()
        {
            var goodResult = controller.Get();
            Assert.IsType<OkObjectResult>(goodResult);
        }

        [Fact]
        public void Add_New_Training()
        {
            // Arrange
            var newItem = new Training()
            {
               Name="Cloud",
               EndDate= new DateTime(2019,03,01),
               StartDate = new DateTime(2019, 02, 01)
            };

            // Act
            var okResult = (controller.Add(newItem) as OkObjectResult);
            

            // Assert
            Assert.IsType<Training>(okResult.Value);
            //Assert.Equal("Cloud", newTraining.Name);
        }
    }
}
