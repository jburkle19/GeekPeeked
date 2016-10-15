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
                //Console.WriteLine("\t1: process Movie Genres");
                //Console.WriteLine("\t2: process Movie Certifications");
                //Console.WriteLine("\t0: Exit");
                Console.Write("=> ");
                string selection = Console.ReadLine();
                Console.WriteLine(string.Empty);

                //MovieProcessor movieProcessor = new MovieProcessor();

                switch (selection)
                {
                    //case "1": // process Movie Genres

                    //    Console.WriteLine("Processing Movie Genres...");
                    //    Console.WriteLine(string.Empty);

                    //    movieProcessor.ProcessMovieGenres().Wait();

                    //    Console.WriteLine(string.Empty);
                    //    Console.WriteLine("Movie Genres processed!");

                    //    break;
                    //case "2": // process Movie Certifications

                    //    Console.WriteLine("Processing Movie Certifications...");
                    //    Console.WriteLine(string.Empty);

                    //    movieProcessor.ProcessMovieCertifications().Wait();

                    //    Console.WriteLine(string.Empty);
                    //    Console.WriteLine("Movie Certifications processed!");

                    //    break;
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
