namespace Library.Controllers;
using Library.Dto;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class BookTypeController : Controller
{
    private readonly BookDbContext bookDb;

    public BookTypeController()
    {
        bookDb = new BookDbContext();
    }
    public IActionResult Index(string keyword){
        if(string.IsNullOrEmpty(keyword)){
            var list = bookDb.BookTypes.ToList();
            return View(list);
        }
        var res = bookDb.BookTypes.Where(x => x.BookTypes.Contains(keyword));
        return View(res);
    }

    public IActionResult Create(){
        return View();
    }
    [HttpPost]
    public IActionResult Create(BookTypeCreateDto input)
    {
       var ent = new BookType
       {
            BookTypes = input.BookType
       };
       bookDb.BookTypes.Add(ent);
       bookDb.SaveChanges();
       return RedirectToAction("Index");
       
    }
    public IActionResult Delete(int Id){
        var obj = bookDb.BookTypes.FirstOrDefault(x => x.Id==Id);
        return View();
    }
    [HttpPost]
    public IActionResult Delete1(int Id){
        var obj = bookDb.BookTypes.FirstOrDefault(x => x.Id == Id);
        if(obj == null){
            return NotFound();
        }
        bookDb.BookTypes.Remove(obj);
        bookDb.SaveChanges();
        return RedirectToAction("Index");


    }
    public IActionResult Result(){
        return View();
    }
}