using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
//using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_database_first.Extensions;
using web_app_asp_net_mvc_database_first.Models.Attributes;
using web_app_asp_net_mvc_database_first.Models.Entities;

namespace web_app_asp_net_mvc_database_first.Models
{
    public class KinoViewModel
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Дата сеанса
        /// </summary>    
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Дата сеанса", Order = 40)]
        public DateTime KinoDate { get; set; }

        /// <summary>
        /// Время сеанса
        /// </summary>    
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Время сеанса", Order = 40)]
        public DateTime KinoTime { get; set; }

        /// <summary>
        /// Кинотеатр, где будет фильм
        /// </summary> 


        [ScaffoldColumn(false)]
        public virtual ICollection<Cinemas> Cinemas { get; set; }

        [ScaffoldColumn(false)]
        public List<int> CinemaIds { get; set; }

        [Display(Name = "Кинотеатры", Order = 70)]
        [UIHint("DropDownList")]
        [TargetProperty("CinemaIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> CinemaDictionary
        {
            get
            {
                var db = new KinoAfishaDFEntities();
                var query = db.Cinemas;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Kinos.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.CinemaName}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }





        /// <summary>
        /// Фильм
        /// </summary> 
        [ScaffoldColumn(false)]
        public int FilmId { get; set; }
        [ScaffoldColumn(false)]
        public Films Films { get; set; }
        [Display(Name = "Фильм", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("FilmId")]
        [NotMapped]
        public IEnumerable<SelectListItem> FilmDictionary
        {
            get
            {
                var db = new KinoAfishaDFEntities();
                var query = db.Films;

                if (query != null)
                {
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.OrderBy(d => d.Name).ToSelectList(c => c.Id, c => c.Name, c => c.Id == FilmId));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }







    }
}