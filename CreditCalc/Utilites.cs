using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input.StylusPlugIns;
using Microsoft.VisualBasic;
namespace контрольная_2
{
    internal class Utilites
    { 
        public int[] completeMass(int lenght)//заполнение массива длиной lenght 
        {
            int[] str = new int[lenght];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Convert.ToInt32(Interaction.InputBox("Введите символ")); 
            }
            return str;
        }
        public double RightTriangl(double a,double b,double n)
        {
           
            double h = (b - a) / n;
            double x = a + h;
            double s = 0;
            for (int i = 1; i <= n; i++)
            {
                double f = Math.Pow(x, 3) + (-2) * Math.Pow(x, 2) + (5) * x + (16);
                s += f;
                x += h;
            }
            s *= h;
            return s;
        }

        public string RepeatingChar(string[] chars)//находит самый используемый символ в строке
        {
            
            var count = 0;//количесвто повторов
            var index = -1;//индекс в массиве
            for (var i = 0; i < chars.Length; ++i)
            {
                var k = 1;
                for (var j = i + 1; j < chars.Length; ++j)
                    if (chars[i] == chars[j]) k++;
                if (k <= count) continue;
                count = k;
                index = i;
            }
         
            return chars[index]; //возвращает самое повторяющиеся число 
        }
        public string[] DeleteChar( string[] Mass, string charDel)// удаляет символ с шагом через два
        {
            int k = 0;
            for (int i = 0; i < Mass.Length; i++)
            {
                if (charDel == Mass[i])
                {
                    k++;
                    if (k % 2 == 0)
                    {
                        Mass[i] = "";
                    }
                }

            }
            return Mass;
        }
        public string CharackterInTextBox(string[] str)//метод для вывода символов с массива в TextBox
        {
            string textBox = "";
            foreach (string item in str)
            {
                textBox += item+";";
            }
            return textBox;
        }
        public string[] ConvertToStr(int[] mass)
        {
            string[] str = new string[mass.Length];
            for(int i = 0; i < mass.Length; i++)
            {
                str[i] = Convert.ToString(mass[i]);
            }
            return str;
        }
        public int[] ReplacePowInt(int[] mass)
        {
            for(int i = 0; i < mass.Length; i++)
            {
                if (mass[i] % 2 == 0)
                {
                    mass[i] = mass[i] * mass[i];
                }
            }
            return mass;
        }
        public int midleNum(int[] mass)
        {
            int summ = 0;
            for (int i = 0; i < mass.Length; i++)
                summ += mass[i];
            int midleNum = summ / mass.Length;
            return midleNum;
        }
        public string RemoveMidle(int[] mass)
        { 
            string newNum = "";
            int midleeNum = midleNum(mass);
            for (int i = 0; i < mass.Length; i++)
            {
                
                if (mass[i] > midleeNum)
                {
                    newNum += mass[i]+";";
                }
            }
            return newNum;
        }
        public int[] ConvertToIntArray(string[] mass)
        {
            int [] result = new int[mass.Length];
            for (int i = 0; i < mass.Length;i++) 
            {
                result[i] = Convert.ToInt32(mass[i]);

            }   
             return result;
        }
       public string CompleteRandomStr(int size)
        {
            
            Random random = new Random();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789\n";
            string RandndomStr = "";
            for(int i = 0; i < size; i++)
            {
                RandndomStr = RandndomStr + str[random.Next(str.Length)];
                //if(i%10 == 0)
                //{
                //    RandndomStr += "\n";
                //}
            }
            return RandndomStr;
        }
    }
}
