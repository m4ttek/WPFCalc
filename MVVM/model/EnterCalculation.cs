using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Obliczenie typu żądanie wyniku.
     * 
     * @author Mateusz Kamiński
     */
    public class EnterCalculation : Calculation {

        private static readonly log4net.ILog log =
                       log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if ("=".Equals(mnemonic)) {
			    // jeśli operacja i bufor jest dostępny to wartość przepisywana jest do drugiej liczby
			    if (calculatorBean.Operation != null && calculatorBean.Buffer != null) {
				    calculatorBean.SecondNumber = Double.Parse(calculatorBean.Buffer.ToString());
                    log.InfoFormat("Second number accepted: {0}", calculatorBean.SecondNumber);
			    }
			
			    // operacja zawsze czyści bufor
			    calculatorBean.Buffer = null;
			
			    // jeżeli dostępna jest operacja do wykonania, ale drugiej liczby nie ma, powtarzana jest pierwsza z liczb
			    if (calculatorBean.Operation != null && calculatorBean.SecondNumber == null) {
                    log.InfoFormat("First number copied to be second number : {0}", calculatorBean.FirstNumber);
                    calculatorBean.SecondNumber = calculatorBean.FirstNumber;
			    }
			
			    // jeżeli dwie liczby znajdują się w pamięci to wykonujemy na nich operację
			    if (calculatorBean.FirstNumber != null && calculatorBean.SecondNumber != null) {
				    Double result = calculatorBean.Operation(calculatorBean.FirstNumber.GetValueOrDefault(0),
                                                             calculatorBean.SecondNumber.GetValueOrDefault(0));
                    log.InfoFormat("Calucation result: {0}", result);
                    if (Double.IsInfinity(result) || Double.IsNaN(result)) {
                        CalculationException calculationException = new CalculationException();
                        log.Warn("Calcuation error!", calculationException);
                        throw calculationException;
				    }
                    log.InfoFormat("Result copied to first number: {0}", result);
				    calculatorBean.FirstNumber = result;
				    return CalculatorUtils.formatNumber(result);
			    }
		    }
		    return null;
	    }

    }
}
