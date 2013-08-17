using UnityEngine;
using System.Collections;

public class PoopGame : MonoBehaviour{

	private FContainer _currentPage;
	
	// This acts as a singleton
	public static PoopGame instance;
	
	private void Start () {
		instance = this;
		FutileParams fparams = new FutileParams(true,true,false,false);
		fparams.AddResolutionLevel(480.0f,	1.0f,	1.0f,	"_Scale1"); //iPhone
		fparams.origin = new Vector2(0.5f, 0.5f);
		Futile.instance.Init (fparams);
		Futile.atlasManager.LoadAtlas("Atlases/Banana");
		Futile.atlasManager.LoadFont("Franchise","FranchiseFont"+Futile.resourceSuffix, "Atlases/FranchiseFont"+Futile.resourceSuffix, 0.0f,-4.0f);
		
		SwitchToTitlePage();
		
	}
	public void SwitchToTitlePage(){
		if(_currentPage != null) _currentPage.RemoveFromContainer();
		_currentPage = new TitlePage();
		Futile.stage.AddChild(_currentPage);
	}
	public void SwitchToInGame(){
	}
	private void Update () {

	}
	
}
