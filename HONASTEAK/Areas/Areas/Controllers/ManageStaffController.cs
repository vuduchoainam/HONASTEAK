using HONASTEAK.Controllers;
using HONASTEAK.Models;
using HONASTEAK.Models.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HONASTEAK.Areas.Areas.Controllers
{
    public class ManageStaffController : BaseController<Staff>
    {
        public ActionResult Index()
        {
            var staffs = GetAll().ToList();
            return View(staffs);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection formCollection, Staff staff)
        {
            List<string> errors = new List<string>();
            try
            {
                var Name = formCollection["name"];
                var Gender = formCollection["gender"];
                var DateOfBirth = formCollection["dateofbirth"];
                var Position = formCollection["position"];
                var Status = formCollection["status"];
                if (string.IsNullOrEmpty(Name))
                {
                    errors.Add("Chưa nhập tên nhân viên");
                }
                if (string.IsNullOrEmpty(Gender))
                {
                    errors.Add("Giới tính không được để trống");
                }
                if (string.IsNullOrEmpty(DateOfBirth))
                {
                    errors.Add("Ngày sinh không được để trống");
                }
                if (string.IsNullOrEmpty(Position))
                {
                    errors.Add("Chức vụ không được để trống");
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            TempData["Errors"] = errors;

            return RedirectToAction("Index", "ManageStaff");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "ManageStaff");
            }
            var checkId = GetById(Id.Value);
            if (checkId == null)
            {
                return RedirectToAction("Index", "ManageStaff");
            }
            Staff staff = GetById(Id.Value);
            return View(staff);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            List<string> errors = new List<string>();
            try
            {
                var Name = formCollection["name"];
                var Gender = formCollection["gender"];
                var DateOfBirth = formCollection["dateofbirth"];
                var Position = formCollection["position"];
                var Status = formCollection["status"];
                var Author = formCollection["Author"];
                var Image = formCollection["Image"];
                if (string.IsNullOrEmpty(Name))
                {
                    errors.Add("Chưa nhập tên nhân viên");
                }
                if (string.IsNullOrEmpty(Gender))
                {
                    errors.Add("Giới tính không được để trống");
                }
                if (string.IsNullOrEmpty(DateOfBirth))
                {
                    errors.Add("Ngày sinh không được để trống");
                }
                if (string.IsNullOrEmpty(Position))
                {
                    errors.Add("Chức vụ không được để trống");
                }
                if (errors.Count == 0)
                {
                    var staff = GetById(Int32.Parse(formCollection["Id"]));
                    staff.Name = Name;
                    staff.Gender = Gender;
                    DateTime dateOfBirth;
                    if (DateTime.TryParseExact(formCollection["DateOfBirth"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
                    {
                        staff.DateOfBirth = dateOfBirth;
                    }
                    else
                    {
                        errors.Add("Ngày sinh không hợp lệ.");
                    }
                    staff.Position = Position;
                    staff.Status = Status;
                    Update(staff);
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            TempData["Errors"] = errors;
            return RedirectToAction("Index", "ManageBlog");
        }
    }
}