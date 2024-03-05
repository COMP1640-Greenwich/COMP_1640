//using COMP_1640.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace COMP_1640.Controllers
//{
//    public class AssignmentController : Controller
//    {
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        public AssignmentController( IWebHostEnvironment webHostEnvironment)
//        {
//            _webHostEnvironment = webHostEnvironment;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult Create(int? id)
//        {
//            Assignment assignment = new Assignment();
//            if (id == null || id == 0)
//            {
//                //Create
//                return View(assignment);
//            }
//            else
//            {
//                return View(assignment);
//            }

//        }
//        [HttpPost]

//        public IActionResult Create(Assignment assignment, IFormFile? file)
//        {

//            if (ModelState.IsValid)
//            {
//                string wwwRootPath = _webHostEnvironment.WebRootPath;
//                if (file != null)
//                {
//                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//                    string bookPath = Path.Combine(wwwRootPath, @"images\assignments");

//                    if (!string.IsNullOrEmpty(assignment.UrlImage))
//                    {
//                        var oldImagePath = Path.Combine(wwwRootPath, assignment.UrlImage.TrimStart('\\'));
//                        if (System.IO.File.Exists(oldImagePath))
//                        {
//                            System.IO.File.Delete(oldImagePath);
//                        }
//                    }
//                    using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
//                    {
//                        file.CopyTo(fileStream);
//                    }
//                    assignment.UrlImage = @"\images\assignments\" + fileName;
//                }
//                if (bookVM.Book.Id == 0)
//                {
//                    _unitOfWork.BookRepository.Add(bookVM.Book);
//                    TempData["success"] = "Book Created successfully";
//                }
//                else
//                {
//                    _unitOfWork.BookRepository.Update(bookVM.Book);
//                    TempData["success"] = "Book Updated successfully";
//                }

//                _unitOfWork.Save();
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                BookVM bookVMNew = new BookVM()
//                {
//                    Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
//                    {
//                        Text = c.Name,
//                        Value = c.Id.ToString(),
//                    }),
//                    Book = new Book()
//                };
//                return View(bookVMNew);
//            }

//        }
//    }
//}
