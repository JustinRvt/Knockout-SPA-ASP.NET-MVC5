using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.CodeAffaire
{
    [DebuggerDisplay("Code = {Code} - Is Valid = {IsValid} - Type Affaire = {TypeAffaire}")]
    [DataContract]
    public class CodeAffaireDTO : BaseDTO
    {
        #region ATTRIBUTS / ACCESSEURS

        private string _Code;
        /// <summary>
        /// Accesseur du code affaire
        /// </summary>
        [DataMember]
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _FullCode;
        /// <summary>
        /// Accesseur du code affaire long
        /// </summary>
        [DataMember]
        public string FullCode
        {
            get { return _FullCode; }
            set { _FullCode = value; }
        }

        private bool _IsValid;
        /// <summary>
        /// Accesseur du isValid
        /// </summary>
        [DataMember]
        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }

        private string _Type;
        /// <summary>
        /// Accesseur du type d'affaire
        /// </summary>
        [DataMember]
        public string TypeAffaire
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private string _Legende;
        /// <summary>
        /// Accesseur de la legende
        /// </summary>
        [DataMember]
        public string Legende
        {
            get { return _Legende; }
            set { _Legende = value; }
        }
        #endregion
    }
}
