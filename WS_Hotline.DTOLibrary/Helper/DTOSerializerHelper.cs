using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WS_Hotline.DTOLibrary.Helper
{
    /// <summary>
    /// Summary description for DTOSerializerHelper.
    /// </summary>
    /// <remarks>LOUIS Yoann 16/06/2015 Version 1.0.1</remarks>
    public class DTOSerializerHelper
    {
        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public DTOSerializerHelper()
        {
        }

        #endregion

        /// <summary>
        /// Creation d'un string xml a partir d'un dto.
        /// </summary>
        /// <param name="dto">DTO</param>
        /// <returns>XML</returns>
        /// <remarks>LOUIS Yoann 16/06/2015 Version 1.0.1</remarks>
        public static string SerializeDTO(IBaseDTO dto)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(dto.GetType());
                StringWriter sWriter = new StringWriter();
                // yl - Serializsation dto vers xml.
                xmlSer.Serialize(sWriter, dto);
                // yl - Retourne string of xml. on remplace les < par ¤ pour autoriser le tranfere
                return sWriter.ToString();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deserialisation d'un xml vers un DTO Specifique.
        /// </summary>
        /// <param name="pXml">xml en string</param>
        /// <param name="dto">Type du DTO Atendu</param>
        /// <returns>DTO</returns>
        /// <remarks>LOUIS Yoann 16/06/2015 Version 1.0.1</remarks>
        public static TIn DeserializeXml<TIn>(string pXml)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(TIn));
                // yl - lecture du XML.
                StringReader sReader = new StringReader(pXml);
                // yl - Cast de l'xml en dto
                TIn lReturnDTO = (TIn)xmlSer.Deserialize(sReader);

                return lReturnDTO;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
