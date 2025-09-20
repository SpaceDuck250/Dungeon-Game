using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    public Camera cam;
    public Vector3 mousePos;
    public Vector3 shootDir;
    public GameObject bulletPrefab;

    public float bulletSpeed;
    public float timeAlive;
    public Transform shootPoint;

    public AmmoScript ammoScript;
    public int ammoUseAmount;

    private void Start()
    {
        //cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shootPoint.rotation = Quaternion.Euler(0, 0, 90);
    }


    public void Use()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //shootDir = (mousePos - gameObject.transform.position).normalized;


        //float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        //Quaternion angleQ = Quaternion.Euler(0, 0, angle - 90);
        //shootPoint.rotation = angleQ;



        if (Input.GetKeyDown(KeyCode.Mouse0) && ammoScript.canUseWeapon)
        {
            GameObject newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            newBullet.GetComponent<BulletScript>().SetupBullet(bulletSpeed, timeAlive, shootPoint.up);
            //newBullet.GetComponent<BulletScript>().SetupBullet(bulletSpeed, timeAlive, shootPoint.up);

            ammoScript.UseAmmo(ammoUseAmount);
        }


    }


}
