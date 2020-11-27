using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : BaseController
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;
        public UsersController(DataContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<MemberDto>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(users);
        }

        [HttpGet("{username}")]
        [Authorize]
        public async Task<MemberDto> GetUser(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username.ToLower());
            return _mapper.Map<MemberDto>(user);
        }
    }
}
