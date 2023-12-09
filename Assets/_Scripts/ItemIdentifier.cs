using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdentifier : MonoBehaviour
{
   [field : SerializeField] public ScriptableObject ItemType { get; set; }
}
