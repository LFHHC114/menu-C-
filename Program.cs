using System;

class Program

{
    static void Main()
    {
        ShowMainMenu();
    }
      
    static LibroService libroService = new LibroService();
    static UsuarioService usuarioService = new UsuarioService();
     static PrestamoService prestamoService = new PrestamoService();

      static void TestModels()
{
    Console.Clear();
    Console.WriteLine("=== PRUEBA DE MODELOS ===");

    // LIBROS
    Libro libro1 = new Libro(1, "Cien años de soledad", "Gabriel García Márquez", 1967, "Novela");
    Libro libro2 = new Libro(2, "1984", "George Orwell", 1949, "Distopía");

    // USUARIOS
    Usuario user1 = new Usuario(1, "Juan", "123456");
    Usuario user2 = new Usuario(2, "Ana", "789456");

    // PRÉSTAMO
    Prestamo prestamo1 = new Prestamo(1, libro1, user1, DateTime.Now.AddDays(-10));

    Console.WriteLine("\n--- LIBROS ---");
    Console.WriteLine(libro1.ResumenCorto());
    Console.WriteLine(libro1.DetalleCompleto());

    Console.WriteLine("\n--- USUARIOS ---");
    Console.WriteLine(user1.ResumenCorto());
    Console.WriteLine(user1.DetalleCompleto());

    Console.WriteLine("\n--- PRÉSTAMO ---");
    Console.WriteLine(prestamo1.ResumenCorto());
    Console.WriteLine(prestamo1.DetalleCompleto());

    Console.WriteLine("\n--- VALIDACIONES ---");
    Console.WriteLine("Disponible: " + libro1.Disponible);
    Console.WriteLine("Usuario activo: " + user1.Activo);
    Console.WriteLine("Estado préstamo: " + prestamo1.Estado);
    Console.WriteLine("¿Está vencido?: " + prestamo1.EstaVencido());
    Console.WriteLine("Días transcurridos: " + prestamo1.DiasTranscurridos());

    Console.WriteLine("\nPresione una tecla para volver...");
    Console.ReadKey();
}

static void TestServices()
{
    Console.Clear();
    Console.WriteLine("=== PRUEBA SERVICES ===");

    // 1. Crear servicios
    var libroService = new LibroService();
    var usuarioService = new UsuarioService();
    var prestamoService = new PrestamoService();

    // 2. Crear datos
    var libro = new Libro(1, "1984", "Orwell", 1949, "Distopía");
    var usuario = new Usuario(1, "Juan", "123");

    // =========================
    // LIBROS
    // =========================
    Console.WriteLine("\n=== LIBROS ===");

    // AGREGAR
    libroService.AgregarLibro(libro);
    Console.WriteLine("Libro agregado");

    // LISTAR
    Console.WriteLine("\nLista de libros:");
    foreach (var l in libroService.ObtenerTodos())
    {
        Console.WriteLine(l.ResumenCorto());
    }

    // BUSCAR
    Console.WriteLine("\nBuscar libro:");
    var encontrado = libroService.BuscarPorTitulo("1984");

    if (encontrado != null)
    {
        Console.WriteLine(encontrado.DetalleCompleto());
    }

    // ELIMINAR
    Console.WriteLine("\nEliminar libro:");
    libroService.EliminarLibro(libro.Id);
    Console.WriteLine("Libro eliminado");

    // VERIFICAR
    Console.WriteLine("\nLista final libros:");
    foreach (var l in libroService.ObtenerTodos())
    {
        Console.WriteLine(l.ResumenCorto());
    }

    // =========================
    // USUARIOS
    // =========================
    Console.WriteLine("\n=== USUARIOS ===");

    usuarioService.AgregarUsuario(usuario);
    Console.WriteLine("Usuario agregado");

    Console.WriteLine("\nLista de usuarios:");
    foreach (var u in usuarioService.ObtenerTodos())
    {
        Console.WriteLine(u.ResumenCorto());
    }

    // =========================
    // PRÉSTAMOS
    // =========================
    Console.WriteLine("\n=== PRÉSTAMOS ===");

    var prestamo = new Prestamo(1, libro, usuario, DateTime.Now.AddDays(-5));

    // AGREGAR
    prestamoService.AgregarPrestamo(prestamo);
    Console.WriteLine("Préstamo agregado");

    // LISTAR
    Console.WriteLine("\nLista de préstamos:");
    foreach (var p in prestamoService.ObtenerTodos())
    {
        Console.WriteLine(p.ResumenCorto());
    }

    // BUSCAR
    Console.WriteLine("\nBuscar préstamos activos:");
    var activos = prestamoService.BuscarPorEstado(EstadoPrestamo.Activo);

    foreach (var p in activos)
    {
        Console.WriteLine(p.DetalleCompleto());
    }

    // ELIMINAR
    Console.WriteLine("\nEliminar préstamo:");
    prestamoService.EliminarPrestamo(prestamo.Id);
    Console.WriteLine("Préstamo eliminado");

    // VERIFICAR
    Console.WriteLine("\nLista final préstamos:");
    foreach (var p in prestamoService.ObtenerTodos())
    {
        Console.WriteLine(p.ResumenCorto());
    }

    // =========================
    // KPIs
    // =========================
    Console.WriteLine("\n=== KPIs ===");

    Console.WriteLine("\n--- LIBROS ---");
    Console.WriteLine("Total: " + libroService.TotalLibros());
    Console.WriteLine("Disponibles: " + libroService.LibrosDisponibles());

    Console.WriteLine("\n--- USUARIOS ---");
    Console.WriteLine("Activos: " + usuarioService.UsuariosActivos());

    Console.WriteLine("\n--- PRÉSTAMOS ---");
    Console.WriteLine("Total: " + prestamoService.TotalPrestamos());
    Console.WriteLine("Activos: " + prestamoService.PrestamosActivos());
    Console.WriteLine("Vencidos: " + prestamoService.PrestamosVencidos());
    Console.WriteLine("Devueltos: " + prestamoService.PrestamosDevueltos());
    Console.WriteLine("Promedio días: " + prestamoService.PromedioDiasPrestamo());

    Console.WriteLine("\nPresione una tecla para volver...");
    Console.ReadKey();
}
    // ============================
    // ARRAY VS LIST
    // ============================
    static void ComparacionArrayList()
    {
        Console.Clear();

        Console.WriteLine("=== ARRAY ===");
        int[] numeros = new int[3] { 1, 2, 3 };
        Console.WriteLine("Tamaño fijo (no crece)");

        Console.WriteLine("\n=== LIST ===");
        List<int> lista = new List<int> { 1, 2, 3 };
        lista.Add(4);
        Console.WriteLine("Tamaño dinámico (sí crece)");

        Console.ReadKey();
    }

    // ==============================
    // MENÚ PRINCIPAL
    // ==============================


    static void ShowMainMenu()
    {
        int option;

        do
        {
            Console.Clear();

            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Probar modelos");
            Console.WriteLine("7. Probar services");
            Console.WriteLine("8. Comparación Array vs List");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                continue;
            }

            switch (option)
            {
                case 1: ShowBooksMenu(); break;
                case 2: ShowUsersMenu(); break;
                case 3: ShowLoansMenu(); break;
                case 4: ShowSearchReportsMenu(); break;
                case 5: ShowPersistenceMenu(); break;
                case 6: TestModels(); break;
                case 7: TestServices(); break;
                case 8: ComparacionArrayList(); break;
                case 9: ConfirmExitAndSave(); break;
                default:
                    Console.WriteLine("Opción no válida");
                    Console.ReadKey();
                    break;
            }

        } while (option != 9);
    }


    // ==============================
    // LIBROS
    // ==============================

    static void ShowBooksMenu()
    {
        int option;

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

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: RegisterBook(); break;
                case 2: ListBooksMenu(); break;
                case 3: ViewBookDetail(); break;
                case 4: UpdateBookMenu(); break;
                case 5: DeleteBook(); break;
            }

        } while (option != 0);
    }

    static void ListBooksMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR LIBROS ===");
            Console.WriteLine("1. Listar todos");
            Console.WriteLine("2. Listar disponibles");
            Console.WriteLine("3. Listar prestados");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ListBooksAll(); break;
                case 2: ListBooksAvailable(); break;
                case 3: ListBooksBorrowed(); break;
            }

        } while (option != 0);
    }

    static void UpdateBookMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR LIBRO ===");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: EditBookTitle(); break;
                case 2: EditBookAuthor(); break;
                case 3: EditBookYearCategory(); break;
            }

        } while (option != 0);
    }

    // ==============================
    // USUARIOS
    // ==============================

    static void ShowUsersMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle usuario");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: RegisterUser(); break;
                case 2: ListUsers(); break;
                case 3: ViewUserDetail(); break;
                case 4: UpdateUserMenu(); break;
                case 5: DeleteUser(); break;
            }

        } while (option != 0);
    }

    static void UpdateUserMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR USUARIO ===");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: EditUserName(); break;
                case 2: EditUserContact(); break;
                case 3: ToggleUserActiveStatus(); break;
            }

        } while (option != 0);
    }

    // ==============================
    // PRÉSTAMOS
    // ==============================

    static void ShowLoansMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRÉSTAMOS ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle préstamo");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: CreateLoan(); break;
                case 2: ListLoansMenu(); break;
                case 3: ViewLoanDetail(); break;
                case 4: RegisterReturn(); break;
                case 5: DeleteLoan(); break;
            }

        } while (option != 0);
    }

    static void ListLoansMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR PRÉSTAMOS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ListLoansAll(); break;
                case 2: ListLoansActive(); break;
                case 3: ListLoansClosed(); break;
            }

        } while (option != 0);
    }

    // ==============================
    // BÚSQUEDAS Y REPORTES
    // ==============================

    static void ShowSearchReportsMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: SearchBook(); break;
                case 2: SearchUser(); break;
                case 3: ShowReportsMenu(); break;
            }

        } while (option != 0);
    }

    static void ShowReportsMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== REPORTES ===");
            Console.WriteLine("1. Reporte por usuario");
            Console.WriteLine("2. Reporte por libro");
            Console.WriteLine("3. Libros vencidos");
            Console.WriteLine("4. Resumen");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ReportByUser(); break;
                case 2: ReportByBook(); break;
                case 3: ReportOverdue(); break;
                case 4: ReportSummary(); break;
            }

        } while (option != 0);
    }

    // ==============================
    // PERSISTENCIA
    // ==============================

    static void ShowPersistenceMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== PERSISTENCIA ===");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: SaveData(); break;
                case 2: LoadData(); break;
                case 3: ConfirmResetData(); break;
            }

        } while (option != 0);
    }

    // ==============================
    // FUNCIONES STUB
    // ==============================

    static void RegisterBook()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR LIBRO ===");

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Autor: ");
    string autor = Console.ReadLine();

    Console.Write("Año: ");
    if (!int.TryParse(Console.ReadLine(), out int anio))
    {
        Console.WriteLine("Año inválido");
        Console.ReadKey();
        return;
    }

    Console.Write("Categoría: ");
    string categoria = Console.ReadLine();

    var libro = new Libro(id, titulo, autor, anio, categoria);
    libroService.AgregarLibro(libro);

    Console.WriteLine(" Libro registrado");
    Console.ReadKey();
}
    static void ListBooksAll()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE LIBROS ===");

    foreach (var l in libroService.ObtenerTodos())
    {
        Console.WriteLine(l.ResumenCorto());
    }

    Console.ReadKey();
}
    static void ListBooksAvailable() { Console.WriteLine("Listar libros disponibles"); Console.ReadKey(); }
    static void ListBooksBorrowed() { Console.WriteLine("Listar libros prestados"); Console.ReadKey(); }
    static void ViewBookDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE DEL LIBRO ===");

    Console.Write("Ingrese ID del libro: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var libro = libroService.ObtenerTodos()
                            .FirstOrDefault(l => l.Id == id);

    if (libro != null)
    {
        Console.WriteLine("\n--- INFORMACIÓN ---");
        Console.WriteLine(libro.DetalleCompleto());
    }
    else
    {
        Console.WriteLine("Libro no encontrado");
    }

    Console.ReadKey();
}
   static void EditBookTitle()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR TÍTULO ===");

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == id);

    if (libro == null)
    {
        Console.WriteLine("Libro no encontrado");
        Console.ReadKey();
        return;
    }

    Console.Write("Nuevo título: ");
    libro.Titulo = Console.ReadLine();

    Console.WriteLine("Actualizado");
    Console.ReadKey();
}
    static void EditBookAuthor() { Console.WriteLine("Editar autor del libro"); Console.ReadKey(); }
    static void EditBookYearCategory() { Console.WriteLine("Editar año o categoría"); Console.ReadKey(); }
    static void DeleteBook()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR LIBRO ===");

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == id);

    if (libro == null)
    {
        Console.WriteLine("Libro no encontrado");
        Console.ReadKey();
        return;
    }

    libroService.EliminarLibro(id);

    Console.WriteLine("Libro eliminado");
    Console.ReadKey();
}

   static void RegisterUser()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR USUARIO ===");

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Contacto: ");
    string contacto = Console.ReadLine();

    var usuario = new Usuario(id, nombre, contacto);
    usuarioService.AgregarUsuario(usuario);

    Console.WriteLine(" Usuario registrado");
    Console.ReadKey();
}
   static void ListUsers()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE USUARIOS ===");

    foreach (var u in usuarioService.ObtenerTodos())
    {
        Console.WriteLine(u.ResumenCorto());
    }

    Console.ReadKey();
}
    static void ViewUserDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE DEL USUARIO ===");

    Console.Write("Ingrese ID del usuario: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var usuario = usuarioService.ObtenerTodos()
                                .FirstOrDefault(u => u.Id == id);

    if (usuario != null)
    {
        Console.WriteLine("\n--- INFORMACIÓN ---");
        Console.WriteLine(usuario.DetalleCompleto());
    }
    else
    {
        Console.WriteLine("Usuario no encontrado");
    }

    Console.ReadKey();
}
    static void EditUserName()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR USUARIO ===");

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado");
        Console.ReadKey();
        return;
    }

    Console.Write("Nuevo nombre: ");
    usuario.Nombre = Console.ReadLine();

    Console.WriteLine("Usuario actualizado");
    Console.ReadKey();
}
    static void EditUserContact()
{
    Console.Clear();
    Console.WriteLine("=== EDITAR CONTACTO ===");

    Console.Write("ID del usuario: ");
    int id = int.Parse(Console.ReadLine());

    var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);

    if (usuario != null)
    {
        Console.Write("Nuevo contacto: ");
        usuario.Contacto = Console.ReadLine();

        Console.WriteLine(" Contacto actualizado.");
    }
    else
    {
        Console.WriteLine(" Usuario no encontrado.");
    }

    Console.ReadKey();
}
    static void ToggleUserActiveStatus()
{
    Console.Clear();
    Console.WriteLine("=== ACTIVAR / DESACTIVAR USUARIO ===");

    Console.Write("ID del usuario: ");
    int id = int.Parse(Console.ReadLine());

    var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);

    if (usuario != null)
    {
        usuario.Activo = !usuario.Activo;

        Console.WriteLine("Estado cambiado.");
    }
    else
    {
        Console.WriteLine("Usuario no encontrado.");
    }

    Console.ReadKey();
}
   static void DeleteUser()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR USUARIO ===");

    Console.Write("ID: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado");
        Console.ReadKey();
        return;
    }

    usuarioService.EliminarUsuario(id);

    Console.WriteLine(" Usuario eliminado");
    Console.ReadKey();
}
    static void CreateLoan() { Console.WriteLine("Crear préstamo (mostrar validaciones)"); Console.ReadKey(); }
    static void ListLoansAll() { Console.WriteLine("Listar todos los préstamos"); Console.ReadKey(); }
    static void ListLoansActive() { Console.WriteLine("Listar préstamos activos"); Console.ReadKey(); }
    static void ListLoansClosed() { Console.WriteLine("Listar préstamos cerrados"); Console.ReadKey(); }
    static void ViewUserDetail()
{
    Console.Clear();
    Console.WriteLine("=== DETALLE DEL USUARIO ===");

    Console.Write("Ingrese ID del usuario: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("ID inválido");
        Console.ReadKey();
        return;
    }

    var usuario = usuarioService.ObtenerTodos()
                                .FirstOrDefault(u => u.Id == id);

    if (usuario != null)
    {
        Console.WriteLine("\n--- INFORMACIÓN ---");
        Console.WriteLine(usuario.DetalleCompleto());
    }
    else
    {
        Console.WriteLine("Usuario no encontrado");
    }

    Console.ReadKey();
}
    static void RegisterReturn() { Console.WriteLine("Registrar devolución"); Console.ReadKey(); }
    static void DeleteLoan() { Console.WriteLine("Eliminar préstamo"); Console.ReadKey(); }

    static void SearchBook() { Console.WriteLine("Buscar libro"); Console.ReadKey(); }
    static void SearchUser() { Console.WriteLine("Buscar usuario"); Console.ReadKey(); }
    static void ReportByUser() { Console.WriteLine("Reporte por usuario"); Console.ReadKey(); }
    static void ReportByBook() { Console.WriteLine("Reporte por libro"); Console.ReadKey(); }
    static void ReportOverdue() { Console.WriteLine("Reporte de préstamos vencidos"); Console.ReadKey(); }
    static void ReportSummary() { Console.WriteLine("Resumen del sistema"); Console.ReadKey(); }

    static void SaveData() { Console.WriteLine("Datos guardados"); Console.ReadKey(); }
    static void LoadData() { Console.WriteLine("Datos cargados"); Console.ReadKey(); }

    static void ResetData()
    {
        Console.WriteLine("Datos reiniciados");
        Console.ReadKey();
    }

    static void ConfirmResetData()
    {
        Console.WriteLine("¿Seguro que desea reiniciar los datos? (S/N)");
        string answer = Console.ReadLine();

        if (answer.ToUpper() == "S")
        {
            ResetData();
        }
    }

    static void ConfirmExitAndSave()
    {
        Console.WriteLine("¿Desea guardar antes de salir? (S/N)");
        string answer = Console.ReadLine();

        if (answer.ToUpper() == "S")
        {
            SaveData();
        }

        Console.WriteLine("Saliendo del sistema...");
        Console.ReadKey();
    }
} 