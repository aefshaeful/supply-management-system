using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.TenderProjects
{
    public class TenderProjectDtoGet
    {
        public Guid Guid { get; set; }
        public string ProjectName { get; set; } = default!;
        public decimal Budget { get; set; }
        public StatusApprovalEnum AdminApprovalStatus { get; set; }
        public StatusApprovalEnum ManagerApprovalStatus { get; set; }


        // implicit operator
        public static implicit operator TenderProject(TenderProjectDtoGet dto)
        {
            return new TenderProject
            {
                Guid = dto.Guid,
                ProjectName = dto.ProjectName,
                Budget = dto.Budget,
                AdminApprovalStatus = dto.AdminApprovalStatus,
                ManagerApprovalStatus = dto.ManagerApprovalStatus,
            };
        }


        // explicit operator
        public static explicit operator TenderProjectDtoGet(TenderProject tenderProject)
        {
            return new TenderProjectDtoGet
            {
                Guid = tenderProject.Guid,
                ProjectName = tenderProject.ProjectName,
                Budget = tenderProject.Budget,
                AdminApprovalStatus = tenderProject.AdminApprovalStatus,
                ManagerApprovalStatus = tenderProject.ManagerApprovalStatus,
            };
        }
    }
}