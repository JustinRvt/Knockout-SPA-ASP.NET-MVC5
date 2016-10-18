using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Entities.Softlog
{
    /// <summary>
    /// Classe de critère pour SoftlogDTO
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0 </remarks>
    public class CritereSoftlogDTO : CritereBaseDTO<SoftlogDTO>
    {
        #region Property
		
		private int _IdSl;
        /// <summary>
        /// Filtre sur IdSl
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public int IdSl
        {
            get { return _IdSl; }
            set
            {
                _IdSl = value;
                // yl - Mise en place du filtre
                this.Filters["IdSl"] = p => p.IdSl == _IdSl;
            }
        }
		
		private string _IdUser;
        /// <summary>
        /// Filtre sur IdUser
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string IdUser
        {
            get { return _IdUser; }
            set
            {
                _IdUser = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_IdUser)==false)
					this.Filters["IdUser"] = p => p.IdUser.StartsWith(_IdUser);
            }
        }
		
		private DateTime? _SuperieurADate;
        /// <summary>
        /// Filtre sur Date
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public DateTime? SuperieurADate
        {
            get { return _SuperieurADate; }
            set
            {
                _SuperieurADate = value;
                // yl - Mise en place du filtre
                if (_SuperieurADate != null)
					this.Filters["SuperieurADate"] = p => p.Date >= _SuperieurADate;
            }
        }
		
		private DateTime? _InferieurADate;
        /// <summary>
        /// Filtre sur Date
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public DateTime? InferieurADate
        {
            get { return _InferieurADate; }
            set
            {
                _InferieurADate = value;
                // yl - Mise en place du filtre
                if (_InferieurADate != null)
					this.Filters["InferieurADate"] = p => p.Date <= _InferieurADate;
            }
        }
		
		private string _Descr;
        /// <summary>
        /// Filtre sur Descr
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Descr
        {
            get { return _Descr; }
            set
            {
                _Descr = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Descr)==false)
					this.Filters["Descr"] = p => p.Descr.StartsWith(_Descr);
            }
        }
		
		private string _Descr2;
        /// <summary>
        /// Filtre sur Descr2
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Descr2
        {
            get { return _Descr2; }
            set
            {
                _Descr2 = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Descr2)==false)
					this.Filters["Descr2"] = p => p.Descr2.StartsWith(_Descr2);
            }
        }
		
		private bool? _Iserreur;
        /// <summary>
        /// Filtre sur Iserreur
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public bool? Iserreur
        {
            get { return _Iserreur; }
            set
            {
                _Iserreur = value;
                // yl - Mise en place du filtre
                if (_Iserreur != null)
					this.Filters["Iserreur"] = p => p.Iserreur == _Iserreur;
            }
        }
		
		private string _Module;
        /// <summary>
        /// Filtre sur Module
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Module
        {
            get { return _Module; }
            set
            {
                _Module = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Module)==false)
					this.Filters["Module"] = p => p.Module.StartsWith(_Module);
            }
        }
		
		private string _NiveauMessage;
        /// <summary>
        /// Filtre sur NiveauMessage
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string NiveauMessage
        {
            get { return _NiveauMessage; }
            set
            {
                _NiveauMessage = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_NiveauMessage)==false)
					this.Filters["NiveauMessage"] = p => p.NiveauMessage.StartsWith(_NiveauMessage);
            }
        }
		
		private string _Source;
        /// <summary>
        /// Filtre sur Source
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Source
        {
            get { return _Source; }
            set
            {
                _Source = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Source)==false)
					this.Filters["Source"] = p => p.Source.StartsWith(_Source);
            }
        }
		
		private string _Version;
        /// <summary>
        /// Filtre sur Version
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Version)==false)
					this.Filters["Version"] = p => p.Version.StartsWith(_Version);
            }
        }
		  
		#endregion
	
		#region Liaison
		
        #endregion
    }
}

		