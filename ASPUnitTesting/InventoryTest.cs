

using ASPMind.Controllers;
using ASPMind.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPUnitTesting
{
    public class InventoryTest
    {
        private readonly InventoryController _controller;
        private readonly IInventoryService _service;

        public InventoryTest()
        {
            _service = new InventoryService();
            _controller = new InventoryController(_service);
        }

        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetType_Ok()
        {
            var result = _controller.GetType();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetBrand_Ok()
        {
            var result = _controller.GetBrand();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetModel_Ok()
        {
            var result = _controller.GetModel();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}