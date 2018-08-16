using System;
using System.Collections.Generic;

namespace attentionbutton_backend.Controllers {
    public class LockManager {
        private Dictionary<String, Lock> dic = new Dictionary<String, Lock>();
        public Lock getLock (String id){
            if(dic.ContainsKey(id)){
                return dic[id];
            } else {
                Lock tempLock = new Lock();
                dic.Add(id, tempLock);
                return dic [id];
            }
        }

        public bool isIdInUse (string id){
            return dic.ContainsKey(id);
        }
    }
}