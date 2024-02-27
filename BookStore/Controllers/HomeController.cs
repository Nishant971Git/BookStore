using BookStore.Interface;
using BookStore.ViewModal;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookInv _bookinv;

        public HomeController(ILogger<HomeController> logger,IBookInv __bookInv)
        {
            _logger = logger;
            _bookinv = __bookInv;
        }

        public IActionResult BookStoreInv()
        {

            return View();
        }

        [Route("get-book-inventory-list")]
        public IActionResult GetBookStoreInvList(BookData book)
        {

            
            var (result, succeeded) = _bookinv.BookInvList();

            var jsondata = new { result };
            return Ok(jsondata);
        }

        [Route("delete-book-inventory-list/{id:int}")]
        public IActionResult DeleteInventoryList(int id)
        {
            var (result,succeeded) = _bookinv.DeleteInvList(id);
            return RedirectToAction("BookStoreInv");
           
        }


        

        [Route("get-book-inv-data/{id:int}")]
        public IActionResult UpdateBookInvData(int id)
        {
             var (result, succeeded) = _bookinv.GetBookInvList(id);
            
           ViewBag.Data = result.Value;
            return View();
        }


        
        public IActionResult UpdateBookDataList(BookData book)
        {
            var (result, succeeded) = _bookinv.UpdateBookInvList(book);
            return RedirectToAction("BookStoreInv");

        }

       

        
        public IActionResult SaveNewBookDetailsData(BookData book)
        {
            var (result, succeeded) = _bookinv.AddNewBookDataList(book);

            return RedirectToAction("BookStoreInv");
        }



    }
}