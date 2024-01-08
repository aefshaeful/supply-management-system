using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.TenderProjects
{
    public class TenderProjectDtoCreate
    {
        public string ProjectName { get; set; } = default!;
        public decimal Budget { get; set; }
        public StatusApprovalEnum AdminApprovalStatus { get; set; } 
        public StatusApprovalEnum ManagerApprovalStatus { get; set; } 

        // implicit operator
        public static implicit operator TenderProject(TenderProjectDtoCreate dto)
        {
            return new TenderProject
            {
                ProjectName = dto.ProjectName,
                Budget = dto.Budget,
                AdminApprovalStatus = dto.AdminApprovalStatus,
                ManagerApprovalStatus = dto.ManagerApprovalStatus,
                CreatedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator TenderProjectDtoCreate(TenderProject tenderProject)
        {
            return new TenderProjectDtoCreate
            {
                ProjectName = tenderProject.ProjectName,
                Budget = tenderProject.Budget,
                AdminApprovalStatus = tenderProject.AdminApprovalStatus,
                ManagerApprovalStatus = tenderProject.ManagerApprovalStatus,
            };
        }
    }
}