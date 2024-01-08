using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.TenderProjects
{
    public class VendorDtoCreate
    {
        public string CompanyName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string PhotoProduct { get; set; } = default!;
        public string BusinessField { get; set; } = default!;
        public string CompanyType { get; set; } = default!;
        public StatusApprovalEnum AdminApprovalStatus { get; set; } 
        public StatusApprovalEnum ManagerApprovalStatus { get; set; }
        public bool IsInRegistrationProcess { get; set; }

        // implicit operator
        public static implicit operator Vendor(VendorDtoCreate dto)
        {
            return new Vendor
            {
                CompanyName = dto.CompanyName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PhotoProduct = dto.PhotoProduct,
                BusinessField = dto.BusinessField,
                CompanyType = dto.CompanyType,
                AdminApprovalStatus = dto.AdminApprovalStatus,
                ManagerApprovalStatus = dto.ManagerApprovalStatus,
                IsInRegistrationProcess = dto.IsInRegistrationProcess,
                CreatedDate = DateTime.UtcNow,
            };
        }

        // explicit operator
        public static explicit operator VendorDtoCreate(Vendor vendor)
        {
            return new VendorDtoCreate
            {
                CompanyName = vendor.CompanyName,
                Email = vendor.Email,
                PhoneNumber = vendor.PhoneNumber,
                PhotoProduct = vendor.PhotoProduct,
                BusinessField = vendor.BusinessField,
                CompanyType = vendor.CompanyType,
                AdminApprovalStatus = vendor.AdminApprovalStatus,
                ManagerApprovalStatus = vendor.ManagerApprovalStatus,
            };
        }
    }
}