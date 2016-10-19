using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Cause
{
    //jc- classe de critère pour CritereDetailTypeDTO
    [DebuggerDisplay("ID DetailType = {IdDetailType} - Nom DetailType = {NomDetailType}")]
    [DataContract]
    public class CritereDetailTypeDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private int _IdDetailType;
        /// <summary>
        /// Accesseur de l'id du detail type
        /// </summary>
        [DataMember]
        public int IdDetailType
        {
            get { return _IdDetailType; }
            set { _IdDetailType = value; }
        }

        private string _NomDetailType;
        /// <summary>
        /// Accesseur du nom du detail type
        /// </summary>
        [DataMember]
        public string NomDetailType
        {
            get { return _NomDetailType; }
            set { _NomDetailType = value; }
        }

        #endregion
    }
}
