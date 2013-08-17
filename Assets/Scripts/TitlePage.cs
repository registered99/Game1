using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitlePage : FContainer
{
	private FSprite _background;
	private FSprite _mainLogo;
	
	private FButton _startButton;

	public TitlePage ()
	{
		_background = new FSprite("JungleBG.png");
		AddChild (_background);
		
		_mainLogo = new FSprite("MainLogo.png");
		AddChild (_mainLogo);
		
		_startButton = new FButton("YellowButton_normal.png", "YellowButton_over.png");
		_startButton.AddLabel ("Franchise","Start!",Color.white);
		
	}
	private void HandleStartButtonRelease(FButton button){
		PoopGame.instance.SwitchToInGame();
	}
}

