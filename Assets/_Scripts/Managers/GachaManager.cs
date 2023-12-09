using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;

public class GachaManager : MonoBehaviour
{
    private float randomNum;

    [Header("Gacha animations")]
    [SerializeField] private float animTime;
    [SerializeField] private GameObject videoPlayerObj;

    [Header("Possible Drops")]
    [SerializeField] private CharacterScriptable[] possibleCharacters;
    [SerializeField] private WeaponScriptable[] possibleWeapons;

    [Header("Dropped Items")]
    private CharacterScriptable droppedChara;
    private WeaponScriptable droppedWeap;

    [Header("Events")]
    public Action<CharacterScriptable> OnCharacterDropped; //Adding characters to inventory
    public Action<WeaponScriptable> OnWeaponsDropped; //Adding weapons to inventory
    public Action OnGachaAnimStart; //Activate Gacha Animation UI
    public Action OnGachaAnimEnd; //Deactive Gacha Animation UI

    #region Rolling Drops
    public void RollCharacterOnce()
    {
        //Play some cool animation
        OnGachaAnimStart?.Invoke();
        videoPlayerObj.SetActive(true);
        Debug.Log("Playing animtion for " + animTime + " seconds");

        //Randomize Dropped Character
        droppedChara = GetOneCharacterPull();

        //Wait for second till animation finished then fire and event to update UI according to the dropped character
        StartCoroutine(DisplayUICoroutine(true));
    }

    public void RollWeaponOnce()
    {
        //Play some cool animation
        OnGachaAnimStart?.Invoke();
        videoPlayerObj.SetActive(true);
        Debug.Log("Playing animtion for " + animTime + " seconds");

        //Randomize Dropped Weapon
        droppedWeap = GetOneWeaponPull();

        //Wait for second till animation finished then fire and event to update UI according to the dropped weapon
        StartCoroutine(DisplayUICoroutine(false));
    }

    private IEnumerator DisplayUICoroutine(bool _isRollingChara)
    {
        yield return new WaitForSeconds(animTime);

        if (_isRollingChara)
        {
            //Deactive Animation Object
            OnGachaAnimEnd?.Invoke();
            videoPlayerObj.SetActive(false);
            Debug.Log("You get : " + droppedChara.characterName);

            //Display UI and Add characters to inventory list
            OnCharacterDropped?.Invoke(droppedChara);
        }
        else
        {
            //Deactive Animation Object
            OnGachaAnimEnd?.Invoke();
            videoPlayerObj.SetActive(false);
            Debug.Log("You get : " + droppedWeap.weaponName);

            //Display UI and Add characters to inventory list
            OnWeaponsDropped?.Invoke(droppedWeap);
        }

        //Save game
        SaveManager.instance.SaveGame();
    }
    #endregion

    #region Randomizing Drops
    public CharacterScriptable GetOneCharacterPull()
    {
        randomNum = UnityEngine.Random.Range(0f, 100f);
        List<CharacterScriptable> possibleCharactersDrop = new List<CharacterScriptable>();

        for (int i = 0; i < possibleCharacters.Length; i++)
        {
            if (randomNum <= possibleCharacters[i].rarity)
            {
                possibleCharactersDrop.Add(possibleCharacters[i]);
            }
        }

        CharacterScriptable droppedCharacter = possibleCharactersDrop[UnityEngine.Random.Range(0, possibleCharactersDrop.Count)];
        return droppedCharacter;
    }

    public WeaponScriptable GetOneWeaponPull()
    {
        randomNum = UnityEngine.Random.Range(0f, 100f);
        List<WeaponScriptable> possibleWeaponDrops = new List<WeaponScriptable>();

        for (int i = 0; i < possibleWeapons.Length; i++)
        {
            if (randomNum <= possibleWeapons[i].rarity)
            {
                possibleWeaponDrops.Add(possibleWeapons[i]);
            }
        }

        WeaponScriptable droppedWeapon = possibleWeaponDrops[UnityEngine.Random.Range(0, possibleWeaponDrops.Count)];
        return droppedWeapon;
    }
    #endregion
}
