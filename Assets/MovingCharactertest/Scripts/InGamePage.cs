using System;
using UnityEngine;

namespace move_character_space
{
	public class InGamePage : FContainer, FMultiTouchableInterface
	{
		public Vector2 touchPos;
		bool touchInput = false;
		BCharacter character;

		public InGamePage ()
		{
			EnableMultiTouch (); //IMPORTANT!!
			character = new BCharacter ();
			character.scale = 0.25f;
			AddChild (character);
			ListenForUpdate (HandleUpdate);
		}

		private void HandleUpdate ()
		{
			character.x = touchPos.x;	
			character.y = touchPos.y;
		}
		public void HandleMultiTouch(FTouch[] touches)
		{
			if (touches.Length > 0){
				touchPos = touches[0].position;
			}
		}
	}
}

