using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyBookstore.Core;

namespace MyBookstore.Models
{
    public partial class MyBookstoreBaseModel
    {
        public ApplicationUser User { get; set; }
        public bool UserIsLogged { get { return User != null;  } }
        public string PageTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public MyBookstoreBaseModel()
        {
            PostInitialize();
        }

        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        protected virtual void PostInitialize()
        {
        }

    }

}
