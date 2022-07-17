using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
  public GameObject bulletPrefab;
  private GameObject bulletContainer;
  private GameObject firePoint;
  private float bulletForce = 5f;

  float timeCountdown = 2f;
  float currentTime = 0f;

  /// <summary>
  /// Define Tank Barrel to rotate and target to look at
  /// </summary>
  GameObject enemy;
  GameObject barrelTank;
  void Start()
  {
    bulletContainer = GameObject.Find("Bullet Container");
    firePoint = GameObject.Find("Fire Point");
    enemy = GameObject.FindWithTag("Enemy");
    barrelTank = GameObject.Find("Tower");
    currentTime = timeCountdown;
  }

  void Update()
  {
    RotateTowards(new Vector2(enemy.transform.position.x, enemy.transform.position.y), barrelTank);

    currentTime -= Time.deltaTime;
    if (currentTime < 0)
    {
      Shoot();
      currentTime = timeCountdown;
    }
  }

  private void RotateTowards(Vector2 target, GameObject barrel)
  {
    Vector2 direction = (target - (Vector2)barrel.transform.position).normalized;
    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    var offset = 90f;
    barrel.transform.rotation = Quaternion.Euler(Vector3.forward * (angle - offset));
  }

  private void Shoot()
  {
    GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation, bulletContainer.transform);
    Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
    rigidBody.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);

    DestroyBullet(bullet, 3f);
  }

  private void DestroyBullet(GameObject bullet, float lifeTime)
  {
    Destroy(bullet, lifeTime);
  }
}
