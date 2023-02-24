using ConnectorResource.Core.Common.Entities;

namespace ConnectorResource.Core.Entities
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string ExpDate { get; set; }
        public string UnitPrice { get; set; }
        public string Qty { get; set; }
        public string Manufacturer { get; set; }
        public string NDC { get; set; }

    }
}
