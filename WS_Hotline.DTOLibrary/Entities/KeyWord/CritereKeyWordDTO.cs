using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace WS_Hotline.DTOLibrary.Entities.KeyWord
{
    //jc- classe de critère pour KeyWordDTO
    [DebuggerDisplay("ID KeyWord = {IdKeyWord} - Nom KeyWord = {NomKeyWord}")]
    [DataContract]
    public class CritereKeyWordDTO : CritereBaseDTO
    {
        #region ACCESSEURS

        private int _IdKeyWord;
        /// <summary>
        /// Accesseur de l'id du mot clé
        /// </summary>
        [DataMember]
        public int IdKeyWord
        {
            get { return _IdKeyWord; }
            set { _IdKeyWord = value; }
        }

        private string _NomKeyWord;
        /// <summary>
        /// Accesseur du nom du mot clé
        /// </summary>
        [DataMember]
        public string NomKeyWord
        {
            get { return _NomKeyWord; }
            set { _NomKeyWord = value; }
        }

        #endregion
    }
}
