using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Entities.Customer
{
    /// <summary>
        /// Classe DTO permettant de gérer Objet
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
    [DataContract]
    [Table("V_HOTLINE_CONTRACT")]
    public class CustomerDTO : BaseDTO
    {
        #region property

        private string _CustomerPhone;
        /// <summary>
        /// Customer Phone #
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        [DataMember]
        [Column("MainInvoicingContact_Phone")]
        [Required(ErrorMessage = "CustomerPhone error")]
        [MaxLength(40)]
        public string CustomerPhone
        {
            get { return _CustomerPhone; }
            set
            {
                _CustomerPhone = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CustomerPhone" });
            }
        }

        private string _CustomerCellPhone;
        /// <summary>
        /// Customer Cell Phone #
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        [DataMember]
        [Column("MainInvoicingContact_CellPhone")]
        [Required(ErrorMessage = "CustomerPhone error")]
        [MaxLength(40)]
        public string CustomerCellPhone
        {
            get { return _CustomerCellPhone; }
            set
            {
                _CustomerCellPhone = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CustomerCellPhone" });
            }
        }


        private string _CustomerLastName;
        /// <summary>
        /// Customer Last Name
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        [DataMember]
        [Column("MainInvoicingContact_Name")]
        [Required(ErrorMessage = "Variable error")]
        [MaxLength(120)]
        public string CustomerLastName
        {
            get { return _CustomerLastName; }
            set
            {
                _CustomerLastName = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CustomerLastName" });
            }
        }


        private string _CustomerFirstName;
        /// <summary>
        /// Customer First Name
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        [DataMember]
        [Column("MainInvoicingContact_FirstName")]
        [Required(ErrorMessage = "CustomerFirstName error")]
        [MaxLength(120)]
        public string CustomerFirstName
        {
            get { return _CustomerFirstName; }
            set
            {
                _CustomerFirstName = value;
                ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CustomerFirstName" });
            }
        }


    private int _IdLcp;
    /// <summary>
    /// Trying to resolve EntityType issue
    /// </summary>
    /// <remarks>[jravat] - [30092016] - Généré par snippet v1.0</remarks>
    [DataMember]
    [Column("ID_LCP")]
    [Required(ErrorMessage = "IdLcp error")]
    [Key]
    public int IdLcp
    {
      get { return _IdLcp; }
      set
      {
        _IdLcp = value;
        ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "IdLcp" });
      }
    }
        #endregion

        #region Liaison

        #endregion
    }
}
