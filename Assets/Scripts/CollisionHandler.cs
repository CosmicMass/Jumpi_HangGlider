using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.AdaptivePerformance.VisualScripting;
using System.Globalization;

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

    bool isTouchedWater = true;
    bool isTouchedRoof = true;

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
        rb.transform.DOLocalMoveY(transform.localPosition.y + 50f, 40f * Time.fixedDeltaTime);
    }
    public void RoofCollision()
    {
        rb.transform.DOLocalMoveY(transform.localPosition.y - 50f, 40f * Time.fixedDeltaTime);
    }
    public void StartCrashSequence()
    {
        //isTransitioining = true;
        //audioSource.Stop();
        //audioSource.PlayOneShot(crash);
        //crashParticles.Play();
        GetComponent<DeltaController>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
    void StartSuccessSequence()
    {
        //isTransitioining = true;
        //audioSource.Stop();
        //audioSource.PlayOneShot(success);
        //successParticles.Play();
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
