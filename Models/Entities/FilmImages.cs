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
    
    public partial class FilmImages
    {
        public int Id { get; set; }
        public System.Guid Guid { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public System.DateTime DateChanged { get; set; }
        public string FileName { get; set; }
    
        public virtual Films Films { get; set; }
    }
}
