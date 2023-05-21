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
        public void TestMDIContainerPresenter_InitAndViewShow()
        {
            MDIContainerPresenter presenter = new MDIContainerPresenter(MDIContainerView.Instance);
            Assert.IsTrue(MDIContainerView.Instance.IsOpen);
            Assert.IsNull(MDIContainerView.Instance.MdiParent);
        }

        [TestMethod]
        public void TestMDIContainerPresenter_ViewMovement()
        {
            MDIContainerPresenter presenter = new MDIContainerPresenter(MDIContainerView.Instance);
            PrivateObject pvtObj = new PrivateObject(presenter);
            object[] args = new object[] { this, null };

            pvtObj.Invoke("OnMouseDown", args); // Should allow form movement on mouse movement

            Point prevViewLocation = MDIContainerView.Instance.Location;
            Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);

            pvtObj.Invoke("OnMouseMove", args); // Should move the form on mouse movement

            Assert.AreNotEqual(prevViewLocation, MDIContainerView.Instance.Location);

            pvtObj.Invoke("OnMouseUp", args); // Should make the form not movable on mouse movement

            prevViewLocation.X = MDIContainerView.Instance.Location.X;
            prevViewLocation.Y = MDIContainerView.Instance.Location.Y;

            Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
            Assert.AreEqual(prevViewLocation, MDIContainerView.Instance.Location);
        }
    }
}
