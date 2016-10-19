using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.Groupe
{
    //jc- classe de critère pour GroupeDTO
    [DebuggerDisplay("ID Groupe = {IdGroupe} - Nom Groupe = {GroupeNom} - User = {User.Login} - ID Ticket = {Ticket.IdTicket}")]
    [DataContract]
    public class CritereGroupeDTO : CritereBaseDTO
    {
        #region ATTRIBUTS

        private int _IdGroupe;
        /// <summary>
        /// Accesseur de l'identifiant du groupe
        /// </summary>
        [DataMember]
        public int IdGroupe
        {
            get { return _IdGroupe; }
            set { _IdGroupe = value; }
        }

        private string _GroupeNom;
        /// <summary>
        /// Accesseur du nom du groupe
        /// </summary>
        [DataMember]
        public string GroupeNom
        {
            get { return _GroupeNom; }
            set { _GroupeNom = value; }
        }

        private string _GroupeDescription;
        /// <summary>
        /// Accesseur de la description du groupe
        /// </summary>
        [DataMember]
        public string GroupeDescription
        {
            get { return _GroupeDescription; }
            set { _GroupeDescription = value; }
        }

        private DateTime _GroupeDateCreation;
        /// <summary>
        /// Accesseur de la date de création du groupe
        /// </summary>
        [DataMember]
        public DateTime GroupeDateCreation
        {
            get { return _GroupeDateCreation; }
            set { _GroupeDateCreation = value; }
        }

        private List<int> _GroupeInteractions;
        /// <summary>
        /// Accesseur des intéractions du groupe
        /// </summary>
        [DataMember]
        public List<int> GroupeInteractions
        {
            get { return _GroupeInteractions; }
            set { _GroupeInteractions = value; }
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

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du ticket en cours
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        #endregion
    }
}
