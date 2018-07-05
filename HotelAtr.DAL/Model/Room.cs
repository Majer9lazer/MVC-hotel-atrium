//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace HotelAtr.DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        [Required]
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public Nullable<decimal> Square { get; set; }
        public Nullable<int> MaxPersons { get; set; }
        public bool IsFreeWifi { get; set; }
        public bool IsPrivateBalcony { get; set; }
        public bool IsFullAC { get; set; }
        public int Floor { get; set; }
        public bool HasTV { get; set; }
        public bool IsBeachView { get; set; }
    
        public virtual RoomType RoomType { get; set; }
    }
}