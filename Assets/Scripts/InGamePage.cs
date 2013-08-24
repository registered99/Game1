using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InGamePage : FContainer //FMultiTouchableInterface
{
	private FSprite _background;
	private PDPaddle _player1;
	private PDPaddle _player2;
	private PDBall _ball;
	
	public FLabel lblScore1;
	public FLabel lblScore2;
	
	private bool paused = false;
	private int maxScore = 5;

	public InGamePage ()
	{
		_background = new FSprite ("JungleBlurryBG");
		AddChild (_background);
		
		_player1 = new PDPaddle ("Player1");
		_player2 = new PDPaddle ("Player2");
		_ball = new PDBall ();
		ResetPaddles ();
		ResetBall ();
		AddChild (_player1);
		AddChild (_player2);
		AddChild (_ball);
		ListenForUpdate (Update);
		
		lblScore1 = new FLabel("arial", _player1.name + ": " + _player1.score);
		lblScore1.anchorX = 0; 
		lblScore1.anchorY = 0;
		lblScore1.x = -Futile.screen.halfWidth;
		lblScore1.y = -Futile.screen.halfHeight;
		
		lblScore2 = new FLabel("arial", _player2.name + ": " + _player2.score);	
		lblScore2.anchorX = 1.0f; //Anchor at the right edge.
		lblScore2.anchorY = 0;
		lblScore2.x = Futile.screen.halfWidth;
		lblScore2.y = -Futile.screen.halfHeight;
		
		AddChild (lblScore1);
		AddChild (lblScore2);
	}

	private void ResetPaddles ()
	{
		_player1.x = -Futile.screen.halfWidth + _player1.width / 2;
		_player1.y = 0;
		
		_player2.x = Futile.screen.halfWidth - _player2.width / 2;
		_player2.y = 0;
	}

	private void ResetBall ()
	{
		_ball.x = 0;
		_ball.y = 0;
		// Ensure that the ball starts at a random angle that is never greater than 45 degrees from 0 in either direction
		_ball.yVelocity = (_ball.defaultVelocity / 2) - (RXRandom.Float () * _ball.defaultVelocity);
		// Make sure that the defaultVelocity (hypotenuse) is honored by setting the xVelocity accordingly, then choose a random horizontal direction
		_ball.xVelocity = Mathf.Sqrt ((_ball.defaultVelocity * _ball.defaultVelocity) - (_ball.yVelocity * _ball.yVelocity)) * (RXRandom.Int (2) * 2 - 1);
	}
	private void BallPaddleCollision(PDPaddle player, float newBallY, float newPaddleY)
	{
		float localHitLoc = newBallY - newPaddleY;
		float angleMultiplier = Mathf.Abs (localHitLoc = newBallY - newPaddleY);
			
		float xVelocity = Mathf.Cos (65.0f * angleMultiplier * Mathf.Deg2Rad) * _ball.currentVelocity;
		float yVelocity = Mathf.Sin (65.0f * angleMultiplier * Mathf.Deg2Rad) * _ball.currentVelocity;
		
		if (localHitLoc < 0){
			yVelocity = -yVelocity;
		}
		if(_ball.xVelocity > 0){
			xVelocity = -xVelocity;
		}
		
		_ball.xVelocity = xVelocity;
		_ball.yVelocity = yVelocity;
	}

	public void Update ()
	{
		if(!paused) {
			float _newplayer1Y = _player1.y;
			float _newplayer2Y = _player2.y;
			float dt = Time.deltaTime;
			// Integrate to find the new x and y values for the ball
			float newBallX = _ball.x + dt * _ball.xVelocity;
			float newBallY = _ball.y + dt * _ball.yVelocity;
			// Check for ball-and-wall collisions
	        if (newBallY + (_ball.height/2) >= Futile.screen.halfHeight) {
	            newBallY = Futile.screen.halfHeight - (_ball.height/2) - Mathf.Abs((newBallY - Futile.screen.halfHeight));
	            _ball.yVelocity = -_ball.yVelocity;
	        } else if (newBallY - _ball.height/2 <= -Futile.screen.halfHeight) {
	            newBallY = -Futile.screen.halfHeight + (_ball.height/2) + Mathf.Abs((-Futile.screen.halfHeight - newBallY));
	            _ball.yVelocity = -_ball.yVelocity;
	        }
			// Check for paddle-and-ball collisions
			Rect ballRect = _ball.localRect.CloneAndOffset(newBallX, newBallY);
			Rect player1Rect = _player1.localRect.CloneAndOffset(_player1.x, _newplayer1Y);
			Rect player2Rect = _player2.localRect.CloneAndOffset(_player2.x, _newplayer2Y);
			 
			if (ballRect.CheckIntersect(player1Rect)) {
			    BallPaddleCollision(_player1, newBallY, _newplayer1Y);
				_ball.x += (ballRect.xMin - player1Rect.xMax);
			}
			if (ballRect.CheckIntersect(player2Rect)) {
			    BallPaddleCollision(_player2, newBallY, _newplayer2Y);
				_ball.x -= (ballRect.xMax - player2Rect.xMin);
			}	
			// Render the ball at its new location
			_ball.x = newBallX;
			_ball.y = newBallY;
			
			// Handle Input
		    if (Input.GetKey("w")) { _newplayer1Y += dt * _player1.currentVelocity; }
		    if (Input.GetKey("s")) { _newplayer1Y -= dt * _player1.currentVelocity; }
		    if (Input.GetKey("up")) { _newplayer2Y += dt * _player2.currentVelocity; }
		    if (Input.GetKey("down")) { _newplayer2Y -= dt * _player2.currentVelocity; }
			if (Input.GetKey ("space")) { ResetBall (); }
			
			_player1.y = _newplayer1Y;
		    _player2.y = _newplayer2Y;
			
			//Scoring Conditions
			PDPaddle scoringPlayer = null;
			if (newBallX - _ball.width/2 < -Futile.screen.halfWidth) { 
				scoringPlayer = _player2;
			} else if (newBallX + _ball.width/2 > Futile.screen.halfWidth){
				scoringPlayer = _player1;
			}
			
			if (scoringPlayer != null){
				ResetBall();
				ResetPaddles();
				++scoringPlayer.score;
				lblScore1.text = _player1.name + ": " + _player1.score;
				lblScore2.text = _player2.name + ": " + _player2.score;
				if (scoringPlayer.score >= maxScore){
					paused = true;
					RemoveAllChildren();
					FLabel lblWinner = new FLabel("arial", scoringPlayer.name + " WINS!");
					AddChild (lblWinner);
				}	
			}
		}
	}
}

