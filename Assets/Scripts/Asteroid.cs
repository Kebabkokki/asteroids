
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 8.0f;
    public float maxSize = 10.0f;
    public float speed = 30.0f;
    public float maxLifetime = 15.0f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Start()
   
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;

        _rigidbody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
      _rigidbody.AddForce(direction * this.speed);
      Destroy(this.gameObject, this.maxLifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if ((this.size * 8.0f) >= this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);



            Destroy(this.gameObject);
        }
            
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f; 

      Asteroid half = Instantiate(this, position, this.transform.rotation);
      half.size = this.size * 0.5f;

      half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }


}
