using API.Models;

namespace API.DataTransferObjects.Roles
{
    public class RoleDtoCreate
    {
        public string Name { get; set; } = default!;

        // implicit operator
        public static implicit operator Role(RoleDtoCreate dto)
        {
            return new Role
            {
                Name = dto.Name,
                CreatedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator RoleDtoCreate(Role role)
        {
            return new RoleDtoCreate
            {
                Name = role.Name
            };
        }
    }
}