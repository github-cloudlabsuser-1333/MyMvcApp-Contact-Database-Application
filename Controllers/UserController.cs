using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

    // GET: User
    public ActionResult Index()
    {
        return View(userlist); // Return a view with the user list
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return a 404 if the user is not found
        }
        return View(user); // Return a view with the user details
    }

    // GET: User/Create
    public ActionResult Create()
    {
        return View(); // Return a view for creating a new user
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1; // Generate a new ID
            userlist.Add(user); // Add the new user to the list
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }
        return View(user); // Return the view with validation errors
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return a 404 if the user is not found
        }
        return View(user); // Return the Edit view with the user details
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        var existingUser = userlist.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            return NotFound(); // Return a 404 if the user is not found
        }

        if (ModelState.IsValid)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }
        return View(user); // Return the view with validation errors
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return a 404 if the user is not found
        }
        return View(user); // Return the Delete confirmation view
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return a 404 if the user is not found
        }

        userlist.Remove(user); // Remove the user from the list
        return RedirectToAction(nameof(Index)); // Redirect to the Index action
    }
}
