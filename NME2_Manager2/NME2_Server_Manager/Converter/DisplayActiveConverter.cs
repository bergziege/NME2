using System;
using System.Globalization;
using System.Windows.Data;

namespace NME2_Server_Manager.Converter {

    [ValueConversion(typeof(double), typeof(string))]
    class DisplayActiveConverter:IValueConverter {
        #region Implementation of IValueConverter

        private string _labelText = "Active: ";
        private string _yes = "Yes";
        private string _no = "No";

        /// <summary>
        /// Konvertiert einen Wert. 
        /// </summary>
        /// <returns>
        /// Ein konvertierter Wert.Wenn die Methode null zurückgibt, wird der gültige NULL-Wert verwendet.
        /// </returns>
        /// <param name="value">Der von der Bindungsquelle erzeugte Wert.</param>
        /// <param name="targetType">Der Typ der Bindungsziel-Eigenschaft.</param>
        /// <param name="parameter">Der zu verwendende Konverterparameter.</param>
        /// <param name="culture">Die im Konverter zu verwendende Kultur.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return _labelText + ((int)value == 1 ?_yes:_no);
        }

        /// <summary>
        /// Konvertiert einen Wert. 
        /// </summary>
        /// <returns>
        /// Ein konvertierter Wert.Wenn die Methode null zurückgibt, wird der gültige NULL-Wert verwendet.
        /// </returns>
        /// <param name="value">Der Wert, der vom Bindungsziel erzeugt wird.</param>
        /// <param name="targetType">Der Typ, in den konvertiert werden soll.</param>
        /// <param name="parameter">Der zu verwendende Konverterparameter.</param>
        /// <param name="culture">Die im Konverter zu verwendende Kultur.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            string sValue = (string)value;
            string yesNo = sValue.Remove(0, _labelText.Length);
            return yesNo == this._yes ? 1 : 0;
        }

        #endregion
    }
}
