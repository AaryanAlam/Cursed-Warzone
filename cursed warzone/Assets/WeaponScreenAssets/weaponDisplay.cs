using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponDisplay : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text desc;
    [SerializeField] private Text weight;
    [SerializeField] private Text magSize;
    [SerializeField] private Slider Damage;
    [SerializeField] private Slider fireRate;
    [SerializeField] private Slider accuracy;
    [SerializeField] private Image sprite;

    public void displayGun(M4SO gun)
    {
        name.text = gun.name;
        desc.text = gun.description;
        weight.text = "The gun weighs " + gun.weight;
        magSize.text = "Magizine Size is " + gun.magazineSize;
        Damage.value = gun.Damage;
        fireRate.value = gun.fireRate;
        accuracy.value = gun.accuracy;
        sprite.sprite = gun.sprite;
    }


}
