using System.Collections.ObjectModel;
using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.UI.Design;
using DaiMreo_models;

namespace DAI_MREO.UI
{
    public class PersonMenu : BaseCrudMenu<Person>
    {
        public PersonMenu(IRepository<Person> service, ErrorLogger logger)
            : base(service, logger)
        {
        }

        protected override string GetEntityName() => "Власники (Особи)";

        protected override void ShowCustomMenuOptions()
        {
            Console.WriteLine("5. [ПОШУК] Знайти за прізвищем");
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

        protected override void GetDetailsForUpdate(Person itemToUpdate)
        {
            ArgumentNullException.ThrowIfNull(itemToUpdate);
            Console.WriteLine($"Поточне ПІБ: {itemToUpdate.Surname} {itemToUpdate.Name} {itemToUpdate.MiddleName}");

            itemToUpdate.Surname = ConsoleHelper.ReadString("Нове прізвище: ", 100);
            itemToUpdate.Name = ConsoleHelper.ReadString("Нове ім'я: ", 100);
            itemToUpdate.MiddleName = ConsoleHelper.ReadString("Нове по-батькові: ", 100);
            itemToUpdate.DateOfBirth = ConsoleHelper.ReadDateTime("Нова дата народження (дд.мм.рррр): ");
        }

        protected override Person GetDetailsForCreate()
        {
            string surname = ConsoleHelper.ReadString("Прізвище: ", 100);
            string name = ConsoleHelper.ReadString("Ім'я: ", 100);
            string middleName = ConsoleHelper.ReadString("По-батькові: ", 100);
            System.DateTime dob = ConsoleHelper.ReadDateTime("Дата народження (дд.мм.рррр): ");

            return new Person { Surname = surname, Name = name, MiddleName = middleName, DateOfBirth = dob };
        }

        protected override void ShowAll(IEnumerable<Person> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            var headers = new[] { "ID", "Прізвище", "Ім'я", "По-батькові", "Дата народж." };
            var widths = new[] { 6, 25, 20, 20, 14 };

            var rows = new List<string[]>();
            foreach (var p in items)
            {
                rows.Add(new[]
                {
                    p.PersonId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    p.Surname,
                    p.Name,
                    p.MiddleName,
                    p.DateOfBirth.ToShortDateString(),
                });
            }

            Window.DrawTable(headers, new ReadOnlyCollection<string[]>(rows), widths);
        }

        private void HandleSearch()
        {
            Window.DrawHeader("Пошук особи");
            string query = ConsoleHelper.ReadString("Введіть частину прізвища: ", 50);

            var results = this.service.Find(p => p.Surname != null && p.Surname.Contains(query, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\n--- Результати пошуку ('{query}') ---");
            if (!results.Any())
            {
                Window.ShowError("Нікого не знайдено.");
            }
            else
            {
                this.ShowAll(results);
            }
        }
    }
}