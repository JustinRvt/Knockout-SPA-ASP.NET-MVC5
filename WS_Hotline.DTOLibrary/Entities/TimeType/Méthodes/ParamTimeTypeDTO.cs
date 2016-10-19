using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.TimeType.Méthodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires pour les MAJ et création de time type
    /// </summary>
    /// <remarks>JClaud 2015-03-19 - Création</remarks>
    [DebuggerDisplay("User = {User.Login} - Statut Critere Ticket = {CriteteTicket.CritereStatut} - Nom CritereTimeType = {CriteteTimeType.NomTimeType}")]
    [DataContract]
    public class ParamTimeTypeDTO : BaseDTO
    {
        #region PROPERTIES

        private AuthentificationDTO _User;
        /// <summary>
        /// Accesseur de l'utilisateur
        /// </summary>
        [DataMember]
        public AuthentificationDTO User
        {
            get { return _User; }
            set { _User = value; }
        }

        private CritereTicketDTO _CriteteTicket;
        /// <summary>
        /// Accesseur du critère pour le ticket
        /// </summary>
        [DataMember]
        public CritereTicketDTO CriteteTicket
        {
            get { return _CriteteTicket; }
            set { _CriteteTicket = value; }
        }

        private CritereTimeTypeDTO _CriteteTimeType;
        /// <summary>
        /// Accesseur du critère pour le time type
        /// </summary>
        [DataMember]
        public CritereTimeTypeDTO CriteteTimeType
        {
            get { return _CriteteTimeType; }
            set { _CriteteTimeType = value; }
        }

        #endregion

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {

        }
    }
}
