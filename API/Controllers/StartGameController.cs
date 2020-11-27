using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class StartGameController : BaseController
    {
        public StartGameController() { }

        [HttpPost]
        public void CpuAction(string username)
        {
            return;
        }

     
    }
}