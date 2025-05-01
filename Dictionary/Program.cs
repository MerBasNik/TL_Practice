using Dictionary.Implementation;

namespace Dictionary;

class Program
{
    const string dictionaryFileName = "dictionary.txt";
    const string dictionaryFilePath = $"../../../{dictionaryFileName}";
    static void Main()
    {
        
        Console.WriteLine("Словарь с переводом (английский/русский)");
        DictionaryImplement.LoadDictionary(dictionaryFilePath);
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
                    DictionaryImplement.TranslateWord();
                    break;
                case "2":
                    DictionaryImplement.AddNewWord();
                    break;
                case "3":
                    DictionaryImplement.SaveDictionary(dictionaryFilePath);
                    isContinue = false;
                    break;
                default:
                    Console.WriteLine("Попробуйте ещё раз выбрать действие: 1, 2 или 3");
                    break;
            }
        }
    }
}