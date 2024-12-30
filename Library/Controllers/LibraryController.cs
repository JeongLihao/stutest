using Library.Dto;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace Library.Controllers;

public class LibraryController : Controller
{
    private readonly BookDbContext _db;

    public LibraryController()
    {
        _db = new BookDbContext();
    }
    public IActionResult Index(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            var list = _db.Books.ToList();
            return View(list);
        }
        var res = _db.Books.Where(x => x.BookName.Contains(keyword));

        return View(res);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(LibraryCreateDto input)
    {
        var enter = new Book
        {
            BookName = input.BookName,
            Mach = input.Mach
        };
        _db.Books.Add(enter);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Revise(int id)
    {
        var obj = _db.Books.FirstOrDefault(x=> x.Id ==id);
        return View(obj);
    }
    [HttpPost]
    public IActionResult Revise(Book input){
         var obj = _db.Books.FirstOrDefault(x=> x.Id == input.Id);
         if(obj == null){
            return NotFound();
         }
         obj.BookName = input.BookName;
         obj.Mach = input.Mach;
        _db.Books.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");

    }
    public IActionResult Delete(int id)
    {   
        var obj = _db.Books.FirstOrDefault(x=>x.Id==id);
        return View(obj);
    }
    public IActionResult Delete1(int Id)
    {
         var obj = _db.Books.FirstOrDefault(x=> x.Id == Id);
         if(obj == null){
            return NotFound();
         }
        _db.Books.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


}