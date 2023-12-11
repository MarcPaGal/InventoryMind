using ASPMind.Models;
using ASPMind.Models.Request;
using ASPMind.Models.Response;

namespace ASPMind.Services
{
    public interface IInventoryService
    {
        public Response Get();
        public Response GetType();
        public Response GetBrand();
        public Response GetModel();
        public Response AddNewType(TypeRequest request);

    }
}
