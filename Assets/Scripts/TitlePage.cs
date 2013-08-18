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
		_background = new FSprite("JungleBlurryBG");
		AddChild (_background);
		
		_mainLogo = new FSprite("MainLogo");
		AddChild (_mainLogo);
		
		_startButton = new FButton("YellowButton_normal", "YellowButton_over");
		_startButton.AddLabel ("Franchise","Start!",Color.white);
		AddChild (_startButton);
		
	}
	private void HandleStartButtonRelease(FButton button){
		PoopGame.instance.SwitchToInGame();

	}
}

