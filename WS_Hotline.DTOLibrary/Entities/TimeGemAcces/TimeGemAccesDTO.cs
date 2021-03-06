﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.TimeGemAcces
{
    /// <summary>
    /// Classe pour la gestion des accès aux fonctionnalitées du logiciel
    /// </summary>
    /// <remarks>JClaud 2016-01-12 Création</remarks>
    [DebuggerDisplay("ID = {Id} - ID User = {Id_User} - Bouton Acces = {BoutonAcces}")]
    [DataContract]
    public class TimeGemAccesDTO : BaseDTO
    {
        #region PROPERTIES

        private int _Id;
        /// <summary>
        /// Accesseur de l'id
        /// </summary>
        [DataMember]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Id_User;
        /// <summary>
        /// Accesseur de l'id de l'utilisateur
        /// </summary>
        [DataMember]
        public int Id_User
        {
            get { return _Id_User; }
            set { _Id_User = value; }
        }

        private string _TemplateExclusion;
        /// <summary>
        /// Accesseur du champ d'exclusion des templates
        /// </summary>
        [DataMember]
        public string TemplateExclusion
        {
            get { return _TemplateExclusion; }
            set { _TemplateExclusion = value; }
        }

        private string _BoutonAcces;
        /// <summary>
        /// Accesseur du champs d'accès au boutons
        /// </summary>
        [DataMember]
        public string BoutonAcces
        {
            get { return _BoutonAcces; }
            set { _BoutonAcces = value; }
        }

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-07-20 - Création</remarks>
        public TimeGemAccesDTO()
        {

        }

        #endregion
    }
}

