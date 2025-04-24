using System.Runtime.InteropServices;

namespace AtelierPro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Отключает DPI-масштабирование для всего приложения
            SetProcessDPIAware(); // Для старых версий Windows (до 8.1)
                                  // Или для Windows 10+:
            SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.Process_DPI_Unaware);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }

        // Импорт функций WinAPI
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("shcore.dll")]
        private static extern bool SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);

        public enum PROCESS_DPI_AWARENESS
        {
            Process_DPI_Unaware = 0,
            Process_System_DPI_Aware = 1,
            Process_Per_Monitor_DPI_Aware = 2
        }
    }
}