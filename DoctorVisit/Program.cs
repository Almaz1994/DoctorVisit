using System;
using System.Collections.Generic;

namespace DoctorVisit
{
    class Program
    {
        private static string CheckString(string str)
        {
            while(string.IsNullOrEmpty(str))
            {
                str = Console.ReadLine();
                if(!string.IsNullOrEmpty(str))
                    continue;                
                else
                    Console.WriteLine("Ничего не введено! Попробуйте еще раз!");
            }
            return CheckCharacters(str);
        }

        private static string CheckCharacters(string str)
        {
            foreach(char c in str)
            {
                if(Char.IsDigit(c) || (Char.IsPunctuation(c)))
                {
                    return "";
                }
            }
            return str;
        }


        static void Main(string[] args)
        {
            string lastname;
            string firstname;
            string middlename;
            string education;
            string company;
            string diagnose;
            string post;
            string medname;

            int count = 0;
            double price = 0.0F;
            double average = 0.0F;

            Console.WriteLine("Введите фамилию врача: ");
            lastname = CheckString(Console.ReadLine());

            Console.WriteLine("Введите имя врача: ");
            firstname = CheckString(Console.ReadLine());

            Console.WriteLine("Введите отчество врача: ");
            middlename = CheckString(Console.ReadLine());

            Console.WriteLine("Введите ВУЗ, который закончил врач: ");
            education = CheckString(Console.ReadLine());

            Console.WriteLine("Введите место работы врача: ");
            company = CheckString(Console.ReadLine());

            Console.WriteLine("Введите должность врача: ");
            post = CheckString(Console.ReadLine());

            var doctor = new Doctor(lastname, firstname, middlename, education, company, post);


            Console.WriteLine("Введите фамилию пациента: ");
            lastname = CheckString(Console.ReadLine());

            Console.WriteLine("Введите имя пациента: ");
            firstname = CheckString(Console.ReadLine());

            Console.WriteLine("Введите отчество пациента: ");
            middlename = CheckString(Console.ReadLine());

            Console.WriteLine("Введите ВУЗ, который закончил пациент: ");
            education = CheckString(Console.ReadLine());

            Console.WriteLine("Введите место работы пациента: ");
            company = CheckString(Console.ReadLine());

            var patient = new Patient(lastname, firstname, middlename, education, company);

            Console.WriteLine("Введите диагноз пациента: ");
            diagnose = CheckString(Console.ReadLine());
            doctor.SetDiagnose(patient, diagnose);

            Console.WriteLine("Рецепт врача: ");
            Console.WriteLine("Введите названия лекарств: ");
            List<string> medication = new List<string>();

            while(!string.IsNullOrEmpty(CheckCharacters(medname = Console.ReadLine())))
            {
                medication.Add(medname);
            }
            doctor.SetMedication(patient, medication);


            Console.WriteLine("Покупка: ");
            Console.WriteLine("Введите названия лекарств, их цену и необходимое количество: ");
            List<Medication<double,int>> medications = new List<Medication<double,int>>();

            while((!string.IsNullOrEmpty(CheckCharacters(medname = Console.ReadLine()))) && ((Double.TryParse(Console.ReadLine(), out price) && (Int32.TryParse(Console.ReadLine(), out count))) == true))
            {
                if((price > 0) && (count >= 0)) // Специально допускаю возможность указать количество товара нуль для вызова и обработки своего исключения
                    medications.Add(new Medication<double,int>(medname, price, count));
                else
                {
                    Console.WriteLine("Цена и количество должны быть только положительными! Попробуйте еще раз!");
                    while(((Double.TryParse(Console.ReadLine(), out price)) && (Int32.TryParse(Console.ReadLine(), out count))) == true)
                    {
                        if((price > 0) && (count >= 0))
                        {
                            medications.Add(new Medication<double,int>(medname, price, count));
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Цена и количество должны быть только положительными!");
                        }
                    }
                }
            }
            patient.BuyMedication(medications);

            Console.WriteLine($"\nФамилия: {doctor.LastName}\nИмя: {doctor.FirstName}\nОтчество: {doctor.MiddleName}\nВУЗ: {doctor.Education}\nМесто работы: {doctor.Company}\nДолжность: {doctor.Post}\n");
            Console.WriteLine($"Фамилия: {patient.LastName}\nИмя: {patient.FirstName}\nОтчество: {patient.MiddleName}\nВУЗ: {patient.Education}\nМесто работы: {patient.Company}\nДиагноз: {patient.GetDiagnose(doctor)}\n");

            Console.WriteLine("Рецепт врача: ");
            foreach(var item in patient.GetMedication(doctor))
            {
                Console.WriteLine($"Название лекарства: {item}");
            }

            Console.WriteLine();

            Console.WriteLine("Купленные лекарства: ");
            foreach(var item in patient.BuyMedication(medications))
            {
                price += Math.Round((item.Price * item.Count), 2);

                Console.WriteLine($"Название лекарства: {item.Name}");
                Console.WriteLine($"Цена: {item.Price}");
                Console.WriteLine($"Количество: {item.Count}");
            }

            try
            {
                Console.WriteLine($"Стоимость покупки: {price}");
                if(count == 0)
                {
                    throw new MyOwnException();  //кидаю свое исключение
                }
                average = Math.Round((price / count), 2);
                Console.WriteLine($"Средняя стоимость покупки: {average}");
            }
            catch (MyOwnException myex)          //ловлю и обрабатываю свое исключение
            {
                Console.WriteLine(myex.Message);
            }
            finally
            {
                Console.WriteLine("Расчет покупки завершен!");
            }
        }
    }
}