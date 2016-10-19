using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.Commentaire
{
    //jc- Classe de critère pour CommentaireDTO
    [DataContract]
    public class CritereCommentaireDTO : CritereBaseDTO
    {
        [DebuggerDisplay("ID Commentaire = {IdCommentaire} - ID Ticket = {TicketId} - ID User = {UserId} - User Name = {UserName}")]
        #region PROPERTIES

        private int _IdCommentaire;
        /// <summary>
        /// Accesseur de l'identifiant du commentaire
        /// </summary>
        [DataMember]
        public int IdCommentaire
        {
            get { return _IdCommentaire; }
            set { _IdCommentaire = value; }
        }

        private int _TicketId;
        /// <summary>
        /// Accesseur de l'id du ticket
        /// </summary>
        [DataMember]
        public int TicketId
        {
            get { return _TicketId; }
            set { _TicketId = value; }
        }

        private int _UserId;
        /// <summary>
        /// Accesseur de l'id de l'utilisateur
        /// </summary>
        [DataMember]
        public int UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
            }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur du IdProjet
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _Commentaire;
        /// <summary>
        /// Accesseur du commentaire du ticket
        /// </summary>
        [DataMember]
        public string Commentaire
        {
            get { return _Commentaire; }
            set { _Commentaire = value; }
        }

        private string _UserName;
        /// <summary>
        /// Accesseur du nom du créateur
        /// </summary>
        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private bool _IsClosing;
        /// <summary>
        /// Accesseur du booléen de fermeture
        /// </summary>
        [DataMember]
        public bool IsClosing
        {
            get { return _IsClosing; }
            set { _IsClosing = value; }
        }

        private int _Visibilitée;
        /// <summary>
        /// Accesseur de la visibilitée
        /// </summary>
        [DataMember]
        public int Visibilitée
        {
            get { return _Visibilitée; }
            set { _Visibilitée = value; }
        }

        private DateTime _DateCreation;
        /// <summary>
        /// Accesseur de la date de création du ticket
        /// </summary>
        [DataMember]
        public DateTime DateCreation
        {
            get { return _DateCreation; }
            set { _DateCreation = value; }
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
