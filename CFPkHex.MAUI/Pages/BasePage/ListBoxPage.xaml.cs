using CFPkHex.Backend.Repository;
using CFPkHex.Core.Models.General;
using CFPkHex.MAUI.ViewModels;
using PKHeX.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFPkHex.MAUI.Pages.BasePage
{
    public partial class ListBoxPage : ContentPage
    {
        public ListBoxPage()
        {
            InitializeComponent();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            var boxViewModel = (BoxViewModel)BindingContext;
            boxViewModel.CurrentBox--;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            var boxViewModel = (BoxViewModel)BindingContext;
            boxViewModel.CurrentBox++;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var boxViewModel = (BoxViewModel)BindingContext;
            boxViewModel.CurrentBox = pickerBox.SelectedIndex;
        }
    }
}
