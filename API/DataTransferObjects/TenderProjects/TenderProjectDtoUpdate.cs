using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.TenderProjects
{
    public class TenderProjectDtoUpdate
    {
        public Guid Guid { get; set; }
        public string ProjectName { get; set; } = default!;
        public decimal Budget { get; set; }
        public Guid VendorGuid { get; set; }
        public StatusApprovalEnum AdminApprovalStatus { get; set; }
        public StatusApprovalEnum ManagerApprovalStatus { get; set; }


        // implicit operator
        public static implicit operator TenderProject(TenderProjectDtoUpdate dto)
        {
            return new TenderProject
            {
                Guid = dto.Guid,
                ProjectName = dto.ProjectName,
                Budget = dto.Budget,
                VendorGuid = dto.VendorGuid,
                AdminApprovalStatus = dto.AdminApprovalStatus,
                ManagerApprovalStatus = dto.ManagerApprovalStatus,
                ModifiedDate = DateTime.UtcNow
            };
        }


        // explicit operator
        public static explicit operator TenderProjectDtoUpdate(TenderProject tenderProject)
        {
            return new TenderProjectDtoUpdate
            {
                Guid = tenderProject.Guid,
                ProjectName = tenderProject.ProjectName,
                Budget = tenderProject.Budget,
                VendorGuid = tenderProject.VendorGuid,
                AdminApprovalStatus = tenderProject.AdminApprovalStatus,
                ManagerApprovalStatus = tenderProject.ManagerApprovalStatus,
            };
        }
    }
}