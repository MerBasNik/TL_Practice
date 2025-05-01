namespace Dictionary.Implementation;

public class DictionaryImplement
{
    static Dictionary<string, string> translationEnToRu = new Dictionary<string, string>();
    static Dictionary<string, string> translationRuToEn = new Dictionary<string, string>();
    public static void TranslateWord()
    {
        Console.Write("Введите слово для перевода: ");
        string word = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(word))
        {
            Console.WriteLine("Слово пустое или состоит из пробелов, попробуйте еще раз");
            return;
        }
        
        if (String.IsNullOrWhiteSpace(word))
        {
            Console.WriteLine("Слово пустое или состоит из пробелов, попробуйте еще раз");
            return;
        }
        
        if (translationEnToRu.ContainsKey(word))
        {
            Console.WriteLine($"{word} --> {translationEnToRu[word]}");
        }
        else if (translationRuToEn.ContainsKey(word))
        {
            Console.WriteLine($"{word} --> {translationRuToEn[word]}");
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

        if (!translationEnToRu.ContainsKey(word) && !translationRuToEn.ContainsKey(word))
        {
            Console.Write($"Введите перевод слова {word}: ");
            string translateWord = Console.ReadLine().Trim();

            string lang = WhatLanguage(translateWord);
            if (lang == "ru")
            {
                translationEnToRu.Add(word, translateWord);
                translationRuToEn.Add(translateWord, word);
            }
            else
            {
                translationEnToRu.Add(word, translateWord);
                translationRuToEn.Add(translateWord, word);
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
            translationEnToRu.Add(pair[0], pair[1]);
            translationRuToEn.Add(pair[1], pair[0]);
        }
    }

    public static void SaveDictionary(string filePath)
    {
        List<string> words = new List<string>();
        foreach (KeyValuePair<string, string> pair in translationEnToRu)
        {
            words.Add($"{pair.Key}:{pair.Value}");
        }

        File.WriteAllLines(filePath, words);
        Console.WriteLine("Словарь сохранён");
    }
}