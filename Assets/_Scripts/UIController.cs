using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    private string PercentFormatString = "{0:0}%";

    public Text WeaponCooldownText;

    public void SetWeaponCooldownText(string s) {
        WeaponCooldownText.text = string.Format(PercentFormatString, s);
    }
}
