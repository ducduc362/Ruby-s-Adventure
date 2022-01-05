using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
  public static EnemyController Instance { get; private set; }
  public float speed;
  public bool vertical;
  public float changeTime = 3.0f;

  public ParticleSystem smokeEffect;

  public ParticleSystem getHitEffect;

  Rigidbody2D rigidbody2DRobot;
  float timer;
  int direction = 1;
  bool broken = true;

  Animator animator;

  AudioSource audioSource;
  public AudioClip getHitClip;

  private void Awake()
  {
    Instance = this;
    getHitEffect.Stop();
    // smokeEffect.Stop();
  }

  // Start is called before the first frame update
  void Start()
  {
    rigidbody2DRobot = GetComponent<Rigidbody2D>();
    audioSource = GetComponent<AudioSource>();
    timer = changeTime;
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!broken)
    {
      return;
    }

    timer -= Time.deltaTime;

    if (timer < 0)
    {
      direction = -direction;
      timer = changeTime;
    }
  }

  void FixedUpdate()
  {
    if (!broken)
    {
      return;
    }

    Vector2 position = rigidbody2DRobot.position;

    if (vertical)
    {
      position.y = position.y + Time.deltaTime * speed * direction;
      animator.SetFloat("Move X", 0);
      animator.SetFloat("Move Y", direction);
    }
    else
    {
      position.x = position.x + Time.deltaTime * speed * direction;
      animator.SetFloat("Move X", direction);
      animator.SetFloat("Move Y", 0);
    }

    rigidbody2DRobot.MovePosition(position);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    RubyController player = other.gameObject.GetComponent<RubyController>();

    if (player != null)
    {
      player.ChangeHealth(-1);

      player.GetHitSound(getHitClip);
    }
  }

  public void Fix()
  {
    broken = false;

    rigidbody2DRobot.simulated = false;

    animator.SetTrigger("Fixed");

    smokeEffect.Stop();
    gameObject.tag = "FixedRobot";
  }

  public void GetHitSoundByRuby(AudioClip clip)
  {
    audioSource.PlayOneShot(clip);
  }

}
