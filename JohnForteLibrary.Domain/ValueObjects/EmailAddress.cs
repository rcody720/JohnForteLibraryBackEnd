using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JohnForteLibrary.Domain.ValueObjects
{
    public class EmailAddress : SimpleValueObject<string>
    {
        private EmailAddress(string value) : base(value) { }

        public static Result<EmailAddress> Create(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return Result.Success(new EmailAddress(email));
            }

            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            if (!IsValidEmail(email))
            {
                return Result.Failure<EmailAddress>("Email address is not in a valid format");
            }

            return Result.Success(new EmailAddress(email));
        }
    }
}
