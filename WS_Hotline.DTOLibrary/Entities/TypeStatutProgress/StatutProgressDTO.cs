using WS_Hotline.DTOLibrary.Entities.Statut;
using WS_Hotline.DTOLibrary.Entities.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Resolution;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.TypeStatutProgress
{
    /// <summary>
    /// Classe permettant de gérer les statuts en cours
    /// en fonction des types de ticket
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-03 - Création</remarks>
    [DebuggerDisplay("Statut = {Statut.LibelleStatut} - Type = {Type.LibelleType} - Resolution = {Resolution.IdResolution}")]
    [DataContract]
    public class StatutProgressDTO : BaseDTO
    {
        #region PROPERTIES

        private StatutDTO _Statut;
        /// <summary>
        /// Accesseur du statut
        /// </summary>
        [DataMember]
        public StatutDTO Statut
        {
            get { return _Statut; }
            set { _Statut = value; }
        }

        private TypeDTO _Type;
        /// <summary>
        /// Accesseur du type
        /// </summary>
        [DataMember]
        public TypeDTO Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private ResolutionDTO _Resolution;
        /// <summary>
        /// Accesseur de la résolution
        /// </summary>
        [DataMember]
        public ResolutionDTO Resolution
        {
            get { return _Resolution; }
            set { _Resolution = value; }
        }
        
        #endregion
    }
}
