using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.TicketLien
{
    [DebuggerDisplay("ID Ticket = {TicketId} - ID SecondTicket = {SecondTicketId} - User = {User.Login}")]
    [DataContract]
    public class CritereTicketLienDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private int _IdTicketLien;
        /// <summary>
        /// Accesseur de l'identifiant du lien
        /// </summary>
        [DataMember]
        public int IdTicketLien
        {
            get { return _IdTicketLien; }
            set { _IdTicketLien = value; }
        }

        private int _TypeLienId;
        /// <summary>
        /// Accesseur de l'id du type de lien
        /// </summary>
        [DataMember]
        public int TypeLienId
        {
            get { return _TypeLienId; }
            set { _TypeLienId = value; }
        }

        private int _TicketId;
        /// <summary>
        /// Accesseur de l'id du ticket
        /// </summary>
        [DataMember]
        public int TicketId
        {
            get { return _TicketId; }
            set
            {
                _TicketId = value;
            }
        }

        private int _SecondTicketId;
        /// <summary>
        /// Accesseur de l'id du second ticket
        /// </summary>
        [DataMember]
        public int SecondTicketId
        {
            get { return _SecondTicketId; }
            set
            {
                _SecondTicketId = value;
            }
        }

        private string _LienDirection;
        /// <summary>
        /// Accesseur de la direction du lien
        /// </summary>
        [DataMember]
        public string LienDirection
        {
            get { return _LienDirection; }
            set { _LienDirection = value; }
        }

        private DateTime _Creation;
        /// <summary>
        /// Accesseur de la date de création du lien
        /// </summary>
        [DataMember]
        public DateTime Creation
        {
            get { return _Creation; }
            set { _Creation = value; }
        }

        private AuthentificationDTO _User;
        /// <summary>
        /// Accesseur de l'utilisateur en cours
        /// </summary>
        [DataMember]
        public AuthentificationDTO User
        {
            get { return _User; }
            set { _User = value; }
        }

        #endregion
    }
}
