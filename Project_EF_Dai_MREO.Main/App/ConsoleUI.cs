using DAI_MREO.Services;

namespace DAI_MREO.UI
{
    public class ConsoleUI
    {
        private readonly ErrorLogger logger;
        private readonly List<IMenu> menus;

        public ConsoleUI(ErrorLogger logger, IEnumerable<IMenu> menus)
        {
            this.logger = logger;
            this.menus = menus.ToList();
        }

        public void Run()
        {
            while (true)
            {
                var menuNames = new List<string>();
                foreach (var menu in this.menus)
                {
                    menuNames.Add(menu.Name);
                }

                menuNames.Add("Вихід");

                int selectedIndex = ConsoleHelper.ShowInteractiveMenu("ГОЛОВНЕ МЕНЮ", menuNames.AsReadOnly());

                if (selectedIndex == this.menus.Count)
                {
                    return;
                }

                try
                {
                    this.menus[selectedIndex].Run();
                }
                catch (Exception ex)
                {
                    ConsoleHelper.ShowError($"Помилка запуску меню: {ex.Message}");
                    this.logger.Log(ex);
                }
            }
        }
    }
}