using System;
using System.Collections.Generic;
using System.Text;

namespace Lab14Crud.Models
{
    public class ComponentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComponentModel { get; set; }
        public string NameComponentModel { get; set; }
        public DateTime BirthComponentModel { get; set; }
        public bool ActiveModel { get; set; }
    }
}