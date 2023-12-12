using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Class Reference")]
    [SerializeField] private GachaManager gachaManager;
    [SerializeField] private Inventory inventory;

    [Header("Gacha Animation")]
    [SerializeField] private GameObject gachaAnimationObj;

    [Header("Gacha Result Screen Components")]
    [SerializeField] private GameObject gachaResultParent;
    [SerializeField] private Image itemImage;
    [SerializeField] private Image itemBackground;
    [SerializeField] private TMP_Text itemName;

    [Header("General Details Menu")]
    [SerializeField] private GameObject ItemDetailParent;
    [SerializeField] private Image itemDetailImage;
    [SerializeField] private TMP_Text itemDetailNameText;


    [Header("Characters Details Menu")]
    [SerializeField] private GameObject charaDetailsParent;
    [SerializeField] private TMP_Text charaDefenseText;
    [SerializeField] private TMP_Text charaHpText;
    [SerializeField] private TMP_Text charaAtkText;

    [Header("Weapons Detail Menu")]
    [SerializeField] private GameObject weapDetailsParent;
    [SerializeField] private TMP_Text weapDescText;
    [SerializeField] private TMP_Text weapAtkSpeedText;
    [SerializeField] private TMP_Text weapBaseAtkText;
    [SerializeField] private TMP_Text weapSpecialEffectDescText;

    private void OnEnable()
    {
        //Activate and Deactivate Gacha UI Animation
        gachaManager.OnGachaAnimStart += () => { gachaAnimationObj.SetActive(true); };
        gachaManager.OnGachaAnimEnd += () => { gachaAnimationObj.SetActive(false); };

        //Displaying Gacha Result
        gachaManager.OnCharacterDropped += (CharacterScriptable _chara) =>
        {
            gachaResultParent.SetActive(true);
            itemImage.sprite = _chara.characterSprite;
            itemName.text = _chara.characterName;
        };
        gachaManager.OnWeaponsDropped += (WeaponScriptable _weap) =>
        {
            gachaResultParent.SetActive(true);
            itemImage.sprite = _weap.weaponSprite;
            itemName.text = _weap.weaponName;
        };

        //Displaying Character Details
        inventory.OnCharaPressed += (CharacterScriptable _chara) =>
        {
            ItemDetailParent.SetActive(true);

            itemDetailImage.sprite = _chara.characterSprite;
            itemDetailNameText.text = _chara.characterName;
            charaAtkText.text = "Attack : " + _chara.attack.ToString();


            charaDetailsParent.SetActive(true);
            weapDetailsParent.SetActive(false);

            charaDefenseText.text = "Defense : " + _chara.defense.ToString();
            charaHpText.text = "HP : " + _chara.hp.ToString();
        };

        //Displaying Weapon Details
        inventory.OnWeapPressed += (WeaponScriptable _weap) =>
        {
            ItemDetailParent.SetActive(true);

            itemDetailImage.sprite = _weap.weaponSprite;
            itemDetailNameText.text = _weap.weaponName;
            weapBaseAtkText.text = "Base ATK : " + _weap.baseAttack.ToString();


            weapDetailsParent.SetActive(true);
            charaDetailsParent.SetActive(false);

            weapDescText.text = _weap.weaponDesc;
            weapAtkSpeedText.text = "ATK Speed : " + _weap.attackSpeed.ToString();
            weapSpecialEffectDescText.text = _weap.specialEffectDesc;
        };

    }

    private void OnDisable()
    {
        //Activate and Deactivate Gacha UI Animation
        gachaManager.OnGachaAnimStart -= () => { gachaAnimationObj.SetActive(true); };
        gachaManager.OnGachaAnimEnd -= () => { gachaAnimationObj.SetActive(false); };

        //Displaying Gacha Result
        gachaManager.OnCharacterDropped -= (CharacterScriptable _chara) =>
        {
            gachaResultParent.SetActive(true);
            itemImage.sprite = _chara.characterSprite;
            itemName.text = _chara.characterName;
        };
        gachaManager.OnWeaponsDropped -= (WeaponScriptable _weap) =>
        {
            gachaResultParent.SetActive(true);
            itemImage.sprite = _weap.weaponSprite;
            itemName.text = _weap.weaponName;
        };

        //Displaying Character Details
        inventory.OnCharaPressed -= (CharacterScriptable _chara) =>
        {
            ItemDetailParent.SetActive(true);

            itemDetailImage.sprite = _chara.characterSprite;
            itemDetailNameText.text = _chara.characterName;
            charaAtkText.text = "Attack : " + _chara.attack.ToString();


            charaDetailsParent.SetActive(true);
            weapDetailsParent.SetActive(false);

            charaDefenseText.text = "Defense : " + _chara.defense.ToString();
            charaHpText.text = "HP : " + _chara.hp.ToString();
        };

        //Displaying Weapon Details
        inventory.OnWeapPressed -= (WeaponScriptable _weap) =>
        {
            ItemDetailParent.SetActive(true);

            itemDetailImage.sprite = _weap.weaponSprite;
            itemDetailNameText.text = _weap.weaponName;
            weapBaseAtkText.text = "Base ATK : " + _weap.baseAttack.ToString();


            weapDetailsParent.SetActive(true);
            charaDetailsParent.SetActive(false);

            weapDescText.text = _weap.weaponDesc;
            weapAtkSpeedText.text = "ATK Speed : " + _weap.attackSpeed.ToString();
            weapSpecialEffectDescText.text = _weap.specialEffectDesc;
        };
    }
}
