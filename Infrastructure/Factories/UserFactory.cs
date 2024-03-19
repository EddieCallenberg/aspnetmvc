using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity Create()
    {
        try
        {
            var date = DateTime.Now;

            return new UserEntity() { 
                Id = Guid.NewGuid().ToString(),
                Created = date,
                Modified = date
            };
        }
        catch { }
        return null!;
    }

    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;
            var (password, securityKey) = PasswordHasher.GenerateSecurePassword(model.Password);


            return new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.EmailAddress,
                Password = password,
                SecurityKey = securityKey,
                Created = date,
                Modified = date
            };
        }
        catch { }
        return null!;
    }
}
