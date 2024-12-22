using System.Text;
using System.Text.RegularExpressions;

namespace Todo.Core.ValueObjects
{
    public partial class Email
    {
        private const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        protected Email()
        {
            
        }
        public Email(string address)
        {
            address = address.Trim().ToLower();

            if (string.IsNullOrEmpty(address))
                throw new Exception("Email inválido");

            if (address.Length < 5)
                throw new Exception("Email inválido");

            if (!EmailRegex().IsMatch(address))
                throw new Exception("Email inválido");

            Address = address;
        }
        public string Address { get; }
        public string Hash =>  Convert.ToBase64String(Encoding.ASCII.GetBytes(Address));
        public Verification Verification {get; private set;} = new();
        public void ResendVerification()
        {
            Verification = new Verification();
        }

        public static implicit operator string(Email email) => email.ToString();
        public static implicit operator Email(string address) => new Email(address);

        public override string ToString()
        {
            return Address;
        }

        [GeneratedRegex(pattern)]
        private static partial Regex EmailRegex();

    }
}