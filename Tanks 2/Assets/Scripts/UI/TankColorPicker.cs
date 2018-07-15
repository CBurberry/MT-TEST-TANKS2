/* Script based on default unity code for color sliders */

using UnityEngine;
using UnityEngine.UI;

public class TankColorPicker : MonoBehaviour
{
	//These are the Sliders that control the values. Remember to attach them in the Inspector window.
	public Slider m_SliderRed, m_SliderGreen, m_SliderBlue;

	public Color m_PlayerColor;								// This is the color this tank will be tinted (passed in as RGB).
	private Color m_OldPlayerColor;							// Save the old color so we're not updating every frame when not needed.
	[SerializeField] private Text m_PlayerTextDisplay;		// Text component that displays the player name.

	//Renderers to modify
	[SerializeField] Renderer[] m_RenderersArray;

	void Start()
	{
		//Set the maximum and minimum values for the Sliders
		m_SliderRed.maxValue	= 1;
		m_SliderGreen.maxValue	= 1;
		m_SliderBlue.maxValue	= 1;

		m_SliderRed.minValue	= 0;
		m_SliderGreen.minValue	= 0;
		m_SliderBlue.minValue	= 0;

		m_SliderRed.value		= m_PlayerColor.r;
		m_SliderGreen.value		= m_PlayerColor.g;
		m_SliderBlue.value		= m_PlayerColor.b;

		m_PlayerColor.a = 1.0f;
		UpdateTankColor();
	}

	void Update()
	{
		m_OldPlayerColor = m_PlayerColor;

		//These are the Sliders that determine the amount of the hue, saturation and value in the Color
		m_PlayerColor.r = m_SliderRed.value;
		m_PlayerColor.g = m_SliderGreen.value;
		m_PlayerColor.b = m_SliderBlue.value;

		//Create an RGB color from the HSV values from the Sliders
		//Change the Color of your GameObject to the new Color if the color has changed
		if ( m_RenderersArray.Length != 0 && m_OldPlayerColor != m_PlayerColor ) 
		{
			UpdateTankColor();
		}
	}

	void UpdateTankColor() 
	{
		foreach ( Renderer renderer in m_RenderersArray )
		{
			renderer.material.color = m_PlayerColor;
		}

		if ( m_PlayerTextDisplay != null ) 
		{
			m_PlayerTextDisplay.color = m_PlayerColor;
		}
	}
}