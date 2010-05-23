using System;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using Serendipity.Core;
using Serendipity.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;
using ForeignKeyConvention = Serendipity.Data.NHibernateMaps.Conventions.ForeignKeyConvention;
using ManyToManyTableNameConvention = Serendipity.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention;

namespace Serendipity.Data.NHibernateMaps
{
    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            var mappings = new AutoPersistenceModel();

            mappings.AddEntityAssembly(typeof (Class1).Assembly).Where(GetAutoMappingFilter);
            mappings.Conventions.Setup(GetConventions());
            mappings.Setup(GetSetup());
            mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
            
            return mappings;
        }

        #endregion

        private Action<AutoMappingExpressions> GetSetup()
        {
            return c => { c.FindIdentity = type => type.Name == "Id"; };
        }

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
                       {
                           c.Add<ForeignKeyConvention>();
                           c.Add<HasManyConvention>();
                           c.Add<HasManyToManyConvention>();
                           c.Add<ManyToManyTableNameConvention>();
                           c.Add<PrimaryKeyConvention>();
                           c.Add<ReferenceConvention>();
                           c.Add<TableNameConvention>();

                       };
        }

        /// <summary>
        /// Provides a filter for only including types which inherit from the IEntityWithTypedId interface.
        /// </summary>
        private bool GetAutoMappingFilter(Type t)
        {
            return typeof (Entity).IsAssignableFrom(t);
        }
    }
}