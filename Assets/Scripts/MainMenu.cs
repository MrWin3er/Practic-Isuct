using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Slider slider;
	public Text TextLink;
	int TestValue;
    void Start()
    {
		
    }

    void Update()
    {
        AudioListener.volume = slider.value; //передает значение громкоси звука в значение слайдера
		TestValue = (int) (slider.value * 100); //преобразует значение слайдера в текст
		TextLink.text = TestValue.ToString();
    }
	public void PlayGame()
	{
		 SceneManager.LoadScene("Lvl_1");
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
