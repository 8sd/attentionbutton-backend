using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace attentionbutton_backend.Controllers {
    [Route("/"), ApiController]
    public class ValuesController : ControllerBase {
        private static LockManager lockManager = new LockManager();

        [HttpGet("{id}")]
        public ActionResult<String> waitForAlert(String id) {
            Lock waitHandler = lockManager.getLock (id);
            if (waitHandler.wait()) {
                return "alert";
            } else {
                return "no alert " + id;
            }
        }
        
        [HttpPost("{id}")]
        public ActionResult<String> triggerAlert(String id) {
            Lock waitHandler = lockManager.getLock (id);
            waitHandler.unwaitall();
            return "alert initiated " + id;
        }

        [HttpGet("/getUnusedID")]
        public ActionResult<String> getUnusedID() {
            string id;
            
            do {
                Random random = new Random(System.DateTime.Now.Millisecond);
                const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                id = new string(Enumerable.Repeat(chars, 5)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (lockManager.isIdInUse(id));

            return id;
        }
    }
}
