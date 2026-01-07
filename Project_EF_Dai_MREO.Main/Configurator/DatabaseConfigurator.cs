using System.IO;
using DAI_MREO.Data;
using DAI_MREO.UI;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DAI_MREO.Configuration
{
    public static class DatabaseConfigurator
    {
        public static MreoStorageContext? ConfigureAndConnect()
        {
            string baseConnectionString = string.Empty;
            bool configLoaded = false;

            try
            {
                var currentDir = Directory.GetCurrentDirectory();
                var configPath = Path.Combine(currentDir, "app_config.json");

                if (File.Exists(configPath))
                {
                    var configBuilder = new ConfigurationBuilder()
                        .SetBasePath(currentDir)
                        .AddJsonFile("app_config.json", optional: true, reloadOnChange: true);

                    var config = configBuilder.Build();
                    baseConnectionString = config.GetConnectionString("DefaultConnection") ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(baseConnectionString))
                    {
                        configLoaded = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Warning] Не вдалося прочитати конфіг: {ex.Message}");
            }

            if (!configLoaded)
            {
                ConsoleHelper.ShowError("Конфіг не знайдено або він порожній. Використовуємо стандартні налаштування.");
                baseConnectionString = "server=localhost;database=dai_mreo;user=root;password=;";
            }
            else
            {
                ConsoleHelper.ShowSuccess("Конфігурацію завантажено успішно.");
            }

            MySqlConnectionStringBuilder builder;
            try
            {
                builder = new MySqlConnectionStringBuilder(baseConnectionString);
            }
            catch
            {
                builder = new MySqlConnectionStringBuilder
                {
                    Server = "localhost",
                    UserID = "root",
                    Database = "dai_mreo",
                };
            }

            if (!string.IsNullOrWhiteSpace(builder.Password))
            {
                Console.WriteLine($"Базовий хост: {GetHostInfo(builder.ConnectionString)}");
                Console.WriteLine("Спроба автоматичного підключення за даними з конфігурації...");

                try
                {
                    using var testContext = new MreoStorageContext(builder.ConnectionString);
                    if (testContext.Database.CanConnect())
                    {
                        ConsoleHelper.ShowSuccess("Успішне підключення (автоматично)!");
                        ConsoleHelper.Pause();
                        return new MreoStorageContext(builder.ConnectionString);
                    }
                    else
                    {
                        ConsoleHelper.ShowError("Автопідключення не вдалось. Буде запропоновано ввести облікові дані вручну.");
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.ShowError($"Автопідключення завершилось помилкою: {ex.Message}");
                }
            }

            ConsoleHelper.PrintHeader("Налаштування підключення");
            Console.WriteLine($"Базовий хост: {GetHostInfo(builder.ConnectionString)}");
            Console.WriteLine("Будь ласка, введіть облікові дані для підключення.\n");

            string dbName = ConsoleHelper.ReadString("Введіть назву БД (Enter для стандартної): ", 50, isNullable: true);
            if (!string.IsNullOrWhiteSpace(dbName))
            {
                builder.Database = dbName;
            }

            while (true)
            {
                string password = ConsoleHelper.ReadPassword("Введіть пароль до БД: ");
                Console.WriteLine();

                builder.Password = password;

                Console.WriteLine("Спроба підключення...");

                try
                {
                    using var testContext = new MreoStorageContext(builder.ConnectionString);

                    if (testContext.Database.CanConnect())
                    {
                        ConsoleHelper.ShowSuccess("Успішне підключення!");
                        ConsoleHelper.Pause();
                        return new MreoStorageContext(builder.ConnectionString);
                    }
                    else
                    {
                        ConsoleHelper.ShowError("Не вдалося підключитися. Невірний пароль або сервер недоступний.");
                    }
                }
                catch (Exception ex)
                {
                    ConsoleHelper.ShowError($"Помилка підключення: {ex.Message}");
                }

                if (!ConsoleHelper.Confirm("Спробувати ще раз?"))
                {
                    Console.WriteLine("Скасування підключення...");
                    return null;
                }

                Console.WriteLine();
            }
        }

        private static string GetHostInfo(string connectionString)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    return "Empty";
                }

                var builder = new MySqlConnectionStringBuilder(connectionString);
                return $"{builder.Server} (User: {builder.UserID})";
            }
            catch
            {
                return "Unknown host";
            }
        }
    }
}