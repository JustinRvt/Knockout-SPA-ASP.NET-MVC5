using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Statut
{
    /// <summary>
    /// Classe de critères sur la recherche des statuts
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("IsStatutFinal = {IsStatutFinal} - ValidStatuts = {ValidStatuts} - InvalidStatuts = {InvalidStatuts}")]
    [DataContract]
    public class CritereStatutDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private bool? _IsStatutFinal;
        /// <summary>
        /// Accesseur du bool qui indique si on est sur un statut final ou non
        /// </summary>
        [DataMember]
        public bool? IsStatutFinal
        {
            get { return _IsStatutFinal; }
            set { _IsStatutFinal = value; }
        }

        private List<int> _ValidStatuts = new List<int>();
        /// <summary>
        /// Accesseur de la liste des statuts valides
        /// </summary>
        [DataMember]
        public List<int> ValidStatuts
        {
            get { return _ValidStatuts; }
            set { _ValidStatuts = value; }
        }

        private List<int> _InvalidStatuts = new List<int>();
        /// <summary>
        /// Accesseur de al liste des statuts non valides
        /// </summary>
        [DataMember]
        public List<int> InvalidStatuts
        {
            get { return _InvalidStatuts; }
            set { _InvalidStatuts = value; }
        }

        private List<int> _BloquedStatuts = new List<int>();
        /// <summary>
        /// Accesseur de la liste des statuts bloqués
        /// </summary>
        [DataMember]
        public List<int> BloquedStatuts
        {
            get { return _BloquedStatuts; }
            set { _BloquedStatuts = value; }
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

        private List<int> _InValidQuestion = new List<int>();
        /// <summary>
        /// Accesseur des question valide
        /// </summary>
        [DataMember]
        public List<int> InValidQuestion
        {
            get { return _InValidQuestion; }
            set { _InValidQuestion = value; }
        }

        private List<int> _ValidQuestion = new List<int>();
        /// <summary>
        /// Accesseur des question valide
        /// </summary>
        [DataMember]
        public List<int> ValidQuestion
        {
            get { return _ValidQuestion; }
            set { _ValidQuestion = value; }
        }

        #endregion
    }
}
