using WS_Hotline.Framework.Domain.Command;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Info
{
    /// <summary>
    /// Classe DTO permettant de gérer InfoSession
    /// </summary>
    /// <remark> ylouis - 24/09/2015 - généré par snippet v1.0 </remark>
    [DataContract]
    public class InfoSessionDTO : BaseDTO
    {
        private Entities.User.UserDTO _User;
        /// <summary>
        /// utilisateur
        /// </summary>
        /// <remarks>ylouis - 24/09/2015 générer par snippet V 1.0</remarks>
        [DataMember]
        public Entities.User.UserDTO User
        {
            get { return _User; }
            set
            {
                _User = value;
            }
        }

        private string _Culture = "fr-FR";
        /// <summary>
        /// Culture
        /// </summary>
        /// <remarks>ylouis - 24/09/2015 générer par snippet V 1.0</remarks>
        [DataMember]
        public string Culture
        {
            get { return _Culture; }
            set
            {
                _Culture = value;
            }
        }

        private Dictionary<String, object> _ParamsSession;
        /// <summary>
        /// Dictionnaire de données session
        /// </summary>
        /// <remarks>vmangel - 15/04/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public Dictionary<String, object> ParamsSession
        {
            get { return _ParamsSession; }
            set
            {
                _ParamsSession = value;
            }
        }
    }
}
