using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Logic
{
    public class UserLogic
    {
        private ProjectASPEntities db = null; 
        public UserLogic()
        {
            db = new ProjectASPEntities();
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.EMPLOYEEs.Count(x => x.user_name == userName && x.password == passWord);
            if(result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public EMPLOYEE GetUserID(string userName)
        {
            return db.EMPLOYEEs.SingleOrDefault(x=>x.user_name== userName);
        }
        public List<EMPLOYEE> GetAllUser()
        {
            return db.EMPLOYEEs.ToList();
        }
        public int Insert(EMPLOYEE user)
        {
            db.EMPLOYEEs.Add(user);
            db.SaveChanges();
            return user.id_emp;
        }
        public bool Update(EMPLOYEE user)
        {
            try
            {
                var userFind = db.EMPLOYEEs.Find(user.id_emp);
                userFind.name_emp = user.name_emp;
                if (!string.IsNullOrEmpty(user.password))
                {
                    user.password = userFind.password;
                }
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.EMPLOYEEs.Find(id);
                db.EMPLOYEEs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}