using WS_Hotline.DataAccessLayer.Entities.Softlog;
using WS_Hotline.DTOLibrary.Entities.Softlog;
using WS_Hotline.DTOLibrary.Exception.SoftlogException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DomainLibrary.Metier.Softlog
{
    /// <summary>
    /// Classe metier de Softlog
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    public class SoftlogMetier : BaseMetier<SoftlogDAL, SoftlogDTO, CritereSoftlogDTO,SoftlogException>
    {

		#region Validation

        /// <summary>
        /// Validation de la Softlog
        /// </summary>
        /// <param name="pEntity">Entité a valider</param>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        public override void ValidatedDTO(Framework.AccesDonnees.IBaseDTO pEntity)
        {
            try
            {
                base.ValidatedDTO(pEntity);
            }
            catch(Exception ex)
            {
                throw new SoftlogException(ex);
            }
        }

        #endregion

    }
}
		