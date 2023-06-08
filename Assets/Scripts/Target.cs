using UnityEngine;

public class Target : MonoBehaviour
{
    private AudioSource _source;
    private Rigidbody _rb;
    private GameObject _gameMan;
    private GameManager _gameManagerScript;

    [SerializeField]
    private AudioClip _death;
    [SerializeField]
    private ParticleSystem _explos;
    [SerializeField]
    private GameObject _finish;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(Vector3.up * Random.Range(12, 15), ForceMode.Impulse);
        _rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -1, Random.Range(0, 3));

        _gameMan = GameObject.Find("Game Manager");
        _gameManagerScript = _gameMan.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void DestroyTarget()
    {
        Instantiate(_explos);
        _explos.Play();
        _source.PlayOneShot(_death);

        if (gameObject.CompareTag("Finish"))
        {
            Instantiate(_finish);
            _gameMan.SetActive(false);
        }
        else if (gameObject.CompareTag("Respawn"))
        {
            _gameManagerScript.Score(5);
        }

        gameObject.layer = LayerMask.NameToLayer("Water");
        Destroy(gameObject, 0.4f);
    }
}
