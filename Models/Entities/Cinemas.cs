//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_app_asp_net_mvc_database_first.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cinemas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cinemas()
        {
            this.Kinos = new HashSet<Kinos>();
        }
    
        public int Id { get; set; }
        public string CinemaName { get; set; }
        public int NumberOfPlaces { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kinos> Kinos { get; set; }
    }
}
