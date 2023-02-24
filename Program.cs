// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
// длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры,
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
// лучше обойтись исключительно массивами.
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

Console.Clear();
string taskText = "Программа формирования массива строк из исходного массива, длина которых не более 3 символов.\n";
Console.WriteLine(taskText);
File.WriteAllText("output.txt", taskText);

// Создание и инициализация строковых массивов
string[] array1 = { "Hello", "2", "world", ":-)" };
string[] array2 = { "1234", "1567", "-2", "computer science" };
string[] array3 = { "Russia", "Denmark", "Kazan" };

int maxLength = 3; // Инициализация переменной для ограничения по количеству символов в слове

OutputArrays(array1);
OutputArrays(array2);
OutputArrays(array3);

void OutputArrays(string[] array) // Метод результирующего вывода массивов
{
    string resultString = (PrintArray(array) + "   ->   " +
                           PrintArray(SelectRequiredArrayElements(array)) +
                           "\n"); // Формирование строки как в задании
    Console.WriteLine(resultString);
    File.AppendAllText("output.txt", resultString); // Добавление результатов в файл
}

string PrintArray(string[] array) // Метод приведения массива к виду [" ", ..., " "]
{
    string formatArray = ("[\"" + string.Join("\", \"", array) + "\"]");
    return formatArray;
}

string[] SelectRequiredArrayElements(string[] original) // Метод отбора подходящих условию элементов массива
{
    int length = original.Length;
    string[] result = new string[length];   // Создание результирующего массива с длиной равной исходному
    int count = 0;                          // Инициализация счетчика подходяших элементов

    for (int i = 0; i < length; i++)
    {
        if (original[i].Length <= maxLength)
        {
            result[count] = original[i];    // Запись подходящего элемента в результирующий массив
            count++;
        }
    }
    Array.Resize(ref result, count);        // Сокращение результирующего массива

    return result;
}