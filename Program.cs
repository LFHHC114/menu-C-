using System;

class Program
{
    static void Main()
    {
        ShowMainMenu();
    }

    static void ShowMainMenu()
    {
        int option = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("== SISTEMA DE BIBLIOTECA ==");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ShowBooksMenu(); break;
                case 2: ShowUsersMenu(); break;
                case 3: ShowLoansMenu(); break;
                case 4: ShowSearchReportsMenu(); break;
                case 5: ShowPersistenceMenu(); break;
                case 6: ConfirmExitAndSave(); break;
                default:
                    Console.WriteLine("Opción inválida");
                    Console.ReadKey();
                    break;
            }

        } while (option != 6);
    }

    // Stubs para que compile:
    static void ShowBooksMenu() => Console.WriteLine("Menú Libros (simulación).");
    static void ShowUsersMenu() => Console.WriteLine("Menú Usuarios (simulación).");
    static void ShowLoansMenu() => Console.WriteLine("Menú Préstamos (simulación).");
    static void ShowSearchReportsMenu() => Console.WriteLine("Menú Búsquedas y Reportes (simulación).");
    static void ShowPersistenceMenu() => Console.WriteLine("Menú Persistencia (simulación).");
    static void ConfirmExitAndSave() => Console.WriteLine("Salir del sistema (simulación).");
}