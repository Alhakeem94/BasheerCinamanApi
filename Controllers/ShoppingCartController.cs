using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("AddNewShoppingReceipt")]
        public async Task<IActionResult> addNewShoppingReceipt([FromBody] ShoppingReceiptViewModel newReceiptInfo)
        {

            try
            {
                var ShoppingReceipt = new ShoppingReceipt()
                {
                    RecieptTotalAmount = newReceiptInfo.RecieptTotalAmount,
                    UserId = newReceiptInfo.UserId,
                    UserNotes = newReceiptInfo.UserNotes,
                };

                await _db.ShoppingRecieptTable.AddAsync(ShoppingReceipt);
                await _db.SaveChangesAsync();


                var ListOfAllProducts = new List<ShoppingCartModel>();
              
                foreach (var item in newReceiptInfo.ListOfShoppingProduct)
                {
                    var ShoppingItem = new ShoppingCartModel()
                    {
                        ProductId = item.Id,
                        ProductQuantity = item.Quantity,
                        ShoppingCartId = ShoppingReceipt.ShoppingCartId,
                        ProductSellAmount = item.Price,
                        ProductTotalAmount = item.TotalPrice,
                    };

                    ListOfAllProducts.Add(ShoppingItem);
                }

                await _db.ShoppingCartTable.AddRangeAsync(ListOfAllProducts);
                await _db.SaveChangesAsync();


                return Ok(new GeneralResponse()
                {
                    IsSuccess = true,
                    Message = "The Cart Has been added successfuly"
                });
            }
            catch (Exception e)
            {
                return Ok(new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = e.Message
                });
            }

         
        }




    }
}
