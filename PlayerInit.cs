using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**Playerinit
 * A script that initializes everything about the player with one inspector field
 */
public class PlayerInit : MonoBehaviour{
    private SpriteRenderer sr; //A reference to the Player GameObject
    private Rigidbody2D rb; //A reference to the Player Rigidbody
    public PlayerStatsSO playerStats; //The scriptable Object that contains all information about the player

    /**PlayerStats
     * A property that allows other objects to access the player stats. Currently unused. 
     */
    public PlayerStatsSO PlayerStats {
        get { return playerStats; }
    }

    /**CreateFirepoint()
     * A method called at Awake that initializes Gameobjects that can fire bullets
     * Takes a PlayerWeaponSO that contains information about the weapon (rate of fire, offset on player, sprite, etc)
     */
    public void CreateFirepoint(PlayerWeaponSO weapon, int val) {
        GameObject weaponObj = new GameObject();
        weaponObj.transform.position = transform.position;
        weaponObj.transform.SetParent(gameObject.transform);
        weapon.offset.x *= val;
        weaponObj.transform.position += weapon.offset;
        weaponObj.AddComponent<PlayerWeapon>().WeaponSetup(weapon);
    }

    /**Awake()
     * Called at startup, initializes everything about the player.
     */
    public void Awake() {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = playerStats.shipSprite;
        sr.sortingOrder = 1;

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;

        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        gameObject.AddComponent<PlayerMovement>().MovementSetup(playerStats);

        foreach (PlayerWeaponSO weapon in playerStats.weapons) {
            CreateFirepoint(weapon, 1);
            if(weapon.type == WeaponType.Double) {
                CreateFirepoint(weapon, -1);
            }
        }
    }

}
