using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIBAssessment.Data.Models
{
    public partial class Entry
    {
        public int EntryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public int PhonebookId { get; set; }

        public virtual Phonebook Phonebook { get; set; }
    }
}
