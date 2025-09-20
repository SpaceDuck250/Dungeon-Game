using UnityEngine;

public class SwordScript : MonoBehaviour, IWeapon
{
    public DamageAreaScript damageArea;
    public float activeTime;

    public void Use()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            damageArea.Activate(activeTime);
        }
    }


}
