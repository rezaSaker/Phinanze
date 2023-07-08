﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phinanze.Models;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class AddTransactionPresenter : Presenter
    {
        private IAddTransactionView _view;
        private IContainerView _containerView;
        private ITransaction _transaction;

        public AddTransactionPresenter(IAddTransactionView view, IContainerView containerView, ITransaction transaction)
            _view = view;
            _containerView = containerView;
            _transaction = transaction;

            _view.ViewLoading += OnViewLoading;
            //_view.ViewShown += OnViewShown;
            _view.ViewVisibilityChanged += OnViewShown;
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
            Category cat = _view.Category;

            Transaction transaction = new Transaction()
            {
                Date = _view.Date,
                Amount = _view.Amount,
                CategoryId = _view.Category.Id,
                Note = _view.Note
            };

            if (transaction.Save())
            {
                MessageBox.Show("Transacation has been saved!");
                _view.Hide();
            }
            else
            {
                MessageBox.Show(transaction.ResponseStringFromLastSaveRequest());
            }
        }
    }
}