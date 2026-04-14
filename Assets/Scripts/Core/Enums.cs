using UnityEngine;

namespace BatalladeMundos
{
    public enum WorldType
    {
        Ninguno = 0,
        Terrenal = 1,
        Celestial = 2,
        Infernal = 3
    }
    public enum CardType
    {
        Ser = 0,
        Apoyo = 1,
        Arma = 2
    }
    public enum BattleType
    {
        Ninguno = 0,
        Ataque = 1,
        Defensa = 2,
        Hibrido = 3
    }
    public enum SupportSubtype
    {
        Ninguno = 0,
        Asistencia = 1,
        Refuerzo = 2
    }
    public enum ActivationMode
    {
        EfectoInmediato = 0,
        Permanencia = 1
    }
    public enum GamePhase
    {
        Inicial = 0,
        RoboDeCarta = 1,
        Estrategia = 2,
        Ataque = 3,
        FinDeTurno = 4
    }
    public enum PlayerSide
    {
        Jugador = 0,
        Oponente = 1
    }
    public enum CombatResult
    {
        AtacanteDestruido = 0,
        DefensorDestruido = 1,
        AmbosDestruidos = 2,
        SinResultado = 3
    }
    public enum FieldZone
    {
        Ataque = 0,
        Defensa = 1,
        Apoyo = 2
    }
    public enum WeaponType
    {
        Ninguno = 0,
        Mortifera = 1,
        Proyectil = 2,
        ArmaBlanca = 3,
        Combate = 4
    }
    public enum DeckType
    {
        Estrategia = 0,
        Armas = 1
    }
}
