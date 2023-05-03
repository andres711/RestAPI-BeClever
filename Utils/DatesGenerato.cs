namespace API_Clever.Utils
{
    public class RandomDates
    {
        public static DateTime Generate()
        {
            Random rnd = new Random();
            DateTime start = new DateTime(2023, 1, 1);
            DateTime end = new DateTime(2023, 12, 31);

            TimeSpan timeSpan = end - start;
            TimeSpan randomTimeSpan = new TimeSpan(0, rnd.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime randomDate = start + randomTimeSpan;

            return randomDate;
            
        }

    }
}