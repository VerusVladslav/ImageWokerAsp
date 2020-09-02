using ImageWorkerASP.NET.Entity;
using ImageWorkerASP.NET.Images.Helper;
using ImageWorkerASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageWorkerASP.NET.Controllers
{
    public class ProductController : Controller
    {
        private readonly EFContext _context;
        public ProductController()
        {
            _context = new EFContext();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model, HttpPostedFileBase imageFile)
        {
            
            string filename = Guid.NewGuid().ToString() + ".jpg";
            string FullPathImage = Server.MapPath(Config.ProductImagePath) + "\\" + filename;

            using (Bitmap bmp = new Bitmap(imageFile.InputStream))
            {
                var readyImage = ImageWorker.CreateImage(bmp, 450, 450);
                if (readyImage != null)
                {
                    readyImage.Save(FullPathImage,ImageFormat.Jpeg);
                    Product product = new Product()
                    {
                        Name = model.Name,
                        Price = model.Price,
                        ImageName = filename

                    };
                    _context.products.Add(product);
                    _context.SaveChanges();
                }
                
            }
           

            return View();
        }

        public ActionResult List()
        {
            List<ProductViewModel> data = _context.products.Select(t => new ProductViewModel
            {
                Name = t.Name,
                Price = t.Price,
                LinkImage = Config.Domain+"Images/Product/"+t.ImageName
            }).ToList() ;
            return View(data);
        }




    }
}