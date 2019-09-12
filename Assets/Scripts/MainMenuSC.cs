using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
	public Slider slider;
	public Text TextLink;
	int TestValue;
    void Start()
    {
		
    }

    void Update()
    {
        AudioListener.volume = slider.value;
		TestValue = (int) (slider.value * 100);
		TextLink.text = TestValue.ToString();
    }
	public void PlayGame()
	{
		 SceneManager.LoadScene("level1");
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
