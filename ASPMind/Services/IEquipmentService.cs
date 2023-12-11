using ASPMind.Models;

namespace ASPMind.Services
{
    public interface IEquipmentService
    {
        public IEnumerable<Equipment> Get();
        public Equipment? Get(int id);
    }
}
