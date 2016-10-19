using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Entities.KeyWord.Methodes
{
    /// <summary>
    /// Classe de paramètre pour la création d'un mot clé
    /// </summary>
    /// <remarks>JClaud 2015-07-20 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Nom KeyWord = {KeyWord.NomKeyWord}")]
    [DataContract]
    public class ParamCreationKeyWordDTO : BaseDTO
    {
        #region ATTRIBUTS

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
        /// Accesseur du ticket
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        private KeyWordDTO _KeyWord;
        /// <summary>
        /// Accesseur du mot clé
        /// </summary>
        [DataMember]
        public KeyWordDTO KeyWord
        {
            get { return _KeyWord; }
            set { _KeyWord = value; }
        }

        #endregion
    }
}
