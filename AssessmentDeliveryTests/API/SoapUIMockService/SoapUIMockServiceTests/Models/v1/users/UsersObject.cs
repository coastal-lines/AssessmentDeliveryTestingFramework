namespace SoapUIMockServiceTests.Models.v1.users
{
    internal class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User other = (User)obj;
            return Id == other.Id && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    internal class UsersObject
    {
        public List<User> Users { get; set; }
    }
}