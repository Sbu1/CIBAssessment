using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIBAssessment.Data.Models
{
    public partial class Phonebook
    {
        public Phonebook()
        {
            Entry = new HashSet<Entry>();
        }

        public int PhonebookId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Entry> Entry { get; set; }
    }
}
