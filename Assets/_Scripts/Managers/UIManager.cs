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
    [SerializeField] private GameObject UiParent;
    [SerializeField] private Image itemImage;
    [SerializeField] private Image itemBackground;
    [SerializeField] private TMP_Text itemName;

    [Header("General Details Menu")]
    [SerializeField] private Image itemDetailImage;
    [SerializeField] private TMP_Text itemDetailNameText;
    [SerializeField] private TMP_Text itemDetailAttackText;
    [SerializeField] private TMP_Text itemRarityText;


    [Header("Characters Details Menu")]
    [SerializeField] private GameObject charaDetailsParent;
    [SerializeField] private TMP_Text charaDefenseText;
    [SerializeField] private TMP_Text charaHpText;

    [Header("Weapons Detail Menu")]
    [SerializeField] private GameObject weapDetailsParent;
    [SerializeField] private TMP_Text weaponAttackSpeedText;
    [SerializeField] private TMP_Text weapDescText;
    [SerializeField] private TMP_Text weapSpecialEffectDescText;

    private void OnEnable()
    {
        //Activate and Deactivate Gacha UI Animation
        gachaManager.OnGachaAnimStart += () => { gachaAnimationObj.SetActive(true); };
        gachaManager.OnGachaAnimEnd += () => { gachaAnimationObj.SetActive(false); };

        //Displaying Gacha Result
        gachaManager.OnCharacterDropped += (CharacterScriptable _chara) =>
        {
            UiParent.SetActive(true);
            itemImage.sprite = _chara.characterSprite;
            itemName.text = _chara.characterName;
        };
        gachaManager.OnWeaponsDropped += (WeaponScriptable _weap) =>
        {
            UiParent.SetActive(true);
            itemImage.sprite = _weap.weaponSprite;
            itemName.text = _weap.weaponName;
        };

        //Displaying Character Details
        inventory.OnCharaPressed += (CharacterScriptable _chara) =>
        {
            charaDetailsParent.SetActive(true);

            itemDetailImage.sprite = _chara.characterSprite;
            itemDetailNameText.text = _chara.characterName;
            itemDetailAttackText.text = _chara.attack.ToString();
            itemRarityText.text = _chara.rarity.ToString() + "%";

            charaDefenseText.text = _chara.defense.ToString();
            charaHpText.text = _chara.hp.ToString();
        };

        //Displaying Weapon Details
        inventory.OnWeapPressed += (WeaponScriptable _weap) =>
        {
            weapDetailsParent.SetActive(true);

            itemDetailImage.sprite = _weap.weaponSprite;
            itemDetailNameText.text = _weap.weaponName;
            itemDetailAttackText.text = _weap.baseAttack.ToString();
            itemRarityText.text = _weap.rarity.ToString() + "%";

            weapDescText.text = _weap.weaponDesc;
            weapSpecialEffectDescText.text = _weap.specialEffectDesc;
            weaponAttackSpeedText.text = _weap.attackSpeed.ToString();
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
            UiParent.SetActive(true);
            itemImage.sprite = _chara.characterSprite;
            itemName.text = _chara.characterName;
        };
        gachaManager.OnWeaponsDropped -= (WeaponScriptable _weap) =>
        {
            UiParent.SetActive(true);
            itemImage.sprite = _weap.weaponSprite;
            itemName.text = _weap.weaponName;
        };

        //Displaying Character Details
        inventory.OnCharaPressed -= (CharacterScriptable _chara) =>
        {
            charaDetailsParent.SetActive(true);

            itemDetailImage.sprite = _chara.characterSprite;
            itemDetailNameText.text = _chara.characterName;
            itemDetailAttackText.text = _chara.attack.ToString();
            itemRarityText.text = _chara.rarity.ToString() + "%";

            charaDefenseText.text = _chara.defense.ToString();
            charaHpText.text = _chara.hp.ToString();
        };

        //Displaying Weapon Details
        inventory.OnWeapPressed -= (WeaponScriptable _weap) =>
        {
            weapDetailsParent.SetActive(true);

            itemDetailImage.sprite = _weap.weaponSprite;
            itemDetailNameText.text = _weap.weaponName;
            itemDetailAttackText.text = _weap.baseAttack.ToString();
            itemRarityText.text = _weap.rarity.ToString() + "%";

            weapDescText.text = _weap.weaponDesc;
            weapSpecialEffectDescText.text = _weap.specialEffectDesc;
            weaponAttackSpeedText.text = _weap.attackSpeed.ToString();
        };
    }
}
