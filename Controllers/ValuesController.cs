using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace attentionbutton_backend.Controllers {
    [Route("/"), ApiController]
    public class ValuesController : ControllerBase {
        private static Lock waitHandler = new Lock();

        [HttpGet]
        public ActionResult<String> Get() {
            if (waitHandler.wait()) {
                return "alert";
            } else {
                return "no alert";
            }
        }
        
        [HttpPost]
        public ActionResult<String> HttpPost() {
            waitHandler.unwaitall();
            return "alert initiated";
        }
    }
}
