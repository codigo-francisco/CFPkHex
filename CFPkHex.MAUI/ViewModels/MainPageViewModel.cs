using CFPkHex.Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFPkHex.MAUI.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel(
            BuilderRepository builderRepository
        )
        {
            BuilderRepository = builderRepository;
        }

        public BuilderRepository BuilderRepository { get; set; }
    }
}
