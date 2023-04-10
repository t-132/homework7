using System;
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

        public string GetJson() => $@"{{""Id"":""{default(Guid).ToString()}"", ""Firstname"":""{Firstname}"",""Lastname"":""{Lastname}""}}";
    }
}