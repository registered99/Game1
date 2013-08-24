using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestGame : MonoBehaviour{

	private FContainer _currentPage;
	
	// This acts as a singleton
	public static TestGame instance;
	
	private void Start () {
		instance = this;
		FutileParams fparams = new FutileParams(true,true,false,false);
		fparams.AddResolutionLevel(480.0f,	1.0f,	1.0f,	"_Scale1"); //iPhone
		fparams.origin = new Vector2(0.5f, 0.5f);
		Futile.instance.Init (fparams);
		Futile.atlasManager.LoadAtlas("Atlases/Banana");
		Futile.atlasManager.LoadAtlas("Atlases/BananaLargeAtlas");
		Futile.atlasManager.LoadAtlas("Atlases/PongDemo");
		Futile.atlasManager.LoadAtlas("Atlases/BananaGameAtlas"); // one of these is important for Font. I guess font is inside the atlas? 
		Futile.atlasManager.LoadFont ("arial", "arial", "Atlases/arial", 0, 0);
			
		Futile.atlasManager.LoadFont("Franchise","FranchiseFont"+Futile.resourceSuffix, "Atlases/FranchiseFont"+Futile.resourceSuffix, 0.0f,-4.0f);
		
//		SwitchToTitlePage();
		SwitchToInGamePage();

		
	}
	public void SwitchToTitlePage(){
		if(_currentPage != null) _currentPage.RemoveFromContainer();
		_currentPage = new TitlePage();
		Futile.stage.AddChild(_currentPage);
	}
	public void SwitchToInGamePage(){
		if(_currentPage != null) _currentPage.RemoveFromContainer();
		_currentPage = new InGamePage();
		Futile.stage.AddChild(_currentPage);

	}
	private void Update () {
	}
	
}
