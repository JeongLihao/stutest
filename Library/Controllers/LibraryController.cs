using Library.Dto;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


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

    public IActionResult Create(){
        return View();
    }
    [HttpPost]
    public IActionResult Create(LibraryCreateDto input)
    {
        var enter = new Book{
            BookName = input.BookName,
            Mach = input.Mach
        };
        _db.Books.Add(enter);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(){
        return View();
    }

    public IActionResult Revise(){
        return View();
    }
}