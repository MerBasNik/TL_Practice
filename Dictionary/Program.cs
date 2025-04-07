class Dictionary
{
    static Dictionary<string, string> dictEngToRus = new Dictionary<string, string>();
    static Dictionary<string, string> dictRusToEng = new Dictionary<string, string>();
    public static void TranslateWord()
    {
        Console.Write("Введите слово для перевода: ");
        string word = Console.ReadLine().Trim();
        if (dictEngToRus.ContainsKey(word))
        {
            Console.WriteLine($"{word} --> {dictEngToRus[word]}");
        }
        else if (dictRusToEng.ContainsKey(word))
        {
            Console.WriteLine($"{word} --> {dictRusToEng[word]}");
        }
        else
        {
            Console.Write("Такого слова в словаре нет. Хотите его добавить? (да/нет): ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "да")
            {
                AddNewWord(word);
            }
        }
    }

    public static void AddNewWord(string word = null)
    {
        if (word == null)
        {
            Console.Write("Введите слово которое хотите добавить: ");
            word = Console.ReadLine().Trim();
        }

        if (!dictEngToRus.ContainsKey(word) && !dictRusToEng.ContainsKey(word))
        {
            Console.Write($"Введите перевод слова {word}: ");
            string translateWord = Console.ReadLine().Trim();

            string lang = WhatLanguage(translateWord);
            if (lang == "ru")
            {
                dictEngToRus.Add(word, translateWord);
                dictRusToEng.Add(translateWord, word);
            }
            else
            {
                dictRusToEng.Add(word, translateWord);
                dictEngToRus.Add(translateWord, word);
            }

            Console.WriteLine($"Слово c переводом добавлено в словарь: {word} --> {translateWord}");
        }
        else
        {
            Console.WriteLine("Такое слово уже есть в словаре");
        }
    }

    static string WhatLanguage(string word)
    {
        foreach (char ch in word)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
            {
                return "en";
                break;
            }
        }

        return "ru";
    }
    
    public static void LoadDictionary(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {fileName} не существует");
        }
        List<string> dict = File.ReadLines(filePath).ToList();
        foreach (string line in dict)
        {
            string[] pair = line.Split(':');
            dictEngToRus.Add(pair[0], pair[1]);
            dictRusToEng.Add(pair[1], pair[0]);
        }
    }

    public static void SaveDictionary(string filePath)
    {
        List<string> words = new List<string>();
        foreach (KeyValuePair<string, string> pair in dictEngToRus)
        {
            words.Add($"{pair.Key}:{pair.Value}");
        }

        File.WriteAllLines(filePath, words);
        Console.WriteLine("Словарь сохранён");
    }
}

class Program
{
    const string dictionaryFileName = "dictionary.txt";
    const string dictionaryFilePath = $"../../../{dictionaryFileName}";
    static void Main()
    {
        Console.WriteLine("Словарь с переводом (английский/русский)");
        Dictionary.LoadDictionary(dictionaryFilePath);
        bool isContinue = true;

        while (isContinue)
        {
            Console.WriteLine("Выберите действие (1, 2 или 3): ");
            Console.WriteLine("1. Перевести слово");
            Console.WriteLine("2. Добавить новое слово");
            Console.WriteLine("3. Выйти");
            string desicion = Console.ReadLine();
            switch (desicion)
            {
                case "1":
                    Dictionary.TranslateWord();
                    break;
                case "2":
                    Dictionary.AddNewWord();
                    break;
                case "3":
                    Dictionary.SaveDictionary(dictionaryFilePath);
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Попробуйте ещё раз выбрать действие: 1, 2 или 3");
                    break;
            }
        }
    }
}