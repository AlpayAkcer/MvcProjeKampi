using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFilesService
    {
        IImageFilesDal _imageFilesDal;

        public ImageFileManager(IImageFilesDal imageFilesDal)
        {
            _imageFilesDal = imageFilesDal;
        }

        public Contact GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFiles> GetList()
        {
            return _imageFilesDal.List();
        }

        public void ImageFilesAdd(ImageFiles ımageFiles)
        {
            throw new NotImplementedException();
        }

        public void ImageFilesDelete(ImageFiles ımageFiles)
        {
            throw new NotImplementedException();
        }

        public void ImageFilesUpdate(ImageFiles ımageFiles)
        {
            throw new NotImplementedException();
        }
    }
}
