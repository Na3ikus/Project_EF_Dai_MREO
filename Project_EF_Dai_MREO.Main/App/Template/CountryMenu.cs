using System.Collections.ObjectModel;
using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.UI.Design;
using DaiMreo_models;

namespace DAI_MREO.UI
{
    public class CountryMenu : BaseCrudMenu<Country>
    {
        public CountryMenu(IRepository<Country> service, ErrorLogger logger)
            : base(service, logger)
        {
        }

        protected override string GetEntityName() => "Країни-виробники";

        protected override void ShowCustomMenuOptions()
        {
            // No custom menu options are required for CountryMenu.
            // This method is intentionally left empty.
        }

        protected override bool HandleCustomOption(string input)
        {
            if (input == "5")
            {
                this.HandleSearch();
                return true;
            }

            return false;
        }

        protected override Country GetDetailsForCreate()
        {
            string countryName = ConsoleHelper.ReadString("Введіть назву нової країни: ", 50);
            return new Country { CountryName = countryName ?? string.Empty };
        }

        protected override void GetDetailsForUpdate(Country itemToUpdate)
        {
            ArgumentNullException.ThrowIfNull(itemToUpdate);
            Console.WriteLine($"Поточна назва: {itemToUpdate.CountryName}");
            itemToUpdate.CountryName = ConsoleHelper.ReadString("Введіть нову назву країни: ", 50, false);
        }

        protected override void ShowAll(IEnumerable<Country> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            var headers = new[] { "ID", "Назва Країни" };
            var widths = new[] { 6, 50 };

            var rows = new List<string[]>();
            foreach (var country in items)
            {
                rows.Add(new[]
                {
                    country.CountryId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    country.CountryName,
                });
            }

            Window.DrawTable(headers, new ReadOnlyCollection<string[]>(rows), widths);
        }

        private void HandleSearch()
        {
            Window.DrawHeader("Пошук країни");
            string query = ConsoleHelper.ReadString("Введіть частину назви країни: ", 50);

            var results = this.service.Find(c => c.CountryName != null && c.CountryName.Contains(query, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\n--- Результати пошуку ('{query}') ---");
            if (!results.Any())
            {
                Window.ShowError("Країн не знайдено.");
            }
            else
            {
                this.ShowAll(results);
            }
        }
    }
}