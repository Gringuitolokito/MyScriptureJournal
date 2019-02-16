using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        //The ID field is required by the database for the primary key.
        public int ID { get; set; }
        //The DataType attribute specifies the type of the data (Date). With this attribute:
        //  The user is not required to enter time information in the date field.
        //  Only the date is displayed, not time information.
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }        
        public string Book { get; set; }
        
        public double Chapter { get; set; }
        public double Verse { get; set; }
        public string Notes { get; set; }

    }
}
