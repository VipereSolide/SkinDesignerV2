using UnityEngine;

[CreateAssetMenu(fileName = "ModelSO", menuName = "New Weapon Model", order = 0)]
public class ModelSO : ScriptableObject {
    
    public string WeaponNameInGUI;

    [Tooltip("This should have the name of the weapon in game in capital. (Example: \"AK47\")")] public Sprite WeaponImageInGUI;

    public GameObject WeaponInstantiatedModel;

}