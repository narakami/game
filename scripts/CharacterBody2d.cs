using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;            // Скорость движения

	private Vector2 velocity = Vector2.Zero;      // Вектор скорости
  
	private AnimatedSprite2D _animationPlayer;
  
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Получение направления движения по горизонтали и вертикали
		Vector2 direction = Input.GetVector("left", "right", "up", "down");

		// Обновляем скорость
		velocity.X = direction.X * Speed;
		velocity.Y = direction.Y * Speed;

		// Проверка на движение и запуск соответствующей анимации
		if (velocity.X != 0)
		{
			_animationPlayer.Play("walk"); // Запускаем анимацию ходьбы
			_animationPlayer.FlipH = velocity.X < 0; // Поворачиваем персонажа влево или вправо
		}
		else if (velocity.Y != 0)
		{
			_animationPlayer.Play("walk");
		}
		else
		{
			_animationPlayer.Stop(); // Останавливаем анимацию, если не движемся
		}

		// Обновляем скорость и применяем движение с учетом коллизий
		Velocity = velocity;
		MoveAndSlide();
	}
}
