using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace web_app_asp_net_mvc_database_first.Models
{
	public enum FilmYears
	{
        [Display(Name = "0+")]
        ZeroYears = 1,

        [Display(Name = "6+")]
        SixYears = 2,

        [Display(Name = "12+")]
        TwentyYears = 3,

        [Display(Name = "16+")]
        SixteenYears = 4,

        [Display(Name = "18+")]
        EighteenYears = 5,
    }
}