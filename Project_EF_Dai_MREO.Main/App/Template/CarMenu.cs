using System.Collections.ObjectModel;
using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.UI.Design;
using DaiMreo_models;

namespace DAI_MREO.UI
{
    public class CarMenu : BaseCrudMenu<Car>
    {
        public CarMenu(IRepository<Car> service, ErrorLogger logger)
            : base(service, logger)
        {
        }

        protected override string GetEntityName() => "Автомобілі";

        protected override void ShowCustomMenuOptions()
        {
            Console.WriteLine("5. [ПОШУК] Знайти авто за VIN-кодом");
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

        protected override Car GetDetailsForCreate()
        {
            Window.DrawHeader("Додавання автомобіля");

            return new Car
            {
                ModelFactoryId = (int)ConsoleHelper.ReadLong("ID Моделі (ModelFactoryId): "),
                VehicleTypeId = (int)ConsoleHelper.ReadLong("ID Типу ТЗ (VehicleTypeId): "),
                ColorId = (int)ConsoleHelper.ReadLong("ID Кольору (ColorId): "),
                ProductionDate = ConsoleHelper.ReadDateTime("Дата виробництва (дд.мм.рррр): "),
                TransmissionType = ConsoleHelper.ReadString("Тип трансмісії: ", 30),
                FuelType = ConsoleHelper.ReadString("Тип палива: ", 20),
                SecondFuelType = ConsoleHelper.ReadString("Другий тип палива (Enter, щоб пропустити): ", 20, true),
                VinNumber = ConsoleHelper.ReadString("VIN (Enter, щоб пропустити): ", 17, true),
                EngineSerialNumber = ConsoleHelper.ReadString("Серійний номер двигуна: ", 50, true),
            };
        }

        protected override void GetDetailsForUpdate(Car itemToUpdate)
        {
            ArgumentNullException.ThrowIfNull(itemToUpdate);

            Window.DrawHeader($"Редагування авто ID: {itemToUpdate.CarId}");

            itemToUpdate.ModelFactoryId = (int)ConsoleHelper.ReadLong("Новий ID Моделі: ");
            itemToUpdate.VehicleTypeId = (int)ConsoleHelper.ReadLong("Новий ID Типу ТЗ: ");
            itemToUpdate.ColorId = (int)ConsoleHelper.ReadLong("Новий ID Кольору: ");
            itemToUpdate.ProductionDate = ConsoleHelper.ReadDateTime("Нова дата (дд.мм.рррр): ");
            itemToUpdate.TransmissionType = ConsoleHelper.ReadString("Нова трансмісія: ", 30);
            itemToUpdate.FuelType = ConsoleHelper.ReadString("Нове паливо: ", 20);
            itemToUpdate.SecondFuelType = ConsoleHelper.ReadString("Нове 2-ге паливо: ", 20, true);
            itemToUpdate.VinNumber = ConsoleHelper.ReadString("Новий VIN: ", 17, true);
            itemToUpdate.EngineSerialNumber = ConsoleHelper.ReadString("Новий S/N двигуна: ", 50, true);
        }

        protected override void ShowAll(IEnumerable<Car> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            var headers = new[] { "ID", "Модель ID", "Тип ID", "Колір", "VIN", "Рік" };

            var widths = new[] { 5, 10, 8, 8, 20, 12 };

            var rows = new List<string[]>();

            foreach (var car in items)
            {
                rows.Add(new[]
                {
                    car.CarId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    car.ModelFactoryId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    car.VehicleTypeId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    car.ColorId.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    car.VinNumber ?? "-",
                    car.ProductionDate.ToShortDateString(),
                });
            }

            Window.DrawTable(headers, new ReadOnlyCollection<string[]>(rows), widths);
        }

        private void HandleSearch()
        {
            Window.DrawHeader("Пошук по VIN");
            string query = ConsoleHelper.ReadString("Введіть частину VIN-коду: ", 20);

            var results = this.service.Find(c => c.VinNumber != null && c.VinNumber.Contains(query));

            Console.WriteLine($"\n--- Результати пошуку VIN ('{query}') ---");
            if (!results.Any())
            {
                Window.ShowError("Авто не знайдено.");
            }
            else
            {
                this.ShowAll(results);
            }
        }
    }
}