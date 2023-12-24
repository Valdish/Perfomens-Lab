using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task3
{

    class Program
    {
        static void Main()
        {
            // Загружаем данные из файлов
            string path = "C:\\Users\\SKORPION\\Desktop\\Task3\\Task3";
            string file = Console.ReadLine();
            string fullPath = System.IO.Path.Combine(path, file);
            string testsJson = File.ReadAllText(fullPath);

            file = Console.ReadLine();
            fullPath = System.IO.Path.Combine(path, file);
            string valuesJson = File.ReadAllText("C:\\Users\\SKORPION\\Desktop\\Task3\\Task3\\values.json");


            // Преобразуем JSON в объекты
            var testsData = JsonConvert.DeserializeObject<Rootobject>(testsJson);
            var valuesData = JsonConvert.DeserializeObject<Rootobject1>(valuesJson);

            // Заполняем значения
            FillValues(testsData, valuesData);

            // Преобразуем объекты обратно в JSON и записываем результат в report.json

            string reportJson = JsonConvert.SerializeObject(testsData, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("report.json", reportJson);
        }

        static void FillValues(Rootobject test, Rootobject1 values)
        {
            // Создаем словарь для быстрого доступа к результатам тестов по их id
            var valuesDict = new Dictionary<int, string>();
            foreach (var result in values.values)
            {
                valuesDict[result.id] = result.value;
            }

            // Функция для рекурсивного обхода и заполнения значений
            void FillRecursive(Test currentTest)
            {
                if (valuesDict.ContainsKey(currentTest.id))
                {
                    currentTest.value = valuesDict[currentTest.id];
                }

                if (currentTest.values != null)
                {
                    foreach (var nestedValue in currentTest.values)
                    {
                        FillValueRecursive(nestedValue);
                    }
                }
            }

            void FillValueRecursive(Value current)
            {
                if (valuesDict.ContainsKey(current.id))
                {
                    current.value = valuesDict[current.id];
                }

                if (current.values != null)
                {
                    foreach (var nestedValue1 in current.values)
                    {
                        FillValue1Recursive(nestedValue1);
                    }
                }
            }

            void FillValue1Recursive(Value1 current)
            {
                if (current.values != null)
                {
                    foreach (var nestedValue2 in current.values)
                    {
                        FillValue2Recursive(nestedValue2);
                    }
                }
            }

            void FillValue2Recursive(Value2 current)
            {
                if (valuesDict.ContainsKey(current.id))
                {
                    current.value = valuesDict[current.id];
                }
            }

            // Запускаем обход только с корневого элемента
            if (test.tests != null)
            {
                foreach (var rootTest in test.tests)
                {
                    FillRecursive(rootTest);
                }
            }
        }
    }
}