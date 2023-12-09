using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //[Header("Class Reference")]
    //[SerializeField] private GachaManager gachaManager;

    //[Header("Gacha animations")]
    //[SerializeField] private float animTime;

    //[Header("Dropped Items")]
    //private CharacterScriptable droppedChara;
    //private WeaponScriptable droppedWeap;

    //[Header("Events")]
    //public Action<CharacterScriptable> OnCharacterDropped; //Adding characters to inventory
    //public Action<WeaponScriptable> OnWeaponsDropped; //Adding weapons to inventory

    //public void RollCharacterOnce()
    //{
    //    //Play some cool animation
    //    Debug.Log("Playing animtion for " + animTime + " seconds");

    //    //Wait for second till animation finished then fire and event to update UI according to the dropped character
    //    StartCoroutine(DisplayUICoroutine(true));
    //}

    //public void RollWeaponOnce()
    //{
    //    //Play some cool animation
    //    Debug.Log("Playing animtion for " + animTime + " seconds");

    //    //Wait for second till animation finished then fire and event to update UI according to the dropped weapon
    //    StartCoroutine(DisplayUICoroutine(false));
    //}

    //private IEnumerator DisplayUICoroutine(bool _isRollingChara)
    //{
    //    yield return new WaitForSeconds(animTime);

    //    if (_isRollingChara)
    //    {
    //        //Randomize Drops
    //        droppedChara = gachaManager.GetOneCharacterPull();
    //        Debug.Log("You get : " + droppedChara.characterName);

    //        //Add characters to inventory list
    //        OnCharacterDropped?.Invoke(droppedChara);
    //    }
    //    else
    //    {
    //        //Randomize Drops
    //        droppedWeap = gachaManager.GetOneWeaponPull();
    //        Debug.Log("You get : " + droppedWeap.weaponName);

    //        //Add weapons to inventory list
    //        OnWeaponsDropped?.Invoke(droppedWeap);
    //    }

    //}
}
