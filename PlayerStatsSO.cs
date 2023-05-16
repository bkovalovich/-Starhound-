using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
/**PlayerStatsSO
 * A scriptable object that contains everything about a player instance
 * Aims to simplify new ship creation in order to efficiently fill out a roster of playable characters
 */
public class PlayerStatsSO : ScriptableObject {
    public string shipname, dogname;
    public float health, speed, turnSpeed;
    public Sprite shipSprite;
    //public __ ability;
    public PlayerWeaponSO[] weapons;
}
