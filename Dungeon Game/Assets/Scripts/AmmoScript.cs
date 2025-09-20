using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public int maxAmmo;
    public int ammo;

    public float reloadTime;
    public bool canUseWeapon;

    private void Start()
    {
        ammo = maxAmmo;
        canUseWeapon = true;
    }

    public void UseAmmo(int amount)
    {
        ammo -= amount;
        if (ammo <= 0)
        {
            canUseWeapon = false;
            Invoke("Recharge", reloadTime);
        }
    }

    public void Recharge()
    {
        ammo = maxAmmo;
        canUseWeapon = true;
    }
}
