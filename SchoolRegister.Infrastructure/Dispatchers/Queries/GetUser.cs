using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Queries
{
    public class GetUser: IQuery<UserDto>
    {
        public string Email { get; set; }
    }
}