using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponsController : MonoBehaviour
{
    // == private fields ==
    [SerializeField] private float bulletSpeed = 12.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float firingRate = 0.4f;

    private Coroutine firingCoroutine;
    private GameObject bulletParent;
    private GameObject weapon;

    // == private methods ==
    private void Start()
    {
        weapon = GameObject.Find("weapon");
        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // one way to fire
            //FireBullet();
            // implement a coroutine to fire
            firingCoroutine = StartCoroutine(FireCoroutine());
            FindObjectOfType<AudioController>().Play("PlayerShoot");
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //StopAllCoroutines();    // not good, sledgehammer approach
            StopCoroutine(firingCoroutine);
        }
    }

    // coroutine returns an IEnumerator type
    private IEnumerator FireCoroutine()
    {
        while(true)
        {
            // create a bullet
            Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
            bullet.transform.position = weapon.transform.position;
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            rbb.velocity = Vector2.right * bulletSpeed;
            // sleep for short time
            yield return new WaitForSeconds(firingRate); // pick a number!!!
        }
    }

    //private void FireBullet()
    //{
    //    // instantiate bullet
    //    Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
    //    // give it the same position as the player
    //    bullet.transform.position = transform.position;
    //    // give it velocity and move right
    //    Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
    //    //rbb.velocity = new Vector2(1 * speed, 0);
    //    rbb.velocity = Vector2.right * bulletSpeed;
    //}
}
