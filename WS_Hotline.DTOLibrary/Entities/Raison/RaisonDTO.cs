using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Statut;
using WS_Hotline.DTOLibrary.Entities.Temps;
using WS_Hotline.DTOLibrary.Entities.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Raison
{
    public class RaisonDTO : BaseDTO
    {
        [DebuggerDisplay("ID Raison = {IdRaison} - Titre Raison = {TitreRaison} - OrdreRaison = {OrdreRaison}")]
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
            set { _IdRaison = value;}
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

        private int? _OrdreRaison;
        /// <summary>
        /// Accesseur de l'ordre de la raison
        /// </summary>
        [DataMember]
        public int? OrdreRaison
        {
            get { return _OrdreRaison; }
            set 
            {
                _OrdreRaison = value;
            }
        }

        private bool? _IsActif;
        /// <summary>
        /// Accesseur du IsActif de la raison
        /// </summary>
        [DataMember]
        public bool? IsActif
        {
            get { return _IsActif; }
            set { _IsActif = value; }
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
        public RaisonDTO()
        {

        }

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
        }

        #endregion
    }
}
