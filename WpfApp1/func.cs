using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class func
    {
        
        private int click(int kl, int aup)
        {
            kl = kl + aup;
            return kl;
        }

        public bool pokup(int kl, int n)
        {
            if (kl >= n)
            {
                return true;
            }
            else { return false; }
        }
    }


}
