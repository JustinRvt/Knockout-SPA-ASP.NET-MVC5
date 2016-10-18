using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Countersoft.Gemini.Api;
using Countersoft.Gemini.Commons.Dto;
using DTOLibrary;
using DTOLibrary.Entities.Authentification;
using DTOLibrary.Entities.Groupe;

namespace API_GeminiLibrary
{
    /// <summary>
    /// Classe permettant l'authentification à l'API
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-03-12 - Création</remarks>
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS

        /// <summary>
        /// Fonction permettant de tester la connexion vers Gemini
        /// Si celle-ci est correcte on retourne l'Identifiant de l'utilisateur
        /// </summary>
        /// <returns>Identifiant de l'utilisateur</returns>
        /// <remarks>Guillaume Bécard - 2015-02-18 - Création</remarks>
        public UserDto GetUtilisateur(AuthentificationDTO pAuth)
        {
            //gb - Retourne l'identifiant de l'utilisateur
            return  LanceAuthentification(pAuth).Admin.WhoAmI();
        }

        /// <summary>
        /// Méthode qui permet le chargement d'une liste d'utilisateur
        /// </summary>
        /// <param name="pAuth">User en cours</param>
        /// <returns>Une liste d'utilisateur au format AuthentificationDTO</returns>
        /// <remarks>JClaud 2015-11-12 Création</remarks>
        public ObservableCollection<IBaseDTO> GetListeData(IBaseDTO pAuth)
        {
            //jc- déclaration de variables
            ObservableCollection<AuthentificationDTO> lListeFinale = new ObservableCollection<AuthentificationDTO>();
            AuthentificationDTO lUser = ((CritereAuthentificationDTO)pAuth).AuthentificationDTO;

            //jc- on récupère la liste des utilisateurs au format AuthentificationDTO
            List<UserDto> lListTemp = LanceAuthentification(CopyUserAsAPI(lUser)).User.GetActive();
                //jc- TODO - A VOIR POURQUOI IMPOSSIBLE DE CHARGER PLUS DE 220 ROWS
                //.Where(s => s.Entity.Active == true).Take(50)
                //.ToList();
                
            lListTemp.ToList().ForEach(p => lListeFinale.Add(ConvertUserDtoToAuth(p)));

            //jc- retourne la liste d'users
            return new ObservableCollection<IBaseDTO>(lListeFinale);
        }

        /// <summary>
        /// Fonction qui retourne l'utilisateur après connexion à Gemini
        /// </summary>
        /// <param name="pUser">Identifiant de l'utilisateur</param>
        /// <returns>Connexion vers Gemini</returns>
        /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
        private ServiceManager LanceAuthentification(AuthentificationDTO pUser)
        {
            try
            {
                //gb - Construction de l'Url Gemini
                string lUrlGemini = pUser.Url +
                    (String.IsNullOrEmpty(pUser.Proxy) == false ? ":" + pUser.Proxy : String.Empty);

                //gb - Déclaration du service Gemini
                ServiceManager lService = new ServiceManager(lUrlGemini,
                pUser.Login, pUser.Password, String.Empty);

                //gb - Test de la connexion
                lService.Admin.WhoAmI();

                //gb - Retourne l'utilisateur
                return lService;
            }
            catch (Exception ex)
            {
                //gb - En fonction de l'erreur
                switch (ex.Message)
                {
                    case "Invalid username / password":
                        throw new Exception("ErrorLogin");
                    case "Unknown error, status code: 0":
                        throw new Exception("ErrorUrl");
                    default:
                        throw new Exception("ErrorGemini");
                }
            }
        }

        /// <summary>
        /// Permet de dupliquer l'utilisateur en cours sous le statut d'utilisateur API avec droit
        /// </summary>
        /// <param name="pUserSource">Utilisateur en cours de base</param>
        /// <returns>Un utilisateur avec droits API</returns>
        /// <remarks>JClaud 2015-07-27 Création</remarks>
        private AuthentificationDTO CopyUserAsAPI(AuthentificationDTO pUserSource)
        {
            return new AuthentificationDTO()
            {
                Proxy = pUserSource.Proxy,
                Url = pUserSource.Url,
                Login = "API_user",
                Password = "8wP!4d$V3c"
            };
        }
        
        /// <summary>
        /// Méthode qui permet de convertir un userDto en AuthentificationDTO
        /// </summary>
        /// <param name="pUser">utilisateur de base issue de l'api Gemini</param>
        /// <returns>DTO de type AuthentificationDTO</returns>
        /// <remarks>JClaud 2015-12-11 Création</remarks>
        private AuthentificationDTO ConvertUserDtoToAuth(UserDto pUser)
        {
            //jc- création d'un nouvel object AuthentificationDTO
            return new AuthentificationDTO(){
                Login = pUser.Entity.Username,
                Password = (pUser.Entity.Password != null) ? System.Text.Encoding.UTF8.GetString(pUser.Entity.Password) : "password",
                ApiKey = pUser.Entity.ApiKey,
                LastConnexion = pUser.Entity.LastLoggedIn,
                IdGemini = Convert.ToString(pUser.Entity.Id),
                Url = "https://gemini.exo-partners.com/",
                Groupes = FormatGroupeToDTO(pUser.ProjectGroups)
            };
        }

        #endregion
    }
}
