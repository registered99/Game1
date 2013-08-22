using UnityEngine;
using System.Collections;

public class PDBall : FSprite
{
	public float xVelocity;
	public float yVelocity;
	public float defaultVelocity;
	public float currentVelocity;
     
	public PDBall () : base("ball")
	{
		defaultVelocity = 100.0f;
		currentVelocity = defaultVelocity;
	}
}
