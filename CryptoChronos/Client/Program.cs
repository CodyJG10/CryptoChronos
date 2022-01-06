using CryptoChronos.Client;
using CryptoChronos.Shared.Services;
using MetaMask.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NFT.ContractInteraction.Client.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMetaMaskBlazor();

builder.Services.AddContractControllers();

var baseAddress = builder.Configuration["BaseAddress"];

builder.Services.AddHttpClient<IUserService, UserService>(options => options.BaseAddress = new Uri(baseAddress + "api/Users/"));
builder.Services.AddHttpClient<IAuctionService, AuctionService>(options => options.BaseAddress = new Uri(baseAddress + "api/Auctions/"));
builder.Services.AddHttpClient<IContractInteractionService, ContractInteractionService>(options => options.BaseAddress = new Uri(baseAddress + "api/ContractInteraction/"));
builder.Services.AddHttpClient<EmailService>(options => options.BaseAddress = new Uri(baseAddress + "api/Email/"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
