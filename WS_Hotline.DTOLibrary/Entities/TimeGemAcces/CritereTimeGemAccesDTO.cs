using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace DTOLibrary.Entities.TimeGemAcces
{
    /// <summary>
    /// Classe de critères pour les objects de type TimeGemAccesDTO
    /// </summary>
    /// <remarks>JClaud 2016-01-12 Création</remarks>
    [DebuggerDisplay("ID = {Id} - ID User = {Id_User} - Bouton Acces = {BoutonAcces}")]
    [DataContract]
    public class CritereTimeGemAccesDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private int _Id;
        /// <summary>
        /// Accesseur de l'id
        /// </summary>
        [DataMember]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Id_User;
        /// <summary>
        /// Accesseur de l'id de l'utilisateur
        /// </summary>
        [DataMember]
        public string Id_User
        {
            get { return _Id_User; }
            set { _Id_User = value; }
        }

        private string _TemplateExclusion;
        /// <summary>
        /// Accesseur du champ d'exclusion des templates
        /// </summary>
        [DataMember]
        public string TemplateExclusion
        {
            get { return _TemplateExclusion; }
            set { _TemplateExclusion = value; }
        }

        private int _BoutonAcces;
        /// <summary>
        /// Accesseur du champs d'accès au boutons
        /// </summary>
        [DataMember]
        public int BoutonAcces
        {
            get { return _BoutonAcces; }
            set { _BoutonAcces = value; }
        }

        #endregion
    }
}

