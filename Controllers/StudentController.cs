using MVCcrud.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCcrud.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        MVCcrudEntities2 dbObj = new MVCcrudEntities2();
        public ActionResult Student(tbl_student obj)
        {
            
                return View();
        }

       [HttpPost]
        public ActionResult AddStudent(tbl_student model)
        {
            tbl_student obj = new tbl_student();
            if (ModelState.IsValid)
            {

                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if(model.ID == 0)
                {
                    dbObj.tbl_student.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }
                dbObj.tbl_student.Add(obj);
                dbObj.SaveChanges();
            }
            ModelState.Clear();

           // Response.Redirect("~/StudentList.cshtm);

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = dbObj.tbl_student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.tbl_student.Where(x => x.ID == id).First();
            dbObj.tbl_student.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.tbl_student.ToList();

            return View("StudentList", list);
        }



    }
}