﻿namespace RoleplayGame;

// Ejemplos de objetos
public static class Items
{
    public static ItemAtaque Espada { get; } = new ItemAtaque { Nombre = "Espada", Ataque = 30 };
    public static ItemDefensa Escudo { get; } = new ItemDefensa { Nombre = "Escudo", Defensa = 50 };
    public static ItemAtaque Arco { get; } = new ItemAtaque { Nombre = "Arco", Ataque = 25 };
    public static ItemDefensa Armadura { get; } = new ItemDefensa { Nombre = "Armadura", Defensa = 40 };
    public static ItemMagico varita { get; } = new ItemMagico { Nombre = "Varita", Ataque = 50 };

    public static ItemAtaque PaloGigante { get; } = new ItemAtaque { Nombre = "Palo Gigante", Ataque = 25 };
    
    public static ItemMagico grimorio { get; } = new ItemMagico { Nombre = "grimorio", Ataque = 100 };
}