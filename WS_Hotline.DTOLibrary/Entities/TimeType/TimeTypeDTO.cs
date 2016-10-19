using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.TimeType
{
    [DebuggerDisplay("ID Time Type = {IdTimeType} - Nom Time Type = {NomTimeType} - Sequencement = {Seq}")]
    [DataContract]
    public class TimeTypeDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private decimal _IdTimeType;
        /// <summary>
        /// Accesseur de l'identifiant de la résolution
        /// </summary>
        [DataMember]
        public decimal IdTimeType
        {
            get { return _IdTimeType; }
            set { _IdTimeType = value; }
        }

        private string _NomTimeType;
        /// <summary>
        /// Accesseur du nom du type de temps
        /// </summary>
        [DataMember]
        public string NomTimeType
        {
            get { return _NomTimeType; }
            set { _NomTimeType = value; }
        }

        private string _DescriptionTimeType;

        /// <summary>
        /// Accesseur de la description
        /// </summary>
        [DataMember]
        public string DescriptionTimeType
        {
            get { return _DescriptionTimeType; }
            set
            {
                _DescriptionTimeType = value;
            }
        }

        private DateTime _DateCreationTimeType;
        /// <summary>
        /// Accesseur de la date de création du time type
        /// </summary>
        [DataMember]
        public DateTime DateCreationTimeType
        {
            get { return _DateCreationTimeType; }
            set { _DateCreationTimeType = value; }
        }

        private int _TemplateId;
        /// <summary>
        /// Accesseur du template lié au time type
        /// </summary>
        [DataMember]
        public int TemplateId
        {
            get { return _TemplateId; }
            set { _TemplateId = value; }
        }

        private int _Seq;
        /// <summary>
        /// Accesseur du sequencement des time type
        /// </summary>
        [DataMember]
        public int Seq
        {
            get { return _Seq; }
            set { _Seq = value; }
        }

        #endregion

        #region PUBLICS VARIABLES


        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public TimeTypeDTO()
        {

        }

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            GetAssocHorsTicket
        }

        #endregion
    }
}
