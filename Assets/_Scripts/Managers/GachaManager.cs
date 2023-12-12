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
    public Action<CharacterScriptable> OnSingleCharacterDropped; //Adding single characters to inventory then activate result screen
    public Action<WeaponScriptable> OnSingleWeaponsDropped; //Adding single weapons to inventory then activate result screen
    public Action<List<CharacterScriptable>> On10CharactersDropped; //Adding 10 characters to inventory then activate result screen
    public Action<List<WeaponScriptable>> On10WeaponsDropped; //Adding 10 weapons to inventory then activate result screen
    public Action OnGachaAnimStart; //Activate Gacha Animation UI
    public Action OnGachaAnimEnd; //Deactive Gacha Animation UI

    #region Rolling Drops
    private void OngachaButtonPressed()
    {
        //Play some cool animation
        OnGachaAnimStart?.Invoke();
        videoPlayerObj.SetActive(true);
        Debug.Log("Playing animtion for " + animTime + " seconds");
    }

    public void RollOnce(bool _isRollingChara)
    {
        OngachaButtonPressed();

        if (_isRollingChara)
        {
            //Randomize Dropped Character
            droppedChara = GetOneCharacter();

            //Wait for second till animation finished then fire and event to update UI according to the dropped character
            StartCoroutine(RollsCoroutine(_isRollingChara, true));
        }
        else
        {
            //Randomize Dropped Weapon
            droppedWeap = GetOneWeapon();

            //Wait for second till animation finished then fire and event to update UI according to the dropped weapon
            StartCoroutine(RollsCoroutine(_isRollingChara, true));
        }

    }

    public void Roll10Times(bool _isRollingChara)
    {
        OngachaButtonPressed();

        if (_isRollingChara)
        {
            //Randomize 10 Dropped Characters
            dropped10Chara = GetTenCharacters();

            //Wait for second till animation finished then fire and event to update UI according to the dropped character
            StartCoroutine(RollsCoroutine(_isRollingChara, false));
        }
        else
        {
            //Randomize 10 Dropped Weapons
            dropped10Weap = GetTenWeapons();

            //Wait for second till animation finished then fire and event to update UI according to the dropped character
            StartCoroutine(RollsCoroutine(_isRollingChara, false));
        }
    }

    private IEnumerator RollsCoroutine(bool _isRollingChara, bool _isRollingOnce)
    {
        yield return new WaitForSeconds(animTime);

        //Deactive Animation Object
        OnGachaAnimEnd?.Invoke();
        videoPlayerObj.SetActive(false);

        if (_isRollingChara)
        {
            if (_isRollingOnce)
                //Display UI and Add characters to inventory list
                OnSingleCharacterDropped?.Invoke(droppedChara);
            else
                //Display UI and Add characters to inventory list
                On10CharactersDropped?.Invoke(dropped10Chara);
        }
        else
        {
            if (_isRollingOnce)
                //Display UI and Add weapon to inventory list
                OnSingleWeaponsDropped?.Invoke(droppedWeap);
            else
                //Display UI and Add weapons to inventory list
                On10WeaponsDropped?.Invoke(dropped10Weap);
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
