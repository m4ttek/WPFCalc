using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.model
{
    /**
     * Zwykłe zachowanie polegające na dodawaniu znaków
     * 
     * @author Mateusz Kamiński
     */
    public class DefaultCalculation : Calculation {
	
	    public static String SIGNS = "01234567890.";

	    public String calculate(CalculatorBean calculatorBean, String mnemonic) {
		    if (!SIGNS.Contains(mnemonic)) {
			    return null;
		    }
		    StringBuilder buffer;
		    if (calculatorBean.Buffer != null) {
                buffer = calculatorBean.Buffer;
		    } else {
			    buffer = new StringBuilder();
			    calculatorBean.Buffer = buffer;
			    if (calculatorBean.FirstNumber != null && calculatorBean.Operation == null) {
                    calculatorBean.FirstNumber = null;
			    }
		    }
		    if (!CalculatorUtils.hasMaxNumberOfDigits(buffer.ToString())) {
			    if (".".Equals(mnemonic) && buffer.Length == 0) 
                {
                    buffer.Append("0").Append(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                }     
                else if ("0".Equals(buffer.ToString()) && !".".Equals(mnemonic))
                {
                    calculatorBean.Buffer = buffer = new StringBuilder(mnemonic);
                }
                else if (!(".".Equals(mnemonic) && buffer.ToString()
                                    .Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)))
                {
                    if (".".Equals(mnemonic))
                    {
                        buffer.Append(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                    }
                    else
                    {
                        buffer.Append(mnemonic);
                    }
			    }
		    }
		    return buffer.ToString();
	    }

    }
}
