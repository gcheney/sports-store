using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, 
                 ModelBindingContext bindingContext)
        {
            HttpContextBase context = controllerContext.HttpContext;
            HttpSessionStateBase session = context.Session;

            //Get cart from the session
            Cart cart = null;
            if (session != null)
            {
                cart = (Cart)session[sessionKey];
            }

            //create the cart if not in session
            if (cart == null)
            {
                cart = new Cart();
                if (session != null)
                {
                    session[sessionKey] = cart;
                }
            }
            //return the cart
            return cart;
        }
    }
}