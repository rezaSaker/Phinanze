using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phinanze.Models;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class AddTransactionPresenter : Presenter
    {
        private IAddTransactionView _view;
        private IContainerView _containerView;
        private ITransaction _transaction;

        public AddTransactionPresenter(IAddTransactionView view, IContainerView containerView, ITransaction transaction)        {
            _view = view;
            _containerView = containerView;
            _transaction = transaction;

            _view.ViewLoading += OnViewLoading;
            //_view.ViewShown += OnViewShown;
            _view.ViewVisibilityChanged += OnViewShown;

            Show(_view, _containerView);
        }

        public void OnViewLoading(object sender, EventArgs e)
        {
            List<Category> cats = Category.Get.All();
            _view.InitializeComponents(cats);
        }

        public void OnViewShown(object sender, EventArgs e)
        {
            if(_transaction != null && _view.IsOpen)
            {
                _view.PlotData(_transaction);
            }
        }
    }
}
