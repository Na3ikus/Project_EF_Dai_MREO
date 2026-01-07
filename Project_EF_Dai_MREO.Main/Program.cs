using System.Text;
using DAI_MREO.Configuration;
using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.UI;

namespace DAI_MREO
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== DAI MREO System Initialization ===\n");

            var context = DatabaseConfigurator.ConfigureAndConnect();
            if (context == null)
            {
                Console.WriteLine("Натисніть Enter для виходу.");
                Console.ReadLine();
                return;
            }

            var logger = new ErrorLogger();

            using var unitOfWork = new UnitOfWork(context, logger);

            var menus = new List<IMenu>
            {
                new PersonMenu(unitOfWork.Persons, logger),
                new BrandMenu(unitOfWork.Brands, logger),
                new CountryMenu(unitOfWork.Countries, logger),
                new CarMenu(unitOfWork.Cars, logger),
                new SystemMenu(logger),
            };

            var consoleUI = new ConsoleUI(logger, menus);
            consoleUI.Run();

            Console.WriteLine("\nРоботу завершено. Збереження логів...");
            logger.SaveToFile();
            Console.WriteLine("Натисніть Enter для виходу.");
            Console.ReadLine();
        }
    }
}