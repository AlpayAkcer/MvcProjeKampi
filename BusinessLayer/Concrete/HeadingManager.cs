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

        public List<Heading> HeadingByCategory(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }

        public List<Heading> HeadingByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public List<Heading> HeadingByWriter()
        {
            return _headingDal.List(x => x.WriterId == 13);
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
            _headingDal.Update(heading);
        }
    }
}
