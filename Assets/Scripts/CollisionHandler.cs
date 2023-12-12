using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CollisionHandler : MonoBehaviour
{
    public static CollisionHandler Instance;

    [SerializeField] float levelLoadDelay = 0.2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    Rigidbody rb;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    public GameObject Water;
    public GameObject CeilingCollider;

    public GameObject Splash;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    public void WaterCollision()
    {
        rb.transform.DOLocalMoveY(transform.localPosition.y + 25f, 50f * Time.fixedDeltaTime);
        rb.transform.DOLocalRotate(new Vector3(-10, 0, 0), 50f * Time.fixedDeltaTime);
    }

    public void RoofCollision()
    {
        rb.transform.DOLocalMoveY(transform.localPosition.y - 20f, 50f * Time.fixedDeltaTime);
        rb.transform.DOLocalRotate(new Vector3(10,0,0), 50f * Time.fixedDeltaTime);
    }

    public void LeftCollision()
    {
        rb.transform.DOLocalMoveX(transform.localPosition.x + 5f, 50f * Time.fixedDeltaTime);
    }

    public void RightCollision()
    {
        rb.transform.DOLocalMoveX(transform.localPosition.x - 5f, 50f * Time.fixedDeltaTime);
    }

    public void StartCrashSequence()
    {
        GetComponent<DeltaController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
    void StartSuccessSequence()
    {
        Invoke("LoadNextLevel", levelLoadDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = (SceneManager.GetActiveScene().buildIndex);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }
}
