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
    public WeaponSound[] sounds;
}

[Serializable]
public class WeaponSound
{
    public string name;
    public AudioClip clip;
    [Range(0.1f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
}
