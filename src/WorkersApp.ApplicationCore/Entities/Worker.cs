using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public partial class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Secondname { get; set; }
        public String Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsMan { get; set; }
        public int Childrens { get; set; }

        public String Sex { get
            { return IsMan ? "Муж" : "Жен"; }
        }
    }
}
