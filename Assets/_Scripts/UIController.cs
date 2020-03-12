using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text WeaponCooldownText = null;

    [SerializeField]
    private GameObject QuickMenu = null;

    private string PercentFormatString = "{0:0}%";

    void Awake() {
        QuickMenu.SetActive(false);
    }

    public void SetWeaponCooldownText(string s) {
        WeaponCooldownText.text = string.Format(PercentFormatString, s);
    }

    public void ToggleQuickMenu() {
        QuickMenu.SetActive(!QuickMenu.activeSelf);
    }
}
