using System.Collections.Generic;
using Jeryblog.Data;

namespace Jeryblog.Models
{
    public class FloorArticleModel : blog_article
    {
        public IEnumerable<blog_article> FloorArticles { get; set; }
    }
}