//////////////////////////////////////////////////////////////////
// Jasper Jung
// TINFO-200C
// L1mpg - First Lab Assignment
// This program takes in user input on their weight in pounds, heigh in inches, 
// and then calculate their BMI. Information from the Department of Health and Human 
// services are also shown to help the user determine what their bmi means
// body mass index. 
/////////////////////////////////////////////////////////////////
// Change History
// Date     Developer       Description of Change
// 1/20/2022  Jasper Jung     File and Project created - implementation and testing
// 1/20/2022  Jasper Jung     Added brief description

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// BodyMass namespace holds the solutions project for the BMI calculations
namespace BodyMass
{
    // main class that holds the BodyMass program
    internal class Program
    {
        
        // main driver of the program that asks the user what to input
        static void Main(string[] args)
        {
            Introduction();
            Console.WriteLine("Enter your weight in pounds (eg. 130, 140): ");
            int weightPounds = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your height in inches (eg. 50, 65): ");
            int heightInches = int.Parse(Console.ReadLine());
            Console.WriteLine("Your current BMI is: " + BMICalculator(weightPounds, heightInches));
            BMIStats();
        }

        // tells the user what the program does
        protected static void Introduction()
        {
            Console.WriteLine(@"
This program takes in your weight in pounds and height in inches. This information is then used 
to calucluate your bmi. Using your BMI number, you can then compare it to information from the 
Department of Health and Human Services/National Institutes of Health to see where your health 
is at. ");
        }
       
        // this method calculates the user's BMI from their inputted weight and height
        protected static int BMICalculator(int weightPounds, int heightInches)
        {
            // BMI variable
            int userBMI;
            // equation to calculate the bmi of the user
            userBMI = (weightPounds * 703) / (heightInches * heightInches);
            // return the BMI value
            return userBMI;
        }
        // this method resents information on BMI from the Department of health https://www.nhlbi.nih.gov/health/educational/lose_wt/BMI/bmicalc.htm
        protected static void BMIStats()
        {
            Console.WriteLine(@"
-------------------------------------------
*               BMI Values                *
*   Underweight:  less than 18.5          *
*   Normal:       between 18.5 and 24.9   *
*   Overweight:   between 25 and 29.9     *
*   Obese:        30 or greater           *
-------------------------------------------");
        }
  
    }
}   
