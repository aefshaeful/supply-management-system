using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_vendors")]
    public class Vendor : BaseEntity
    {
        [Column("company_name", TypeName = "nvarchar(100)")]
        public string CompanyName { get; set; } = default!;

        [Column("email", TypeName = "nvarchar(100)")]
        public string Email { get; set; } = default!;

        [Column("phone_number", TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; } = default!;

        [Column("photo_product", TypeName = "nvarchar(255)")]
        public string PhotoProduct { get; set; } = default!;

        [Column("business_field", TypeName = "nvarchar(100)")]
        public string BusinessField { get; set; } = default!;

        [Column("company_type", TypeName = "nvarchar(100)")]
        public string CompanyType { get; set; } = default!;

        [Column("admin_approval_status")]
        public StatusApprovalEnum AdminApprovalStatus { get; set; } = StatusApprovalEnum.Pending;

        [Column("manager_approval_status")]
        public StatusApprovalEnum ManagerApprovalStatus { get; set; } = StatusApprovalEnum.Pending;

        [Column("is_register_process")]
        public bool IsInRegistrationProcess { get; set; } = true;

        [Column("is_register_approved")]
        public bool IsRegistrationApproved => AdminApprovalStatus == StatusApprovalEnum.Approved && ManagerApprovalStatus == StatusApprovalEnum.Approved;

        [Column("is_sumbit_tender")]
        public bool IsSubmitTender => IsRegistrationApproved && !IsInRegistrationProcess;


        // Cardinality
        public AccountForVendor? AccountForVendor { get; set; }

        public ICollection<TenderProject>? TenderProjects { get; set; }
    }
}
