namespace SoapUIMockServiceTests.Models.v1.users.get
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UsersResponse
    {
        public List<User> Users { get; set; }
    }
}