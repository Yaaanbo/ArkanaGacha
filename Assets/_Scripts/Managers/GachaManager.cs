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
    private List<CharacterScriptable> dropped10Chara = new List<CharacterScriptable>();
    private List<WeaponScriptable> dropped10Weap = new List<WeaponScriptable>();
    private WeaponScriptable droppedWeap;

    [Header("Events")]
    public Action<CharacterScriptable> OnCharacterDropped; //Adding characters to inventory
    public Action<WeaponScriptable> OnWeaponsDropped; //Adding weapons to inventory
    public Action OnGachaAnimStart; //Activate Gacha Animation UI
    public Action OnGachaAnimEnd; //Deactive Gacha Animation UI

    #region Rolling Drops
    public void RollOnce(bool _isRollingChara)
    {
        //Play some cool animation
        OnGachaAnimStart?.Invoke();
        videoPlayerObj.SetActive(true);
        Debug.Log("Playing animtion for " + animTime + " seconds");

        if (_isRollingChara)
        {
            //Randomize Dropped Character
            droppedChara = GetOneCharacter();

            //Wait for second till animation finished then fire and event to update UI according to the dropped character
            StartCoroutine(RollOnceCoroutine(true));
        }
        else
        {
            //Randomize Dropped Weapon
            droppedWeap = GetOneWeapon();

            //Wait for second till animation finished then fire and event to update UI according to the dropped weapon
            StartCoroutine(RollOnceCoroutine(false));
        }
        
    }

    public void Roll10Times(bool _isRollingChara)
    {
        if (_isRollingChara)
        {
            //Randomize 10 Dropped Characters
            dropped10Chara = GetTenCharacters();
        }
        else
        {
            //Randomize 10 Dropped Weapons
            dropped10Weap = GetTenWeapons();
        }
    }

    private IEnumerator RollOnceCoroutine(bool _isRollingChara)
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

            //Display UI and Add weapon to inventory list
            OnWeaponsDropped?.Invoke(droppedWeap);
        }

        //Save game
        SaveManager.instance.SaveGame();
    }
    #endregion

    #region Randomizing Drops

    //Get One Character
    private CharacterScriptable GetOneCharacter()
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

    //Get 10 Characters
    private List<CharacterScriptable> GetTenCharacters()
    {
        List<CharacterScriptable> charactersDropped = new List<CharacterScriptable>();

        int pullAmount = 10;
        for (int i = 0; i < pullAmount; i++)
        {
            charactersDropped.Add(GetOneCharacter());
            Debug.Log(charactersDropped[i]); 
        }

        return charactersDropped;
    }

    //Get One Weapon
    private WeaponScriptable GetOneWeapon()
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

    //Get 10 Weapons
    private List<WeaponScriptable> GetTenWeapons()
    {
        List<WeaponScriptable> weaponsDropped = new List<WeaponScriptable>();
        
        int pullAmount = 10;
        for (int i = 0; i < pullAmount; i++)
        {
            weaponsDropped.Add(GetOneWeapon());
            Debug.Log(weaponsDropped[i]);
        }

        return weaponsDropped;
    }
    #endregion
}
