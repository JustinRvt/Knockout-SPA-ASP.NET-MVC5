using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace WS_Hotline.DTOLibrary.Entities.Version
{
    /// <summary>
    /// Classe de DTO pour les versions
    /// </summary>
    /// <remarks>JClaud 2015-03-11 Création</remarks>
    [DebuggerDisplay("ID Version = {IdVersion} - ID Projet = {IdProjet} - Nom de Version = {VersionName} - Numéro de version = {VersionNumber}")]
    [DataContract]
    public class VersionDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdVersion;
        /// <summary>
        /// Accesseur de l'id de la version
        /// </summary>
        [DataMember]
        public int IdVersion
        {
            get { return _IdVersion; }
            set { _IdVersion = value; }
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

        private string _VersionName;
        /// <summary>
        /// Accesseur VersionName
        /// </summary>
        [DataMember]
        public string VersionName
        {
            get { return _VersionName; }
            set { _VersionName = value; }
        }

        private string _VersionNumber;
        /// <summary>
        /// Accesseur VersionNumber
        /// </summary>
        [DataMember]
        public string VersionNumber
        {
            get { return _VersionNumber; }
            set { _VersionNumber = value; }
        }

        private string _VersionDescr;
        /// <summary>
        /// Accesseur VersionDescr
        /// </summary>
        [DataMember]
        public string VersionDescr
        {
            get { return _VersionDescr; }
            set { _VersionDescr = value; }
        }

        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public VersionDTO()
        {

        }

        #endregion
    }
}
