using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phinanze.Models;
using Phinanze.Models.Statics;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class AddTransactionPresenter : Presenter
    {
        private IAddTransactionView _view;
        private IContainerView _containerView;
        private ITransaction _transaction;

        public AddTransactionPresenter(IAddTransactionView view, IContainerView containerView, ITransaction transaction = null)        {
            _view = view;
            _containerView = containerView;
            _transaction = transaction;

            _view.ViewLoading += OnViewLoading;
            _view.ViewShown += OnViewShown;
            _view.SaveButtonClicked += OnSaveButtonClicked;

            Show(_view, _containerView);
        }

        public void OnViewLoading(object sender, EventArgs e)
        {
            List<Category> categoryList = Category.Get.All();
            _view.InitializeComponents(categoryList);
        }

        public void OnViewShown(object sender, EventArgs e)
        {
            if(_transaction != null && _view.IsOpen)
            {
                _view.PlotData(_transaction);
            }
        }

        public void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Transaction transaction = _transaction != null ? (Transaction)_transaction : new Transaction();

            transaction.Date = _view.Date;
            transaction.Amount = _view.Amount;
            transaction.CategoryId = _view.Category != null ? _view.Category.Id : 0;
            transaction.Note = _view.Note;

            if (transaction.Save())
            {
                MessageBox.Show("Transacation has been saved!");
                _view.Close();

                if(MDIContainerView.Instance.ActiveMdiChild.GetType() == typeof(DashboardView))
                {
                    DashboardPresenter dashboardPresenter = new DashboardPresenter(new DashboardView(), MDIContainerView.Instance);
                }
                else if(MDIContainerView.Instance.ActiveMdiChild.GetType() == typeof(TransactionsView))
                {
                    TransactionsPresenter presenter = new TransactionsPresenter(new TransactionsView(), MDIContainerView.Instance, _view.Date.Year, _view.Date.Month);
                }
            }
            else
            {
                MessageBox.Show(transaction.ResponseStringFromLastSaveRequest());
            }
        }
    }
}
