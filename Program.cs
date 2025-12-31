using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Windows Trusted Connection string
string connectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pet;Integrated Security=True;TrustServerCertificate=True;Max Pool Size=50000;Pooling=True";
builder.Services.AddDbContext<PetContext>(options=>
options.UseSqlServer(connectionString));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


class Pet
{
    public int ID { get; set; }
    public string PetName { get; set; }="";
    public int Cutness { get; set; }
}

class PetContext:DbContext
{
    public PetContext(DbContextOptions<PetContext> options):base(options){}
    public DbSet<Pet> pets=> Set<Pet>();
}