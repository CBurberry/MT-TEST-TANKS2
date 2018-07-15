/* Mostly a trimmed copy of TutorialInfo.cs code provided with the template. */

using UnityEngine;

public class GameStartingMenus : MonoBehaviour {

	//Preview meshes used by customisation screen for render textures
	[SerializeField] private GameObject m_PreviewTank1;
	[SerializeField] private GameObject m_PreviewTank2;
	
	//Access to GameManager as returning null for component
	[SerializeField] private GameManager m_GameManager;

	void Awake() 
	{
		ShowLaunchScreen();
	}

	// show overlay info, pausing game time, disabling the audio listener 
	// and enabling the overlay info parent game object
	public void ShowLaunchScreen()
	{
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
		gameObject.transform.GetChild( 0 ).gameObject.SetActive( true );
	}

	//Hide the starting screen and display the customisation menu
	public void ShowCustomisationScreen()
	{
		gameObject.transform.GetChild( 0 ).gameObject.SetActive( false );
		gameObject.transform.GetChild( 1 ).gameObject.SetActive( true );
	}

	// continue to play, by ensuring the preference is set correctly, the overlay is not active, 
	// and that the audio listener is enabled, and time scale is 1 (normal)
	public void StartGame()
	{
		gameObject.transform.GetChild( 0 ).gameObject.SetActive( false );
		gameObject.transform.GetChild( 1 ).gameObject.SetActive( false );

		//Disable the preview meshes since we're not going to see them again
		m_PreviewTank1.SetActive( false );
		m_PreviewTank2.SetActive( false );

		AudioListener.volume = 1f;
		Time.timeScale = 1f;
	}
}
