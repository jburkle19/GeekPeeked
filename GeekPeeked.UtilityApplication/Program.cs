using System;
using GeekPeeked.UtilityApplication.Processors;

namespace GeekPeeked.UtilityApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            Helpers.OutputMessage("###################################################################", ConsoleColor.Yellow);
            Helpers.OutputMessage(string.Format("Starting the GeekPeeked Utility Application - {0}", DateTime.Now.ToString()), ConsoleColor.Yellow);
            Helpers.OutputMessage("###################################################################", ConsoleColor.Yellow);
            Helpers.OutputMessage();

            do
            {
                Helpers.OutputMessage("1: process TMDb Jobs", ConsoleColor.Magenta);
                Helpers.OutputMessage("2: process TMDb Genres", ConsoleColor.Magenta);
                Helpers.OutputMessage("3: process TMDb Certifications", ConsoleColor.Magenta);
                Helpers.OutputMessage("4: process TMDb Movies By Year", ConsoleColor.Magenta);
                Helpers.OutputMessage("5: process TMDb Movies By Month", ConsoleColor.Magenta);
                Helpers.OutputMessage("6: process TMDb Movies By Day", ConsoleColor.Magenta);
                Helpers.OutputMessage("7: process IMDb Movie", ConsoleColor.Magenta);
                Helpers.OutputMessage("8: process All IMDb Movies", ConsoleColor.Magenta);
                Helpers.OutputMessage("0: Exit", ConsoleColor.Magenta);
                Helpers.OutputMessage();
                Helpers.RequestInput("Option", ConsoleColor.Magenta);
                string selection = Console.ReadLine();
                Helpers.OutputMessage();

                TmdbProcessor processor = new TmdbProcessor();

                switch (selection)
                {
                    case "1": // process Jobs

                        Helpers.OutputMessage("Processing Jobs...", ConsoleColor.Yellow);
                        Helpers.OutputMessage();

                        processor.ProcessTmdbJobs().Wait();

                        Helpers.OutputMessage();
                        Helpers.OutputMessage("Jobs processed!", ConsoleColor.Yellow);

                        break;
                    case "2": // process Genres

                        Helpers.OutputMessage("Processing Genres...", ConsoleColor.Yellow);
                        Helpers.OutputMessage();

                        processor.ProcessTmdbGenres().Wait();

                        Helpers.OutputMessage();
                        Helpers.OutputMessage("Genres processed!", ConsoleColor.Yellow);

                        break;
                    case "3": // process Certifications

                        Helpers.OutputMessage("Processing Certifications...", ConsoleColor.Yellow);
                        Helpers.OutputMessage();

                        processor.ProcessTmdbCertifications().Wait();

                        Helpers.OutputMessage();
                        Helpers.OutputMessage("Certifications processed!", ConsoleColor.Yellow);

                        break;
                    case "4": // process Movies By Year

                        Helpers.RequestInput("Year", ConsoleColor.Magenta);
                        int year = 0;
                        string yearSelection = Console.ReadLine();
                        if (Int32.TryParse(yearSelection, out year) && year > 0)
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("Processing {0} Movies...", year), ConsoleColor.Yellow);
                            Helpers.OutputMessage();

                            processor.ProcessTmdbMoviesByYear(year).Wait();

                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("{0} Movies processed!", year), ConsoleColor.Yellow);
                        }
                        else
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage("!!! Invalid Year entered !!!", ConsoleColor.Red);
                            Helpers.OutputMessage();
                        }

                        break;
                    case "5": // process Movies By Month

                        Helpers.RequestInput("Date", ConsoleColor.Magenta);
                        DateTime startDate = new DateTime();
                        string dateSelection = Console.ReadLine();
                        if (DateTime.TryParse(dateSelection, out startDate))
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("Processing Movies between {0} and {1}...", startDate, startDate.AddMonths(1)), ConsoleColor.Yellow);
                            Helpers.OutputMessage();

                            processor.ProcessTmdbMoviesByDates(startDate, startDate.AddMonths(1)).Wait();

                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("Movies between {0} and {1} processed!", startDate, startDate.AddMonths(1)), ConsoleColor.Yellow);
                        }
                        else
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage("!!! Invalid Date entered !!!", ConsoleColor.Red);
                            Helpers.OutputMessage();
                        }

                        break;
                    case "6": // process Movies By Day

                        Helpers.RequestInput("Date", ConsoleColor.Magenta);
                        DateTime dayStartDate = new DateTime();
                        string daySelection = Console.ReadLine();
                        if (DateTime.TryParse(daySelection, out dayStartDate))
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("Processing Movies on {0}...", dayStartDate), ConsoleColor.Yellow);
                            Helpers.OutputMessage();

                            processor.ProcessTmdbMoviesByDates(dayStartDate, dayStartDate).Wait();

                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("Movies on {0} processed!", dayStartDate), ConsoleColor.Yellow);
                        }
                        else
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage("!!! Invalid Date entered !!!", ConsoleColor.Red);
                            Helpers.OutputMessage();
                        }

                        break;
                    case "7": // process IMDb Movie

                        Helpers.RequestInput("IMDb Movie Id", ConsoleColor.Magenta);
                        string imdbId = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(imdbId))
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("Processing IMDb Movie {0}...", imdbId), ConsoleColor.Yellow);
                            Helpers.OutputMessage();

                            processor.ProcessImdbMovie(imdbId).Wait();

                            Helpers.OutputMessage();
                            Helpers.OutputMessage(string.Format("IMDb Movie {0} processed!", imdbId), ConsoleColor.Yellow);
                        }
                        else
                        {
                            Helpers.OutputMessage();
                            Helpers.OutputMessage("!!! Invalid IMDb Id entered !!!", ConsoleColor.Red);
                            Helpers.OutputMessage();
                        }

                        break;
                    case "8": // process All IMDb Movies

                            Helpers.OutputMessage("Processing IMDb Movies", ConsoleColor.Yellow);
                            Helpers.OutputMessage();

                            processor.ProcessImdbMovies().Wait();

                            Helpers.OutputMessage();
                        Helpers.OutputMessage("IMDb Movies Process!", ConsoleColor.Yellow);
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }

                Helpers.OutputMessage();

            } while (keepRunning);

            Helpers.OutputMessage();
            Helpers.OutputMessage("###################################################################", ConsoleColor.Yellow);
            Helpers.OutputMessage(string.Format("Exiting the GeekPeeked Utility Application - {0}", DateTime.Now.ToString()), ConsoleColor.Yellow);
            Helpers.OutputMessage("###################################################################", ConsoleColor.Yellow);

            Console.ReadLine();
        }
    }
}
