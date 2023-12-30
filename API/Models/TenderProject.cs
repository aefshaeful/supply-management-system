using API.Utilities.Enums;

namespace API.Models
{
    public class TenderProject : BaseEntity
    {
        public Guid VendorGuid { get; set; }

        public string ProjectName { get; set; } = default!;

        public decimal Budget { get; set; }
        
        public StatusApprovalEnum AdminApprovalStatus { get; set; } = StatusApprovalEnum.Pending;
        
        public StatusApprovalEnum ManagerApprovalStatus { get; set; } = StatusApprovalEnum.Pending;
    }
}
