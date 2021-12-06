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
        void ImageFilesAdd(ImageFiles imageFiles);
        void ImageFilesDelete(ImageFiles imageFiles);
        void ImageFilesUpdate(ImageFiles imageFiles);
        ImageFiles GetByID(int id);
    }
}
