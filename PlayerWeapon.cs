using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**PlayerWeapon
 * Script for handling bullet information and instantiation 
 */
public class PlayerWeapon : MonoBehaviour {

    public GameObject bulletprefab;
    public float bulletSpeed, rateOfFire, lifetime;
    public Transform firePoint;
    protected float currentRechargeTime = 0f;//Determines current time between weapon uses

    /**WeaponSetup()
     * Called on instantiation in Playerinit
     * Takes stats from the playerStats arg
     * Initializes Bullet prefab
     */
    public void WeaponSetup(PlayerWeaponSO weaponInfo) {
        bulletprefab = weaponInfo.bullet;
        rateOfFire = weaponInfo.rateOfFire;
        firePoint = gameObject.transform;
        bulletprefab.AddComponent<BulletScript>().BulletSetup(weaponInfo.bulletSpeed, weaponInfo.lifetime);
    }

    //Basic Unity shoot code
    public void Shoot(Vector3 offset) {
        Instantiate(bulletprefab, firePoint.position + offset, firePoint.rotation);
    }

    private void FixedUpdate() {
        currentRechargeTime += Time.deltaTime;
        if (currentRechargeTime >= rateOfFire) {
            currentRechargeTime = currentRechargeTime % rateOfFire;
            Shoot(new Vector3(0, 0, 0));
        }
    }
}
