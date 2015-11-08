using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Specjalna operacja matematyczna - pierwiastek.
     * 
     * @author Mateusz Kamiński
     */
    public class SquareRootCalculation : Calculation {

        private static readonly log4net.ILog log =
                       log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if ("sqrt".Equals(mnemonic)) {
			    Double value;
			    if (calculatorBean.Buffer != null) {
                    value = Double.Parse(calculatorBean.Buffer.ToString());
				    calculatorBean.Buffer = null;
			    } else {
                    value = calculatorBean.FirstNumber.GetValueOrDefault(0);
			    }
			    value = Math.Sqrt(value);
			    if (Double.IsNaN(value) || Double.IsInfinity(value)) {
				    throw new CalculationException();
			    }
                log.InfoFormat("Square root calculated and copied to first number: {0}", value);
			    calculatorBean.FirstNumber = value;
			    return CalculatorUtils.formatNumber(value);
		    }
		    return null;
	    }

    }
}
