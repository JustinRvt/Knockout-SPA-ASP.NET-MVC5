using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.Projet
{
    /// <summary>
    /// Classe de critère sur la recherche des projets
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("ID Projet = {IdProjet} - Libelle Projet = {LibelleProjet} - User = {User.Login}")]
    [DataContract]
    public class CritereProjetDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private List<int> _ValidProject = new List<int>();
        /// <summary>
        /// Accesseur de la liste des projets autorisés
        /// </summary>
        [DataMember]
        public List<int> ValidProject
        {
            get { return _ValidProject; }
            set { _ValidProject = value; }
        }

        private List<int> _InvalidProject = new List<int>();
        /// <summary>
        /// Accesseur de la liste des projets non autorisés
        /// </summary>
        [DataMember]
        public List<int> InvalidProject
        {
            get { return _InvalidProject; }
            set { _InvalidProject = value; }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur de l'id du projet
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _LibelleProjet;
        /// <summary>
        /// Accesseur du nom du projet
        /// </summary>
        [DataMember]
        public string LibelleProjet
        {
            get { return _LibelleProjet; }
            set { _LibelleProjet = value; }
        }

        private string _CodeProjet;
        /// <summary>
        /// Accesseur du code projet
        /// </summary>
        [DataMember]
        public string CodeProjet
        {
            get { return _CodeProjet; }
            set { _CodeProjet = value; }
        }

        private string _DescrProjet;
        /// <summary>
        /// Accesseur de la description du projet
        /// </summary>
        [DataMember]
        public string DescrProjet
        {
            get { return _DescrProjet; }
            set { _DescrProjet = value; }
        }

        private int _TemplateId;
        /// <summary>
        /// Accesseur de l'id du template
        /// </summary>
        [DataMember]
        public int TemplateId
        {
            get { return _TemplateId; }
            set { _TemplateId = value; }
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

        private bool _IsVue;
        /// <summary>
        /// Accesseur de l'indicateur de vue projet
        /// </summary>
        [DataMember]
        public bool IsVue
        {
            get { return _IsVue; }
            set { _IsVue = value; }
        }

        #endregion
    }
}
