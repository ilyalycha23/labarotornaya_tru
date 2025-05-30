using System;
using System.Collections.Generic;
using System.IO;  // для работы с File
using System.Linq;
using Newtonsoft.Json;  // Для работы с JSON

namespace laba_tru.Pokalo
{
    public static class DataLoader
    {
        public static List<DiseaseData> LoadData(string filePath)
        {
            try
            {
                if (filePath.EndsWith(".json"))
                {
                    string json = File.ReadAllText(filePath);
                    var data = JsonConvert.DeserializeObject<List<DiseaseData>>(json);
                    CalculateYearlyChanges(data);
                    return data;
                }
                throw new NotSupportedException("Поддерживаются только JSON файлы");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private static void CalculateYearlyChanges(List<DiseaseData> data)
        {
            var diseases = data.Select(d => d.DiseaseName).Distinct();

            foreach (var disease in diseases)
            {
                var yearlyData = data
                    .Where(d => d.DiseaseName == disease)
                    .OrderBy(d => d.Year)
                    .ToList();

                for (int i = 1; i < yearlyData.Count; i++)
                {
                    double change = (yearlyData[i].CasesCount - yearlyData[i - 1].CasesCount) /
                                   (double)yearlyData[i - 1].CasesCount * 100;
                    yearlyData[i].YearlyChangePercent = change;
                }
            }
        }
    }
}
