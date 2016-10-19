using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Projet
{
    /// <summary>
    /// Classe permettant la gsetion des projets
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("ID Projet = {IdProjet} - Libelle Projet = {LibelleProjet} - Code Projet = {CodeProjet}")]
    [DataContract]
    public class ProjetDTO : BaseDTO
    {
        #region PROPERTIES

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

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de relier un ticket à un projet en BDD</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationProjetDTO</para>
            /// </summary>
            CreateProjetData,
        }

        #endregion
    }
}
