using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using FistCore.Common;
using FistCore.Common.Serialization;
using FistCore.Core;
using FistCore.Core.Common;
using Fistnet.FistBot.DAL;

namespace Fistnet.FistBot.BL
{
    /// <summary>Generation.</summary>
    [Serializable]
    public class Generation : GenerationEntity, IBusinessObject
    {
        #region Static.

        public static int GetLastGenerationId()
        {
            GenerationMeta genMeta = new GenerationMeta();
            SelectStatement select = new SelectStatement(genMeta);
            select.Top = 1;
            select.OrderBy.Add(genMeta.IdGeneration, false);
            DataTable rows = select.Execute();
            if (rows.Rows.Count == 0)
                return 0;
            else
                return new GenerationEntity(rows.Rows[0]).IdGeneration;
        }

        public static int GetGenerationCount()
        {
            GenerationMeta genMeta = new GenerationMeta();
            SelectStatement select = new SelectStatement(genMeta);
            select.OrderBy.Add(genMeta.IdGeneration, false);
            DataTable rows = select.Execute();

            return rows.Rows.Count;
        }

        #endregion Static.

        #region Constructors.

        /// <summary>Kreira novi prazni objekt s aktivnim statusom.</summary>
        public Generation()
            : base()
        {
        }

        /// <summary>Inicijalizira postojeći entitet i postavlja mu ID. Ostala polja se ne inicijaliziraju.</summary>
        public Generation(int id)
            : base(id)
        {
        }

        /// <summary>Konvertira entitet u business object.</summary>
        protected Generation(GenerationEntity entity)
            : base(entity)
        {
        }

        #endregion Constructors.

        #region Security - grant everything.

        /// <summary>
        /// Returns empty BusinessRuleCollection indicating that the actor has permissions to fetch the data requested.
        /// </summary>
        /// <param name="actor">Actor whose data-access permissions are to be checked.</param>
        /// <returns>Collection of permissions (broken rules) that the actor has failed.</returns>
        /// <remarks>Override in derived classes to add security checks.</remarks>
        public virtual BusinessRuleCollection GrantFetch(IActor actor)
        {
            return new BusinessRuleCollection();
        }

        /// <summary>
        /// Returns empty BusinessRuleCollection indicating that the actor has permissions to save the current object.
        /// </summary>
        /// <param name="actor">Actor whose data-access permissions are to be checked.</param>
        /// <returns>Collection of permissions (broken rules) that the actor has failed.</returns>
        /// <remarks>Override in derived classes to add security checks.</remarks>
        public virtual BusinessRuleCollection GrantSave(IActor actor)
        {
            return new BusinessRuleCollection();
        }

        /// <summary>
        /// Returns empty BusinessRuleCollection indicating that the actor has permissions to delete the data requested.
        /// </summary>
        /// <param name="actor">Actor whose data-access permissions are to be checked.</param>
        /// <returns>Collection of permissions (broken rules) that the actor has failed.</returns>
        /// <remarks>Override in derived classes to add security checks.</remarks>
        public virtual BusinessRuleCollection GrantDelete(IActor actor)
        {
            return new BusinessRuleCollection();
        }

        /// <summary>
        /// Returns empty BusinessRuleCollection indicating that the actor has permissions to create the current object.
        /// </summary>
        /// <param name="actor">Actor whose data-access permissions are to be checked.</param>
        /// <returns>Collection of permissions (broken rules) that the actor has failed.</returns>
        /// <remarks>Override in derived classes to add security checks.</remarks>
        public virtual BusinessRuleCollection GrantCreate(IActor actor)
        {
            return new BusinessRuleCollection();
        }

        #endregion Security - grant everything.

        #region Fetch.

        /// <summary>Fetches existing entity that with PK set.</summary>
        public virtual bool Fetch(IActor actor, DataAccessScope detailLevel)
        {
            IEntityDAO dao = DALHelper.GetDao(this, _ConnectionProvider);
            bool exists = dao.SelectOne(detailLevel.IncludesParents);
            if (exists && detailLevel.IncludesChildren)
                DbFetchChildren();

            return exists;
        }

        /// <summary>Saves biz object if actor has required permission and if biz object is valid.</summary>
        public virtual BusinessRuleCollection FetchIfValid(IActor actor, DataAccessScope detailLevel, bool enforceSecurityChecks)
        {
            BusinessRuleCollection rules = new BusinessRuleCollection();

            // Check permissions.
            if (enforceSecurityChecks)
                rules.Add(GrantFetch(actor));

            if (rules.HasBrokenRules)
                return rules.GetBrokenRules();

            rules.Add(new BusinessRule("Entity_Exists", this.Fetch(actor, detailLevel), "Entity does not exist.", 1));
            return rules.GetBrokenRules();
        }

        protected virtual void DbFetchChildren()
        {
        }

        #endregion Fetch.

        #region Save.

        /// <summary>Saves biz object if actor has required permission.</summary>
        public virtual void Save(IActor actionInitiator)
        {
            IEntityDAO dao = DALHelper.GetDao(this, _ConnectionProvider);
            dao.Save();
        }

        #endregion Save.

        #region SaveIfValid.

        /// <summary>Saves biz object if actor has required permission and if biz object is valid.</summary>
        public virtual BusinessRuleCollection SaveIfValid(IActor actionInitiator, ValidationLevel level, bool enforceSecurityChecks)
        {
            // Validate object.
            BusinessRuleCollection rules = new BusinessRuleCollection();
            rules.Add(Validate(level));
            if (rules.HasBrokenRules)
                return rules.GetBrokenRules();

            // Check permissions.
            if (enforceSecurityChecks && !this.IsNew)
                rules.Add(GrantSave(actionInitiator));

            if (enforceSecurityChecks && this.IsNew)
                rules.Add(GrantCreate(actionInitiator));

            if (rules.HasBrokenRules)
                return rules.GetBrokenRules();

            // Save if valid and actor has all required permissions.
            Save(actionInitiator);
            return rules.GetBrokenRules();
        }

        #endregion SaveIfValid.

        #region Validate.

        /// <summary>Validates object.</summary>
        public virtual BusinessRuleCollection Validate(ValidationLevel level)
        {
            BusinessRuleCollection rules = new BusinessRuleCollection();
            rules.Add(DALHelper.CheckEntityRules(this));
            if (rules.AllRulesAreObeyed && level > ValidationLevel.BasicFieldConstraints)
                ValidateChildren(rules, level);

            return rules.GetBrokenRules();
        }

        protected virtual void ValidateChildren(BusinessRuleCollection rules, ValidationLevel level)
        {
        }

        #endregion Validate.

        #region Delete.

        /// <summary>Deletes biz object if PK is set and if user has required permission.</summary>
        public virtual void Delete(IActor actor)
        {
            if (GetPrimaryKeyValue() == null) throw new InvalidOperationException("ID nije postavljen.");

            DeleteChildren(actor);
            IEntityDAO dao = DALHelper.GetDao(this, _ConnectionProvider);
            dao.DeleteOne();
        }

        /// <summary>Saves biz object if actor has required permission and if biz object is valid.</summary>
        public virtual BusinessRuleCollection DeleteIfValid(IActor actor, bool enforceSecurityChecks)
        {
            BusinessRuleCollection rules = new BusinessRuleCollection();

            // Check permissions.
            if (enforceSecurityChecks)
                rules.Add(GrantDelete(actor));

            if (rules.HasBrokenRules)
                return rules.GetBrokenRules();

            this.Delete(actor);
            return rules.GetBrokenRules();
        }

        /// <summary>Briše child objekte ako je postavljen ID i ako korisnik ima potrebne dozvole.</summary>
        private void DeleteChildren(IActor actor)
        {
            if (GetPrimaryKeyValue() == null) throw new InvalidOperationException("ID nije postavljen.");
            this.DbFetchChildren();
        }

        #endregion Delete.

        #region ConvertEntitiesToBusinessObjects.

        /// <summary>Non-business object elemente kolekcije konvertira u business objekte.</summary>
        public static void ConvertEntitiesToBusinessObjects(IEntityCollection entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                GenerationEntity entity = (GenerationEntity)entities[i];
                bool isBizObject = (entity is IBusinessObject);
                if (!isBizObject)
                    entities[i] = new Generation(entity);
            }
        }

        /// <summary>Po potrebi konvertira entity u business objekt.</summary>
        public static Generation ConvertEntityToBusinessObject(GenerationEntity entity)
        {
            Generation bizobj = entity as Generation;
            if (bizobj == null)
                bizobj = new Generation(entity);

            return bizobj;
        }

        #endregion ConvertEntitiesToBusinessObjects.

        #region NewGeneration.

        /// <summary>Kreira novi objekt i postavlja default vrijednosti.</summary>
        public static Generation NewGeneration(IActor creator)
        {
            var newObject = new Generation(-1)
            {
                NullCheckEnabled = false
            };

            return newObject;
        }

        #endregion NewGeneration.
    }
}