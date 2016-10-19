using WS_Hotline.DTOLibrary.Entities.Authentification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Ticket.Methodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires
    /// pour mettre à jour les informations générales d'un ticket
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID CriteteTicket = {CriteteTicket.IdTicket} - % Avancement = {Avancement}")]
    [DataContract]
    public class ParamUpdateAvancementDTO : BaseDTO
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

        private int _Avancement;
        /// <summary>
        /// Accesseur de l'avancement du ticket
        /// </summary>
        [DataMember]
        public int Avancement
        {
            get { return _Avancement; }
            set { _Avancement = value; }
        }

        #endregion

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de retourner la liste des statuts pour un ticket</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamUpdateTicketDTO</para>
            /// </summary>
            GetListeStatut
        }
    }

    /// <summary>
    /// Classe contenant les paramètres nécessaires
    /// pour mettre à jour les informations générales d'un ticket
    /// </summary>
    /// <remarks>JClaud - 2015-09-21 - Création</remarks>
    [DataContract]
    public class ParamUpdateTicketDTO : BaseDTO
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

        #endregion
    }
}
