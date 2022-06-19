using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH_Project.Models.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int ModelCaptionId { get; set; }
        public int Diversity  { get; set; }
        public int Novality { get; set; }
        public int Informativeness { get; set; }
        public int Fluency { get; set; }

        public ModelCaption? ModelCaption { get; set; }
    }
}
