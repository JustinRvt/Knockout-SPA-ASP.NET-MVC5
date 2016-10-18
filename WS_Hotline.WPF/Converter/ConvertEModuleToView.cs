using WS_Hotline.DTOLibrary.Enum.Module;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WS_Hotline.WPF.Converter
{
    public class ConvertEModuleToView : IValueConverter
    {
        /// <summary>
        /// Modifies the source data before passing it to the target for display in the UI.
        /// </summary>
        /// <returns>
        /// The value to be passed to the target dependency property.
        /// </returns>
        /// <param name="pValue">The source data being passed to the target.</param>
        /// <param name="pTargetType">The <see cref="T:System.Type"/> of data expected by the target dependency property.</param>
        /// <param name="pArameter">An optional parameter to be used in the converter logic.</param><param name="pCulture">The culture of the conversion.</param>
        public object Convert(object pValue, Type pTargetType, object pArameter, CultureInfo pCulture)
        {
            // yl - Si le type est bien un Emodule
            if (pValue is EModule)
            {
                var lEModule = (EModule)pValue;
                // yl - Selon le module choisi on retourne la bonne interface
                switch (lEModule)
                {
                    case EModule.SelectionEcriture :
                        return new View.Ecriture.UCModuleSelectionEcriture();
                    case EModule.AddOrUpdateEcriture :
                        return new View.Ecriture.UCAddOrUpdateEcriture();
                }

            }

            return pValue;
        }

        /// <summary>
        /// Modifies the target data before passing it to the source object.  This method is called only in <see cref="F:System.Windows.Data.BindingMode.TwoWay"/> bindings.
        /// </summary>
        /// <returns>
        /// The value to be passed to the source object.
        /// </returns>
        /// <param name="pValue">The target data being passed to the source.</param><param name="pTargetType">The <see cref="T:System.Type"/> of data expected by the source object.</param><param name="pArameter">An optional parameter to be used in the converter logic.</param><param name="pCulture">The culture of the conversion.</param>
        public object ConvertBack(object pValue, Type pTargetType, object pArameter, CultureInfo pCulture)
        {
            throw new NotImplementedException();
        }
    }

}
