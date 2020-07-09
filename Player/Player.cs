using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	public float maxSpeed = 250;
	
	public float speed = 0;
	
	[Export]
	public int acceleration = 1200;
	
	float moveDirection;
	bool moving = false;
	Vector2 destination = new Vector2();
	Vector2 movement = new Vector2();

	public override void _UnhandledInput(InputEvent @event)
	{
		if(Input.IsActionPressed("touch"))
		{
			moving = true;
			destination = GetGlobalMousePosition();
		}
	}

	public void Movement(float delta)
	{
		if (!moving)
		{
			speed = 0;
		}
		else
		{
			speed += acceleration * delta;
			if (speed > maxSpeed)
			{
				speed = maxSpeed;
			}
		}
		
		movement = Position.DirectionTo(destination) * speed;
		moveDirection = Mathf.Rad2Deg(destination.AngleToPoint(Position));
		
		if (Position.DistanceTo(destination) > 5)
		{
			movement = MoveAndSlide(movement);
		}
		else
		{
			moving = false;
		}
	}
	
	public override void _PhysicsProcess(float delta)
	{
		Movement(delta);
	}
	
	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		
		
		
	}

}
