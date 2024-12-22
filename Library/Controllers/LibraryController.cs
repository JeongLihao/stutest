using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class LibraryController:Controller
{
    private readonly BookDbContext _db;

    public LibraryController()
    {
        _db = new BookDbContext();
    }
    public IActionResult Index(string keyword){
        if (string.IsNullOrEmpty(keyword))
        {
            var list = _db.Books.ToList();
            return View(list);
        }
        var res = _db.Books.Where(x=>x.BookName.Contains(keyword));

        return View(res);
    }

    public IActionResult Add(){
        return View();
    }

    public IActionResult Delete(){
        return View();
    }

    public IActionResult Revise(){
        return View();
    }
}