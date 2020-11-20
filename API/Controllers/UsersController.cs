using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContex _context;
        public UsersController(DataContex context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }

        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
