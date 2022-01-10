using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfScholApp.Model
{
     public partial class Service
    {
        public string GetPhoto
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + Pic;
            }
            set
            {
                Pic = value;
            }
        }
        public string FullTitle
        {
            get
            {
                return $"{Title}, Цена: {Cost} рублей";
            }
        }
    }
}
