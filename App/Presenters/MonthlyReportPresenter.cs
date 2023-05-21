using Phinanze.Views;
using Phinanze.Views.MonthlyReportView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phinanze.Presenters
{
    public class MonthlyReportPresenter : Presenter
    {
        private IMonthlyReportView _view;
        private IView _containerView;

        public MonthlyReportPresenter(IMonthlyReportView view, IView containerView)
        {
            _view = view;
            _containerView = containerView;

            Show(_view, _containerView);
        }
    }
}
