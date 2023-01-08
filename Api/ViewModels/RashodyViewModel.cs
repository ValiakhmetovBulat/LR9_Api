using Api.Models;
using Api.Models.Sklad;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Api.ViewModels
{
    public class RashodyViewModel
    {
        public ObservableCollection<Spr_oplat_sklad> Spr_Oplat_Sklad { get; set; }
        public ObservableCollection<Spr_period_filtr> Spr_Periods_Filter { get; set; }
        public ObservableCollection<string> Spr_Managers_Filter { get; set; }
        public ObservableCollection<Sklad_rashod> Rashods { get; set; }
        public ObservableCollection<int> Months { get; set; }
        public ObservableCollection<int> Years { get; set; }

        public RashodyViewModel()
        {            
        }

        public async Task<RashodyViewModel> GetVM(ApiContext apiContext)
        {
            //Rashods = new ObservableCollection<Sklad_rashod>(_rashods);
            Spr_Oplat_Sklad = new ObservableCollection<Spr_oplat_sklad>(apiContext.spr_oplat_sklad);
            Spr_Periods_Filter = new ObservableCollection<Spr_period_filtr>(apiContext.Spr_period_filtr);
            //Spr_Managers_Filter = new ObservableCollection<string>(_rashods.Select(p => p.otpustil).Distinct().OrderBy(p => p));
            Months = new ObservableCollection<int>() { 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12 };
            Years = new ObservableCollection<int>(apiContext.sklad_rashod.Select(p => p.date_rash.Year).Distinct().OrderBy(p => p));

            return this;
        }
    }
}
