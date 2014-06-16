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
    /// <summary>Strategy.</summary>
    [Serializable]
    public class Strategy : StrategyEntity, IBusinessObject
    {
        #region Static.

        public static EntityCollection<StrategyEntity, StrategyMeta> GetAllTop(int topCount, int noGenId)
        {
            StrategyMeta sMeta = new StrategyMeta();
            SelectStatement select = new SelectStatement(sMeta);
            select.Top = topCount;
            select.Where.Add(PredicateFactory.IsNull(sMeta.Fitness, true));
            select.Where.And(PredicateFactory.Compare(sMeta.IdGeneration, ComparisonOperator.NotEqual, noGenId));
            select.OrderBy.Add(sMeta.Fitness, false);

            return (EntityCollection<StrategyEntity, StrategyMeta>)select.Execute();
        }

        public static EntityCollection<StrategyEntity, StrategyMeta> GetGeneration(int idGeneration)
        {
            StrategyMeta sMeta = new StrategyMeta();
            SelectStatement select = new SelectStatement(sMeta);
            select.Where.Add(sMeta.IdGeneration, idGeneration);
            select.Where.And(PredicateFactory.IsNull(sMeta.Fitness, true));
            select.OrderBy.Add(sMeta.Fitness, false);

            return (EntityCollection<StrategyEntity, StrategyMeta>)select.Execute();
        }

        #endregion Static.

        #region Constructors.

        /// <summary>Kreira novi prazni objekt s aktivnim statusom.</summary>
        public Strategy()
            : base()
        {
        }

        /// <summary>Inicijalizira postojeći entitet i postavlja mu ID. Ostala polja se ne inicijaliziraju.</summary>
        public Strategy(int id)
            : base(id)
        {
        }

        /// <summary>Konvertira entitet u business object.</summary>
        protected Strategy(StrategyEntity entity)
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
                StrategyEntity entity = (StrategyEntity)entities[i];
                bool isBizObject = (entity is IBusinessObject);
                if (!isBizObject)
                    entities[i] = new Strategy(entity);
            }
        }

        /// <summary>Po potrebi konvertira entity u business objekt.</summary>
        public static Strategy ConvertEntityToBusinessObject(StrategyEntity entity)
        {
            Strategy bizobj = entity as Strategy;
            if (bizobj == null)
                bizobj = new Strategy(entity);

            return bizobj;
        }

        #endregion ConvertEntitiesToBusinessObjects.

        #region NewStrategy.

        /// <summary>Kreira novi objekt i postavlja default vrijednosti.</summary>
        public static Strategy NewStrategy(IActor creator)
        {
            var newObject = new Strategy(-1)
            {
                NullCheckEnabled = false
            };

            return newObject;
        }

        #endregion NewStrategy.
    }
}