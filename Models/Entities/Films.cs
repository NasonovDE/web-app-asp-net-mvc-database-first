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
    
    public partial class Films
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Films()
        {
            this.Kinos = new HashSet<Kinos>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int FilmYears { get; set; }
    
        public virtual FilmImages FilmImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kinos> Kinos { get; set; }
    }
}
