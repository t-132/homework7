
using System.Data.Common;

namespace WebClient
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest()
        {
        }

        public CustomerCreateRequest(
            string firstName,
            string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public string Firstname { get; init; }

        public string Lastname { get; init; }

        public string GetJson() => $@"{{""Id"":0, ""Firstname"":""{Firstname}"",""Lastname"":""{Lastname}""}}";
    }
}