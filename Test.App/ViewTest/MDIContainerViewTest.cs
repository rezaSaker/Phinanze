using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Views;
using System.Windows.Forms;

namespace Phinanze.Test.App.ViewTest
{
    [TestClass]
    public class MDIContainerViewTest
    {
        [TestMethod]
        public void TestMDIContainerViewInitAndObjectRelations()
        {
            IView view1 = MDIContainerView.Instance;
            IContainerView view2 = MDIContainerView.Instance;

            Assert.AreSame(view1, view2);

            view2 = view1 as IContainerView;
            Assert.AreSame(view1, view2);

            Assert.IsTrue(((Form)view1).IsMdiContainer);
            Assert.IsTrue(((Form)view2).IsMdiContainer);

            PrivateObject pvtObj = new PrivateObject(view2);
            
            Assert.IsNotNull(pvtObj.GetFieldOrProperty("headerPanel"));
            Assert.IsInstanceOfType(view1, typeof(Form));
        }
    }
}
