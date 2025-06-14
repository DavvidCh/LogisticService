namespace LogisticService.Users
{
    internal class SuperAdmin : AdminUser
    {
        public SuperAdmin(string name, string email, string password, string pinCode) 
            : base(name, email, password, pinCode)
        {

        }
    }
}
