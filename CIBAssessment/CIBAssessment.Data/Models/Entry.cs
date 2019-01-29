using System;
using System.Collections.Generic;

namespace CIBAssessment.Data.Models
{
    public partial class Entry
    {
        public int EntryId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int PhonebookId { get; set; }

        public virtual Phonebook Phonebook { get; set; }
    }
}
