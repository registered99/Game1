using UnityEngine;
using System;

namespace move_character_space {
	public class BMain : MonoBehaviour
	{
		public BCharacter character;
		// Use this for initialization
		void Start () {
			FutileParams fparams = new FutileParams(true,true,false,false);
			fparams.AddResolutionLevel(480.0f,	1.0f,	1.0f,	"");
			fparams.origin = new Vector2(0.5f, 0.5f);
			Futile.instance.Init(fparams);
			
			Futile.atlasManager.LoadAtlas("Atlases/SpriteSheets/MoveCharacterAtlas");
			
			InGamePage char_container = new InGamePage();
			Futile.stage.AddChild(char_container);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
