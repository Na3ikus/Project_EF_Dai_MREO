using DAI_MREO.Services;
using DAI_MREO.UI.Design;

namespace DAI_MREO.UI
{
    public class SystemMenu : IMenu
    {
        private readonly ErrorLogger logger;

        public SystemMenu(ErrorLogger logger)
        {
            this.logger = logger;
        }

        public string Name => "Системні повідомлення (Логи)";

        public void Run()
        {
            Window.DrawHeader("Системні логи");

            this.logger.DisplayMessages();
            Console.WriteLine();

            if (ConsoleHelper.Confirm("Бажаєте зберегти логи у файл?"))
            {
                this.logger.SaveToFile();
                Window.ShowSuccess("Логи збережено успішно.");
            }

            ConsoleHelper.Pause();
        }
    }
}