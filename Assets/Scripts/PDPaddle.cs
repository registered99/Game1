using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PDPaddle : FSprite 
{
	public string name;
	public int score;
	public float defaultVelocity;
	public float currentVelocity;
	
	public PDPaddle(string name) : base("paddle")
	{
		this.name = name;
		ListenForUpdate (HandleUpdate);
		
		defaultVelocity = Futile.screen.height; // Our paddle will be able to traverse the height of our screen in 1 second, seems reasonable.
        currentVelocity = defaultVelocity;
		color = Color.red;
//		rotation = 45.0f;
//		width = 100.0f;
//		height = 200.0f;
	}
	public void HandleUpdate(){

	}
}

