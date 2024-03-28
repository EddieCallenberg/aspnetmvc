using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;


    #region CREATE

    [HttpPost]
    public async Task<IActionResult> Create(string email)
    {

        if (!string.IsNullOrEmpty(email))
        {
            if (!await _context.Subscribers.AnyAsync(x => x.Email == email))
            {
                try
                {
                    var subscriberEntity = new SubscriberEntity { Email = email };
                    _context.Subscribers.Add(subscriberEntity);
                    await _context.SaveChangesAsync();

                    return Created("", null);
                }
                catch 
                {
                    return Problem("Unable to create subscription");
                }              
            }
            return Conflict("This email address is already subscriebd to the newsletter");
        }
        return BadRequest();
    }

    #endregion

}
