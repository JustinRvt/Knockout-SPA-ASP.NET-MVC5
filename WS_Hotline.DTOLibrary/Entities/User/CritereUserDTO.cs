using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Entities.User
{
    /// <summary>
    /// Classe de critère pour UserDTO
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0 </remarks>
    public class CritereUserDTO : CritereBaseDTO<UserDTO>
    {
        #region Property
		
		private int _IdUser;
        /// <summary>
        /// Filtre sur IdUser
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public int IdUser
        {
            get { return _IdUser; }
            set
            {
                _IdUser = value;
                // yl - Mise en place du filtre
                this.Filters["IdUser"] = p => p.IdUser == _IdUser;
            }
        }
		
		private bool? _IsAdmin;
        /// <summary>
        /// Filtre sur IsAdmin
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public bool? IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                _IsAdmin = value;
                // yl - Mise en place du filtre
                if (_IsAdmin != null)
					this.Filters["IsAdmin"] = p => p.IsAdmin == _IsAdmin;
            }
        }
		
		private string _Login;
        /// <summary>
        /// Filtre sur Login
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Login
        {
            get { return _Login; }
            set
            {
                _Login = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Login)==false)
					this.Filters["Login"] = p => p.Login.StartsWith(_Login);
            }
        }
		
		private string _Mail;
        /// <summary>
        /// Filtre sur Mail
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Mail
        {
            get { return _Mail; }
            set
            {
                _Mail = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Mail)==false)
					this.Filters["Mail"] = p => p.Mail.StartsWith(_Mail);
            }
        }
		
		private string _Mdp;
        /// <summary>
        /// Filtre sur Mdp
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Mdp
        {
            get { return _Mdp; }
            set
            {
                _Mdp = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Mdp)==false)
					this.Filters["Mdp"] = p => p.Mdp.StartsWith(_Mdp);
            }
        }
		
		private string _Nom;
        /// <summary>
        /// Filtre sur Nom
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        public string Nom
        {
            get { return _Nom; }
            set
            {
                _Nom = value;
                // yl - Mise en place du filtre
                if (string.IsNullOrEmpty(_Nom)==false)
					this.Filters["Nom"] = p => p.Nom.StartsWith(_Nom);
            }
        }
		  
		#endregion
	
		#region Liaison
		
        #endregion
    }
}

		