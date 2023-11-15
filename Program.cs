using System;
using System.Collections.Generic;

// Клас конфігураційного менеджера з використанням Singleton
public sealed class ConfigurationManager
{
    // Єдиний екземпляр класу
    private static ConfigurationManager instance = null;

    // Колекція для збереження конфігураційних налаштувань
    private Dictionary<string, string> settings;

    // Ініціалізація за замовчуванням
    private ConfigurationManager()
    {
        settings = new Dictionary<string, string>();
    }

    // Метод для отримання єдиного екземпляру класу
    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    // Метод для зміни конфігураційного параметра
    public void UpdateSetting(string key, string value)
    {
        if (settings.ContainsKey(key))
        {
            settings[key] = value;
        }
        else
        {
            settings.Add(key, value);
        }
    }

    // Метод для виведення усіх конфігураційних налаштувань
    public void DisplaySettings()
    {
        Console.WriteLine("Конфігураційні налаштування:");
        foreach (var setting in settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Використання Singleton патерну
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Зміна конфігураційних налаштувань через консольний інтерфейс
        Console.WriteLine("Введіть назву налаштування:");
        string key = Console.ReadLine();

        Console.WriteLine("Введіть значення:");
        string value = Console.ReadLine();

        // Оновлення конфігураційного параметра
        configManager.UpdateSetting(key, value);

        // Виведення усіх конфігураційних налаштувань
        configManager.DisplaySettings();
    }
}
