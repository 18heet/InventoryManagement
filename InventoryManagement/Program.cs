
using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Repository;
using InventoryManagement.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InventoryManagementDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICustomers , CustomerRepository>();
builder.Services.AddScoped<IVendors , VendorRepository>();
builder.Services.AddScoped<IProducts , ProductRepository>();
builder.Services.AddScoped<IProductVariants , ProductVariantRepository>();
builder.Services.AddScoped<IPurchase , PurchaseRepository>();
builder.Services.AddScoped<IPurchaseReturn , PurchaseReturnRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
