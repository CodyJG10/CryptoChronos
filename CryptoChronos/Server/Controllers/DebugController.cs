using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using NFT.ContractInteraction.Server;

namespace CryptoChronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebugController : Controller
    {
        private NftServerService _nftService;

        public DebugController(NftServerService nftService)
        {
            _nftService = nftService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("MintDebugWatches")]
        public async Task<IActionResult> Debug()
        {
            string address = "0x8060519CEef76c676eF7DF6F716839a1f28dea9f";

            var imageUrls = new Dictionary<string, string>()
            {
                {"Audemars", "audemars_piguet.jpg"},
                {"Blancpain", "blancpain.jpg"},
                {"Frederique", "FREDERIQUE CONSTANT.png"},
                {"HarryWinston", "harry_winston.jpg"},
                {"Omega", "omega.png"},
                {"Piaget", "piaget.jpg"},
                {"Tudor", "tudor.jpg"},
                {"Zenith", "zenith.jpg"},
                {"Longiness",  "longiness_hydroquest.png" }
            };

            var imageBytes = new Dictionary<string, byte[]>();

            foreach (KeyValuePair<string, string> kvp in imageUrls)
            {
                string name = kvp.Key;
                string uri = kvp.Value;

                imageBytes[name] = await System.IO.File.ReadAllBytesAsync("wwwroot/images/" + uri);
            }

            new MintNftModel[]
            {
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Audemars"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Audemars Piguet",
                        Model = "Royal Oak",
                        Serial = "2td7fK2h",
                        Metadata = new List<Metadata>(),
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Blancpain"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Blancpain",
                        Model = "Villeret Ultra Slim Automatic",
                        Serial = "5LjsTUJx",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Model",
                                Value = "6223-1127-55B"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Frederique"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Frederique Constant",
                        Model = "Classics",
                        Serial = "3UJ8jSfM",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Dial Material",
                                Value = "Silver"
                            },
                            new Metadata()
                            {
                                Key = "Bracelet",
                                Value = "Leather Ladies"
                            },
                            new Metadata()
                            {
                                Key = "FC",
                                Value = "220MS3B6"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["HarryWinston"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Harry Winston",
                        Model = "18K White Gold Men'stainless",
                        Serial = "4YPbptYY",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Model",
                                Value = "MIDAHD42WW002"
                            },
                            new Metadata()
                            {
                                Key = "Color",
                                Value = "Midnight"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Omega"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Omega",
                        Model = "Seamaster Aqua Terra",
                        Serial = "8UBbLviA",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Dimensions",
                                Value = "50MM"
                            },
                            new Metadata()
                            {
                                Key = "Movement",
                                Value = "Automatic"
                            },
                            new Metadata()
                            {
                                Key = "Dial Color",
                                Value = "Blue"
                            },
                            new Metadata()
                            {
                                Key = "Case Material",
                                Value = "Stainless Steel"
                            },
                            new Metadata()
                            {
                                Key = "Water Resistance",
                                Value = "50 Meters"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Piaget"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Piaget",
                        Model = "Polo S",
                        Serial = "3muKRuGe",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Color",
                                Value = "Silver Blue"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Tudor"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Tudor",
                        Model = "Heritage",
                        Serial = "8H2PtMME",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Dimensions",
                                Value = "41MM"
                            },
                            new Metadata()
                            {
                                Key = "Dial Color",
                                Value = "Black"
                            },
                            new Metadata()
                            {
                                Key = "Model Number",
                                Value = "M79733N - 0008"
                            },
                            new Metadata()
                            {
                                Key = "Case",
                                Value = "Stainless Steel"
                            },
                            new Metadata()
                            {
                                Key = "Bracelet",
                                Value = "Yellow Gold Center Links"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Zenith"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Zenith",
                        Model = "El Chronomaster Primero Chronograph",
                        Serial = "7bYLxedc",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Model",
                                Value = "51.2080.400 / 69.C494"
                            },
                            new Metadata()
                            {
                                Key = "Material",
                                Value = "Stainless Steel"
                            },
                            new Metadata()
                            {
                                Key = "Bracelet",
                                Value = "Brown Leather"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                },
                new MintNftModel()
                {
                    UserAddress = address,
                    FileData =  imageBytes["Longiness"],
                    Watch = new Watch()
                    {
                        Manufacturer = "Longiness",
                        Model = "HydroConquest",
                        Serial = "6pnTHqSD",
                        Metadata = new List<Metadata>()
                        {
                            new Metadata()
                            {
                                Key = "Model",
                                Value = "L3.841.4.56.6"
                            },
                            new Metadata()
                            {
                                Key = "Dimensions",
                                Value = "44MM"
                            },
                            new Metadata()
                            {
                                Key = "Material",
                                Value = "Stainless Steel"
                            },
                            new Metadata()
                            {
                                Key = "Dial Color",
                                Value = "Sunray Black"
                            }
                        },
                        ImageCID = ""
                    },
                    RoyaltyAmount = "1000",
                    RoyaltyRecipient = address
                }

            }.ToList().ForEach(async x =>
            {
                await _nftService.NftController.MintNft(x);
            });

            return Ok();
        }
    }
}
