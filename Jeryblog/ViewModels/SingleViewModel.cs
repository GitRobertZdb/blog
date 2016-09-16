using Jeryblog.Data;
using Jeryblog.Models;

namespace Jeryblog.ViewModels
{
    public class SingleViewModel
    {
        public string WebTitle { get; set; }
        public string WebPath { get; set; }
        public string CurrentUrl { get; set; }
        public blog_varticle ArticleInfo { get; set; }
        public CategoryModel Category { get; set; }
    }
}
