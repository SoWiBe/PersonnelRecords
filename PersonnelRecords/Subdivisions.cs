//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonnelRecords
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subdivisions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subdivisions()
        {
            this.Positions = new HashSet<Positions>();
        }
    
        public int Id { get; set; }
        public string Info { get; set; }
        public Nullable<int> IdType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Positions> Positions { get; set; }
        public virtual TypesOfSubdivisions TypesOfSubdivisions { get; set; }
    }
}
