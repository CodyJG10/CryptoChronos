using CryptoChronos.Server.Data;
using CryptoChronos.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using NFT.ContractInteraction.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("db")));

string storageConnectionString = builder.Configuration.GetConnectionString("storage_connection_string");
builder.Services.AddSingleton<ProfilePictureService>(new ProfilePictureService(storageConnectionString));

string ownerPrivateKey = builder.Configuration["OwnerPrivateKey"];
string pinataApiKey = builder.Configuration["PinataApiKey"];
string pinataApiSecret = builder.Configuration["PinataApiSecret"];
string listingFactoryAddress = builder.Configuration["ListingFactoryAddress"];
string nftAddress = builder.Configuration["NFTAddress"];
string auctionFactoryAddress = builder.Configuration["AuctionFactoryAddress"];
string url = builder.Configuration["URL"];
string chainId = builder.Configuration["ChainId"];
string escrowManagerAddress = builder.Configuration["EscrowManagerAddress"];

builder.Services.AddContractControllers(ownerPrivateKey, pinataApiKey, pinataApiSecret,
    listingFactoryAddress, nftAddress, auctionFactoryAddress, url, chainId, escrowManagerAddress);
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["ConnectionStrings:storage_connection_string:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["ConnectionStrings:storage_connection_string:queue"], preferMsi: true);
});

builder.Services.AddSingleton<EmailSender>(new EmailSender(builder.Configuration["SendGrid_Key"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
