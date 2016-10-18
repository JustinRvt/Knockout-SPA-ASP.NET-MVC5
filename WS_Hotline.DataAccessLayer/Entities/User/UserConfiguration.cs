using WS_Hotline.DTOLibrary.Entities.User;
using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DataAccessLayer.Entities.User
{
    /// <summary>
    /// Classe de configuration de UserDTO
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    public class UserConfiguration : EntityTypeConfiguration<UserDTO>, IEntityConfiguration
    {
        #region METHODS

        /// <summary>
        /// Méthode permettant d'ajouter le registre de configuration
        /// </summary>
        /// <param name="pRegistrar">Registre de configuration à ajouter</param>
        /// <remarks>ylouis - 11/07/2016 - Création</remarks>
        public void Add(ConfigurationRegistrar pRegistrar)
        {
            pRegistrar.Add(this);
        }

        #endregion
    }
}

		