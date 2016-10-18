using NLog;
using WS_Hotline.DTOLibrary.Info;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DomainLibrary.Helper
{
    /// <summary>
    /// Classe static pour ecrire des logs
    /// </summary>
    /// <remarks>LOUIS Yoann 24/09/2015</remarks>
    public class CLogger
    {
        #region Private

        private static Logger mLogger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methode

        #region Log

        /// <summary>
        /// Ecrire un log de debug
        /// </summary>
        /// <param name="pInfoSession">Info de la Session</param>
        /// <param name="pModule">Module enb cours</param>
        /// <param name="pMessage">Message</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static void WriteDebugLog(InfoSessionDTO pInfoSession, string pModule, string pMessage)
        {
            // yl - Ecriture du log
            WriteLogInternal(LogLevel.Debug, pInfoSession, pModule, pMessage);
        }

        /// <summary>
        /// Ecrire un log d'Info
        /// </summary>
        /// <param name="pInfoSession">Info de la Session</param>
        /// <param name="pModule">Module enb cours</param>
        /// <param name="pMessage">Message</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static void WriteInfoLog(InfoSessionDTO pInfoSession, string pModule, string pMessage)
        {
            // yl - Ecriture du log
            WriteLogInternal(LogLevel.Info, pInfoSession, pModule, pMessage);
        }

        /// <summary>
        /// Ecrire un log d'erreur
        /// </summary>
        /// <param name="pInfoSession">Info de la Session</param>
        /// <param name="pModule">Module enb cours</param>
        /// <param name="pMessage">Message</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static void WriteErrorLog(InfoSessionDTO pInfoSession, string pModule, string pMessage)
        {
            // yl - Ecriture du log
            WriteLogInternal(LogLevel.Error, pInfoSession, pModule, pMessage);
        }

        /// <summary>
        /// Ecrire un log Fatal
        /// </summary>
        /// <param name="pInfoSession">Info de la Session</param>
        /// <param name="pModule">Module enb cours</param>
        /// <param name="pMessage">Message</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static void WriteFatalLog(InfoSessionDTO pInfoSession, string pModule, string pMessage)
        {
            // yl - Ecriture du log
            WriteLogInternal(LogLevel.Fatal, pInfoSession, pModule, pMessage);
        }

        /// <summary>
        /// Ecrire le log
        /// </summary>
        /// <param name="pLogLevel">Niveau du log</param>
        /// <param name="pInfoSession">InfoSession</param>
        /// <param name="pModule">Nom du module</param>
        /// <param name="pMessage">Message</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        private static void WriteLogInternal(LogLevel pLogLevel, InfoSessionDTO pInfoSession, string pModule, string pMessage)
        {
            var ltest = GetCallingMethodeName();

            // yl - Creation d'un Log
            LogEventInfo lLogEvent = new LogEventInfo(pLogLevel, "", pMessage);
            // yl - Affectation des property
            lLogEvent.Properties["Methode"] = GetCallingMethodeFullName();
            lLogEvent.Properties["Module"] = pModule;
            lLogEvent.Properties["Agent"] = pInfoSession == null ? "null" : pInfoSession.User == null ? "null" : pInfoSession.User.Login;
            // yl - Ecriture du log
            mLogger.Log(lLogEvent);
        }

        #endregion

        #region GetCallingMethode

        /// <summary>
        /// Remonter a la methode appelante ne possedant pas le mot log dans sont nom
        /// </summary>
        /// <returns>Nom de la methode</returns>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static string GetCallingMethodeName()
        {
            // yl - Recuperation de la methode
            var lMethode = GetCallingMehtodeInternal();
            // yl - Retourne "unknown" si pas trouver, sinon nom de la methode 
            return lMethode != null ? lMethode.Name : "unknown";
        }

        /// <summary>
        /// Remonter a la methode appelante ne possedant pas le mot log dans sont nom
        /// </summary>
        /// <returns>Full name de la classe appelant</returns>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static string GetCallingMethodeDeclaringTypeFullName()
        {
            // yl - Recuperation de la methode
            var lMethode = GetCallingMehtodeInternal();
            // yl - Retourne "unknown" si pas trouver, sinon nom de la methode 
            return lMethode != null ? lMethode.DeclaringType.FullName : "unknown";
        }

        /// <summary>
        /// Remonter a la methode appelante ne possedant pas le mot log dans sont nom
        /// </summary>
        /// <returns>Full name de la methode</returns>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        public static string GetCallingMethodeFullName()
        {
            // yl - Recuperation de la methode
            var lMethode = GetCallingMehtodeInternal();
            // yl - Retourne "unknown" si pas trouver, sinon nom de la methode 
            return lMethode != null ? string.Concat(lMethode.DeclaringType.FullName, ".", lMethode.Name) : "unknown";
        }

        /// <summary>
        /// permet de recuperer la methode appelant qui ne contient pas le mot "log"
        /// </summary>
        /// <returns>Methode</returns>
        /// <remarks>LOUIS yoann 25/09/2015</remarks>
        private static MethodBase GetCallingMehtodeInternal()
        {
            StackTrace trace = new StackTrace(false);
            MethodBase lMethod = null;
            for (int i = 0; i < trace.FrameCount; i++)
            {
                StackFrame frame = trace.GetFrame(i);
                lMethod = frame.GetMethod();
                Type lDt = lMethod.DeclaringType;
                if (!typeof(ILogger).IsAssignableFrom(lDt) && lMethod.DeclaringType.Name != "CLogger" && lMethod.Name.Contains("Logger") == false)
                {
                    break;
                }
            }
            return lMethod;
        }

        #endregion

        #region Exeption

        /// <summary>
        /// Recupere le message de l'execption et des inner exception
        /// </summary>
        /// <param name="pEx">Exception</param>
        /// <returns>Message de l'execption et de l'inner exception</returns>
        /// <remarks>LOUIS Yoann 25/09/2015</remarks>
        public static string GetMessageException(Exception pEx)
        {
            return pEx.InnerException != null ? pEx.Message + " => " + GetMessageException(pEx.InnerException) : string.IsNullOrEmpty(pEx.Message) ? "" : pEx.Message;
        }

        #endregion


        #endregion
    }
}
