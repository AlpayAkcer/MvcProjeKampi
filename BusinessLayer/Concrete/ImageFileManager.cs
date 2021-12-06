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

        public ImageFiles GetByID(int id)
        {
            return _imageFilesDal.Get(x => x.ImageId == id);
        }

        public List<ImageFiles> GetList()
        {
            return _imageFilesDal.List();
        }

        public void ImageFilesAdd(ImageFiles imageFiles)
        {
            _imageFilesDal.Insert(imageFiles);
        }

        public void ImageFilesDelete(ImageFiles imageFiles)
        {
            _imageFilesDal.Delete(imageFiles);
        }

        public void ImageFilesUpdate(ImageFiles imageFiles)
        {
            _imageFilesDal.Update(imageFiles);
        }
    }
}
