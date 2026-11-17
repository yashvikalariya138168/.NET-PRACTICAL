using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practical8.Models;
using Practical8.Services;

namespace Practical8.Controllers
{
    public class ProductsController : Controller
    {
            ProductService service = new ProductService();

            // READ: Display all products
            public ActionResult Index()
            {
                return View(service.GetAll());
            }

            // CREATE: Display form
            public ActionResult Create()
            {
                return View();
            }

            // CREATE: Save product
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Product product)
            {
                if (ModelState.IsValid)
                {
                    service.Add(product);
                    return RedirectToAction("Index");
                }

                return View(product);
            }

            // UPDATE: Display edit form
            public ActionResult Edit(int id)
            {
                Product product = service.GetById(id);

                if (product == null)
                    return HttpNotFound();

                return View(product);
            }

            // UPDATE: Save changes
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Product product)
            {
                if (ModelState.IsValid)
                {
                    service.Update(product);
                    return RedirectToAction("Index");
                }

                return View(product);
            }

            // DELETE: Remove product
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id)
            {
                service.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
