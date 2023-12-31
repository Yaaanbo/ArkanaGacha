using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public readonly string fileName = "/Item Data.json";

    [Header("Class References")]
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SaveGame()
    {
        ItemData itemData = new ItemData(inventory.UnlockedCharacters, inventory.UnlockedWeapons);

        string dataToSave = JsonUtility.ToJson(itemData, true);

        File.WriteAllText(Application.persistentDataPath + fileName, dataToSave);

        Debug.Log(Application.persistentDataPath);
    }

    public List<CharacterScriptable> LoadCharacters()
    {
        string loadData = File.ReadAllText(Application.persistentDataPath + fileName);
        var data = JsonUtility.FromJson<ItemData>(loadData);

        return data.characterList;
    }

    public List<WeaponScriptable> LoadWeapons()
    {
        string loadData = File.ReadAllText(Application.persistentDataPath + fileName);
        var data = JsonUtility.FromJson<ItemData>(loadData);

        return data.weaponList;
    }

}

public class ItemData
{
    public List<CharacterScriptable> characterList = new List<CharacterScriptable>();
    public List<WeaponScriptable> weaponList = new List<WeaponScriptable>();

    public ItemData(List<CharacterScriptable> _characters, List<WeaponScriptable> _weaponList)
    {
        characterList = _characters;
        weaponList = _weaponList;
    }
}
