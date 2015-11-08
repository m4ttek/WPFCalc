using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
      * Obliczenie typu zmiana znaku.
      * 
      * @author Mateusz Kamiński
      */
    public class ChangeSingCalculation : Calculation {

        private static readonly log4net.ILog log =
                       log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if (!"+/-".Equals(mnemonic)) {
			    return null;
		    }
		    // jeżeli bufor jest dostępny to zmieniamy w nim pierwszy znak
		    if (calculatorBean.Buffer != null) {
                if (calculatorBean.Buffer[0] == '-')
                {
                    calculatorBean.Buffer.Remove(0, 1);
			    } 
                else 
                {
                    calculatorBean.Buffer.Insert(0, '-');
			    }
                log.InfoFormat("Sign changed!");
                return calculatorBean.Buffer.ToString();
			
			    // jeżeli w pamięci istnieje już jakaś liczba to zmieniamy jej znak
		    } else if (calculatorBean.FirstNumber != null) {
                Double value = calculatorBean.FirstNumber.GetValueOrDefault(0);
			    if (Double.IsInfinity(value) || Double.IsNaN(value)) {
				    throw new CalculationException();
			    }
			    calculatorBean.FirstNumber = -value;
                
			    return CalculatorUtils.formatNumber(-value);
		    }
 		    return null;
	    }

    }
}
