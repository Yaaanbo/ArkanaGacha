using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Scriptable Character")]
public class CharacterScriptable : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;
    public Sprite characterSprite;

    [Header("Character Stats")]
    public float attack;
    public float defense;
    public float hp;

    [Header("Gacha stats")]
    public float rarity;
}
