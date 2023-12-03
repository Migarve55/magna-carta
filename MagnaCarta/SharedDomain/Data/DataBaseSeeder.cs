using Microsoft.AspNetCore.Identity;
using SharedDomain.Entities;
using SharedDomain.Services;

namespace SharedDomain.Data;

public class DataBaseSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITablesService _tablesService;
    private readonly IProductsService _productsService;

    public DataBaseSeeder(
        RoleManager<IdentityRole> roleManager,
        UserManager<IdentityUser> userManager,
        ITablesService tablesService,
        IProductsService productsService)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _tablesService = tablesService;
        _productsService = productsService;
    }

    public async Task SeedDatabase()
    {
        await SeedUsersAndRoles();
        await SeedData();
    }

    private async Task SeedUsersAndRoles()
    {
        const string adminRole = "admin";
        const string cookRole = "cook";
        const string waiterRole = "waiter";
        await SeedRole(adminRole);
        await SeedRole(cookRole);
        await SeedRole(waiterRole);
        await SeedUser("admin@email.com", "Adm1strator1!", adminRole);
        await SeedUser("cook@email.com", "C0okingIsKool!", cookRole);
        await SeedUser("waiter@email.com", "Wa1t3rMaster!", waiterRole);
    }

    private async Task SeedRole(string roleName)
    {
        bool roleExists = await _roleManager.RoleExistsAsync("Administrator");
        if (!roleExists)
        {
            var role = new IdentityRole()
            {
                Name = roleName
            };
            await _roleManager.CreateAsync(role);
        }
    }

    private async Task SeedUser(string email, string password, params string[] roles)
    {
        bool userExists = await _userManager.FindByEmailAsync(email) != null;
        if (!userExists)
        {
            var user = new IdentityUser()
            {
                UserName = email,
                Email = email
            };
            var identityResult = await _userManager.CreateAsync(user, password);
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, roles);
            }
        }
    }

    private async Task SeedData()
    {
        IReadOnlyCollection<Table> tables = await _tablesService.GetAllTables();
        if (!tables.Any())
        {
            await CreateTable("Mesa 1");
            await CreateTable("Mesa 2");
            await CreateTable("Mesa 3");
            await CreateTable("Mesa 4");
            await CreateTable("Mesa 5");
            await CreateTable("Mesa 6");
        }

        IReadOnlyCollection<Product> products = await _productsService.GetAllProducts();
        if (!products.Any())
        {
            await CreateProduct("Krabby Patty", 12.30m);
            await CreateProduct("Salchipapas", 7.99m);
            await CreateProduct("Khlav Kalash", 2.50m);
            await CreateProduct("Cachopo de Dromedario", 22.25m);
            await CreateProduct("Haggis", 13.99m);
            await CreateProduct("Croquetas", 9.00m);
            await CreateProduct("Cerveza Duff", 6.25m);
            await CreateProduct("Leaf Lovers Special", 3.70m);
        }
    }

    private async Task CreateTable(string name)
    {
        Table table = new Table
        {
            Name = name
        };
        await _tablesService.AddTable(table);
    }

    private async Task CreateProduct(string name, decimal price)
    {
        Product product = new Product
        {
            Name = name,
            Price = price
        };
        await _productsService.AddProduct(product);
    }
}