using System;
using System.Collections.Generic;


public class Motor
{
    public int Cilindros { get; private set; }

    public Motor(int cilindros)
    {
        Cilindros = cilindros;
    }

    public void Arrancar()
    {
        Console.WriteLine("¡Vroom! El motor está en marcha.");
    }
}
public class Auto
{
    public string Marca { get; private set; }
    public Motor Motor { get; private set; }

    public Auto(string marca, int cilindros)
    {
        Marca = marca;
        
        Motor = new Motor(cilindros);
    }
}



public class CPU
{
    public string Modelo { get; private set; }

    public CPU(string modelo)
    {
        Modelo = modelo;
    }
}

public class RAM
{
    public int Gigas { get; private set; }

    public RAM(int gigas)
    {
        Gigas = gigas;
    }
}

public class Computadora
{
    public CPU Cpu { get; private set; }
    public RAM Ram { get; private set; }

    public Computadora(string modeloCpu, int gigasRam)
    {
 
        Cpu = new CPU(modeloCpu);
        Ram = new RAM(gigasRam);
    }
}


public class Conductor
{
    public string Nombre { get; private set; }

    public Conductor(string nombre)
    {
        Nombre = nombre;
    }
}

public class Colectivo
{
    public int Linea { get; private set; }
    public Conductor? Conductor { get; private set; }

    public Colectivo(int linea)
    {
        Linea = linea;
    }

    public void AsignarConductor(Conductor c)
    {
        Conductor = c;
    }

   
    public void DesvincularConductor()
    {
        Conductor = null;
    }
}




public class Jugador
{
    public string Nombre { get; private set; }

    public Jugador(string nombre)
    {
        Nombre = nombre;
    }
}

public class Equipo
{
    public string Nombre { get; private set; }
    public List<Jugador> Jugadores { get; private set; }

    public Equipo(string nombre)
    {
        Nombre = nombre;
        Jugadores = new List<Jugador>();
    }

    public void AgregarJugador(Jugador j)
    {
      
        Jugadores.Add(j);
    }
}




public class LineaFactura
{
    public string Descripcion { get; private set; }
    public decimal Precio { get; private set; }

    public LineaFactura(string descripcion, decimal precio)
    {
        Descripcion = descripcion;
        Precio = precio;
    }
}

public class Factura
{
    public int Numero { get; private set; }
    public List<LineaFactura> Lineas { get; private set; }

    public Factura(int numero)
    {
        Numero = numero;
        Lineas = new List<LineaFactura>();
    }

    public void AgregarLinea(string descripcion, decimal precio)
    {
       
        Lineas.Add(new LineaFactura(descripcion, precio));
    }
}



class Program
{
    static void Main()
    {
        Console.WriteLine("=== TP N° 13: COMPOSICIÓN Y AGREGACIÓN ===\n");

      
        Auto miAuto = new Auto("Ford", 4);
        miAuto.Motor.Arrancar(); // El motor fue creado dentro del Auto

       
        Computadora pc = new Computadora("Intel i5", 16);
        Console.WriteLine($"PC armada con CPU {pc.Cpu.Modelo} y {pc.Ram.Gigas}GB RAM.");

       
        Factura factura = new Factura(101);
        factura.AgregarLinea("Mouse óptico", 5000m);

       
        Conductor chofer1 = new Conductor("Gabriel");
        Conductor chofer2 = new Conductor("Lucas");

        Colectivo colectivoA = new Colectivo(60);
        Colectivo colectivoB = new Colectivo(152);

        colectivoA.AsignarConductor(chofer1);

        
        Console.WriteLine($"\nColectivo Linea {colectivoA.Linea} - Conductor: {colectivoA.Conductor?.Nombre ?? "Sin Conductor"}");
        Console.WriteLine($"Colectivo Linea {colectivoB.Linea} - Conductor: {colectivoB.Conductor?.Nombre ?? "Sin Conductor"}");

       
        colectivoA.DesvincularConductor();
        colectivoB.AsignarConductor(chofer1);

        Console.WriteLine("\n-- Después de reasignar al conductor --");
        Console.WriteLine($"Colectivo Linea {colectivoA.Linea} - Conductor: {colectivoA.Conductor?.Nombre ?? "Sin Conductor"}");
        Console.WriteLine($"Colectivo Linea {colectivoB.Linea} - Conductor: {colectivoB.Conductor?.Nombre ?? "Sin Conductor"}");

      
        Jugador j1 = new Jugador("Enzo");
        Equipo equipo = new Equipo("Mi Equipo");
        equipo.AgregarJugador(j1);

        Console.WriteLine("\nEjecución finalizada con éxito.");
    }
}
