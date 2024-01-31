namespace SoapUIMockServiceTests.Models.v1.users
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class UsersResponse
    {
        public List<User> Users { get; set; }
    }
}