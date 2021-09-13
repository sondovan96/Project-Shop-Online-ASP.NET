using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectShopASP.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int productID, int quantity)
        {
            PRODUCT product = new PRODUCT();
            using (var context = new ProjectASPEntities())
            {
                product = context.PRODUCTs.Where(x => x.id_product == productID).SingleOrDefault();
            }

            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.id_product == productID))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.id_product == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index", "Home");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.id_product == item.Product.id_product);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new { status = true });
        }
        public JsonResult DeleteCartItem(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.id_product == id);
            Session[CartSession] = sessionCart;
            return Json(new { status = true });
        }
        public ActionResult Checkout()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Checkout(string name, string email, string phone, string address)
        {
            if (name != "" && email != "" && phone != "" && address != "")
            {
                var cart = new CART();
                cart.created_date = DateTime.Now;
                cart.address = address;
                cart.phone = phone;
                cart.name = name;
                cart.email = email;
                cart.status = "Chờ Xác Nhận";
                try
                {
                    using (var context = new ProjectASPEntities())
                    {
                        context.CARTs.Add(cart);
                        context.SaveChanges();
                    }
                    var id = cart.id_cart;
                    var cartItem = (List<CartItem>)Session[CartSession];
                    double total = 0;
                    foreach (var item in cartItem)
                    {
                        var cartDetail = new CART_DETAIL();
                        cartDetail.id_product = item.Product.id_product;
                        cartDetail.id_cart = id;
                        cartDetail.price = item.Product.price;
                        cartDetail.quantity = item.Quantity;
                        using (var context = new ProjectASPEntities())
                        {
                            context.CART_DETAIL.Add(cartDetail);
                            context.SaveChanges();
                        }
                        total += (item.Product.price.GetValueOrDefault(0) * item.Quantity);
                    }

                    //string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));

                    //content = content.Replace("{{CustomerName}}", shipName);
                    //content = content.Replace("{{Phone}}", mobile);
                    //content = content.Replace("{{Email}}", email);
                    //content = content.Replace("{{Address}}", address);
                    //content = content.Replace("{{Total}}", total.ToString("N0"));
                    //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    //new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                    //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
                    Session[CartSession] = null;
                }
                catch (Exception ex)
                {
                    //ghi log
                    return Redirect("/error");
                }
            }
            else
            {
                return Redirect("/checkout");
            }

            return Redirect("/success");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}