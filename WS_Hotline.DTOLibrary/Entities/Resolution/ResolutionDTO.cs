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


namespace WS_Hotline.DTOLibrary.Entities.Resolution
{
    [DebuggerDisplay("ID Resolution {IdResolution} - Sequencement = {Seq} - Libelle Resolution = {ResolutionLibelle}")]
    [DataContract]
    public class ResolutionDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdResolution;
        /// <summary>
        /// Accesseur de l'identifiant de la résolution
        /// </summary>
        [DataMember]
        public int IdResolution
        {
            get { return _IdResolution; }
            set { _IdResolution = value;}
        }

        private int _Seq;
        /// <summary>
        /// Accesseur du sequencement des resolutions
        /// </summary>
        [DataMember]
        public int Seq
        {
            get { return _Seq; }
            set { _Seq = value; }
        }

        private bool _IsFinal;
        /// <summary>
        /// Accesseur du statut de finalité
        /// </summary>
        [DataMember]
        public bool IsFinal
        {
            get { return _IsFinal; }
            set 
            {
                _IsFinal = value;
            }
        }

        private string _ResolutionLibelle;
        /// <summary>
        /// Accesseur du libelle de la resolution
        /// </summary>
        [DataMember]
        public string ResolutionLibelle
        {
            get { return _ResolutionLibelle; }
            set { _ResolutionLibelle = value; }
        }

        private int _TemplateId;
        /// <summary>
        /// Accesseur du template lié a la résolution
        /// </summary>
        [DataMember]
        public int TemplateId
        {
            get { return _TemplateId; }
            set { _TemplateId = value; }
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
        public ResolutionDTO()
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
