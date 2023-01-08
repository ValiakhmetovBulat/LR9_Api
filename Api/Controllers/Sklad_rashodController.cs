using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.ViewModels;
using Api.Models.Sklad;
using Microsoft.AspNetCore.StaticFiles;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sklad_rashodController : ControllerBase
    {
        private readonly ApiContext _context;

        public Sklad_rashodController(ApiContext context)
        {
            _context = context;
            
        }

        // GET: api/Sklad_rashod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sklad_rashod>> GetSklad_rashod(int id)
        {
            if (_context.sklad_rashod == null)
            {
                return NotFound();
            }
            var sklad_rashod = await _context.sklad_rashod.FindAsync(id);

            if (sklad_rashod == null)
            {
                return NotFound();
            }

            _context.sklad_rashod_tov.Where(p => p.kod_rashoda == id).Include(p => p.Tovar).Load();
            /*_context.Sheta.Where(p => p.kod_zap == sklad_rashod.shet).Load();
            _context.Sklad_dostavki.Where(p => p.sklad_rashod_id == sklad_rashod.kod_zap).Load();*/
            //_context.Karta.Where(p => p.Id == sklad_rashod.karta).Load();
            return sklad_rashod;
        }
        #region В пдф
        /*        // GET: api/Sklad_rashod/5
                [Route("File")]
                [HttpGet]
                public async Task<IActionResult> GetSklad_rashod_file(int id, string format, bool printZeny, bool printBeznal)
                {
                    if (_context.sklad_rashod == null)
                    {
                        return NotFound();
                    }
                    var sklad_rashod = await _context.sklad_rashod.FindAsync(id);
                    _context.Sklad_rashod_tov.Where(p => p.kod_rashoda == id).Include(p => p.Tovar).Load();
                    _context.Sheta.Where(p => p.kod_zap == sklad_rashod.shet).Load();
                    _context.Sklad_dostavki.Where(p => p.sklad_rashod_id == sklad_rashod.kod_zap).Load();

                    if (sklad_rashod == null)
                    {
                        return NotFound();
                    }
                    try
                    {
                        string fileName_shabl = "Z:\\31 Программы\\АИС\\Место обновления программы\\Товарный чек.xlsx"; //имя Excel файла  
                        Excel.Application xlApp = new Excel.Application();
                        Excel.Workbook xlWb = null;
                        try
                        {
                            xlWb = xlApp.Workbooks.Open(fileName_shabl); //открываем Excel файл              
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().IndexOf("0x80010105") > (-1)) //рандомная ошибка! выскакивала ТОЛЬКО на компе Алены. скорее всего из за какой то не совместимости чего то, возможно версия Office не идеально совмещалась с самой программой, или еще чего то.. Как вариант в интернете писали, что различные версии office и Excel.interop, хотя я проверил и вроде подходит. И всё это с учетом того что в других формах всё работает отлично.. 
                                                                            //по итогу проблема решилась два раза после того как были добавлены строки с Visible(снизу которые) И файл шаблона заменен с .xls на .xlsx (можно просто пересохранить)
                            {
                                xlApp.Visible = true;
                                xlWb = xlApp.Workbooks.Open(fileName_shabl); //открываем Excel файл
                                xlApp.Visible = false;
                            }
                            else
                            {
                                throw;
                            }
                        }
                        //первый лист в файле
                        Excel.Worksheet xlSht = xlWb.Sheets[1];
                        //сохраняем номер счета и плательщика
                        *//*if (sklad_rashod.Sheta != null)
                        {
                            string platelshik = sklad_rashod.Sheta.nom_1C.ToString();

                            xlSht.Cells[2, 1].Value = platelshik;
                            xlSht.Cells[31, 1].Value = platelshik;
                        }*//*

                        xlSht.Cells[4, 1].Value = "Товарный чек №  " + sklad_rashod.nom_rash + " от  " + sklad_rashod.date_rash.ToShortDateString() + " г.";
                        xlSht.Cells[32, 1].Value = "Товарный чек №  " + sklad_rashod.nom_rash + " от  " + sklad_rashod.date_rash.ToShortDateString() + " г.";

                        int nom_str = 0;
                        var linq = sklad_rashod.Sklad_rashod_tov
                            .GroupBy(g => g.kod_tovara)
                            .Select(s => new
                            {
                                tov = s.FirstOrDefault().Tovar,
                                count = s.Sum(a => a.count),
                                zena = Math.Round(s.Sum(a => Convert.ToDecimal(a.zena * Convert.ToDecimal(a.count) / s.Sum(a => Convert.ToDecimal(a.count)))), 2, MidpointRounding.AwayFromZero),
                                summa = s.Sum(a => a.Summa)
                            });

                        try
                        {
                            List<Tovary> tovary_bez_name = new List<Tovary>();

                            foreach (var item in linq)
                            {
                                xlSht.Cells[6 + nom_str, 1].Value = nom_str + 1;
                                xlSht.Cells[34 + nom_str, 1].Value = nom_str + 1;
                                Zen_roznichnie zena = _context.Zen_roznichnie.Where(p=>p.tov == item.tov.kod_tovara).FirstOrDefault();
                                if (zena != null)
                                {
                                    if (zena.name_sklad == null || zena.name_zav_sklad == null)
                                    {
                                        tovary_bez_name.Add(item.tov);
                                        nom_str++;
                                        continue;
                                    }

                                    xlSht.Cells[6 + nom_str, 2].Value = zena.name_zav_sklad;
                                    xlSht.Cells[34 + nom_str, 2].Value = zena.name_sklad;

                                    xlSht.Cells[6 + nom_str, 8].Value = "шт";
                                    xlSht.Cells[34 + nom_str, 8].Value = "шт";

                                    xlSht.Cells[6 + nom_str, 9].Value = item.count.ToString();
                                    xlSht.Cells[34 + nom_str, 9].Value = item.count.ToString();

                                    //печать цен
                                    if (printZeny)
                                    {
                                        xlSht.Cells[6 + nom_str, 10].Value = item.zena.ToString();
                                        xlSht.Cells[34 + nom_str, 10].Value = item.zena.ToString();

                                        xlSht.Cells[6 + nom_str, 13].Value = item.summa.ToString();
                                        xlSht.Cells[34 + nom_str, 13].Value = item.summa.ToString();
                                    }
                                }
                                nom_str++;
                            }

                            if (tovary_bez_name.Count > 0)
                            {
                                string tovary_list = "";
                                foreach (Tovary tov in tovary_bez_name)
                                {
                                    tovary_list += tov.naim;
                                    throw new NotImplementedException();
                                }

                                return BadRequest($"Ошибка! У данных товаров отсутствует наименование: {tovary_list}\n Пожалуйста обратитесь к руководителю склада Оксане, для внесения данного наименования!");
                            }
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }

                        decimal sum_nal = 0;
                        decimal sum_beznal = 0;
                        decimal sum = sklad_rashod.SummaAll;
                        decimal sum_dost = sklad_rashod.SummaDost;

                        if (printZeny)
                        {
                            xlSht.Cells[16, 13].Value = sum.ToString();
                            xlSht.Cells[44, 13].Value = sum.ToString();

                            if (*//*checkBox_oplNaVigr.Checked ||*//*sklad_rashod.na_pechat_dost.Value)
                            {
                                xlSht.Cells[44, 11].Value = "Товары";
                                xlSht.Cells[46, 11].Value = "Доставка";
                                xlSht.Cells[47, 11].Value = "Всего";

                                Microsoft.Office.Interop.Excel.Range tRange = xlSht.Cells[46, 14];
                                tRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                tRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                                tRange = xlSht.Cells[46, 13];
                                tRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                tRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                                tRange = xlSht.Cells[47, 14];
                                tRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                tRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                                tRange = xlSht.Cells[47, 13];
                                tRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                tRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                                xlSht.Cells[46, 13].Value = sum_dost.ToString();
                                xlSht.Cells[47, 13].Value = (sum + sum_dost).ToString();
                            }
                            else
                            {
                                xlSht.Cells[44, 11].Value = "Всего";
                            }


                            *//*if (sklad_rashod.oplata == 20003) // Терминал
                            {
                                decimal nds = sum * 20 / 120;
                                nds = Math.Round(nds, 2, MidpointRounding.AwayFromZero);

                                xlSht.Cells[16, 1].Value = $"В том числе НДС: {nds} руб.";
                                xlSht.Cells[44, 1].Value = $"В том числе НДС: {nds} руб.";
                            }
                            else
                            {*//*
                                xlSht.Cells[16, 1].Value = "Без НДС";
                                xlSht.Cells[44, 1].Value = "Без НДС";
                            //}

                            //xlSht.Cells[19, 5].Value = RusCurrency.Str((double)Convert.ToDecimal(sum.ToString()), "RUR");
                            //xlSht.Cells[51, 5].Value = RusCurrency.Str((double)Convert.ToDecimal(sum.ToString()), "RUR");
                        }
                        else
                        {
                            xlSht.Cells[19, 1].Value = "";
                            xlSht.Cells[51, 1].Value = "";
                            Microsoft.Office.Interop.Excel.Range tRange = xlSht.get_Range("e19", "n19");
                            tRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            tRange = xlSht.get_Range("e51", "n51");
                            tRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                        }
                        if (sklad_rashod.CountDost >= 1)
                        {
                            //пока первая доставка
                            Sklad_dostavki dost = sklad_rashod.Sklad_dostavki.FirstOrDefault();
                            xlSht.Cells[25, 8].Value = dost.address;
                            xlSht.Cells[55, 8].Value = dost.address;

                            xlSht.Cells[27, 8].Value = dost.voditel_id + " (Доставка:" + sklad_rashod.SummaDost + "р.)"; ;
                            xlSht.Cells[57, 8].Value = dost.voditel_id + " (Доставка:" + sklad_rashod.SummaDost + "р.)"; ;
                            xlSht.Cells[46, 1].Value = "Выгрузка платная, заказывается и оплачивается заранее.";
                        }
                        *//*else if (sklad_rashod.CountDost > 1)
                        {
                            *//*SetOutputDostavka();
                            if (OutputDostavkaId != 0)
                            {*//*
                                int Sumdost = (int)Math.Ceiling(double.Parse(dostavkiSumTextBox.Text));
                                string Dostavka_Stoimost = "";

                                Dostavka dostavka = GetDostavkaById(OutputDostavkaId);
                                xlSht.Cells[25, 8].Value = dostavka.adress;
                                xlSht.Cells[55, 8].Value = dostavka.adress;

                                if (dostavka.voditelName != null && dostavka.voditelName != "")
                                {
                                    Dostavka_Stoimost = " (Доставка:" + Sumdost + "р.)";
                                }

                                xlSht.Cells[27, 8].Value = dostavka.voditelName + " (Доставка:" + Sumdost + "р.)";
                                xlSht.Cells[57, 8].Value = dostavka.voditelName + " (Доставка:" + Sumdost + "р.)";
                                xlSht.Cells[46, 1].Value = "Выгрузка платная, заказывается и оплачивается заранее.";
                                OutputDostavkaId = 0;
                            //}
                        }*//*


                        xlSht.Cells[22, 11].Value = "+7" + sklad_rashod.second_phone + " " + sklad_rashod.name_kontact_person +
                            (sklad_rashod.name_pokup != "(   )    -" ? " +7" + sklad_rashod.name_pokup + " " + sklad_rashod.first_phone : "");
                        xlSht.Cells[53, 11].Value = "+7" + sklad_rashod.second_phone + " " + sklad_rashod.name_kontact_person +
                            (sklad_rashod.name_pokup != "(   )    -" ? " +7" + sklad_rashod.name_pokup + " " + sklad_rashod.first_phone : "");

                        xlSht.Cells[22, 3].Value = sklad_rashod.prim_zav_sklad;

                        if (!printBeznal)
                        {
                            try
                            {
                                Microsoft.Office.Interop.Excel.Range xRange = xlSht.get_Range("a31", "o59");
                                xRange.Clear();
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        string path = @"D:\33 Склад\Товарные чеки\";

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        string filename = $@"D:\33 Склад\Товарные чеки\{sklad_rashod.nom_rash}.{format}";

                        try
                        {
                            if (format == "pdf")
                                xlSht.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, filename);
                            if (format == "xlsx")
                                xlSht.SaveAs(filename);

                            xlWb.Close(false, Type.Missing, Type.Missing);
                            xlApp.Workbooks.Close();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWb);
                            xlApp.Quit();
                            GC.Collect();
                            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().Contains("Нет доступа")) //если НЕ из за того что этот файл уже открыт то показать ошибку
                            {
                                return BadRequest("Файл уже открыт!");
                            }
                            else if (!ex.ToString().Contains("0x800A03EC"))
                            {
                                return BadRequest(ex.ToString());
                            }
                        }

                        *//*var fileName = System.IO.Path.GetFileName($@"D:\33 Склад\Товарные чеки\{sklad_rashod.nom_rash}.{format}");
                        var content = await System.IO.File.ReadAllBytesAsync($@"D:\33 Склад\Товарные чеки\{sklad_rashod.nom_rash}.{format}");
                        new FileExtensionContentTypeProvider()
                            .TryGetContentType(fileName, out string contentType);*//*
                        return Ok(filename);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }*/

        /*// GET: api/Sklad_rashod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_rashod>>> GetSklad_rashod()
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }
            var result = await _context.Sklad_rashod.Take(2).Include(p=>p.Sklad_rashod_tov).ToListAsync();
            return result;
        }*/
        #endregion

        [Route("Filter")]
        // Post: api/Sklad_rashod/Filter
        [HttpPost]
        public async Task<ActionResult<List<Sklad_rashod>>> GetSklad_rashodByFilter(RashodyQueryParams? queryParams)
        {
            if (_context.sklad_rashod == null)
            {
                return NotFound();
            }

            List<Sklad_rashod> _rashods = new List<Sklad_rashod>();
            if (queryParams != null)
            {
                switch (queryParams.DateFilter)
                {
                    case 1:
                        {
                            _rashods = await _context.sklad_rashod.
                                Where(p => (queryParams.StartDate.HasValue ? p.date_rash.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue ? p.date_rash.Date <= queryParams.EndDate.Value.Date : true))
                                /*.Include(p => p.Sheta)*//*.Include(p => p.Spr_oplat_sklad)*//*.Include(p => p.Sklad_dostavki)*/.ToListAsync();
                            break;
                        }
                    case 2:
                        {
                            _rashods = await _context.sklad_rashod.
                                Where(p => (queryParams.StartDate.HasValue ? p.date_otgruzki >= queryParams.StartDate.Value : true)
                                        && (queryParams.EndDate.HasValue ? p.date_otgruzki <= queryParams.EndDate : true))
                                /*.Include(p => p.Sheta).Include(p => p.Spr_oplat_sklad)*//*.Include(p => p.Sklad_dostavki)*/.ToListAsync();
                            break;
                        }
                    case 3:
                        {
                            /*_rashods = await _context.Sklad_rashod.
                                Where(p => (queryParams.StartDate.HasValue ? p.data_opl >= queryParams.StartDate.Value : true)
                                        && (queryParams.EndDate.HasValue ? p.data_opl <= queryParams.EndDate : true))
                                .Include(p => p.Sheta).Include(p => p.Spr_oplat_sklad).Include(p => p.Sklad_dostavki).ToListAsync();*/
                            break;
                        }
                }

                if (queryParams.SelectedOplachen != null) _rashods = _rashods.Where(p => p.is_tov_opl == queryParams.SelectedOplachen.Value).ToList();
                if (queryParams.SelectedOtgruzheno != null) _rashods = _rashods.Where(p => p.otgruzheno == queryParams.SelectedOtgruzheno.Value).ToList();
                if (queryParams.SelectedTipOpl != null) _rashods = _rashods.Where(p => p.oplata == queryParams.SelectedTipOpl.kod_zap).ToList();
                if (queryParams.SelectedManager != null) _rashods = _rashods.Where(p => p.id_polz == queryParams.SelectedManager.Id).ToList();

                if (queryParams.Search != null && queryParams.Search != "")
                {
                    _rashods = _rashods.Where(p => p.nom_rash.ToString() == queryParams.Search || p.shet.GetValueOrDefault().ToString() == queryParams.Search
                                            || (p.first_phone != null ? p.first_phone.Contains(queryParams.Search) : false)
                                            || (p.name_kontact_person != null ? p.name_kontact_person.Contains(queryParams.Search) : false)
                                            || (p.name_pokup != null ? p.name_pokup.Contains(queryParams.Search) : false)
                                            //|| (p.otpustil != null ? p.otpustil.Contains(queryParams.Search) : false)
                                            //|| (p.phone_pokup != null ? p.phone_pokup.Contains(queryParams.Search) : false)
                                            || (p.prim != null ? p.prim.Contains(queryParams.Search) : false)
                                            //|| (p.primZavSklad != null ? p.primZavSklad.Contains(queryParams.Search) : false)
                                            || (p.prim_buh != null ? p.prim_buh.Contains(queryParams.Search) : false)
                                            || (p.second_phone != null ? p.second_phone.Contains(queryParams.Search) : false)).ToList();
                }
            }
            else _rashods = await _context.sklad_rashod.ToListAsync();
            _context.users.Load();
            _context.sklad_rashod_tov.Load();
            return _rashods;
        }     

        // PUT: api/Sklad_rashod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSklad_rashod(int id, Sklad_rashod sklad_rashod)
        {
            if (id != sklad_rashod.kod_zap)
            {
                return BadRequest();
            }

            _context.Entry(sklad_rashod).State = EntityState.Modified;
            if (sklad_rashod.otgruzheno && sklad_rashod.date_otgruzki == null) sklad_rashod.date_otgruzki = DateTime.Now;
            else if (!sklad_rashod.otgruzheno) sklad_rashod.date_otgruzki = null;
            /*if (sklad_rashod.oplata == 2 || sklad_rashod.oplata == 20003)
            {
                sklad_rashod.summa = 0;
                sklad_rashod.summa_beznal = sklad_rashod.SummaAll;
                sklad_rashod.summa_karta = 0;
                sklad_rashod.dolg = 0;
            }
            else
            {
                sklad_rashod.summa_beznal = 0;
                if(sklad_rashod.oplata == 20002)
                {
                    sklad_rashod.dolg = sklad_rashod.SummaAll - sklad_rashod.summa - sklad_rashod.summa_karta;
                }
                else
                {
                    if (sklad_rashod.oplata == 3)
                    {
                        sklad_rashod.summa_karta = sklad_rashod.SummaAll - sklad_rashod.summa - sklad_rashod.dolg;
                    }
                    else
                    {
                        sklad_rashod.summa = sklad_rashod.SummaAll - sklad_rashod.summa_karta - sklad_rashod.dolg;
                    }
                }
            }*/
            if (sklad_rashod.Sklad_dostavki != null)
            {
                if(sklad_rashod.Sklad_dostavki.Count != 0)
                {
                    foreach (var dost in sklad_rashod.Sklad_dostavki)
                    {
                        _context.Entry(dost).State = EntityState.Modified;
                        dost.data_rash = sklad_rashod.date_rash;
                    }
                }
            }

            if (sklad_rashod.Sklad_rashod_tov != null)
            {
                foreach (var tov in sklad_rashod.Sklad_rashod_tov)
                {
                    if (tov.kod_zap == 0) _context.Entry(tov).State = EntityState.Added;
                    else _context.Entry(tov).State = EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sklad_rashodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sklad_rashod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sklad_rashod>> PostSklad_rashod(Sklad_rashod sklad_rashod)
        {
            if (_context.sklad_rashod == null)
            {
                return Problem("Entity set 'ApiContext.Sklad_rashod'  is null.");
            }
            sklad_rashod.date_rash = DateTime.Now;
            sklad_rashod.date_sozdania = DateTime.Now;
            sklad_rashod.nom_rash = _context.sklad_rashod.Where(p => p.date_sozdania.Value.Year == DateTime.Now.Year).Max(p => p.nom_rash) + 1;
            //sklad_rashod.otpustil = Environment.UserName;
            _context.sklad_rashod.Add(sklad_rashod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Sklad_rashodExists(sklad_rashod.kod_zap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSklad_rashod", new { id = sklad_rashod.kod_zap }, sklad_rashod);
        }
        [Route("Tov")]
        [HttpPost]
        public async Task<ActionResult<Sklad_rashod>> PostSklad_rashod_tov(Sklad_rashod_tov Sklad_rashod_tov)
        {
            if (_context.sklad_rashod_tov == null)
            {
                return Problem("Entity set 'ApiContext.Sklad_rashod'  is null.");
            }
           
            _context.sklad_rashod_tov.Add(Sklad_rashod_tov);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetSklad_rashod", new { id = Sklad_rashod_tov.kod_zap }, Sklad_rashod_tov);
        }

        [Route("Tov")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSklad_rashod_tov(int id)
        {
            if (_context.sklad_rashod == null)
            {
                return NotFound();
            }
            var sklad_rashod_tov = await _context.sklad_rashod_tov.FindAsync(id);
            if (sklad_rashod_tov == null)
            {
                return NotFound();
            }

            _context.sklad_rashod_tov.Remove(sklad_rashod_tov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSklad_rashod(int id)
        {
            if (_context.sklad_rashod == null)
            {
                return NotFound();
            }
            var sklad_rashod = await _context.sklad_rashod.FindAsync(id);
            if (sklad_rashod == null)
            {
                return NotFound();
            }

            _context.sklad_rashod.Remove(sklad_rashod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Sklad_rashodExists(int id)
        {
            return (_context.sklad_rashod?.Any(e => e.kod_zap == id)).GetValueOrDefault();
        }
    }
}
