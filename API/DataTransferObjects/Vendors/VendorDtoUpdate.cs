using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.TenderProjects
{
    public class VendorDtoUpdate
    {
        public Guid Guid { get; set; }
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
        public static implicit operator Vendor(VendorDtoUpdate dto)
        {
            return new Vendor
            {
                Guid = dto.Guid,
                CompanyName = dto.CompanyName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PhotoProduct = dto.PhotoProduct,
                BusinessField = dto.BusinessField,
                CompanyType = dto.CompanyType,
                AdminApprovalStatus = dto.AdminApprovalStatus,
                ManagerApprovalStatus = dto.ManagerApprovalStatus,
                IsInRegistrationProcess = dto.IsInRegistrationProcess,
                ModifiedDate = DateTime.UtcNow,
            };
        }

        // explicit operator
        public static explicit operator VendorDtoUpdate(Vendor vendor)
        {
            return new VendorDtoUpdate
            {
                Guid = vendor.Guid,
                CompanyName = vendor.CompanyName,
                Email = vendor.Email,
                PhoneNumber = vendor.PhoneNumber,
                PhotoProduct = vendor.PhotoProduct,
                BusinessField = vendor.BusinessField,
                CompanyType = vendor.CompanyType,
                AdminApprovalStatus = vendor.AdminApprovalStatus,
                ManagerApprovalStatus = vendor.ManagerApprovalStatus,
                IsInRegistrationProcess = vendor.IsInRegistrationProcess,
            };
        }
    }
}