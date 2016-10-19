using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Cause
{
    //jc- classe de critère pour CauseDTO
    [DebuggerDisplay("ID Cause = {IdCause} - Nom Cause = {NomCause} - Service Cause = {ServiceCause}")]
    [DataContract]
    public class CritereCauseDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private int _IdCause;
        /// <summary>
        /// Accesseur de l'id de la cause
        /// </summary>
        [DataMember]
        public int IdCause
        {
            get { return _IdCause; }
            set { _IdCause = value; }
        }

        private string _NomCause;
        /// <summary>
        /// Accesseur du nom de la cause
        /// </summary>
        [DataMember]
        public string NomCause
        {
            get { return _NomCause; }
            set { _NomCause = value; }
        }

        private string _ServiceCause;
        /// <summary>
        /// Accesseur du service concerné par la cause
        /// </summary>
        [DataMember]
        public string ServiceCause
        {
            get { return _ServiceCause; }
            set { _ServiceCause = value; }
        }

        #endregion
    }
}
