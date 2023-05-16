using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    Single, 
    Double,
}
[CreateAssetMenu]
/**PlayerWeaponSO
 * A scriptable object that details the properties of weapon the player can shoot
 * Enum details if the weapon will be mirrored on both sides of the player
 * GameObject bullet should contain a sprite renderer, Rigidbody 2D, and transform
 */
public class PlayerWeaponSO : ScriptableObject{
    public Vector3 offset;
    public float bulletSpeed, rateOfFire, lifetime;
    public WeaponType type;
    [Tooltip("Any generic gameobject with a Sprite Renderer and a Collider")]
    public GameObject bullet;
}
