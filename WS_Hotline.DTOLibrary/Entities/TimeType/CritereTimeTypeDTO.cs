using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.TimeType
{
    //jc- classe de critères pour TimeTypeDTO
    [DebuggerDisplay("ID Time Type = {IdTimeType} - Nom Time Type = {NomTimeType} - Sequencement = {Seq}")]
    [DataContract]
    public class CritereTimeTypeDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private int _IdTimeType;
        /// <summary>
        /// Accesseur de l'identifiant de la résolution
        /// </summary>
        [DataMember]
        public int IdTimeType
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
