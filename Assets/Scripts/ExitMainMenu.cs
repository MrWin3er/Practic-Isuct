using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
	public void ExitMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
