﻿using System;
using System.Collections;

namespace RoleplayGame
{
    public class Elfo : IPersonaje, IElfo, IHechicero
    {
        public string Nombre { get; set; }
        public static int Vida;
        public static int Ataque;
        
        //Creación del atributo "maná": Es la representación de la energía mágica del personaje.
        public int Mana { get; set; }

        public int vidaInicial;
        
        //"ManaIncial" es el maná con el que el personaje inicia.
        public int ManaInicial;

        private ArrayList hechizos = new ArrayList();
        
        private ArrayList items = new ArrayList();
        
        public int HechizosCount
        {
            get { return hechizos.Count; }
        }

        
        public int ItemsCount
        {
            get { return items.Count; }
        }
        
        public ArrayList Hechizos
        {
            get { return hechizos; }
        }
        
        // Constructor para inicializar vida_inicial
        public Elfo(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 20;
            vidaInicial = 200;
            Mana = 100;
            ManaInicial = 100;
        }

        public string CargarMana(int mana)
        {
            //Si el maná + el maná cargado es mayor al ManaInicial (100) no se va a poder cargar maná.
            if (Mana + mana > ManaInicial)
            {
                return("No se puede cargar mas mana del que el personaje posee");
            }
            //Si no es mayor al ManaInicial, se carga el maná sin problema
            else
            {
                Mana += mana;
                return ($"Se cargo {mana}");
            }
        }
        public void AgregarHechizo(Hechizo hechizo)
        {
            hechizos.Add(hechizo);
        }

        public void AgregarItemAtaque(ItemAtaque item)
        {
            items.Add(item);
        }
        public void AgregarItemDefensa(ItemDefensa item2)
        {
            items.Add(item2);
        }


        public void Curar(int curar)
        {
            if ((Vida + curar) > vidaInicial || curar > 20)
            {
                Console.WriteLine($"{Nombre} intentó curarse, pero no puede curarse más de su vida base o mas de 20 puntos de vida por turno.");
            }
            else
            {
                Vida += curar;
                Console.WriteLine($"{Nombre} se curó {curar} puntos de vida. Vida actual: {Vida}/{vidaInicial}.");
            }
        }

        public int ValorAtaqueHechizos(Hechizo hechizo = null)
        {
            int valor = Ataque;
            
            if (hechizo != null)
            {
                //Si el maná del personaje es mayor al gasto de maná del hechizo, se ejecuta.
                if (Mana >= hechizo.GastoMana)
                {
                    Mana -= hechizo.GastoMana;
                    valor += hechizo.Ataque;
                }
                //Si el maná del personaje es menor al gasto de maná del hechizo, no se ejecuta
                else
                {
                    Console.WriteLine($"{Nombre} no tiene suficiente mana para usar el hechizo {hechizo.Nombre}.");
                }
            
               
            }
            return valor;
        }

        public int ValorAtaque()
        {
            int valor = Ataque;
            
            foreach (var item in items)
            {
                if (item is ItemAtaque itemAtaque)
                {
                    valor += itemAtaque.Ataque;
                }
            }

            return valor;
        }
        public void RecibirHechizo(IHechicero hechiceroAtacante, Hechizo hechizo)
        {
            int defensaTotal = 0;
    
            // Calcular la defensa total del personaje basado en sus ítems de defensa
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }

            // Verificar si el hechicero tiene suficiente mana para lanzar el hechizo
            if (hechiceroAtacante.Mana >= hechizo.GastoMana)
            {
                hechiceroAtacante.Mana -= hechizo.GastoMana;
        
                // Calcular el daño del hechizo restando la defensa
                int danioRecibido = Math.Max(0, hechizo.Ataque - defensaTotal);
                Vida -= danioRecibido;

                Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño del hechizo {hechizo.Nombre} de {hechiceroAtacante.Nombre}. Vida actual: {Vida}.");
            }
            else
            {
                Console.WriteLine($"{hechiceroAtacante.Nombre} intentó usar el hechizo {hechizo.Nombre}, pero no tiene suficiente mana.");
            }
        }

        public void RecibirAtaque(IPersonaje ataque)
        {
            int defensaTotal = 0;
            
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            int danioRecibido = Math.Max(0, ataque.ValorAtaque() - defensaTotal);
            Vida -= danioRecibido;

            Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {ataque.Nombre}. Vida actual: {Vida}.");
        }
    }
}