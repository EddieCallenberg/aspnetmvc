using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AdressService(DataContext dataContext)
{
    private readonly DataContext _dataContext = dataContext;

    
}
