Imports System
Module distribuidor_de_recursos
    Sub Main(args As String())
        Dim ids(9) As Integer
        Dim recursos(9) As String
        Dim cantidadesDisponibles(9) As Integer
        Dim cantidadesAsignadas(9) As Integer
        Dim responsables(9) As String
        Dim estados(9) As String
        Dim cantidad As Integer = 0
        Dim opcion As Integer
        '---------------------------------------------'
        '--|menu_principal_distribuidor_de_recursos|--'
        '---------------------------------------------'
        Do
            Console.WriteLine("menu principal distribuidor de recursos")
            Console.WriteLine("1) Registrar recurso")
            Console.WriteLine("2) Editar recurso")
            Console.WriteLine("3) Listar recursos")
            Console.WriteLine("4) Buscar recurso")
            Console.WriteLine("5) Eliminar recurso")
            Console.WriteLine("6) Distribuir recurso")
            Console.WriteLine("7) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '-----------------------'
                '--|registrar_recurso|--'
                '-----------------------'
                Case 1
                    If cantidad >= ids.Length Then
                        Console.WriteLine("No hay espacio para registrar mas recursos.")
                    Else
                        ids(cantidad) = cantidad + 1
                        Console.Write("Ingrese el nombre del recurso: ")
                        recursos(cantidad) = Console.ReadLine()
                        Console.Write("Ingrese la cantidad disponible: ")
                        Dim cantidadDisponible As Integer = Convert.ToInt32(Console.ReadLine())
                        If cantidadDisponible < 0 Then
                            Console.WriteLine("La cantidad disponible no puede ser negativa.")
                        Else
                            cantidadesDisponibles(cantidad) = cantidadDisponible
                            cantidadesAsignadas(cantidad) = 0
                            Console.Write("Ingrese el responsable: ")
                            responsables(cantidad) = Console.ReadLine()
                            estados(cantidad) = "Disponible"
                            cantidad += 1
                            Console.WriteLine("Recurso registrado correctamente.")
                            Console.WriteLine("ID: " & ids(cantidad - 1) & " | Recurso: " & recursos(cantidad - 1) & " | Disponible: " & cantidadesDisponibles(cantidad - 1) & " | Asignado: " & cantidadesAsignadas(cantidad - 1) & " | Responsable: " & responsables(cantidad - 1) & " | Estado: " & estados(cantidad - 1))
                        End If
                    End If
                '--------------------'
                '--|editar_recurso|--'
                '--------------------'
                Case 2
                    If cantidad = 0 Then
                        Console.WriteLine("No existen recursos registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Recurso: " & recursos(i) & " | Disponible: " & cantidadesDisponibles(i) & " | Asignado: " & cantidadesAsignadas(i) & " | Responsable: " & responsables(i) & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del recurso a editar: ")
                        Dim idEditar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEditar >= 1 AndAlso idEditar <= cantidad Then
                            Dim posicion As Integer = idEditar - 1
                            Console.Write("Nuevo nombre del recurso: ")
                            recursos(posicion) = Console.ReadLine()
                            Console.Write("Nueva cantidad disponible: ")
                            Dim nuevaCantidad As Integer = Convert.ToInt32(Console.ReadLine())
                            If nuevaCantidad < cantidadesAsignadas(posicion) Then
                                Console.WriteLine("La cantidad disponible no puede ser menor que la cantidad ya asignada.")
                            ElseIf nuevaCantidad < 0 Then
                                Console.WriteLine("La cantidad disponible no puede ser negativa.")
                            Else
                                cantidadesDisponibles(posicion) = nuevaCantidad
                                Console.Write("Nuevo responsable: ")
                                responsables(posicion) = Console.ReadLine()
                                If cantidadesDisponibles(posicion) = 0 Then
                                    estados(posicion) = "Agotado"
                                ElseIf cantidadesAsignadas(posicion) > 0 Then
                                    estados(posicion) = "Parcial"
                                Else
                                    estados(posicion) = "Disponible"
                                End If
                                Console.WriteLine("Recurso actualizado correctamente.")
                                Console.WriteLine("ID: " & ids(posicion) & " | Recurso: " & recursos(posicion) & " | Disponible: " & cantidadesDisponibles(posicion) & " | Asignado: " & cantidadesAsignadas(posicion) & " | Responsable: " & responsables(posicion) & " | Estado: " & estados(posicion))
                            End If
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '---------------------'
                '--|listar_recursos|--'
                '---------------------'
                Case 3
                    If cantidad = 0 Then
                        Console.WriteLine("No existen recursos registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Recurso: " & recursos(i) & " | Disponible: " & cantidadesDisponibles(i) & " | Asignado: " & cantidadesAsignadas(i) & " | Responsable: " & responsables(i) & " | Estado: " & estados(i))
                        Next
                    End If
                '--------------------'
                '--|buscar_recurso|--'
                '--------------------'
                Case 4
                    If cantidad = 0 Then
                        Console.WriteLine("No existen recursos registrados.")
                    Else
                        Console.WriteLine("1) Buscar por ID")
                        Console.WriteLine("2) Buscar por recurso")
                        Console.WriteLine("3) Buscar por responsable")
                        Console.Write("Seleccione una opcion: ")
                        Dim tipoBusqueda As Integer = Convert.ToInt32(Console.ReadLine())
                        If tipoBusqueda = 1 Then
                            Console.Write("Ingrese el ID del recurso: ")
                            Dim idBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                            If idBuscar >= 1 AndAlso idBuscar <= cantidad Then
                                Dim posicion As Integer = idBuscar - 1
                                Console.WriteLine("ID: " & ids(posicion) & " | Recurso: " & recursos(posicion) & " | Disponible: " & cantidadesDisponibles(posicion) & " | Asignado: " & cantidadesAsignadas(posicion) & " | Responsable: " & responsables(posicion) & " | Estado: " & estados(posicion))
                            Else
                                Console.WriteLine("ID no encontrada.")
                            End If
                        ElseIf tipoBusqueda = 2 Then
                            Console.Write("Ingrese el nombre del recurso: ")
                            Dim recursoBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If recursos(i).ToLower().Contains(recursoBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Recurso: " & recursos(i) & " | Disponible: " & cantidadesDisponibles(i) & " | Asignado: " & cantidadesAsignadas(i) & " | Responsable: " & responsables(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron recursos.")
                            End If
                        ElseIf tipoBusqueda = 3 Then
                            Console.Write("Ingrese el responsable: ")
                            Dim responsableBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If responsables(i).ToLower().Contains(responsableBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Recurso: " & recursos(i) & " | Disponible: " & cantidadesDisponibles(i) & " | Asignado: " & cantidadesAsignadas(i) & " | Responsable: " & responsables(i) & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron recursos.")
                            End If
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '----------------------'
                '--|eliminar_recurso|--'
                '----------------------'
                Case 5
                    If cantidad = 0 Then
                        Console.WriteLine("No existen recursos registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Recurso: " & recursos(i) & " | Disponible: " & cantidadesDisponibles(i) & " | Asignado: " & cantidadesAsignadas(i) & " | Responsable: " & responsables(i) & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del recurso a eliminar: ")
                        Dim idEliminar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEliminar >= 1 AndAlso idEliminar <= cantidad Then
                            Dim posicion As Integer = idEliminar - 1
                            For i As Integer = posicion To cantidad - 2
                                ids(i) = ids(i + 1)
                                recursos(i) = recursos(i + 1)
                                cantidadesDisponibles(i) = cantidadesDisponibles(i + 1)
                                cantidadesAsignadas(i) = cantidadesAsignadas(i + 1)
                                responsables(i) = responsables(i + 1)
                                estados(i) = estados(i + 1)
                            Next
                            cantidad -= 1
                            ids(cantidad) = 0
                            recursos(cantidad) = ""
                            cantidadesDisponibles(cantidad) = 0
                            cantidadesAsignadas(cantidad) = 0
                            responsables(cantidad) = ""
                            estados(cantidad) = ""
                            For i As Integer = 0 To cantidad - 1
                                ids(i) = i + 1
                            Next
                            Console.WriteLine("Recurso eliminado correctamente.")
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '------------------------'
                '--|distribuir_recurso|--'
                '------------------------'
                Case 6
                    If cantidad = 0 Then
                        Console.WriteLine("No existen recursos registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Recurso: " & recursos(i) & " | Disponible: " & cantidadesDisponibles(i) & " | Asignado: " & cantidadesAsignadas(i) & " | Responsable: " & responsables(i) & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del recurso a distribuir: ")
                        Dim idDistribuir As Integer = Convert.ToInt32(Console.ReadLine())
                        If idDistribuir >= 1 AndAlso idDistribuir <= cantidad Then
                            Dim posicion As Integer = idDistribuir - 1
                            Console.Write("Ingrese la cantidad a distribuir: ")
                            Dim cantidadDistribuir As Integer = Convert.ToInt32(Console.ReadLine())
                            If cantidadDistribuir <= 0 Then
                                Console.WriteLine("La cantidad a distribuir debe ser mayor que cero.")
                            ElseIf cantidadDistribuir > cantidadesDisponibles(posicion) Then
                                Console.WriteLine("No se pueden distribuir " & cantidadDistribuir & " unidades. Solo hay " & cantidadesDisponibles(posicion) & " disponibles.")
                            Else
                                cantidadesDisponibles(posicion) = cantidadesDisponibles(posicion) - cantidadDistribuir
                                cantidadesAsignadas(posicion) = cantidadesAsignadas(posicion) + cantidadDistribuir
                                If cantidadesDisponibles(posicion) = 0 Then
                                    estados(posicion) = "Agotado"
                                ElseIf cantidadesAsignadas(posicion) > 0 Then
                                    estados(posicion) = "Parcial"
                                Else
                                    estados(posicion) = "Disponible"
                                End If
                                Console.WriteLine("Recurso distribuido correctamente.")
                                Console.WriteLine("Cantidad distribuida: " & cantidadDistribuir & " | Disponible: " & cantidadesDisponibles(posicion) & " | Asignado: " & cantidadesAsignadas(posicion) & " | Estado: " & estados(posicion))
                            End If
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 7
                    Console.WriteLine("Gracias por utilizar Distribuidor de Recursos.")
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 7
    End Sub
End Module