using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    none, one, two
}


public class ObjectTrigger : MonoBehaviour
{
    public List<GameObject> setGOActive;
    public List<GameObject> setGOInactive;

    public State setState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (var go in setGOActive)
            {
                go.SetActive(true);
            }
            foreach (var go in setGOInactive)
            {
                go.SetActive(false);
            }

            //if (setState != State.none)
            //{
            //    GameManager.Instance.SetState(setState);
            //}
        }
    }

}
