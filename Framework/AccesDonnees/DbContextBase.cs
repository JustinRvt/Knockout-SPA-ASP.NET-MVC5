using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WS_Hotline.Framework.Domain.Command;
using System.Web.Mvc;
using System.Data.Entity.ModelConfiguration.Configuration;
using Microsoft.Practices.ServiceLocation;

namespace WS_Hotline.Framework.AccesDonnees
{
    public abstract class DbContextBase<T> : DbContext
       where T : DbContext
    {
        private List<IEntityConfiguration> _registeredConfigurations;

        protected DbContextBase(string pNameOrConnectionString)
            : base(pNameOrConnectionString)
        {
            // this.exceptionManager = exceptionManager;
            Database.SetInitializer<T>(null);
        }

        /// <summary>
        /// Gets configuration, if doesn't initiat, We gets all configuration by DI.
        /// </summary>
        private IEnumerable<IEntityConfiguration> RegisteredConfigurations
        {
            get
            {
                if (this._registeredConfigurations == null || this._registeredConfigurations.Count()== 0)
                {
                    this._registeredConfigurations  = DependencyResolver.Current.GetServices<IEntityConfiguration>().ToList();
                }

                if (this._registeredConfigurations == null || this._registeredConfigurations.Count() == 0)
                {
                    this._registeredConfigurations = ServiceLocator.Current.GetAllInstances<IEntityConfiguration>().ToList();
                }   

                return this._registeredConfigurations;
                
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DataException lDataException)
            {
                throw lDataException;
            }
        }

        /// <summary>
        /// USE ONLY for Unit Tests to avoid use of ServiceLocator in this context
        /// Register a configuration in context
        /// </summary>
        /// <param name="pConfiguration">configuration to add</param>
        public void RegisterConfiguration(IEntityConfiguration pConfiguration)
        {
            this._registeredConfigurations = this._registeredConfigurations ?? new List<IEntityConfiguration>();
            this._registeredConfigurations.Add(pConfiguration);
        }

        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            //pModelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.ColumnTypeCasingConvention>();
            foreach (var lEntityConfiguration in this.RegisteredConfigurations)
            {
                lEntityConfiguration.Add(pModelBuilder.Configurations);
            }
        }

        /// <summary>
        /// Methode to get table name from domain object
        /// </summary>
        /// <typeparam name="TDomainObject"></typeparam>
        /// <returns></returns>
        public string GetTableName<TDomainObject>() where TDomainObject : DomainObject
        {
            var lWorkspace = ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace;
            var lMappingItemCollection = (StorageMappingItemCollection)lWorkspace.GetItemCollection(DataSpace.CSSpace);
            var lStoreContainer = ((EntityContainerMapping)lMappingItemCollection[0]).StoreEntityContainer;
            var lBaseEntitySet = lStoreContainer.BaseEntitySets.Single(pEs => pEs.Name == typeof(TDomainObject).Name);

            return String.Format("{0}.{1}", lBaseEntitySet.Schema, lBaseEntitySet.Table);
        }

        /// <summary>
        /// Methode to get columns database from domain object.
        /// </summary>
        /// <typeparam name="TDomainObject"></typeparam>
        /// <returns></returns>
        public IEnumerable<Tuple<string, Type>> GetColumns<TDomainObject>() where TDomainObject : DomainObject
        {
            var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;

            var lStorageMetadata =
                ((EntityConnection)lObjectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);

            var lEntityProperties = lStorageMetadata
                .Where(pS => pS.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                .Select(pS => pS as EntityType);

            var lTableProperties = lEntityProperties.Single(pEp => pEp.Name == typeof(TDomainObject).Name).Properties;

            return lTableProperties.Select(p => new Tuple<string, Type>(p.Name, p.UnderlyingPrimitiveType.ClrEquivalentType));
        }

    }
}