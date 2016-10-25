using WS_Hotline.DataAccessLayer.Entities.User;
using WS_Hotline.DTOLibrary.Entities.User;
using WS_Hotline.DTOLibrary.Exception.UserException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Hotline.DTOLibrary.Info;
using WS_Hotline.Framework.AccesDonnees;
using WS_Hotline.DomainLibrary.ServiceTimeGem;

namespace WS_Hotline.DomainLibrary.Metier.User
{
    /// <summary>
    /// Classe metier de User
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    public class UserMetier : BaseMetier<UserDAL, UserDTO, CritereUserDTO,UserException>
    {

    public override IBaseDTO GetItem(InfoSessionDTO pInfoSession, IBaseDTO pCritere)
    {
      var lProvider = new Provider.TimeGemProvider();

      var lCurrentAuth = new AuthentificationDTO() { Login = "", Password = "", Proxy = "", Url = "" };

      var lTemp = lProvider.ExecuteFunction<AuthentificationDTO, string>(lCurrentAuth, new MethodDTO()
      {
        NomMethode = "GetUtilisateurGemini",
        Parametrage = lCurrentAuth
      });

     

      return new UserDTO();
    }

    #region Validation

    /// <summary>
    /// Validation de la User
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
                throw new UserException(ex);
            }
        }

        #endregion

    }
}
		