using SalehAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalehAjax.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(MyList.myList);
        }

        [HttpPost]/* we create new action for ajax to fitach each raw in list
        not all list then we make it return to partial view */

        public ActionResult _Table(string searchTxt = "", string City = "")
        {
            if (!string.IsNullOrEmpty(searchTxt))//is not null then go in
            {
                if (City == "city")
                {
                    return PartialView(MyList.myList.Where(x => x.City.ToLower().Contains(searchTxt.ToLower())).OrderBy(x => x.Name));
                }
                else //if (City != "city") because I have a default ="" upp 
                 {
                    return PartialView(MyList.myList.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).OrderBy(x => x.City));
                }
            }
            else// it is not null, it has another value
            {
                return PartialView(MyList.myList);//all list with out filtering 
            }
        }

        //[HttpPost]
        //public ActionResult Index(string searchTxt = "", string City = "")
        //{
        //    if (!string.IsNullOrEmpty(searchTxt))//is not null then go in
        //    {
        //        if (City == "city")
        //        {
        //            return View(MyList.myList.Where(x => x.City.ToLower().Contains(searchTxt.ToLower())).OrderBy(x => x.Name));
        //        }
        //        else if (City != "city")
        //        {
        //            return View(MyList.myList.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).OrderBy(x => x.City));
        //        }
        //    }
        //    else// is null
        //    {
        //        return View(MyList.myList);//all list with out filtering 
        //    }
        //    return View("Index");
        //}

        /*[HttpGet] we use this method as assistant to baind with RenderAction to display list of search
         *to fix problem in searching method no need to strict this method as get or post because index method use partialindex by to way get and post*/

        public ActionResult PrtialIndex(int id)
        {
            Person person = MyList.myList.SingleOrDefault(p => p.Id == id);
            return PartialView("_PartialPerson", person);
        }

        //public ActionResult Search(string src, string City)
        //{
        //    Person SrcPerson = new Person();
        //    if (City == "city")
        //    {
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _Create(Person newPerson)
        {
            newPerson.Id = MyList.myList.Last().Id + 1;

            MyList.myList.Add(newPerson);

            return PartialView("_PartialPerson", newPerson);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Person person = MyList.myList.SingleOrDefault(x => x.Id == id);
            return View(person);
        }
       
        [HttpPost]
        public ActionResult Edit(Person editPerson)
        {
            Person oldPerson = new Person();
            oldPerson = MyList.myList.SingleOrDefault(o => o.Id == editPerson.Id);
            oldPerson.Name = editPerson.Name;
            oldPerson.City = editPerson.City;
            //MyList.myList.Add(editPerson);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Person detPerson = new Person();

            detPerson = MyList.myList.SingleOrDefault(x => x.Id == id);

            return View(detPerson);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person detPerson = new Person();

            detPerson = MyList.myList.SingleOrDefault(x => x.Id == id);

            return View(detPerson);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            Person delPerson = new Person();

            delPerson = MyList.myList.SingleOrDefault(x => x.Id == id);
            
            MyList.myList.Remove(delPerson);
            return RedirectToAction("Index");
        }


    }
}
