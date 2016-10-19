using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace WS_Hotline.DTOLibrary.Entities.Version
{
    /// <summary>
    /// Classe de DTO pour les versions affected
    /// </summary>
    /// <remarks>JClaud 2015-03-11 Création</remarks>
    [DebuggerDisplay("ID AffectedVersion = {IdAffectedVersion} - ID Issue = {IdIssue} - ID Version = {IdVersion}")]
    [DataContract]
    public class VersionAffectedDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdAffectedVersion;
        /// <summary>
        /// Accesseur IdAffectedVersion
        /// </summary>
        [DataMember]
        public int IdAffectedVersion
        {
            get { return _IdAffectedVersion; }
            set { _IdAffectedVersion = value; }
        }

        private int _IdIssue;
        /// <summary>
        /// Accesseur IdIssue
        /// </summary>
        [DataMember]
        public int IdIssue
        {
            get { return _IdIssue; }
            set { _IdIssue = value; }
        }

        private int _IdVersion;
        /// <summary>
        /// Accesseur IdVersion
        /// </summary>
        [DataMember]
        public int IdVersion
        {
            get { return _IdVersion; }
            set { _IdVersion = value; }
        }

        private DateTime _Created;
        /// <summary>
        /// Accesseur Created
        /// </summary>
        [DataMember]
        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }

        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public VersionAffectedDTO()
        {

        }

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de créer une version en BDD</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationVersionAffectedDTO</para>
            /// </summary>
            CreateVersionAffectedData,
        }

        #endregion
    }
}
