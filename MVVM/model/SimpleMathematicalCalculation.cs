using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Przeprowadza matematyczną kalkulację.
     *  
     * @author Mateusz Kamiński
     */
    public class SimpleMathematicalCalculation : Calculation {

        private static readonly log4net.ILog log =
                       log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    public static Dictionary<String, CalcOperation> MATH_OPERATIONS = new Dictionary<String, CalcOperation>() {
            { "+", (t, u) => t + u },
            { "-", (t, u) => t - u },
            { "/", (t, u) => t / u },
            { "*", (t, u) => t * u }
        };

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if (MATH_OPERATIONS.ContainsKey(mnemonic)) {
			    Double? newValue = null;
			    if (calculatorBean.Buffer != null) {
				    newValue = Double.Parse(calculatorBean.Buffer.ToString());
				    if (calculatorBean.FirstNumber != null) {
                        log.InfoFormat("Accepted the second number to calculate: {0}", newValue);
                        calculatorBean.SecondNumber = newValue;
				    } else {
                        log.InfoFormat("Accepted the first number to calculate: {0}", newValue);
					    calculatorBean.FirstNumber = newValue;
				    }
				    calculatorBean.Buffer = null;
			    }
			    if (calculatorBean.Operation != null && calculatorBean.SecondNumber != null) {
				    newValue = calculatorBean.Operation(calculatorBean.FirstNumber.GetValueOrDefault(0),
						                                calculatorBean.SecondNumber.GetValueOrDefault(0));
                    log.InfoFormat("Calucation result: {0}", newValue);
                    if (Double.IsInfinity(newValue.GetValueOrDefault(0)) || Double.IsNaN(newValue.GetValueOrDefault(0))) {
                        CalculationException calculationException = new CalculationException();
                        log.Warn("Calcuation error!", calculationException);
                        throw calculationException;
				    }
				    calculatorBean.FirstNumber = newValue;
                    calculatorBean.SecondNumber = null;
			    }
                if (MATH_OPERATIONS.ContainsKey(mnemonic))
                {
                    log.InfoFormat("Accepted the operation to calculate: {0}", mnemonic);
			        calculatorBean.Operation = MATH_OPERATIONS[mnemonic];
                }
			    if (newValue != null) {
				    return CalculatorUtils.formatNumber(newValue.GetValueOrDefault(0));
			    }
		    }
		    return null;
	    }

    }
}
