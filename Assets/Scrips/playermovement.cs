using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    public GameObject _player;

    private bool leftbound = false;
    private bool rightbound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rightbound)
            if (Input.GetKey("right"))
                _player.transform.position = new Vector3(_player.transform.position.x + moveSpeed, _player.transform.position.y, _player.transform.position.z);
        if (!leftbound)
            if (Input.GetKey("left"))
                _player.transform.position = new Vector3(_player.transform.position.x - moveSpeed, _player.transform.position.y, _player.transform.position.z);
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log("Collision");
        switch (other.gameObject.name) 
        {
            case "leftbound":
                leftbound = true;
                break;
            case "rightbound":
                rightbound = true;
                break;
        }
    }

    void OnCollisionExit(Collision other) {
        Debug.Log("Exit Collision");
        switch (other.gameObject.name)
        {
            case "leftbound":
                leftbound = false;
                break;
            case "rightbound":
                rightbound = false;
                break;
        }
    }
}
