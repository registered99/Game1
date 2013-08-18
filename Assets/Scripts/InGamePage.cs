using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InGamePage : FContainer //FMultiTouchableInterface
{
	private FSprite _background;
	public InGamePage()
	{
		_background = new FSprite("JungleBlurryBG");
		AddChild (_background);

	}
}

