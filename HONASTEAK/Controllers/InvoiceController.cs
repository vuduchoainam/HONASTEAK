using HONASTEAK.Models;
using HONASTEAK.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace HONASTEAK.Controllers
{
    public class InvoiceController : BaseController<Invoice>
    {
        private readonly CartManager _cartManager;
        public InvoiceController()
        {
            _cartManager = new CartManager();
        }
        public static bool ValidateVNPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Replace("+84", "0");
            Regex regex = new Regex(@"^(0)(86|96|97|98|32|33|34|35|36|37|38|39|91|94|83|84|85|81|82|90|93|70|79|77|76|78|92|56|58|99|59|55|87)\d{7}$");
            return regex.IsMatch(phoneNumber);
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()).ToUpper();
        }
        // GET: Order
        public ActionResult CheckOut()
        {
            var cart = _cartManager.GetCartItems();
            if (cart.Count() < 1)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Carts = cart;
            return View();
        }
        [HttpPost]
        public ActionResult CheckOut(FormCollection formCollection)
        {
            List<string> errors = new List<string>();
            try
            {
                var name = formCollection["name"];
                var phoneNumber = formCollection["phoneNumber"];
                var address = formCollection["address"];
                var payment = formCollection["payment"];
                var note = formCollection["note"];
                var UserId = formCollection["UserId"];

                if (string.IsNullOrEmpty(name))
                {
                    errors.Add("Vui lòng nhập tên.");
                }

                if (string.IsNullOrEmpty(address))
                {
                    errors.Add("Vui lòng nhập địa chỉ.");
                }

                if (ValidateVNPhoneNumber(phoneNumber) != true)
                {
                    errors.Add("Số điện thoại không hợp lệ.");
                }

                switch (payment)
                {
                    case "cash":
                    case "momo":
                    case "vnpay":
                        break;
                    default:
                        errors.Add("Phương thức thanh toán không hợp lệ.");
                        break;
                }

                if (errors.Count == 0)
                {
                    Invoice invoice = new Invoice();

                    string code = RandomString(12);
                    invoice.Code = code;
                    invoice.CustomerName = name;
                    invoice.PhoneNumber = phoneNumber;
                    invoice.Address = address;
                    invoice.Payment = payment;
                    invoice.Note = note;
                    invoice.UserId = UserId;
                    invoice.Status = "1";

                    //Add(order);
                    Session["orderCode"] = code;
                    // Lấy tổng tiền từ giỏ hàng
                    var cart = _cartManager.GetCartItems();
                    decimal totalOrder = 0;
                    foreach (var item in cart)
                    {
                        var itemTotal = item.Price; // giá sản phẩm
                        itemTotal += item.PropertyProduct.Price; // giá của thuộc tính (size)
                        foreach (var option in item.Options)
                        {
                            itemTotal += option.Price; // giá của tùy chọn (topping)
                        }
                        totalOrder += itemTotal;
                    }
                    invoice.Total = totalOrder;
                    Session["order"] = invoice;
                    switch (payment)
                    {
                        case "momo":
                            return RedirectToAction("MomoPay", "Pay");
                        case "vnpay":
                            return RedirectToAction("VNPay", "Pay");
                        default:
                            totalOrder = 0;
                            foreach (var item in cart)
                            {
                                var itemTotal = item.Price;
                                itemTotal += item.PropertyProduct.Price;
                                string propertyProduct = "" + item.PropertyProduct.Name + " - " + item.PropertyProduct.Price.ToString("N0") + "đ";
                                string optionProduct = "";
                                foreach (var option in item.Options)
                                {
                                    itemTotal += option.Price;
                                    optionProduct += "" + option.Name + " - " + option.Price.ToString("N0") + "đ\n";
                                }
                                InvoiceDetail invoiceDetail = new InvoiceDetail();
                                invoiceDetail.Invoice = invoice;
                                invoiceDetail.ProductId = item.ProductId;
                                invoiceDetail.ProductName = item.ProductName;
                                invoiceDetail.Price = item.Price;
                                invoiceDetail.Total = itemTotal;
                                invoiceDetail.Quantity = item.Quantity;
                                invoiceDetail.PropertyProduct = propertyProduct;
                                invoiceDetail.OptionProduct = optionProduct;
                                totalOrder += itemTotal;
                                Context.InvoiceDetails.Add(invoiceDetail);
                                Context.SaveChanges();
                            }
                            //Cập nhật tổng số tiền
                            invoice.Total = totalOrder;
                            Update(invoice);
                            _cartManager.ClearCart();
                            break;
                    }
                    return RedirectToAction("CompleteOrder", "Invoice");
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }
            TempData["Errors"] = errors;
            return RedirectToAction("CheckOut", "Invoice");
        }
        [Route("Invoice/Search")]
        public ActionResult Search()
        {
            return View();
        }
        [Route("Invoice/Search/{Code}")]
        public ActionResult Search(string Code)
        {

            if (Code == null)
            {
                return View();
            }
            var invoice = Context.Invoices.FirstOrDefault(p => p.Code == Code);
            //var find =  from o in Context.Orders join od in Context.OrderDetails on o.Id equals od.Id where o.Code== orderCode
            //            select o;


            if (invoice != null)
            {
                // Xóa OrderCode
                Session["Code"] = null;
                var invoiceDetails = Context.InvoiceDetails.Where(p => p.Invoice.Code == Code).ToList();
                ViewBag.OrderDetails = invoiceDetails;
                return View(invoice);
            }
            return View();
        }

        public ActionResult CompleteOrder()
        {
            return View();
        }
    }
}