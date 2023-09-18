using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    public int portalSceneIndex;
    public SceneTransitionManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Hey");
            sceneManager.LoadScene(portalSceneIndex);
        }
        //LoadNextLevel();
    }
}
