using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Presenters;
using Phinanze.Views;
using System.Drawing;
using System.Windows.Forms;

namespace Test.App.PresenterTest
{
    [TestClass]
    public class MDIContainerPresenterTest
    {
        [TestMethod]
        public void MDIContainerPresenter_InitializeAndShowView_SetsIsOpenAndMdiParent()
        {
            MDIContainerPresenter presenter = new MDIContainerPresenter(MDIContainerView.Instance);
            Assert.IsTrue(MDIContainerView.Instance.IsOpen);
            Assert.IsNull(MDIContainerView.Instance.MdiParent);
        }
    }
}
