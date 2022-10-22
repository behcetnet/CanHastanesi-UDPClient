using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MonitorYonetimi.Core
{
    [Table("Settings")]
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string ParamName { get; set; }
        public string ParamValue { get; set; }
    }
}
