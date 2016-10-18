using WS_Hotline.Framework.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Entities.User
{

    /// <summary>
    /// Classe DTO permettant de gérer User
    /// </summary>
    /// <remark>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remark>
    [DataContract]
    [Table("T_USER")]
    public class UserDTO : BaseDTO
    {
        #region Property

        private int _IdUser;
        /// <summary>
        /// id auto
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Key, Column("ID_USER")]
        [Required(ErrorMessage = "IdUser error")]
        public int IdUser
        {
            get { return _IdUser; }
            set
            {
                _IdUser = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "IdUser" });
            }
        }

        private bool? _IsAdmin;
        /// <summary>
        /// true si l'utilisateur est un admin
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("US_IS_ADMIN")]
        public bool? IsAdmin
        {
            get { return _IsAdmin; }
            set
            {
                _IsAdmin = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "IsAdmin" });
            }
        }

        private string _Login;
        /// <summary>
        /// login de l'utilisateur
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("US_LOGIN")]
        [MaxLength(80)]
        public string Login
        {
            get { return _Login; }
            set
            {
                _Login = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Login" });
            }
        }

        private string _Mail;
        /// <summary>
        /// adresse mail de l'utilisateur
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("US_MAIL")]
        [MaxLength(400)]
        public string Mail
        {
            get { return _Mail; }
            set
            {
                _Mail = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Mail" });
            }
        }

        private string _Mdp;
        /// <summary>
        /// mot de passe crypté MD5
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("US_MDP")]
        [MaxLength(100)]
        public string Mdp
        {
            get { return _Mdp; }
            set
            {
                _Mdp = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Mdp" });
            }
        }

        private string _Nom;
        /// <summary>
        /// nom de l'utilisateur
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [DataMember]
        [Column("US_NOM")]
        [MaxLength(100)]
        public string Nom
        {
            get { return _Nom; }
            set
            {
                _Nom = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Nom" });
            }
        }

        #endregion

        #region Liaison

        #endregion
    }
}
