using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text WeaponCooldownText;

    private string PercentFormatString = "{0:0}%";

    public void SetWeaponCooldownText(string s) {
        WeaponCooldownText.text = string.Format(PercentFormatString, s);
    }
}
