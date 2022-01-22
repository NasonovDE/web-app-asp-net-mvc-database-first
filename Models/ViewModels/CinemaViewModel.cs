using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_database_first.Extensions;
using web_app_asp_net_mvc_database_first.Models.Attributes;

namespace web_app_asp_net_mvc_database_first.Models
{
    public class CinemaViewModel
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название кинотеатра
        /// </summary>    
        [Required]
        [Display(Name = "Название кинотеатра", Order = 5)]
        public string CinemaName { get; set; }

        /// <summary>
        /// Количество мест в зале
        /// </summary>  
        [Required]
        [Display(Name = "Количество мест в зале", Order = 6)]
        public int NumberOfPlaces { get; set; }



    }
}