using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace COMP_1640.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUpdate(int? id)
        {
            BookVM bookVM = new BookVM()
            {
                Categories = _unitOfWork.CategoryRepository.GetAllApproval().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Book = new Book()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(bookVM);
            }
            else
            {
                //Update
                bookVM.Book = _unitOfWork.BookRepository.Get(b => b.Id == id);
                return View(bookVM);
            }

        }
        [Authorize(Roles = SD.Role_StoreOwner)]

        [HttpPost]

        public IActionResult CreateUpdate(BookVM bookVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string bookPath = Path.Combine(wwwRootPath, @"images\books");

                    if (!string.IsNullOrEmpty(bookVM.Book.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, bookVM.Book.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    bookVM.Book.ImageUrl = @"\images\books\" + fileName;
                }
                if (bookVM.Book.Id == 0)
                {
                    _unitOfWork.BookRepository.Add(bookVM.Book);
                    TempData["success"] = "Book Created successfully";
                }
                else
                {
                    _unitOfWork.BookRepository.Update(bookVM.Book);
                    TempData["success"] = "Book Updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                BookVM bookVMNew = new BookVM()
                {
                    Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                    }),
                    Book = new Book()
                };
                return View(bookVMNew);
            }

        }
    }
}
