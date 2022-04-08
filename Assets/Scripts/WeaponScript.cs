using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        EntitySystem entity = collision.gameObject.GetComponent<EntitySystem>();

        if (entity != null)
        {
            entity.TakeDamage(damage, collision);
        }
    }

    
}
