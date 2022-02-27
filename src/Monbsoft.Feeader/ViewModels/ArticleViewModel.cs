using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.ViewModels
{
    public class ArticleViewModel : BaseViewModel
    {
        private string _link;

        public ArticleViewModel(string title, string link)
        {
            Title= title;
            Link= link;
        }

        public string Link 
        { 
            get { return _link; }
            set { SetProperty(ref _link, value); }
        }

        public void Clear()
        {
            Title = String.Empty;
            Link = String.Empty;
        }

        internal Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
