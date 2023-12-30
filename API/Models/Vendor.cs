using API.Utilities.Enums;

namespace API.Models
{
    public class Vendor : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string ProjectName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string PhotoProduct {  get; set; } = default!;

        public string BusinessField { get; set; } = default!;

        public string CompanyType { get; set; } = default!;

        public StatusApprovalEnum AdminApprovalStatus { get; set; } 

        public StatusApprovalEnum ManagerApprovalStatus { get; set; } 
    }
}
