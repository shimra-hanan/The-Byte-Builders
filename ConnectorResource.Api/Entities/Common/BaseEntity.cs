using ConnectorResource.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConnectorResource.Core.Common.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public RecordState RecordState { get; set; }
    }
}
