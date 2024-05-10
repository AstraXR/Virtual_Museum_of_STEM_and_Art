using UnityEngine;
using System.Collections;

public class LiquidAnim : MonoBehaviour {

	private Texture2D[] _animationTexture;

	// Public vars
	public int AnimTileX = 8;
	public int AnimTileY = 8;
	public int animSpeedFPS = 25;
	
	public int framesCount = 64;

	public Vector2 textureSize = new Vector2(1,1);
	public Vector2 scrollSpeed;

	// Private vars
	private float _startTime;
	private Vector2 currentOffset;
	
	// Use this for initialization
	void Start () {
		_animationTexture = new Texture2D[framesCount];
		InitAnimTexture();	
		_startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer>().material.SetTextureScale( "_MainTex",new Vector2(1,1));
		
		float index = (Time.time-_startTime) * animSpeedFPS;
		index = index % (AnimTileX * AnimTileY);
		
		if (index==framesCount){
			_startTime = Time.time;	
			index=0;
		}
		
		GetComponent<Renderer>().material.SetTextureScale( "_MainTex",textureSize);
		currentOffset += scrollSpeed * Time.deltaTime;

		GetComponent<Renderer>().material.SetTextureOffset( "_MainTex", currentOffset);
		GetComponent<Renderer>().material.SetTexture("_MainTex", _animationTexture[(int)index]);
	}

	void OnDestroy() {
		for(int i=0;i<framesCount;i++)
			if(_animationTexture != null && _animationTexture[i] != null)
				Texture2D.Destroy (_animationTexture[i]);
	}

	// Init animation spritesheet texture
	public void InitAnimTexture(){
		Texture2D origine = (Texture2D) GetComponent<Renderer>().material.GetTexture("_MainTex");	
		
		int spriteSizeX = GetComponent<Renderer>().material.mainTexture.width / AnimTileX;
		int spriteSizeY = GetComponent<Renderer>().material.mainTexture.height / AnimTileY;
		
		int i=0,x=0,y=AnimTileY-1;

		while (y>=0 && i<framesCount){
			while (x<AnimTileX && i<framesCount){
				
				Color[] couleur = origine.GetPixels( spriteSizeX*x,spriteSizeY*y, spriteSizeX,spriteSizeY);	
				_animationTexture[i] = new Texture2D(spriteSizeX,spriteSizeY);
				_animationTexture[i].SetPixels( couleur);
				_animationTexture[i].Apply();

				x++;
				i++;
			}

			x=0;
			y--;
		}
	}
}
