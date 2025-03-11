using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String nombreJugador1, nombreJugador2;
            int primerTurno;
            Console.WriteLine("Jugador 1, escoge tu nombre: ");
            nombreJugador1 = Console.ReadLine();
            Jugador jugador1 = new Jugador(nombreJugador1,1000);
            jugador1.EscogerPersonaje();
            jugador1.EscogerArma();

            Console.WriteLine("Jugador 2, escoge tu nombre: ");
            nombreJugador2 = Console.ReadLine();
            Jugador jugador2 = new Jugador(nombreJugador2, 1000);
            jugador2.EscogerPersonaje();
            jugador2.EscogerArma();

            primerTurno = Batalla.TirarDados();
            if (primerTurno == 1)
            {
                Console.WriteLine($"{jugador1.Nombre} empieza primero");
                Batalla.SumilarBatalla(jugador1, jugador2);
            }else
            {
                Console.WriteLine($"{jugador2.Nombre} empieza primero");
                Batalla.SumilarBatalla(jugador2, jugador1);
            }



        }
    }
    enum TipoPersonaje
    {
        Escudero,
        Arquero,
        Caballero
    }
    enum TipoArma
    {
        Espada,
        Arco,
        Martillo
    }
    class Jugador
    {
        string nombre;
        int salud;
        int ataque;
        int defensa;
        TipoPersonaje personajeEscogido;
        TipoArma armaEquipada;
        Random rand = new Random();

        public string Nombre { get => nombre; set => nombre = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        internal TipoPersonaje PersonajeEscogido { get => personajeEscogido; set => personajeEscogido = value; }
        internal TipoArma ArmaEquipada { get => armaEquipada; set => armaEquipada = value; }

        public Jugador(string nombre,int salud)
        {
            this.nombre = nombre;
            this.salud = salud;
        }
        public void EscogerPersonaje()
        {
            int opcion;
            Console.Clear();
            do
            {
                Console.WriteLine("1. Escudero");
                Console.WriteLine("2. Arquero");
                Console.WriteLine("3. Caballero");

                Console.WriteLine($"\n{nombre}, escoge un personaje: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear() ;
                switch (opcion)
                {
                    case 1:
                        personajeEscogido = TipoPersonaje.Escudero;
                        ResumenPersonajeEscogido();
                        break;
                    case 2:
                        personajeEscogido = TipoPersonaje.Arquero;
                        ResumenPersonajeEscogido();
                        break;
                    case 3:
                        personajeEscogido = TipoPersonaje.Caballero;
                        ResumenPersonajeEscogido();
                        break;
                    default:
                        Console.WriteLine("Opcion inválida, Intenta de nuevo");
                        break;
                }
            } while (opcion < 1 || opcion > 3);
        }
        public void ResumenPersonajeEscogido()
        {
            Console.WriteLine($"{nombre}, ahora eres \"{PersonajeEscogido}\"");
            Console.WriteLine("\nPresiona cualquier tecla para continuar..");
            Console.ReadKey();
            Console.Clear();
        }
        public void EscogerArma() 
        {
            int opcion;
            Console.Clear();
            do
            {
                Console.WriteLine("1. Espada (Ataque: 130, Defensa; 40)");
                Console.WriteLine("2. Arco (Ataque: 140, Defensa: 30)");
                Console.WriteLine("3. Martillo (Ataque: 150, Defensa: 20)");
                Console.WriteLine($"\n{nombre},elige un arma: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch(opcion)
                {
                    case 1:
                        armaEquipada = TipoArma.Espada;
                        ValoresAtaqueDefensaArma();
                        ResumenArmaEscogida();
                        break;
                    case 2:
                        armaEquipada = TipoArma.Arco;
                        ValoresAtaqueDefensaArma();
                        ResumenArmaEscogida();
                        break;
                    case 3:
                        armaEquipada = TipoArma.Martillo;
                        ValoresAtaqueDefensaArma();
                        ResumenArmaEscogida();
                        break;
                    default:
                        Console.WriteLine("Opcion inválida, intenta de nuevo");
                        break;
                }

            } while (opcion < 1 || opcion > 3);
        }
        public void ValoresAtaqueDefensaArma()
        {
            switch (armaEquipada)
            {
                case TipoArma.Espada:
                    ataque = 130;
                    defensa = 40;
                    break;
                case TipoArma.Arco:
                    ataque = 140;
                    defensa = 30;
                    break;
                case TipoArma.Martillo:
                    ataque = 150;
                    defensa = 20;
                    break;
            }
        }
        public void ResumenArmaEscogida()
        {
            Console.WriteLine($"{nombre}, escogiste \"{armaEquipada}\"\nCon un nivel de ataque de {ataque} y una defensa de {defensa}");
            Console.WriteLine("\nPresiona una tecla para continuar..");
            Console.ReadKey();
            Console.Clear();
        }
        public void Atacar()
        {
            Console.WriteLine($"\n{personajeEscogido} {nombre} ataca con su {armaEquipada}\n");
        }
        public void Defender()
        {
            Console.WriteLine($"\n{personajeEscogido} {nombre} se defiende con su {armaEquipada}\n");
        }
        public void EscogerAtacarDefender()
        {
            int opcion;
            do
            {
                Console.WriteLine("1. atacar");
                Console.WriteLine("2. defender");

                Console.WriteLine($"\n{personajeEscogido} {nombre}, elige una accion: ");
                opcion = Convert.ToInt32( Console.ReadLine() );
                switch (opcion)
                {
                    case 1:
                        Atacar();
                        break;
                    case 2:
                        Defender();
                        break;
                    default:
                        Console.WriteLine("Opcion inválida, intente de nuevo");
                        break;
                }
            } while (opcion < 1 || opcion > 2);
        }
        public void ResumenJugador()
        {
            Console.WriteLine($"{personajeEscogido} {nombre} salud {salud} / {armaEquipada} ataque: {ataque}, defensa: {defensa}");
        }
        public void CalcularDaño(int ataqueOtroJugador)
        {
            int dañoRecibido;
            int ataqueSorpresa;
            ataqueSorpresa = rand.Next(-15, 16);
            dañoRecibido = ataqueOtroJugador - Defensa + ataqueSorpresa;
            salud -= dañoRecibido;
        }
    }
    class Batalla
    {
       static Random random = new Random();
        public static  int TirarDados()
        {
            Console.WriteLine("Presiona cualquier tecla para tirar los dados y determinar quein comienza..");
            Console.ReadKey();
            Console.Clear();
            int primerTurno;
            primerTurno = random.Next(1, 3);
            return primerTurno;
        }
        public static void SumilarBatalla(Jugador jugador1,Jugador jugador2)
        {
            int ronda = 1;
            Console.WriteLine("La batalla ha comenzado\n");
            Console.WriteLine($"RONDA {ronda}\n");

            jugador1.ResumenJugador();
            jugador2.ResumenJugador();
            Console.WriteLine($"\n{jugador1.PersonajeEscogido} {jugador1.Nombre}, empieza a atacar");
            Console.WriteLine($"Presiona enter para usar tu {jugador1.ArmaEquipada}..");
            Console.ReadKey();
            jugador1.Atacar();
            jugador2.CalcularDaño(jugador1.Ataque);

            jugador2.EscogerAtacarDefender();

            jugador1.CalcularDaño(jugador2.Ataque);

            for (ronda = 2;ronda <=5;ronda++)
            {
                Console.WriteLine($"RONDA {ronda}\n");
                jugador1.ResumenJugador();
                jugador2.ResumenJugador();

                jugador1.EscogerAtacarDefender();
                jugador2.CalcularDaño(jugador1.Ataque);
                jugador2.EscogerAtacarDefender();
                jugador1.CalcularDaño(jugador2.Ataque);
                Console.WriteLine();
            }
            Console.WriteLine("\nLa batalla ha terminado");
            jugador1.ResumenJugador();
            jugador2.ResumenJugador();
            if (jugador1.Salud > jugador2.Salud)
            {
                Console.WriteLine($"\n{jugador1.Nombre} ha ganado la batalla");
            } else
            {
                Console.WriteLine($"\n{jugador2.Nombre} ha ganado la batalla");
            }
        }
    }
}
