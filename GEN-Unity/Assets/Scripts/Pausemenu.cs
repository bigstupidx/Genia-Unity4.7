using UnityEngine;
using System.Collections;

public class Pausemenu : MonoBehaviour {

	public UILabel openpuase;


	public void restartgame()

	{
		Application.LoadLevel("Demo");
		Time.timeScale = 1.0f;
	}

	public void endgame()
	{
		Application.Quit();
	}

	public void backtomain()
	{
		Application.LoadLevel("Title");
	}

	public void resumegame()

	{
		openpuase.gameObject.SetActive(false);
		Time.timeScale = 1.0f;
	}

	public void enablepause()
	{
		Time.timeScale = 0.0f;
		openpuase.gameObject.SetActive(true);
	}


}
