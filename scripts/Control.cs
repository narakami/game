using Godot;
using System;

public partial class Control : Godot.Control
{
	private ProgressBar healthBar;
	
	// Переменная для класса HP
	private HP hp;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Находим ProgressBar в сцене (предположим, что он внутри Control)
		healthBar = GetNode<ProgressBar>("HealthBar");

		// Инициализируем здоровье
		hp = new HP(100, 0); // Максимум 100, минимум 0
		healthBar.MinValue = 0;
		healthBar.MaxValue = hp.MaxHP;
		healthBar.Value = hp.CurrentHP; // Устанавливаем начальное значение полоски

		// Устанавливаем позицию полоски здоровья в левый верхний угол
		healthBar.Position = new Vector2(10, 10); // Позиция в пикселях от верхнего левого угла экрана
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Пример уменьшения здоровья при нажатии кнопки
		if (Input.IsActionPressed("ui_accept"))
		{
			hp.ModifyHP(-10); // Уменьшаем здоровье
			healthBar.Value = hp.CurrentHP; // Обновляем значение полоски здоровья
		}

		// Пример восстановления здоровья при нажатии другой кнопки
		if (Input.IsActionPressed("ui_cancel"))
		{
			hp.Heal(5); // Восстанавливаем здоровье
			healthBar.Value = hp.CurrentHP; // Обновляем значение полоски здоровья
		}
	}
}
