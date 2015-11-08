using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Wylicza operację procent.
     * 
     * @author Mateusz Kamiński
     */
    public class PercentageCalulcation : Calculation {

        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if ("%".Equals(mnemonic)) {
			    Double? value = null;
			    if (calculatorBean.Buffer != null) {
				    value = Double.Parse(calculatorBean.Buffer.ToString());
				    calculatorBean.Buffer = null;
			    } else if (calculatorBean.FirstNumber != null) {
				    value = calculatorBean.FirstNumber.GetValueOrDefault(0);
			    }
			    if (value != null) {
				    value = value * 0.01;
                    log.Debug(value);
				    if (calculatorBean.Operation != null) {
                        calculatorBean.SecondNumber = value;
				    } else {
					    calculatorBean.FirstNumber = value;
				    }
                    log.InfoFormat("Percentage calculated: {0}.", value);
				    return CalculatorUtils.formatNumber(value.GetValueOrDefault(0));
			    }
			
		    }
		    return null;
	    }

    }
}
