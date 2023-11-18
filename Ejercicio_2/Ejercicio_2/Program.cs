using (var contextdb = new Contextobd())
{
    contextdb.Database.EnsureCreated();

    while (true)
    {
        Console.WriteLine("Menu de notas");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("| Seleccione una opción que desea realizar:        |");
        Console.WriteLine("| 1- Agregar un nuevo registro                     |");
        Console.WriteLine("| 2- Mostrar los datos de la tabla                 |");
        Console.WriteLine("| 3- Salir                                         |");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        Console.Write("Usuario ingrese el número de la opción que quiere realizar: ");

        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            switch (opcion)
            {
                case 1:
                    var Agregar_Nuevo_Registros = true;
                    while (Agregar_Nuevo_Registros)
                    {
                        Console.WriteLine("Ingrese el nombre del estudiante:");
                        string nombreEstudiante = Console.ReadLine();

                        Console.WriteLine("Ingrese la nota del primer parcial:");
                        double parcial1 = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la nota del segundo parcial:");
                        double parcial2 = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la nota del tercer parcial:");
                        double parcial3 = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la nota del primer laboratorio:");
                        double lab1 = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la nota del segundo laboratorio:");
                        double lab2 = double.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese la nota del tercer laboratorio:");
                        double lab3 = double.Parse(Console.ReadLine());

                        double notaFinalParciales = (parcial1 + parcial2 + parcial3) / 3;
                        double notaFinalLaboratorios = (lab1 + lab2 + lab3) / 3;

                        var nota1 = new Notas()
                        {
                            estudiante = nombreEstudiante,
                            parciales = notaFinalParciales,
                            laboratorios = notaFinalLaboratorios,
                            final = (notaFinalParciales + notaFinalLaboratorios) / 2
                        };

                        using (var contextobd = new Contextobd())
                        {
                            contextdb.Notas.Add(nota1);
                            contextdb.SaveChanges();
                            Console.WriteLine("Registro agregado con éxito.");
                        }

                        Console.Write(@"Usuario ¿Desea agregar más registros?
Si su respuesta es si ingrese la letra: S
Si su respuesta es No ingrese la letra: N (Y volvera al menu inicial)
Ingrese su respuesta: ");
                        string Respuesta_del_usuario = Console.ReadLine();

                        Agregar_Nuevo_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
                    }
                    break;

                //              
                case 2:
                    using (var sqlserver = new Contextobd())
                    {

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("|                              Datos de la tabla                                    |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("| Id   | Estudiantes                  | Parciales        | laboratorios | final     |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");

                        foreach (var item in sqlserver.Notas)
                        {
                            Console.WriteLine($"| {item.id,-4} | {item.estudiante,-27} | {item.parciales,-27} | {item.laboratorios,-3} | {item.final,-5}|");
                        }

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    { Console.WriteLine("Hecho por Josue Bryan Hernandez Zelaya "); }
                    return;
                default:
                    Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                    break;

            }
        }
        else
        {
            Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
        }
    }
}


