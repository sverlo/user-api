using System.Net.Mail;

namespace UserAPI.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public byte Age { get; set; }

        public string Email { get; set; }
    }
}
