using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Przeprowadza operację wyczyszczenia wyniku.
     * 
     * @author Mateusz Kamiński
     */
    public class ClearCalculation : Calculation {

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if ("C".Equals(mnemonic)) {
			    calculatorBean.IsBlocked = false;
			    calculatorBean.Buffer = null;
			    calculatorBean.FirstNumber = null;
			    calculatorBean.SecondNumber = null;
			    calculatorBean.Operation = null;
			    return "0";
		    }
		    return null;
	    }

    }
}
