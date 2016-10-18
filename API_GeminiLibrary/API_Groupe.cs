using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Countersoft.Foundation.Commons.Extensions;
using Countersoft.Gemini.Commons.Dto;
using Countersoft.Gemini.Commons.Entity.Security;
using DTOLibrary.Entities.Groupe;
using DTOLibrary.Entities.Projet;

namespace API_GeminiLibrary
{
    public partial class CServiceGemini
    {
        #region METHODES / FONCTIONS

        /// <summary>
        /// Fonction permettant de récupérer une liste de groupes
        /// </summary>
        /// <returns>Identifiant de l'utilisateur</returns>
        /// <remarks>JClaud 2015-03-28 - Création</remarks>
        private List<ProjectGroup> GetListeGroupeDto(CritereGroupeDTO pParam)
        {
            //jc- récupération de l'user en Bdd
            UserDto lUser = LanceAuthentification(pParam.User).Admin.WhoAmI();

            //jc- récupérationd des id des groupes concernés par l'utilisateur
            return lUser.ProjectGroups.ToList();
        }

        /// <summary>
        /// Méthode qui permet de retourner une liste de groupes
        /// </summary>
        /// <param name="pParam">param</param>
        /// <returns>Liste de Groupes DTO</returns>
        /// <remarks>JClaud 2015-07-28 Création</remarks>
        public ObservableCollection<GroupeDTO> GetGroupes(CritereGroupeDTO pParam)
        {
            return FormatGroupeToDTO(GetListeGroupeDto(pParam));
        }

        /// <summary>
        /// Méthode de convertion des projetgroup de gemini en GroupeDTO de l'application
        /// </summary>
        /// <param name="pIssueProjetDto">Liste de projetgroup de gemini</param>
        /// <returns>Liste de GroupeDTO objets</returns>
        /// <remarks>JClaud 2015-07-28 Création</remarks>
        public ObservableCollection<GroupeDTO> FormatGroupeToDTO(List<ProjectGroup> pProjectGroupDto)
        {
            //jc- on retourne une liste de ProjetDTO
            return new ObservableCollection<GroupeDTO>(pProjectGroupDto
                    .Select(p => new GroupeDTO()
                    {
                        //jc- affectation des différentes valeurs
                        IdGroupe = p.Id,
                        GroupeNom = p.Name,
                        GroupeDescription = p.Description,
                        GroupeDateCreation = p.Created,
                        GroupeInteractions = p.InteractionGroups
                    }));
        }

        #endregion
    }
}
