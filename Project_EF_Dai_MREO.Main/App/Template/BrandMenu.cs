using System.Collections.ObjectModel;
using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.UI.Design;
using DaiMreo_models;

namespace DAI_MREO.UI
{
    public class BrandMenu : BaseCrudMenu<Brand>
    {
        public BrandMenu(IRepository<Brand> service, ErrorLogger logger)
            : base(service, logger)
        {
        }

        protected override string GetEntityName() => "Бренди авто";

        protected override ReadOnlyCollection<(string Name, Action Action)> GetCustomActions()
        {
            var actions = new List<(string Name, Action Action)>
            {
                ("Знайти бренд за назвою", this.HandleSearch),
            };
            return new ReadOnlyCollection<(string Name, Action Action)>(actions);
        }

        protected override Brand GetDetailsForCreate()
        {
            string brandName = ConsoleHelper.ReadString("Введіть назву нового бренду: ", 50);
            return new Brand { BrandName = brandName ?? string.Empty };
        }

        protected override void GetDetailsForUpdate(Brand itemToUpdate)
        {
            ArgumentNullException.ThrowIfNull(itemToUpdate);
            Console.WriteLine($"Поточна назва: {itemToUpdate.BrandName}");
            itemToUpdate.BrandName = ConsoleHelper.ReadString("Введіть нову назву бренду: ", 50, false);
        }

        protected override void ShowAll(IEnumerable<Brand> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            var headers = new[] { "ID", "Назва Бренду" };
            var widths = new[] { 6, 50 };

            var rows = new List<string[]>();
            foreach (var brand in items)
            {
                rows.Add(new[]
                {
                    brand.BrandId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    brand.BrandName,
                });
            }

            Window.DrawTable(headers, new ReadOnlyCollection<string[]>(rows), widths);
        }

        private void HandleSearch()
        {
            Window.DrawHeader("Пошук бренду");
            string query = ConsoleHelper.ReadString("Введіть частину назви бренду: ", 50);

            var results = this.service.Find(b => b.BrandName != null && b.BrandName.Contains(query, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\n--- Результати пошуку ('{query}') ---");
            if (!results.Any())
            {
                Window.ShowError("Брендів не знайдено.");
            }
            else
            {
                this.ShowAll(results);
            }
        }
    }
}