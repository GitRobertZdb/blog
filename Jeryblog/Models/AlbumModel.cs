using System.Collections.Generic;
using Jeryblog.Data;

namespace Jeryblog.Models
{
    public class AlbumModel
    {
        public blog_varticle Varticle { get; set; }
        public int ImgCount { get; set; }
        public List<AlbumPhotoModel> ImageList { get; set; }
        public AlbumPhotoModel Cover { get; set; }
        public CategoryModel Category { get; set; }
    }
}