using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_database_first.Extensions;
using web_app_asp_net_mvc_database_first.Models;
using web_app_asp_net_mvc_database_first.Models.Attributes;
using web_app_asp_net_mvc_database_first.Models.Entities;

namespace web_app_asp_net_mvc_database_first.Models
{
    public class FilmViewModel
    {
        ///<summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        ///<summary>
        /// Название фильма
        /// </summary> 
        [Required]
        [Display(Name = "Название фильма", Order = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Пол
        /// </summary> 
        [ScaffoldColumn(false)]
        public FilmYears FilmYears { get; set; }

        [Display(Name = "Возрастное ограничение", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("FilmYears")]
        [NotMapped]
        public IEnumerable<SelectListItem> FilmYearsDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (FilmYears type in Enum.GetValues(typeof(FilmYears)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == FilmYears
                    });
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Обложка
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual FilmImages FilmImage { get; set; }

        [Display(Name = "Фото преподавателя", Order = 60)]
        [NotMapped]
        public HttpPostedFileBase FilmImageFile { get; set; }

        }
}