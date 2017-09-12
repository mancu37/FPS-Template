using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    public string Name;
    
    public enum TypeEnum {
        Automatic, Manual, sniper
    };
    public TypeEnum Type;
    public int Amount;
    public int Damage;
    public int Distance;
    public float WeaponNextFireRate;
    public float WeaponFireRate;
    public ParticleSystem Muzzeflash;

}
