using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;

    [SerializeField]
    private GameObject presser;

    [SerializeField]
    private AudioSource sound;
    public bool isPressed;

    [SerializeField] private Score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    void OnTriggerEnter(Collider other) 
    { 
        if(!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.5f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }

    }

    public void GorodokActivate()
    {
        foreach (GameObject obj in scoreScript.gorodokObjects)
        {
            SetActive gorodokScript = obj.GetComponent<SetActive>();
            gorodokScript.enabled = true;
        }
    }

    public void onPressTest()
    {
        Debug.Log("Кнопка нажата");
    }

    public void onReleaseTes()
    {
        Debug.Log("Кнопка отжата");
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 1f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
