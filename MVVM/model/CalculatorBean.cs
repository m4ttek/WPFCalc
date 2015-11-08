using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Wyznacza jak mają wyglądać możliwe operacje na kalkulatorze.
     */
    public delegate double CalcOperation(double first, double second);

    /**
     * Zawiera wspólne, użyteczne funkcje.
     * 
     * @author Mateusz Kamiński
     */
    public class CalculatorUtils {

	    public const long MAX_NUMBER_OF_DIGITS = 16;
	
	    /**
	     * Czy wyświetlacz posiada maksymalną liczbę cyfr.
	     * 
	     * @param result wyświetlany rezultat
	     * @return
	     */
	    public static bool hasMaxNumberOfDigits(String result) {
		    if (result != null) {
			    return result.Count(value => value >= '0' && value <= '9') >= MAX_NUMBER_OF_DIGITS;
		    }
		    return false;
	    }

	    /**
	     * Formatuje liczbę, aby pokazać ją na ekranie.
	     * 
	     * @param number
	     * @return
	     */
	    public static String formatNumber(double number) {
            return ("" + number).Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
	    }
	
    }

    /**
      * Bean reprezentujący wewnętrzny stan kalkulatora.
      * 
      * @author Mateusz Kamiński
      */
    public class CalculatorBean
    {
        /**
	      * Bufor na wprowadzane znaki.
	      */
        private StringBuilder buffer = null;
        public StringBuilder Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                buffer = value;
            }
        }

        private Double? firstNumber = null;
        public Double? FirstNumber
        {
            get
            {
                return firstNumber;
            }
            set
            {
                firstNumber = value;
            }
        }

        private Double? secondNumber = null;
        public Double? SecondNumber
        {
            get
            {
                return secondNumber;
            }
            set
            {
                secondNumber = value;
            }
        }

        private bool isBlocked;
        public bool IsBlocked
        {
            get
            {
                return isBlocked;
            }
            set
            {
                isBlocked = value;
            }
        }

        /**
         * Operacja do wykonania (wybrana przez użytkownika)
         */
        private CalcOperation operation = null;
        public CalcOperation Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
            }
        }
    }
}
