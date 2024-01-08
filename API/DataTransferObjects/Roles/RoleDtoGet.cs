using API.Models;

namespace API.DataTransferObjects.Roles
{
    public class RoleDtoGet
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = default!;

        // implicit operator
        public static implicit operator Role(RoleDtoGet dto)
        {
            return new Role
            {
                Guid = dto.Guid,
                Name = dto.Name
            };
        }

        // explicit operator
        public static explicit operator RoleDtoGet(Role role)
        {
            return new RoleDtoGet
            {
                Guid = role.Guid,
                Name = role.Name
            };
        }
    }
}