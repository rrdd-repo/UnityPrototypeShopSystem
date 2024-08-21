using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueFadeOut : MonoBehaviour
{
    [SerializeField]
    private GameObject _talkButtonObj;
    [SerializeField]
    private GameObject _closeButtonObj;

    // Destroys the talk button and replaces it with the close menu button
    // After that, destroys dialogue
    private void Awake()
    {

        Destroy(_talkButtonObj);
        _closeButtonObj.SetActive(true);
        Destroy(gameObject, 3f);
        
        
    }
}
