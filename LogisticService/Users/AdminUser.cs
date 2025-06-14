using LogisticService.Enums;

namespace LogisticService.Users
{
    internal class AdminUser : User
    {
        public string PinCode { get; set; }

        public AdminUser()
        {
        }

        public AdminUser(string name, string email, string password, string pinCode)
            : base(name, email, password)
        {
            UserLevel = UserLevel.Admin;
            PinCode = pinCode;
        }
    }
}
