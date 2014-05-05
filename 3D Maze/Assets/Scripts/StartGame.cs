using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject firstPersonController;

	void OnMouseDown()
    {
        firstPersonController.SetActive(true);
        mainCamera.SetActive(false);
        
	}
}
