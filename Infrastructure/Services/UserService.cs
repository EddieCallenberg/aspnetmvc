using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(UserRepository repository, AdressService addressService)
{
    private readonly UserRepository _repository = repository;
    private readonly AdressService _addressService = addressService;


    public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    {
        try
        {
            var exists = await _repository.AlreadyExistsAsync(x => x.Email == model.EmailAddress);
            if (exists.StatusCode == StatusCode.EXISTS)
                return exists;

            var result = await _repository.CreateOneAsync(UserFactory.Create(model));
            if (result.StatusCode != StatusCode.OK)
                return result;

            return ResponseFactory.Ok("User Successfully Created");

            
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}
