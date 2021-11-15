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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public void HeadingAddBL(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            if (heading.IsActive == false)
            {
                heading.IsActive = true;
            }
            else
            {
                heading.IsActive = false;
            }
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            //Deneme amaçlı yazıldı.
            //heading.CreateDate = DateTime.Now;
            _headingDal.Update(heading);
        }
    }
}
