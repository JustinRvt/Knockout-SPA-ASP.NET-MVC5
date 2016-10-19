using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.CustomField
{
    /// <summary>
    /// Classe permettant la gestion des customFields data
    /// </summary>
    /// <remarks>JClaud 2015-01-10 Création</remarks>
    [DebuggerDisplay("ID CustomFieldData = {IdCustomFieldData} - ID CustomField = {IdCustomField} - ID User = {UserId} - ID Ticket = {IdTicket}")]
    [DataContract]
    public class CustomFieldDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdCustomFieldData;
        /// <summary>
        /// Accesseur de l'identifiant du customField
        /// </summary>
        [DataMember]
        public int IdCustomFieldData
        {
            get { return _IdCustomFieldData; }
            set { _IdCustomFieldData = value; }
        }

        private int _IdCustomField;
        /// <summary>
        /// Accesseur de l'id du type de customField
        /// </summary>
        [DataMember]
        public int IdCustomField
        {
            get { return _IdCustomField; }
            set { _IdCustomField = value; }
        }

        private int _UserId;
        /// <summary>
        /// Accesseur de l'id de l'utilisateur lié à ce champs
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

        private int _IdProject;
        /// <summary>
        /// Accesseur de l'id du projet concerné par ce champs
        /// </summary>
        [DataMember]
        public int IdProject
        {
            get { return _IdProject; }
            set { _IdProject = value; }
        }

        private int _IdTicket;
        /// <summary>
        /// Accesseur de l'id du ticket conerné par ce champs
        /// </summary>
        [DataMember]
        public int IdTicket
        {
            get { return _IdTicket; }
            set { _IdTicket = value; }
        }

        private string _FieldData;
        /// <summary>
        /// Accesseur de la valeur du champs
        /// </summary>
        [DataMember]
        public string FieldData
        {
            get { return _FieldData; }
            set { _FieldData = value; }
        }

        private DateTime _DateCreation;
        /// <summary>
        /// Accesseur de la date de création
        /// </summary>
        [DataMember]
        public DateTime DateCreation
        {
            get { return _DateCreation; }
            set { _DateCreation = value; }
        }

        private byte[] _FileData;
        /// <summary>
        /// Accesseur du champs de données de type fichier
        /// </summary>
        [DataMember]
        public byte[] FileData
        {
            get { return _FileData; }
            set { _FileData = value; }
        }

        private decimal? _NumericData;
        /// <summary>
        /// Accesseur du champs de données de type numéric
        /// </summary>
        [DataMember]
        public decimal? NumericData
        {
            get { return _NumericData; }
            set { _NumericData = value; }
        }

        private DateTime? _DateData;
        /// <summary>
        /// Accesseur du champs de données de type date
        /// </summary>
        [DataMember]
        public DateTime? DateData
        {
            get { return _DateData; }
            set { _DateData = value; }
        }

        #endregion

        #region PUBLICS VARIABLES
        
        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>JClaud 2015-01-10 - Création</remarks>
        public CustomFieldDTO()
        {

        }

        #endregion

        #region METHODES / FONCTIONS

        #region VALIDATION DTO

        /// <summary>
        /// Méthode permettant de valider le DTO
        /// Si il y a une erreur, une exception est levée
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-02-18 - Création</remarks>
        public override void ValidationDTO()
        {
            //gb - Appel les méthodes de validation des DTO
            base.ValidationDTO();
        }

        #endregion

        #endregion
    }
}
