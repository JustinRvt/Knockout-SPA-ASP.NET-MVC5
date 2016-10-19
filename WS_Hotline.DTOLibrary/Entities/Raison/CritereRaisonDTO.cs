using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Raison
{
    //jc- Classe de critère pour RaisonDTO
    [DebuggerDisplay("ID Raison = {IdRaison} - Titre Raison = {TitreRaison} - Ordre Raison = {OrdreRaison}")]
    [DataContract]
    public class CritereRaisonDTO : CritereBaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdRaison;
        /// <summary>
        /// Accesseur de l'identifiant de la raison
        /// </summary>
        [DataMember]
        public int IdRaison
        {
            get { return _IdRaison; }
            set { _IdRaison = value; }
        }

        private string _TitreRaison;
        /// <summary>
        /// Accesseur du titre de la raison
        /// </summary>
        [DataMember]
        public string TitreRaison
        {
            get { return _TitreRaison; }
            set { _TitreRaison = value; }
        }

        private int _OrdreRaison;
        /// <summary>
        /// Accesseur de l'ordre de la raison
        /// </summary>
        [DataMember]
        public int OrdreRaison
        {
            get { return _OrdreRaison; }
            set
            {
                _OrdreRaison = value;
            }
        }

        private bool _IsActif;
        /// <summary>
        /// Accesseur du IsActif de la raison
        /// </summary>
        [DataMember]
        public bool IsActif
        {
            get { return _IsActif; }
            set { _IsActif = value; }
        }

        #endregion

        #endregion
    }
}
