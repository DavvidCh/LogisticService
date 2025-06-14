using LogisticService.Enums;
using LogisticService.Requests;

namespace LogisticService.Users
{
    internal class RegularUser : User
    {
        public List<Order> Orders { get; set; }

        public RegularUser()
        {
        }

        public RegularUser(string name, string email, string password)
            : base(name, email, password)
        {
            UserLevel = UserLevel.User;
        }
    }
}
