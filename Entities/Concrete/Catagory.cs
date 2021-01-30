using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{   //Çıplak class kamasın
    public class Catagory:IEntity
    {   
        public int CatagoryID { get; set; }
        public string CatagoryName { get; set; }

    }
}
