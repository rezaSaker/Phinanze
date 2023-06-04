using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phinanze.Views;

namespace Phinanze.Presenters
{
    public class AddNewDailyInfoPresenter : Presenter
    {
        private IAddNewDailyInfoView _view;
        private IView _containerView;

        public AddNewDailyInfoPresenter(IAddNewDailyInfoView view, IView containerView)        {
            _view = view;
            _containerView = containerView;

            Show(_view, _containerView);
        }

    }
}
