using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_tender_projects")]
    public class TenderProject : BaseEntity
    {
        [Column("vendor_guid")]
        public Guid VendorGuid { get; set; }

        [Column("project_name", TypeName = "nvarchar(255)")]
        public string ProjectName { get; set; } = default!;

        [Column("budget", TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Column("admin_approval_status")]
        public StatusApprovalEnum AdminApprovalStatus { get; set; } = StatusApprovalEnum.Pending;

        [Column("manager_approval_status")]
        public StatusApprovalEnum ManagerApprovalStatus { get; set; } = StatusApprovalEnum.Pending;


        // Cardinality
        public Vendor? Vendor { get; set; }

    }
}
