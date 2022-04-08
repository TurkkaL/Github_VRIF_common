using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySystem : MonoBehaviour
{
    public float health = 1;

    public List<GameObject> hideGOsOnDeath;
    public List<GameObject> showGOsOnDeath;

    public ParticleSystem hitPS;

    [Header("Audio Settings")]
    public AudioSource audioDeath;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage, Collision collision)
    {
        Debug.Log("Taking damage! ("+damage+")");
        hitPS.transform.position = collision.GetContact(0).point;
        hitPS.Stop();
        hitPS.Play();

        health = health - damage;

        if (health <= 0f)
        {
            audioDeath.Play();
            HideGosOnDeath();
            ShowGosOnDeath();

            Destroy(gameObject, GetSafeDestroyDelay() );
        }
    }




    void ShowGosOnDeath()
    {
        foreach (var go in showGOsOnDeath)
        {
            go.SetActive(true);
        }
    }
    void HideGosOnDeath()
    {
        foreach (var go in hideGOsOnDeath)
        {
            go.SetActive(false);
        }
    }

    float GetSafeDestroyDelay()
    {
        // Figure out the longest time we need to keep this GO alive
        float destroyTime = 0f;
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>(true);
        foreach (var ps in particleSystems)
        {
            if (ps.main.duration > destroyTime) destroyTime = ps.main.duration;
        }

        destroyTime = Mathf.Max(destroyTime, audioDeath.clip.length);

        return destroyTime;
    }
}
