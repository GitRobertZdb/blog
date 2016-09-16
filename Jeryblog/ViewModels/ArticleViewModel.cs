using Jeryblog.Data;
using Jeryblog.Models;

namespace Jeryblog.ViewModels
{
    public class ArticleViewModel
    {
        public string WebTitle { get; set; }
        public string WebPath { get; set; }
        public string Seo { get; set; }
        public blog_varticle ArticleInfo { get; set; }
        public CommentModel Comment { get; set; }
        public CategoryModel Category { get; set; }
    }
}
