using Comp213002SchedulerApplication.App_Code.controls.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Comp213002SchedulerApplication.App_Code.controls.task
{
    public class TestController : ApiController
    {
        // GET: Test
        Task[] products = new Task[]
        {
            new Task { Id = 1, Subject = "Tomato Soup", Description = "Groceries"},
            new Task { Id = 2, Subject = "Yo-yo", Description = "Toys"},
            new Task { Id = 3, Subject = "Hammer", Description = "Hardware"}
        };

        public IEnumerable<Task> GetAllProducts() {
            return products;
        }

        public IHttpActionResult GetProduct(int id) {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }
    }
}