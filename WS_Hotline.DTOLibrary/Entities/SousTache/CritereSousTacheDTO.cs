using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.SousTache
{

    [DebuggerDisplay("ID Tache Hors Ticket = {IdTacheHorsTicket} - ID Composant = {ComposantId}")]
    //tbh- classe de critères pour SousTacheDTO
    public class CritereSousTacheDTO : CritereBaseDTO
    {
        private int _IdTacheHorsTicket;
        /// <summary>
        /// Accesseur de l'id de la tache Hors Ticket
        /// </summary>
        [DataMember]
        public int IdTacheHorsTicket
        {
            get { return _IdTacheHorsTicket; }
            set { _IdTacheHorsTicket = value; }
        }

        private int? _ComposantId;
        /// <summary>
        /// Accesseur de l'id du composant
        /// </summary>
        [DataMember]
        public int? ComposantId
        {
            get { return _ComposantId; }
            set { _ComposantId = value; }
        }

        private string _ComposantDescription;
        /// <summary>
        /// Accesseur de la description du composant
        /// </summary>
        [DataMember]
        public string ComposantDescription
        {
            get { return _ComposantDescription; }
            set { _ComposantDescription = value; }
        }

        private decimal? _TimeTypeId;
        /// <summary>
        /// Accesseur de l'id du composant
        /// </summary>
        [DataMember]
        public decimal? TimeTypeId
        {
            get { return _TimeTypeId; }
            set { _TimeTypeId = value; }
        }

        private string _TimeTypeDescription;
        /// <summary>
        /// Accesseur de la description du composant
        /// </summary>
        [DataMember]
        public string TimeTypeDescription
        {
            get { return _TimeTypeDescription; }
            set { _TimeTypeDescription = value; }
        }
    }
}
