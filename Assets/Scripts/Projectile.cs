using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  Rigidbody2D rigidbody2d;

  public AudioClip getHitByRuby;

  // Start is called before the first frame update
  void Awake()
  {
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  public void Launch(Vector2 direction, float force)
  {
    rigidbody2d.AddForce(direction * force);
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.magnitude > 50.0f)
    {
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    EnemyController e = other.collider.GetComponent<EnemyController>();
    if (e != null)
    {
      e.Fix();
      e.GetHitSoundByRuby(getHitByRuby);
      // e.getHitEffect.Play();
      // Debug.Log("Here");
    }

    Destroy(gameObject);
  }
}
