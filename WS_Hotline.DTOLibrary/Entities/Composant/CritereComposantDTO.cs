using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.Composant
{
    /// <summary>
    /// Classe de critère sur la recherche des composants
    /// </summary>
    /// <remarks>JClaud 2015-07-27 - Création</remarks>
    [DebuggerDisplay("ID Composant = {IdComposant} - ID Projet = {IdProjet} - Nom Composant = {NomComposant}")]
    [DataContract]
    public class CritereComposantDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private int _IdComposant;
        /// <summary>
        /// Accesseur de l'identifiant du composant
        /// </summary>
        [DataMember]
        public int IdComposant
        {
            get { return _IdComposant; }
            set { _IdComposant = value; }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur de l'id du projet lié
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _NomComposant;
        /// <summary>
        /// Accesseur du nom du composant
        /// </summary>
        [DataMember]
        public string NomComposant
        {
            get { return _NomComposant; }
            set
            {
                _NomComposant = value;
            }
        }

        private string _DescrComposant;
        /// <summary>
        /// Accesseur de la description du composant
        /// </summary>
        [DataMember]
        public string DescrComposant
        {
            get { return _DescrComposant; }
            set { _DescrComposant = value; }
        }

        private int _OrdreComposant;
        /// <summary>
        /// Accesseur de l'ordre du composant
        /// </summary>
        [DataMember]
        public int OrdreComposant
        {
            get { return _OrdreComposant; }
            set { _OrdreComposant = value; }
        }

        private bool _IsComposantReadOnly;
        /// <summary>
        /// Accesseur du booléen de lecture seule
        /// </summary>
        [DataMember]
        public bool IsComposantReadOnly
        {
            get { return _IsComposantReadOnly; }
            set { _IsComposantReadOnly = value; }
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
