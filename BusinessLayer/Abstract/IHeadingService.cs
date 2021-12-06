using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        void HeadingAddBL(Heading heading);
        Heading GetByID(int id);
        void HeadingDelete(Heading heading);
        List<Heading> HeadingByCategory(int id);

        //Yazarların yazdığı başlıklar için
        List<Heading> HeadingByWriter();

        //Admin paneldeki adminin yazdığı başlıklar için.
        List<Heading> HeadingByWriter(int id);
        void HeadingUpdate(Heading heading);
    }
}
