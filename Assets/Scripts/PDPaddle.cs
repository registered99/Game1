using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PDPaddle : FSprite 
{
	public string name;
	public int score;
	public PDPaddle(string name) : base("paddle")
	{
		this.name = name;
		ListenForUpdate (HandleUpdate);
		color = Color.red;
//		rotation = 45.0f;
//		width = 100.0f;
//		height = 200.0f;
	}
	public void HandleUpdate(){

	}
}

