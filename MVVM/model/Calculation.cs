using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Interfejs dla operacji kalkulacyjnych.
 * 
 * @author Mateusz Kamiński
 */
namespace Calc.model
{
    /**
     * Klasa służąca identyfikująca problem przy obliczeniach 
     */
    public class CalculationException : SystemException
    {
    }

    interface Calculation
    {
        /**
	      * Przeprowadza operację na stanie kalkulatora.
	      * 
	      * @param calculatorBean przechowuje stan pamięci kalkulatora
	      * @param mnemonic input z kalkulatora
	      * @return co wyświetlić na wyświetlaczu, jeżeli nie dotyczy to null
          * @throws CalculationException jeśli błąd podczas obliczeń
	      */
	    String calculate(CalculatorBean calculatorBean, String mnemonic);
    }
}
