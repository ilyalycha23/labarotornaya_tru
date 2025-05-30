using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_tru.Pokalo
{
    public class DiseaseData
    {
        public int Year { get; set; }
        public string DiseaseName { get; set; }
        public int CasesCount { get; set; }

        // Для анализа изменений
        public double YearlyChangePercent { get; set; }
    }
}
