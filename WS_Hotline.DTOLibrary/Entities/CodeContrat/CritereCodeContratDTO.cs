using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary;

namespace WS_Hotline.DTOLibrary.Entities.CodeContrat
{
    public class CritereCodeContratDTO : CritereBaseDTO
    {
        [DebuggerDisplay("Code Contrat = {Code} - Code Affaire = {CodeAffaire} - Code Client = {CodeClient} - Type Contrat = {TypeContrat}")]
        #region ATTRIBUTS / ACCESSEURS
        private string _Code;
        /// <summary>
        /// Accesseur du code contrat
        /// </summary>
        [DataMember]
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _CodeAffaire;
        /// <summary>
        /// Accesseur du code contrat
        /// </summary>
        [DataMember]
        public string CodeAffaire
        {
            get { return _CodeAffaire; }
            set { _CodeAffaire = value; }
        }

        private string _CodeClient;
        /// <summary>
        /// Accesseur du code client
        /// </summary>
        [DataMember]
        public string CodeClient
        {
            get { return _CodeClient; }
            set { _CodeClient = value; }
        }

        private string _NomClient;
        /// <summary>
        /// Accesseur du nom client
        /// </summary>
        [DataMember]
        public string NomClient
        {
            get { return _NomClient; }
            set { _NomClient = value; }
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

        private string _FullCode;
        /// <summary>
        /// Accesseur du code contrat long
        /// </summary>
        [DataMember]
        public string FullCode
        {
            get { return _FullCode; }
            set { _FullCode = value; }
        }

        private bool _IsValid;
        /// <summary>
        /// Accesseur du is valid
        /// </summary>
        [DataMember]
        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }

        private string _TypeContrat;
        /// <summary>
        /// Accesseur du type de contrat
        /// </summary>
        [DataMember]
        public string TypeContrat
        {
            get { return _TypeContrat; }
            set { _TypeContrat = value; }
        }
        #endregion
    }
}
