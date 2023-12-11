using ASPMind.Models;
using ASPMind.Models.Response;
using ASPMind.Models.Request;

namespace ASPMind.Services
{
    public class InventoryService : IInventoryService
    {
        public Response Get()
        {
            Response response = new Response();
            using (StoreMindContext db = new StoreMindContext())
            {
                var list = (from i in db.Inventories
                            join m in db.Models
                            on i.IdModel equals m.Id
                            join t in db.InventoryTypes
                            on i.IdType equals t.Id
                            join b in db.Brands
                            on m.IdBrand equals b.Id
                            select new
                            {
                                ID = i.Id,
                                SerialNumber = i.SerialNumber,
                                Type = t.Name,
                                Brand = b.Name,
                                Model = m.Name,
                                Description = i.Description,
                                Available = i.Available
                            }).ToList();
                response.Data = list;
                return response;
            }
        }

        public Response GetType()
        {
            Response response = new Response();
            using (StoreMindContext db = new StoreMindContext())
            {
                var list = db.InventoryTypes.ToList();
                response.Data = list;
                return response;
            }
        }

        public Response GetBrand()
        {
            Response response = new Response();
            using (StoreMindContext db = new StoreMindContext())
            {
                var list = db.Brands.ToList();
                response.Data = list;
                return response;
            }
        }

        public Response GetModel()
        {
            Response response = new Response();
            using (StoreMindContext db = new StoreMindContext())
            {
                var list = (from m in db.Models
                            join t in db.InventoryTypes
                            on m.IdType equals t.Id
                            join b in db.Brands
                            on m.IdBrand equals b.Id
                            select new
                            {
                                ID = m.Id,
                                Model = m.Name,
                                Type = t.Name,
                                Brand = b.Name,
                                Stock = m.Stock,
                                StockAvailable = m.StockAvailable
                            }).ToList();
                response.Data = list;
                return response;
            }
        }

        public Response AddNewType(TypeRequest request)
        {
            Response response = new Response();
            using (StoreMindContext db = new StoreMindContext())
            {
                InventoryType inventoryType = new InventoryType();
                inventoryType.Name = request.Name;
                db.InventoryTypes.Add(inventoryType);
                db.SaveChanges();
                response.Message = "Success";
                return response;
            }
        }
    }
}
