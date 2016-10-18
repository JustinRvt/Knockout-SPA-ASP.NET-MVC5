using WS_Hotline.Framework.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Entities.Softlog
{

	/// <summary>
    /// Classe DTO permettant de gérer Softlog
    /// </summary>
    /// <remark>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remark>
    [DataContract]
    [Table("T_SOFTLOG")]
    public class SoftlogDTO : BaseDTO
    {
		#region Property
				
		private int _IdSl;
        /// <summary>
        /// Identifient de la table des logs
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Key,Column("ID_SL")] 
		[Required(ErrorMessage = "IdSl error")]
        public int IdSl
        {
            get { return _IdSl; }
            set
            {
                _IdSl = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "IdSl" });
            }
        }
				
		private string _IdUser;
        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("ID_USER")]
		[MaxLength(300)] 
        public string IdUser
        {
            get { return _IdUser; }
            set
            {
                _IdUser = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "IdUser" });
            }
        }
				
		private DateTime? _Date;
        /// <summary>
        /// Date du log
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_DATE")] 
        public DateTime? Date
        {
            get { return _Date; }
            set
            {
                _Date = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Date" });
            }
        }
				
		private string _Descr;
        /// <summary>
        /// Description
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_DESCR")]
		[MaxLength(1000)] 
        public string Descr
        {
            get { return _Descr; }
            set
            {
                _Descr = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Descr" });
            }
        }
				
		private string _Descr2;
        /// <summary>
        /// Description 2
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_DESCR2")]
		[MaxLength(1000)] 
        public string Descr2
        {
            get { return _Descr2; }
            set
            {
                _Descr2 = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Descr2" });
            }
        }
				
		private bool? _Iserreur;
        /// <summary>
        /// Est une erreur ?
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_ISERREUR")] 
        public bool? Iserreur
        {
            get { return _Iserreur; }
            set
            {
                _Iserreur = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Iserreur" });
            }
        }
				
		private string _Module;
        /// <summary>
        /// Module d'ou proviens le Log
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_MODULE")]
		[MaxLength(200)] 
        public string Module
        {
            get { return _Module; }
            set
            {
                _Module = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Module" });
            }
        }
				
		private string _NiveauMessage;
        /// <summary>
        /// Niveau du message
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_NIVEAU_MESSAGE")]
		[MaxLength(200)] 
        public string NiveauMessage
        {
            get { return _NiveauMessage; }
            set
            {
                _NiveauMessage = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "NiveauMessage" });
            }
        }
				
		private string _Source;
        /// <summary>
        /// Source du logiciel d'ou provient le log
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_SOURCE")]
		[MaxLength(200)] 
        public string Source
        {
            get { return _Source; }
            set
            {
                _Source = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Source" });
            }
        }
				
		private string _Version;
        /// <summary>
        /// Version du logiciel
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("SL_VERSION")]
		[MaxLength(40)] 
        public string Version
        {
            get { return _Version; }
            set
            {
                _Version = value; 
				ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Version" });
            }
        }
		  
		#endregion
	
		#region Liaison
			
		#endregion
    }
}
		