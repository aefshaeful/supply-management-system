using API.Utilities.Enums;

namespace API.Models
{
    public class Vendor : BaseEntity
    {
        public string CompanyName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string PhotoProduct {  get; set; } = default!;

        public string BusinessField { get; set; } = default!;

        public string CompanyType { get; set; } = default!;

        public StatusApprovalEnum AdminApprovalStatus { get; set; } = StatusApprovalEnum.Pending;
        public StatusApprovalEnum ManagerApprovalStatus { get; set; } = StatusApprovalEnum.Pending;
        public bool IsInRegistrationProcess { get; set; } = true;
        public bool IsRegistrationApproved => AdminApprovalStatus == StatusApprovalEnum.Approved && ManagerApprovalStatus == StatusApprovalEnum.Approved;
        public bool IsSubmitTender => IsRegistrationApproved && !IsInRegistrationProcess;
    }
}
