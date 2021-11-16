using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFilesService
    {
        List<ImageFiles> GetList();
        void ImageFilesAdd(ImageFiles ımageFiles);
        void ImageFilesDelete(ImageFiles ımageFiles);
        void ImageFilesUpdate(ImageFiles ımageFiles);
        Contact GetByID(int id);
    }
}
