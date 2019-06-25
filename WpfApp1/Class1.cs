using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WpfApp1
{
    [TestFixture]
    class Class1
    {  
        //атрибут, указывающий на то, что это тестовый метод  
        //[STAThread]
        //[TestCase]
        //public void visivility()
        //{
        //    func f = new func();
        //    Assert.AreEqual("Visible", f.main_menu.Visibility);
        //}

        [TestCase]
        public void pokupka()
        {
            func f = new func();
            Assert.IsTrue(f.pokup(250, 150));
        }

        [TestCase]
        public void clicki()
        {
            func f = new func();
            Assert.AreEqual(1, 0,1);
        }
    }
}
