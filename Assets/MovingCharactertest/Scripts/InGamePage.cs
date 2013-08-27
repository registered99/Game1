using System;
using UnityEngine;
namespace move_character_space {
	public class InGamePage : FContainer, FSingleTouchableInterface
	{
		public Vector2 touchPos;
		bool touchInput = false;
		BCharacter character;
		public InGamePage ()
		{
			EnableSingleTouch(); //IMPORTANT!!
			character = new BCharacter();
			character.scale = 0.25f;
			AddChild(character);
			ListenForUpdate(HandleUpdate);
		}
	public bool HandleSingleTouchBegan(FTouch touch){
		touchPos = touch.position;
		touchInput = true;
	    return true;	
	}
	public void HandleSingleTouchMoved(FTouch touch){
		touchPos = touch.position;
	}
	public void HandleSingleTouchEnded(FTouch touch){
		
	}
	public void HandleSingleTouchCanceled(FTouch touch){
			
		}
	private void HandleUpdate(){
		character.x = touchPos.x;	
		character.y = touchPos.y;
	}
	}
	}

