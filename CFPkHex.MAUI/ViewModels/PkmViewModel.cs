using CFPkHex.Backend.Models.General;
using CFPkHex.Backend.Repository;
using CFPkHex.Core.Models.General;
using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CFPkHex.MAUI.ViewModels
{
    public class PkmViewModel
    {
        public IRepository Repository { get; set; }
        public BoxViewModel BoxViewModel { get; set; }

        public PkmViewModel(IRepository repository) 
        {
            Repository = repository;
            BoxViewModel = new BoxViewModel(repository);
        }
    }

    public class BoxViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly SaveFile _saveFile;
        public BoxViewModel(IRepository repository) 
        {
            Repository = repository;
            Boxes = repository.Boxes;
            _saveFile = Repository.SaveFile;
        }
        public IRepository Repository { get; }
        public int CurrentBox 
        {
            get
            {
                return Repository.SaveFile.CurrentBox;
            }
            set
            {
                Repository.SaveFile.CurrentBox = value;
                OnPropertyChanged("CurrentBox");
                OnPropertyChanged("IsEnabledBackButton");
                OnPropertyChanged("IsEnabledNextButton");
            }
        }
        public bool IsEnabledBackButton => CurrentBox > 0;
        public bool IsEnabledNextButton => CurrentBox < Boxes.Count - 1;
        public IList<Box> Boxes { get; }
        public IList<Pokemon> PkmInBox { get => Repository.Boxes[CurrentBox].AllPokemon; }
        public void OnPropertiesChanged(params string[] names)
        {
            foreach (var name in names)
            {
                OnPropertyChanged(name);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
