using UnityEngine;
using System.Collections.Generic;

public class ShotGunScript : MonoBehaviour, IWeapon
{
    public GameObject bulletPrefab;

    public float bulletSpeed;
    public float timeAlive;
    public List<Transform> shotPoints = new List<Transform>();

    public float separation;

    public AmmoScript ammoScript;
    public int ammoUseAmount;


    private void Start()
    {
        //shootPoint.rotation = Quaternion.Euler(0, 0, 90);
        //shootPoint2.rotation = Quaternion.Euler(0, 0, 90 - separation);
        //shootPoint3.rotation = Quaternion.Euler(0, 0, 90 + separation);

        shotPoints[0].rotation = Quaternion.Euler(0, 0, 90);
        shotPoints[1].rotation = Quaternion.Euler(0, 0, 90 - separation);
        shotPoints[2].rotation = Quaternion.Euler(0, 0, 90 + separation);
    }



    public void Use() // rewrite this cleaner
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoScript.canUseWeapon)
        {

            //GameObject newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            //newBullet.GetComponent<BulletScript>().SetupBullet(bulletSpeed, timeAlive, shootPoint.up);

            //GameObject newBullet2 = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            //newBullet2.GetComponent<BulletScript>().SetupBullet(bulletSpeed, timeAlive, shootPoint2.up);

            //GameObject newBullet3 = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            //newBullet3.GetComponent<BulletScript>().SetupBullet(bulletSpeed, timeAlive, shootPoint3.up);

            foreach (Transform point in shotPoints)
            {
                GameObject newBullet = Instantiate(bulletPrefab, point.position, Quaternion.identity);
                newBullet.GetComponent<BulletScript>().SetupBullet(bulletSpeed, timeAlive, point.up);
            }

            ammoScript.UseAmmo(ammoUseAmount);
            ApplyRecoil();
        }
    }

    public void ApplyRecoil()
    {
        GameObject player = PlayerHand.instance.gameObject;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(400 * player.transform.localScale.x, 0), ForceMode2D.Impulse);
    }
}
