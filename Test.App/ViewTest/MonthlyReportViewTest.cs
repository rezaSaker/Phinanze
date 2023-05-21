using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phinanze.Views;
using Phinanze.Views.MonthlyReportView;
using System.Windows.Forms;

namespace Phinanze.Test.App.ViewTest
{
    [TestClass]
    public class MonthlyReportViewTest
    {
        public static IMonthlyReportView view = MonthlyReportView.Instance;

        [TestMethod]
        public void TestMonthlyReportViewInitAndObjectRelations()
        {
            IView view1 = MonthlyReportView.Instance;
            IMonthlyReportView view2 = MonthlyReportView.Instance;

            Assert.AreSame(view1, view2);

            view2 = view1 as IMonthlyReportView;
            Assert.AreSame(view1, view2);

            Assert.IsInstanceOfType(view1, typeof(Form));
        }

        [TestMethod]
        public void TestMonthlyReportDGV()
        {
            Assert.AreEqual(4, view.MonthlyReportDGV.ColumnCount);
            Assert.AreEqual("Date", view.MonthlyReportDGV.Columns[0].HeaderCell.Value);
            Assert.AreEqual("Note", view.MonthlyReportDGV.Columns[1].HeaderCell.Value);
            Assert.AreEqual("Earning", view.MonthlyReportDGV.Columns[2].HeaderCell.Value);
            Assert.AreEqual("Expense", view.MonthlyReportDGV.Columns[3].HeaderCell.Value);
        }
    }
}
