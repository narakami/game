using Godot;
using System;

public partial class HP : Node
{
	// Публичные переменные для максимального, текущего и минимального здоровья
	public int MaxHP { get; private set; }
	public int CurrentHP { get; private set; }
	public int MinHP { get; private set; }

	// Конструктор для инициализации
	public HP(int maxHP, int minHP)
	{
		MaxHP = maxHP;
		MinHP = minHP;
		CurrentHP = maxHP; // Начальное значение текущего здоровья = максимальному
	}

	// Метод для получения текущего здоровья
	public int GetCurrentHP()
	{
		return CurrentHP;
	}

	// Метод для изменения здоровья
	public void ModifyHP(int amount)
	{
		CurrentHP += amount;

		// Убедитесь, что текущие очки здоровья не выходят за пределы диапазона
		if (CurrentHP > MaxHP)
			CurrentHP = MaxHP;
		if (CurrentHP < MinHP)
			CurrentHP = MinHP;
	}

	// Метод для восстановления здоровья
	public void Heal(int amount)
	{
		ModifyHP(amount);
	}

	// Метод для получения процентного значения здоровья
	public float GetHealthPercentage()
	{
		return (float)CurrentHP / MaxHP * 100;
	}
}
