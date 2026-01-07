using DAI_MREO.Repositories;
using DAI_MREO.Services;
using DAI_MREO.UI.Design;

namespace DAI_MREO.UI
{
    public abstract class BaseCrudMenu<T>(IRepository<T> service, ErrorLogger logger)
        : IMenu
        where T : class
    {
        protected readonly IRepository<T> service = service;
        protected readonly ErrorLogger logger = logger;

        public string Name => $"Керування: {this.GetEntityName()}";

        public void Run() => this.RunMenu();

        public virtual void RunMenu()
        {
            while (true)
            {
                var menuOptions = new List<string>
                {
                    "Показати всі",
                    "Додати новий",
                    "Оновити",
                    "Видалити",
                };

                var customActions = this.GetCustomActions();
                foreach (var action in customActions)
                {
                    menuOptions.Add(action.Name);
                }

                menuOptions.Add("Повернутися назад");

                int selectedIndex = ConsoleHelper.ShowInteractiveMenu(this.Name, menuOptions.AsReadOnly());

                try
                {
                    if (selectedIndex == menuOptions.Count - 1)
                    {
                        return;
                    }

                    switch (selectedIndex)
                    {
                        case 0: this.HandleShowAll(); break;
                        case 1: this.HandleCreate(); break;
                        case 2: this.HandleUpdate(); break;
                        case 3: this.HandleDelete(); break;
                        default:
                            int customActionIndex = selectedIndex - 4;
                            if (customActionIndex >= 0 && customActionIndex < customActions.Count)
                            {
                                Console.Clear();
                                customActions[customActionIndex].Action.Invoke();
                            }

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Window.ShowError($"Критична помилка меню: {ex.Message}");
                }

                ConsoleHelper.Pause();
            }
        }

        protected virtual System.Collections.ObjectModel.ReadOnlyCollection<(string Name, Action Action)> GetCustomActions()
        {
            return new System.Collections.ObjectModel.ReadOnlyCollection<(string Name, Action Action)>(
                new List<(string Name, Action Action)>());
        }

        protected virtual void ShowCustomMenuOptions()
        {
        }

        protected virtual bool HandleCustomOption(string input) => false;

        protected abstract string GetEntityName();

        protected abstract void ShowAll(IEnumerable<T> items);

        protected abstract T GetDetailsForCreate();

        protected abstract void GetDetailsForUpdate(T itemToUpdate);

        protected virtual void HandleDelete()
        {
            try
            {
                Window.DrawHeader($"Видалення: {this.GetEntityName()}");
                long idToDelete = ConsoleHelper.ReadLong("Введіть ID для видалення: ");

                if (ConsoleHelper.Confirm($"Ви впевнені, що хочете видалити запис ID {idToDelete}?"))
                {
                    this.service.Delete(idToDelete);
                    Window.ShowSuccess("Запис успішно видалено.");
                }
                else
                {
                    Console.WriteLine("Видалення скасовано.");
                }
            }
            catch (Exception ex)
            {
                Window.ShowError($"Помилка видалення: {ex.Message}");
                this.logger.Log(ex);
            }
        }

        protected virtual void HandleShowAll()
        {
            Window.DrawHeader($"Список: {this.GetEntityName()}");
            var items = this.service.GetAll();
            if (!items.Any())
            {
                Console.WriteLine("  Записів не знайдено.");
                return;
            }

            this.ShowAll(items);
        }

        protected virtual void HandleCreate()
        {
            try
            {
                Window.DrawHeader($"Створення: {this.GetEntityName()}");
                T newItem = this.GetDetailsForCreate();
                if (newItem != null)
                {
                    this.service.Create(newItem);
                    Window.ShowSuccess("Запис успішно додано.");
                }
            }
            catch (Exception ex)
            {
                Window.ShowError($"Помилка додавання: {ex.Message}");
                this.logger.Log(ex);
            }
        }

        protected virtual void HandleUpdate()
        {
            try
            {
                Window.DrawHeader($"Оновлення: {this.GetEntityName()}");
                int idToUpdate = (int)ConsoleHelper.ReadLong("Введіть ID для оновлення: ");
                var itemToUpdate = this.service.GetById(idToUpdate);
                if (itemToUpdate == null)
                {
                    Window.ShowError("Запис не знайдено.");
                    return;
                }

                this.GetDetailsForUpdate(itemToUpdate);
                this.service.Update(itemToUpdate);
                Window.ShowSuccess("Запис успішно оновлено.");
            }
            catch (Exception ex)
            {
                Window.ShowError($"Помилка оновлення: {ex.Message}");
                this.logger.Log(ex);
            }
        }
    }
}