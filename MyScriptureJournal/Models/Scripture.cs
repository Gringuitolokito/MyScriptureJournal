using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        //The DataType attribute specifies the type of the data (Date). With this attribute:
        //  The user is not required to enter time information in the date field.
        //  Only the date is displayed, not time information.
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        //The ID field is required by the database for the primary key.
        public int ID { get; set; }
        public string Book { get; set; }
        
        public string Chapter { get; set; }
        public double Verse { get; set; }

    }
}
