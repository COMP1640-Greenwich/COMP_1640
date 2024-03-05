using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP_1640.Areas.Students.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Net;
using System.Net.Mail;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using COMP_1640.Data;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Utilities.Zlib;
using ICSharpCode.SharpZipLib.Zip;

namespace COMP_1640.Areas.Students.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDBContext _dbcontext;
        private IWebHostEnvironment _oIWebHostEnvironment;

        public AssignmentController(ApplicationDBContext context, IWebHostEnvironment oIWebHostEnvironment)
        {
            _dbcontext = context;
            _oIWebHostEnvironment = oIWebHostEnvironment;

        }

        //private async Task<IdentityUser> GetCurrentUser()
        //{
        //    return await _userManager.GetUserAsync(HttpContext.User);
        //}
        public IActionResult AllFiles()
        {
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Path.Combine(this._oIWebHostEnvironment.WebRootPath, "Uploads/Assigment/"));

            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }
        [Authorize(Roles = "Coordinator")]
        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this._oIWebHostEnvironment.WebRootPath, "Uploads/Assigment/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        [Authorize(Roles = "Coordinator")]
        public FileResult Download()
        {
            var webRoot = _oIWebHostEnvironment.WebRootPath;
            var fileName = "MyZip.zip";
            var tempOutput = webRoot + "/Uploads/Ideas/" + fileName;

            using (ZipOutputStream oZipOutputStream = new ZipOutputStream(System.IO.File.Create(tempOutput)))
            {
                oZipOutputStream.SetLevel(9);
                byte[] buffer = new byte[4096];

                var fileList = new List<string>();

                fileList.Add(webRoot + "/Uploads/Assigment/img1.jpg");

                for (int i = 0; i < fileList.Count; i++)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(fileList[i]));
                    entry.DateTime = DateTime.Now;
                    entry.IsUnicodeText = true;
                    oZipOutputStream.PutNextEntry(entry);

                    using (FileStream oFileStream = System.IO.File.OpenRead(fileList[i]))
                    {
                        int sourceByte;

                        do
                        {

                            sourceByte = oFileStream.Read(buffer, 0, buffer.Length);
                            oZipOutputStream.Write(buffer, 0, sourceByte);
                        } while (sourceByte > 0);
                    }
                }

                oZipOutputStream.Finish();
                oZipOutputStream.Flush();
                oZipOutputStream.Close();
            }

            byte[] finalResult = System.IO.File.ReadAllBytes(tempOutput);

            if (System.IO.File.Exists(tempOutput))
            {
                System.IO.File.Delete(tempOutput);
            }

            if (finalResult == null || !finalResult.Any())
            {
                throw new Exception(String.Format("Nothing Found"));

            }

            return File(finalResult, "application/zip", fileName);

        }
        [Authorize(Roles = "QA Coordinator")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _dbcontext.Assignment.Include(i => i.Id).Include(i => i.Status).Include(i => i.UserId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ideas/Details/5
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var idea = await _dbcontext.Assignment
                .Include(i => i.Id)
                .Include(i => i.Status)
                .Include(i => i.UserId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idea == null)
            {
                return NotFound();
            }

            return View(idea);
        }
    }
}
