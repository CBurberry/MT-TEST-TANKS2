using UnityEngine;
using UnityEngine.UI;

public class ColorSliderImage : MonoBehaviour {

	private RawImage image;

	private void Awake()
	{
		image = GetComponent<RawImage>();
		RegenerateTexture();
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		image = GetComponent<RawImage>();
		RegenerateTexture();
	}
#endif

	private void RegenerateTexture()
	{
		int size = 360;
		Texture2D texture = new Texture2D( size, 1 );
		Color32[] colors = new Color32[size];
		texture.hideFlags = HideFlags.DontSave;

		for ( int i = 0; i < size; i++ )
		{
			colors[i] = Color.HSVToRGB( i, 1, 1 );
			colors[i].a = 1;
		}

		texture.SetPixels32( colors );
		texture.Apply();

		if ( image.texture != null )
		{
			DestroyImmediate( image.texture );
		}

		image.texture = texture;
		image.uvRect = new Rect( 0, 0, 1, 2 );
	}
}
