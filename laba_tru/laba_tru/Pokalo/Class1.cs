using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_tru.Pokalo
{
    public static class MovingAverageCalculator
    {
        public static List<double> Calculate(List<double> data, int windowSize)
        {
            if (windowSize <= 0 || windowSize > data.Count)
                throw new ArgumentException("Некорректный размер окна");

            List<double> movingAverages = new List<double>();

            for (int i = 0; i <= data.Count - windowSize; i++)
            {
                double windowSum = 0;
                for (int j = i; j < i + windowSize; j++)
                {
                    windowSum += data[j];
                }
                movingAverages.Add(windowSum / windowSize);
            }

            return movingAverages;
        }

        public static List<double> Forecast(List<double> data, int windowSize, int periods)
        {
            if (data == null || data.Count == 0)
                throw new ArgumentException("Нет данных для прогноза");

            List<double> forecast = new List<double>();
            List<double> movingAverages = Calculate(data, windowSize);

            for (int i = 0; i < periods; i++)
            {
                double sum = 0;
                int start = Math.Max(0, movingAverages.Count - windowSize);

                for (int j = start; j < movingAverages.Count; j++)
                {
                    sum += movingAverages[j];
                }

                double nextValue = sum / Math.Min(windowSize, movingAverages.Count);
                forecast.Add(nextValue);
                movingAverages.Add(nextValue);
            }

            return forecast;
        }
    }
}
