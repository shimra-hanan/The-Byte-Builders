using ConnectorResource.Core.Common.Entities;

namespace ConnectorResource.Api.Entities
{
    public class Pharmacy : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelePhoneNo { get; set; }
        public string Address { get; set; }
        public string LicenseNo { get; set; }
        
    }
}
