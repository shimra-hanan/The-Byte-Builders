using ConnectorResource.Core.Common.Entities;
using ConnectorResource.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectorResource.Api.Entities
{
    public class Inventory: BaseEntity
    {
        public string MedicineId { get; set; }
        [ForeignKey("MedicineId")]
        public virtual Medicine Medicine { get; set; }
        public string PharmacyId { get; set; }
        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; }
        public string LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Locations Locations { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
    }
}
