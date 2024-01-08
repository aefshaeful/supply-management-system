using API.Models;

namespace API.DataTransferObjects.Roles
{
    public class RoleDtoUpdate
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;

        // implicit operator
        public static implicit operator Role(RoleDtoUpdate dto)
        {
            return new Role
            {
                Guid = dto.Guid,
                Name = dto.Name,
                ModifiedDate = DateTime.UtcNow
            };
        }

        // explicit operator
        public static explicit operator RoleDtoUpdate(Role role)
        {
            return new RoleDtoUpdate
            {
                Guid = role.Guid,
                Name = role.Name
            };
        }
    }
}