using ASPMind.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPMind.Models.Response;
using System.Collections.Generic;
using ASPMind.Models.Request;
using Microsoft.EntityFrameworkCore;
using ASPMind.Services;

namespace ASPMind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                response = _inventoryService.Get();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("GetType")]
        public IActionResult GetType()
        {
            Response response = new Response();
            try
            {
                response = _inventoryService.GetType();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }   
        }

        [HttpGet("GetBrand")]
        public IActionResult GetBrand()
        {
            Response response = new Response();
            try
            {
                response = _inventoryService.GetBrand();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("GetModel")]
        public IActionResult GetModel()
        {
            Response response = new Response();
            try
            {
                response = _inventoryService.GetModel();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("AddNewType")]
        public IActionResult AddNewType(TypeRequest request)
        {
            Response response = new Response();
            try
            {
                response = _inventoryService.AddNewType(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message=ex.Message;
                return BadRequest(response);
            }
            
        }

        [HttpPost("AddNewBrand")]
        public IActionResult AddNewBrand(BrandRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Brand brand = new Brand();
                    brand.Name = request.Name;
                    db.Brands.Add(brand);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }

        [HttpPost("AddNewModel")]
        public IActionResult AddNewModel(ModelRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Model model = new Model();
                    model.Name = request.Name;
                    model.IdType = request.IdType;
                    model.IdBrand = request.IdBrand;
                    model.Stock = request.Stock;
                    model.StockAvailable = request.StockAvailable;
                    db.Models.Add(model);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("AddNewItem")]
        public IActionResult AddNewItem(InventoryRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Inventory inventory = new Inventory();
                    inventory.SerialNumber = request.SerialNumber;
                    inventory.IdModel = request.IdModel;
                    inventory.IdType = request.IdType;
                    inventory.Available = request.Available;
                    inventory.Description = request.Description;
                    db.Inventories.Add(inventory);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateType")]
        public IActionResult UpdateType(TypeRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    InventoryType inventoryType = db.InventoryTypes.Find(request.Id);
                    inventoryType.Name = request.Name;
                    db.Entry(inventoryType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateBrand")]
        public IActionResult UpdateBrand(BrandRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Brand brand = db.Brands.Find(request.Id);
                    brand.Name = request.Name;
                    db.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateModel")]
        public IActionResult UpdateModel(ModelRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Model model = db.Models.Find(request.Id);
                    model.Name = request.Name;
                    model.IdType = request.IdType;
                    model.IdBrand = request.IdBrand;
                    model.Stock = request.Stock;
                    model.StockAvailable = request.StockAvailable;
                    db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateItem")]
        public IActionResult UpdateItem(InventoryRequest request)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Inventory inventory = db.Inventories.Find(request.Id);
                    inventory.SerialNumber = request.SerialNumber;
                    inventory.IdModel = request.IdModel;
                    inventory.IdType = request.IdType;
                    inventory.Available = request.Available;
                    inventory.Description = request.Description;
                    db.Entry(inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteType")]
        public IActionResult DeleteType(int Id)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    InventoryType inventoryType = db.InventoryTypes.Find(Id);
                    db.Remove(inventoryType);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult DeleteBrand(int Id)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Brand brand = db.Brands.Find(Id);
                    db.Remove(brand);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteModel")]
        public IActionResult DeleteModel(int Id)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Model model = db.Models.Find(Id);
                    db.Remove(model);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteItem")]
        public IActionResult DeleteItem(int Id)
        {
            Response response = new Response();
            try
            {
                using (StoreMindContext db = new StoreMindContext())
                {
                    Inventory inventory = db.Inventories.Find(Id);
                    db.Remove(inventory);
                    db.SaveChanges();
                    response.Message = "Success";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
