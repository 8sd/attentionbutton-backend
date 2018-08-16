using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace attentionbutton_backend.Controllers {
    public class ID {
        [JsonProperty("ID")]
        public String id {get;set;}
    }

    [Route("/"), ApiController]
    public class ValuesController : ControllerBase {
        private static Lock waitHandler = new Lock();

        [HttpGet("{id}")]
        public ActionResult<String> waitForAlert(String id) {
            if (waitHandler.wait(100)) {
                return "alert";
            } else {
                return "no alert " + id;
            }
        }
        
        [HttpPost("{id}")]
        public ActionResult<String> triggerAlert(String id) {
            waitHandler.unwaitall();
            return "alert initiated " + id;
        }
    }
}
