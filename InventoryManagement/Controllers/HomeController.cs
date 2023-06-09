using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Entities.View_Models;
using InventoryManagement.Models;
using InventoryManagement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomers _customer;
        private readonly IVendors _vendors;
        private readonly IProducts _products;
        private readonly IProductVariants _productVariant;
        private readonly IPurchase _purchase;
        private readonly IPurchaseReturn _purchaseReturn;
        public readonly int temp;
        public HomeController(ILogger<HomeController> logger, IVendors vendors, ICustomers customers, IProducts products, IProductVariants productVariant, IPurchase purchase , IPurchaseReturn purchaseReturn)
        {
            _logger = logger;
            _vendors = vendors;
            _customer = customers;
            _products = products;
            _purchase = purchase;
            _purchaseReturn = purchaseReturn;
            _productVariant = productVariant;
        }
        #region Common
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region Customer
        public IActionResult UserForm()
        {
            UserVM user = new UserVM();
            return View("AddUser", user);
        }
        [HttpPost]
        public IActionResult UserFormPost(UserVM user)
        {
            if (user.userStatus == 0)
            {
                _vendors.addVendors(user.UserName, user.ContactNumber);
            }
            else
            {
                _customer.addCustomer(user.UserName, user.ContactNumber);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GetCustomers()
        {
            try
            {
                List<Customer> customers = _customer.getCustomers();
                return View("CustomerList", customers);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        #endregion

        #region Vendor
        public IActionResult GetVendors()
        {
            try
            {
                List<Vendor> vendors = _vendors.getVendors();
                return View("VendorList", vendors);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        #endregion

        #region Products
        public IActionResult ProductForm()
        {
            ProductVm product = new ProductVm();
            return View("AddProduct", product);
        }
        [HttpPost]
        public IActionResult ProductPost(ProductVm product)
        {
            _products.addProducts(product.ProductName, product.ProductStatus);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GetProducts()
        {
            try
            {
                List<Product> products = _products.getProducts();
                return View("ProductList", products);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        #endregion

        #region ProductVariant
        public IActionResult ProductVariantForm(int productId)
        {
            ProductVariantVM productVariantVM = new ProductVariantVM();
            productVariantVM.products = _products.getProducts();

            return View("AddProductVariant", productVariantVM);
        }
        [HttpPost]
        public IActionResult ProductVariantPost(ProductVariantVM pVariantVM)
        {
            _productVariant.addProductVariants(pVariantVM.ProductID, pVariantVM.measurementType, pVariantVM.MeasurementAmount, pVariantVM.PurchaseCost, pVariantVM.status);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> GetProductVariants(int id)
        {
            try
            {
                List<ProductVariantVM> productVariants = await _productVariant.getProductVariants(id);

                return View("ProductVariantList", productVariants);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
        #endregion

        #region Purchase

        public async Task<IActionResult> GetPurchases()
        {
            List<PurchaseVM> purchases =await _purchase.getPurchases();
            return View("PurchaseList" , purchases);
        }

        public async Task<IActionResult> addPurchase()
        {
            PurchaseVM purchaseVM = new PurchaseVM();

            purchaseVM.vendors =  _vendors.getVendors();
            purchaseVM.products = await _productVariant.getProductVariants(-20);

            return View("AddPurchase" , purchaseVM);            
        }

        [HttpPost]
        public IActionResult addPurchasePost(PurchaseVM purchase)
        {
            int totalPurchaseCost = purchase.Units * purchase.PurchaseCost;
            _purchase.addPurchase(purchase.VendorId , purchase.ProductVariantId , purchase.Units , totalPurchaseCost);
            return RedirectToAction("Index" , "Home");
        }
        #endregion

        #region PurchaseReturn

        public IActionResult ReturnPurchase(int productVarientId , int purchaseId , int purchasedUnits)
        {
            _purchaseReturn.purchaseReturn(productVarientId , purchaseId , purchasedUnits);
            return RedirectToAction("GetPurchases" , "Home");
        }

        #endregion

        #region

        public async Task<IActionResult> OrderForm()
        {
            var item1 = _customer.getCustomers();
            var item2 = await _productVariant.getProductVariants(-20);
            Tuple<List<Customer> , List<ProductVariantVM> , OrderVM> tuple = new Tuple<List<Customer> ,List<ProductVariantVM>, OrderVM>(item1, item2,null); 

            return View("AddOrder" , tuple);
        }
        [HttpPost]
        public IActionResult OrderPost(OrderVM order)
        {
            _purchase.addOrder(order.CustomerId , order.Total , order.ProductVariantId , order.PurchasedUnits);
            return RedirectToAction("Index" , "Home");
        } 
        #endregion
    }
}