using Grocery.Core.Models;

namespace Grocery.Core.Models
{
    public class Client : Model
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } = Role.None;

        public Client(int id, string name, string emailAddress, string password, Role role = Role.None)
            : base(id, name)
        {
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role;
        }
    }
}
