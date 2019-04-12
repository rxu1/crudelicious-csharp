using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
      private crudeliciousContext dbContext; 
      public HomeController(crudeliciousContext context)
      {
        dbContext = context; 
      }

      [HttpGet("")]
      public IActionResult Index()
      {
        List<Dishes> AllDishesUnsorted = dbContext.Dishes.ToList(); 
        List<Dishes> AllDishes = AllDishesUnsorted.OrderByDescending(d => d.CreatedAt).Take(5).ToList();
        // List<Dishes> AllDishes = dbContext.Dishes
        //   .OrderbyDescending(d => d.CreatedAt)
        //   .ToList()
        //   List<Dishes> EnteredDishes = dbContext.Dishes.Where(d => d.)
        return View(AllDishes);
      }

      [HttpGet("new")]
      public IActionResult ShowAdd()
      {
        return View("AddDish");
      }

      [HttpGet("{dishid}")]
      public IActionResult ShowDetails(int dishid)
      {
        Dishes OneDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishid);
        return View("DishDetails", OneDish);
      }

      [HttpGet("edit/{id}")]
      public IActionResult ShowEdit(int id)
      {
        Dishes EditedDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
        return View("EditDish", EditedDish);
      }

      [HttpPost("update/{id}")]
      public IActionResult Edit(Dishes dish, int id)
      {
        if(ModelState.IsValid)
        {
          Dishes RetrievedDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == id);
          RetrievedDish.Name = dish.Name;
          RetrievedDish.Chef = dish.Chef; 
          RetrievedDish.Tastiness = dish.Tastiness; 
          RetrievedDish.Calories = dish.Calories; 
          RetrievedDish.Description = dish.Description;  
          RetrievedDish.UpdatedAt = DateTime.Now;
          
          dbContext.SaveChanges();
          return RedirectToAction("Index");
        }
        else
        {
          return View("EditDish");
        }
      }

      [HttpPost("dish/new")]
      public IActionResult Add(Dishes newDish)
      {
        if(ModelState.IsValid)
        {
          dbContext.Add(newDish);
          dbContext.SaveChanges();
          return RedirectToAction("Index");
        }
        else
        {
          return View("AddDish");
        }
      }

      [HttpGet("delete/{id}")]
      public IActionResult Delete(int id)
      {
        Dishes RetrievedDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == id);
        dbContext.Dishes.Remove(RetrievedDish);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}
