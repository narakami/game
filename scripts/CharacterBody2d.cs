using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;            // Скорость движения

	private Vector2 velocity = Vector2.Zero;      // Вектор скорости

	public override void _PhysicsProcess(double delta)
	{

		// Получение направления движения по горизонтали и вертикали
		Vector2 direction = Input.GetVector("left", "right", "up", "down");

		// Движение по горизонтали (оси X)
		if (direction.X != 0)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, Speed);  // Замедление, если нет ввода
		}

		// Движение по вертикали (оси Y), если нужно
		if (direction.Y != 0)
		{
			velocity.Y = direction.Y * Speed;  // Вертикальное движение
		}
		else
		{
			velocity.Y = Mathf.MoveToward(velocity.Y, 0, Speed);  // Замедление, если нет ввода
		}

		// Обновляем скорость и применяем движение с учетом коллизифй
		Velocity = velocity;
		MoveAndSlide();
	}
}
