using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Commentaire.Methodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires pour les MAJ et création de commentaires
    /// </summary>
    /// <remarks>JClaud 2015-03-19 - Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket}")]
    [DataContract]
    public class ParamCommentaireDTO : BaseDTO
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

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du critère pour le ticket
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        private CommentaireDTO _Commentaire;
        /// <summary>
        /// Accesseur du critère pour le commentaire
        /// </summary>
        [DataMember]
        public CommentaireDTO Commentaire
        {
            get { return _Commentaire; }
            set { _Commentaire = value; }
        }

        #endregion
    }
}
