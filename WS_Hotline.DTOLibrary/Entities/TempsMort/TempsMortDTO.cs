using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.TempsMort
{
    [DebuggerDisplay("DateSavTempsMort = {DateSavTempsMort} - Temps Mort = {TempsMort}")]

    public class TempsMortDTO : BaseDTO
    {
        #region PROPERTIES

        private DateTime _DateSavTempsMort;
        /// <summary>
        /// Accesseur de la sauvegarde du temps mort
        /// </summary>
        [DataMember]
        public DateTime DateSavTempsMort
        {
            get { return _DateSavTempsMort; }
            set { _DateSavTempsMort = value; }
        }

        private DateTime _TempsMort;
        /// <summary>
        /// Accesseur du temps mort
        /// </summary>
        [DataMember]
        public DateTime TempsMort
        {
            get { return _TempsMort; }
            set { _TempsMort = value; }
        }

        #endregion
    }
}
