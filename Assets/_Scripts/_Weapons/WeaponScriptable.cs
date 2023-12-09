using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Weapon")]
public class WeaponScriptable : ScriptableObject
{
    [Header("Weapon Info")]
    public string weaponName;
    public Sprite weaponSprite;
    [TextArea] public string weaponDesc;

    [Header("Weapon Stats")]
    public float baseAttack;
    public float attackSpeed;
    [TextArea] public string specialEffectDesc;

    [Header("Gacha Stat")]
    public float rarity;
}
