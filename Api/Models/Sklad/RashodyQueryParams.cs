﻿namespace Api.Models.Sklad
{
    public class RashodyQueryParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Флаг какая дата учитвается в сортировке
        /// 1 - дата расходника
        /// 2 - дата отгрузки
        /// 3 - дата оплаты счета
        /// </summary>
        public int DateFilter { get; set; }
        public bool? SelectedOplachen { get; set; }
        public bool? SelectedOtgruzheno { get; set; }
        public Type_oplaty? SelectedTipOpl { get; set; }
        public User? SelectedManager { get; set; }
        public string Search { get; set; }
        //public Tovary SearchTovar { get; set; }

        public RashodyQueryParams(DateTime? startDate, DateTime? endDate, string search, Type_oplaty oplata, User user, bool? otgr, bool? opl, int dateFilter = 1)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Search = search;
            this.DateFilter = dateFilter;
            this.SelectedTipOpl = oplata;
            this.SelectedOtgruzheno = otgr;
            this.SelectedOplachen = opl;
            this.SelectedManager = user;
        }
    }
}
