using Core.Entities;

namespace Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool KeepSession { get; set; } = false;
        public int MaxSessionLimit { get; set; } = 5;
    }
}
