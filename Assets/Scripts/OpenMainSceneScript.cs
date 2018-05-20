
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainSceneScript : MonoBehaviour 
{
	public void GoToNextSceneAction ()
	{
		Application.LoadLevel ("gameplay scene");

	}


    public void GoToNextSceneAction2()
    {
        Application.LoadLevel("guide scene");

    }

    public void GoToNextSceneAction3()
    {
        Application.LoadLevel("credit scene");

    }

    public void GoToNextSceneAction4()
    {
        Application.LoadLevel("main");

    }


}
