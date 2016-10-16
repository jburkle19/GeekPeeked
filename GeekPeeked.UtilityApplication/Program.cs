using System;
using GeekPeeked.UtilityApplication.Processors;

namespace GeekPeeked.UtilityApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            Console.WriteLine("###########################################");
            Console.WriteLine(string.Format("Starting the GeekPeeked Utility Application ({0})", DateTime.Now.ToShortTimeString()));
            Console.WriteLine("###########################################");
            Console.WriteLine(string.Empty);

            do
            {
                Console.WriteLine("\t1: process TMDb Jobs");
                Console.WriteLine("\t2: process TMDb Genres");
                Console.WriteLine("\t3: process TMDb Certifications");
                Console.WriteLine("\t4: process TMDb Movies By Year");
                Console.WriteLine("\t0: Exit");
                Console.Write("=> ");
                string selection = Console.ReadLine();
                Console.WriteLine(string.Empty);

                TmdbProcessor processor = new TmdbProcessor();

                switch (selection)
                {
                    case "1": // process Jobs

                        Console.WriteLine("Processing Jobs...");
                        Console.WriteLine(string.Empty);

                        processor.ProcessTmdbJobs().Wait();

                        Console.WriteLine(string.Empty);
                        Console.WriteLine("Jobs processed!");

                        break;
                    case "2": // process Genres

                        Console.WriteLine("Processing Genres...");
                        Console.WriteLine(string.Empty);

                        processor.ProcessTmdbGenres().Wait();

                        Console.WriteLine(string.Empty);
                        Console.WriteLine("Genres processed!");

                        break;
                    case "3": // process Certifications

                        Console.WriteLine("Processing Certifications...");
                        Console.WriteLine(string.Empty);

                        processor.ProcessTmdbCertifications().Wait();

                        Console.WriteLine(string.Empty);
                        Console.WriteLine("Certifications processed!");

                        break;
                    case "4": // process Movies By Year

                        Console.Write("Year (yyyy) => ");
                        int year = 0;
                        string yearSelection = Console.ReadLine();
                        if (Int32.TryParse(yearSelection, out year) && year > 0)
                        {
                            Console.WriteLine(string.Empty);

                            Console.WriteLine(string.Format("Processing {0} Movies...", year));
                            Console.WriteLine(string.Empty);

                            processor.ProcessTmdbMoviesByYear(year).Wait();

                            Console.WriteLine(string.Empty);
                            Console.WriteLine(string.Format("{0} Movies processed!", year));
                        }
                        else
                        {
                            Console.WriteLine(string.Empty);
                            Console.WriteLine("!!! Invalid Year entered !!!");
                            Console.WriteLine(string.Empty);
                        }

                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }

                Console.WriteLine(string.Empty);

            } while (keepRunning);

            Console.WriteLine(string.Empty);
            Console.WriteLine("###########################################");
            Console.WriteLine(string.Format("Exiting the GeekPeeked Utility Application ({0})", DateTime.Now.ToShortTimeString()));
            Console.WriteLine("###########################################");

            Console.ReadLine();
        }
    }
}
