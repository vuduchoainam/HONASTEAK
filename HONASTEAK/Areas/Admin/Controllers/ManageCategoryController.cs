using HONASTEAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HONASTEAK.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageCategoryController : BaseController<Category>
    {
        // GET: Admin/ManageCategory
        public ActionResult Index()
        {
            var categories = GetAll().ToList();
            return View(categories);
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection, Category category)
        {
            List<string> errors = new List<string>();
            try
            {
                var categoryname = formCollection["categoryname"];
                var slug = formCollection["slug"];
                var description = formCollection["description"];
                var parentid = formCollection["parentid"];
                var status = formCollection["status"];
                var checkSlug = Context.Categories.Count(x => x.Slug == slug);
                if (string.IsNullOrEmpty(categoryname))
                {
                    errors.Add("Chưa nhập tên danh mục");
                }
                if (checkSlug > 0)
                {
                    errors.Add("Slug đã tồn tại");
                }
                if (string.IsNullOrEmpty(description))
                {
                    errors.Add("Chưa nhập mô tả danh mục");
                }
                if (errors.Count == 0)
                {
                    Add(category);
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            TempData["Errors"] = errors;

            return RedirectToAction("Index", "ManageCategory");
        }
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "ManageCategory");
            }
            var checkId = GetById(Id.Value);
            if (checkId == null)
            {
                return RedirectToAction("Index", "ManageCategory");
            }
            Category category = GetById(Id.Value);
            ViewBag.Categories = GetAll().ToList();
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            List<string> errors = new List<string>();
            try
            {
                var categoryid = formCollection["categoryid"];
                var categoryname = formCollection["categoryname"];
                var slug = formCollection["slug"];
                var description = formCollection["description"];
                var status = formCollection["status"];
                var checkSlug = Context.Categories.Count(x => x.Slug == slug);
                var getCategoryContainsSlug = Context.Categories.FirstOrDefault(x => x.Slug == slug);
                if (string.IsNullOrEmpty(categoryname))
                {
                    errors.Add("Chưa nhập tên danh mục");
                }
                if (checkSlug > 0 && getCategoryContainsSlug.CategoryId != Convert.ToInt32(categoryid))
                {
                    errors.Add("Slug đã tồn tại");
                }
                if (string.IsNullOrEmpty(description))
                {
                    errors.Add("Chưa nhập mô tả danh mục");
                }
                if (errors.Count == 0)
                {
                    var category = GetById(Int32.Parse(formCollection["Id"]));
                    category.CategoryName = categoryname;
                    category.Slug = slug;
                    category.Status = status;
                    category.Description = description;
                    category.UpdatedAt = DateTime.Now;
                    Update(category);
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            TempData["Errors"] = errors;
            return RedirectToAction("Index", "ManageCategory");
        }
        [HttpPost]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return Json(new { success = false, message = "ID không hợp lệ" });
            }
            Category category = GetById(Id.Value);
            if (category == null)
            {
                return Json(new { success = false, message = "Danh mục không tồn tại" });
            }
            Remove(category);
            return Json(new { success = true, message = "Xóa danh mục thành công" });
        }
    }
}