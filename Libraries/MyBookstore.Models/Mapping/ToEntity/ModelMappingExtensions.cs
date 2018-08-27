using MyBookstore.Core;

namespace MyBookstore.Models
{

    public static class ModelMappingExtensions
    {

        public static Author ToEntity(this AuthorViewModel model)
        {
            return model.MapTo<AuthorViewModel, Author>();
        }

        public static Book ToEntity(this BookViewModel model)
        {
            return model.MapTo<BookViewModel, Book>();
        }


    }
}
