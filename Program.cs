using System;

class Program
{
    static void Main()    
    {
        ShowMainMenu();
       }

    static void  
    ShowMainMenu()
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
            case 1:
                ShowBooksMenu();
                break;

            case 2:
                ShowUsersMenu();
                break;

            case 3:
                ShowLoansMenu();
                break;

            case 4:
                ShowSearchReportsMenu();
                break;

            case 5:
                ShowPersistenceMenu();
                break;

            case 6:
                ConfirmExitAndSave();
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }

    } while (option != 6);
}

static void ShowBooksMenu()
{
    int option = 0;

    do
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ LIBROS ===");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("0. Volver");
        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1: RegisterBook(); break;
            case 2: ListBooksMenu(); break;
            case 3: ViewBookDetail(); break;
            case 4: UpdateBookMenu(); break;
            case 5: DeleteBook(); break;
            case 0: return;
            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }

    } while (option != 0);
}

static void ListBooksMenu()
{
    int option = 0;

    do
    {
        Console.Clear();
        Console.WriteLine("=== LISTAR LIBROS ===");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("0. Volver");
        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1: ListBooksAll(); break;
            case 2: ListBooksAvailable(); break;
            case 3: ListBooksBorrowed(); break;
            case 0: return;
            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }

    } while (option != 0);
}

static void UpdateBookMenu()
{
    int option = 0;

    do
    {
        Console.Clear();
        Console.WriteLine("=== ACTUALIZAR LIBRO ===");
        Console.WriteLine("1. Editar título");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar año / categoría");
        Console.WriteLine("0. Volver");
        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1: EditBookTitle(); break;
            case 2: EditBookAuthor(); break;
            case 3: EditBookYearCategory(); break;
            case 0: return;
            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }

    } while (option != 0);
}

static void RegisterBook() => Console.WriteLine("Registrar libro (simulación).");
static void ViewBookDetail() => Console.WriteLine("Ver detalle de libro (simulación).");
static void DeleteBook() => Console.WriteLine("Eliminar libro (validar si está prestado).");

static void ListBooksAll() => Console.WriteLine("Listar todos los libros (simulación).");
static void ListBooksAvailable() => Console.WriteLine("Listar libros disponibles (simulación).");
static void ListBooksBorrowed() => Console.WriteLine("Listar libros prestados (simulación).");

static void EditBookTitle() => Console.WriteLine("Editar título del libro (simulación).");
static void EditBookAuthor() => Console.WriteLine("Editar autor del libro (simulación).");
static void EditBookYearCategory() => Console.WriteLine("Editar año/categoría del libro (simulación).");