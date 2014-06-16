// FistCore generated entity and metadata classes for Generation.
using System;
using System.Configuration;
using System.Data;
using FistCore.Common;
using FistCore.Common.Serialization;
using FistCore.Core;
using FistCore.Core.Common;
using Newtonsoft.Json;

namespace Fistnet.FistBot.DAL
{
    /// <summary>
    /// Entity model class for the table/view 'Generation'.
    /// </summary>
    [Serializable]
    public class GenerationEntity : EntityModelBase
    {
        #region Private members.

        // Members mapped to database columns.
        private int? idGeneration;

        private bool? active;

        #endregion Private members.

        #region Protected properties.

        // Properties mapped to database columns.
        protected int? _IdGeneration
        {
            get
            {
                return this.idGeneration;
            }
            set
            {
                if (this.EntityState == EntityState.Synchronized)
                {
                    if ((!value.HasValue != !this.idGeneration.HasValue) || (value.HasValue && (value.Value != this.idGeneration.Value)))
                    {
                        this.EntityState = EntityState.OutOfSync;
                        this.InvalidateJsonValue();
                    }
                }
                this.idGeneration = value;
            }
        }

        protected bool? _Active
        {
            get
            {
                return this.active;
            }
            set
            {
                if (this.EntityState == EntityState.Synchronized)
                {
                    if ((!value.HasValue != !this.active.HasValue) || (value.HasValue && (value.Value != this.active.Value)))
                    {
                        this.EntityState = EntityState.OutOfSync;
                        this.InvalidateJsonValue();
                    }
                }
                this.active = value;
            }
        }

        #endregion Protected properties.

        #region Constructors.

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GenerationEntity()
            : base(new GenerationMeta())
        {
        }

        /// <summary>
        /// Constructor. Initalizes Table property with the specified (shared) instance.
        /// </summary>
        /// <param name="dbTable">Metadata for table/view to which the entity belongs to.</param>
        public GenerationEntity(GenerationMeta dbTable)
            : base(dbTable)
        {
        }

        /// <summary>
        /// Constructor. Initializes primary key. Useful for methods that don't require other values (eg. DeleteOne, SelectOne).
        /// </summary>
        public GenerationEntity(int idGeneration)
            : base(new GenerationMeta())
        {
            _IdGeneration = idGeneration;
        }

        /// <summary>
        /// Constructor. Initializes primary key. Useful for methods that don't require other values (eg. DeleteOne, SelectOne).
        /// </summary>
        public GenerationEntity(GenerationMeta dbTable, int idGeneration)
            : base(dbTable)
        {
            _IdGeneration = idGeneration;
        }

        /// <summary>
        /// Constructor. Initializes members with the values in the given DataRow.
        /// </summary>
        /// <param name="row">DataRow with required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public GenerationEntity(DataRow row)
            : base(new GenerationMeta())
        {
            FromDataRow(row);
        }

        /// <summary>
        /// Constructor. Initializes members with the values in the given DataRow.
        /// </summary>
        /// <param name="dbTable">Metadata for table/view to which the entity belongs to.</param>
        /// <param name="row">DataRow with required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public GenerationEntity(GenerationMeta dbTable, DataRow row)
            : base(dbTable)
        {
            FromDataRow(row);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="existing">Instance of GenerationEntity.</param>
        public GenerationEntity(GenerationEntity existing)
            : base(existing.Table)
        {
            FromExistingEntity(existing);
        }

        private static readonly Type DbTableClass = typeof(GenerationMeta);

        /// <summary>
        /// Initializes all members of GenerationEntity and base EntityModelBase class. This is the fastest way to initialize entity with data from database.
        /// </summary>
        private GenerationEntity(IDbTable table, EntityState entityState, int? idGeneration, bool? active)
            : base(table, DbTableClass, entityState)
        {
            this.idGeneration = idGeneration;
            this.active = active;
        }

        /// <summary>
        /// Initializes all members mapped to fields.
        /// </summary>
        protected void Init(int? idGeneration, bool? active)
        {
            _IdGeneration = idGeneration;
            _Active = active;
        }

        #endregion Constructors.

        #region Methods.

        /// <summary>
        /// Gets the value(s) that uniquely identifiy an entity.
        /// In the order as specified in accompanying IDbTable metadata class.
        /// NULL if the parent table/view doesn't have a primary key constraint or the required fields are not set.
        /// </summary>
        public override object[] GetPrimaryKeyValue()
        {
            if (_IdGeneration != null)
                return new object[] { _IdGeneration.Value };
            else
                return null;
        }

        /// <summary>
        /// Initializes entity members with data stored in the given DataRow.
        /// </summary>
        /// <param name="row">DataRow with the required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public override void FromDataRow(DataRow row)
        {
            object currentColumnValue;

            currentColumnValue = TryGetColumnValue(row, "IdGeneration");
            _IdGeneration = (currentColumnValue != DBNull.Value) ? (int?)Convert.ToInt32(currentColumnValue) : null;

            currentColumnValue = TryGetColumnValue(row, "Active");
            _Active = (currentColumnValue != DBNull.Value) ? (bool?)Convert.ToBoolean(currentColumnValue) : null;

            bool setEntityStateToSynchronized = (row.RowState == DataRowState.Unchanged);
            if (setEntityStateToSynchronized)
                this.EntityState = EntityState.Synchronized;
        }

        private static object TryGetColumnValue(DataRow row, string columnName)
        {
            int colIdx = row.Table.Columns.IndexOf(columnName);
            return (colIdx >= 0) ? row[colIdx] : null;
        }

        private static object GetColumnValue(DataRow row, IDbColumn column)
        {
            int colIdx = row.Table.Columns.IndexOf(column.Alias);
            if (colIdx < 0)
                colIdx = row.Table.Columns.IndexOf(column.ColumnName);
            if (colIdx < 0)
                throw new ArgumentException("DataTable doesn't contain the specified column (" + column.ColumnName + ").");

            return row[colIdx];
        }

        /// <summary>
        /// Initializes entity members with data stored in the given DataRow.
        /// </summary>
        /// <param name="row">DataRow with all or some of the columns defined in meta data.</param>
        /// <param name="fieldMetaData"><see cref="IDbTable"/> meta data object which links ADO.NET row columns to entity properties.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public override void FromDataRow(DataRow row, IDbTable fieldMetaData)
        {
            IDbColumn currentColumn;
            object currentColumnValue;

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.IdGeneration.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _IdGeneration = (currentColumnValue != DBNull.Value) ? (int?)Convert.ToInt32(currentColumnValue) : null;

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Active.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _Active = (currentColumnValue != DBNull.Value) ? (bool?)Convert.ToBoolean(currentColumnValue) : null;

            bool setEntityStateToSynchronized = (row.RowState == DataRowState.Unchanged);
            if (setEntityStateToSynchronized)
                this.EntityState = EntityState.Synchronized;
        }

        /// <summary>
        /// Converts the given DataRow to GenerationEntity.
        /// </summary>
        /// <param name="row">DataRow with required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public static explicit operator GenerationEntity(DataRow row)
        {
            return new GenerationEntity(row);
        }

        /// <summary>
        /// Creates an array of objects containing entity data.
        /// </summary>
        /// <returns>Entity values.</returns>
        public override object[] ToObjectArray()
        {
            object[] values = new object[2];

            values[0] = (_IdGeneration != null) ? (object)_IdGeneration.Value : null;
            values[1] = (_Active != null) ? (object)_Active.Value : null;

            return values;
        }

        /// <summary>
        /// Initializes entity members with the given values.
        /// </summary>
        /// <param name="entityValues">Array with the required values.</param>
        public override void FromObjectArray(object[] entityValues)
        {
            _IdGeneration = (entityValues[0] != null) ? (int?)Convert.ToInt32(entityValues[0]) : null;
            _Active = (entityValues[1] != null) ? (bool?)Convert.ToBoolean(entityValues[1]) : null;
        }

        /// <summary>
        /// Gets the parent entity defined by the given foreign key.
        /// </summary>
        /// <param name="foreignKey">FK which must be defined in the GenerationMeta class or an exception is generated.</param>
        /// <returns>Parent entity. NULL if the FK fields haven't been set or if the entity with the given key values doesn't exist.</returns>
        public override IEntity GetParent(DbRelation foreignKey)
        {
            throw new Exception("No foreign keys are defined in the GenerationMeta class.");
        }

        /// <summary>
        /// Sets the given value into the member that represents the parent entity defined by the foreign key.
        /// </summary>
        /// <param name="foreignKey">FK which must be defined in the CFunctionsMeta class or an exception is generated.</param>
        /// <param name="entity">Parent entity. May be NULL. Must be an instance of the CFunctionsEntity or a derived class.</param>
        public override void SetParent(DbRelation foreignKey, IEntity entity)
        {
            throw new Exception("No foreign keys are defined in the GenerationMeta class.");
        }

        #endregion Methods.

        /// <summary>
        /// Gets typed IDbTable object for the entity's table/view.
        /// </summary>
        [JsonIgnore]
        public GenerationMeta Table
        {
            get { return (GenerationMeta)_Table; }
        }

        #region Public properties mapped to database columns.

        /// <summary>
        /// Gets or sets the value which is mapped to the non-nullable field 'IdGeneration'.
        /// If null-check is enabled a NoNullAllowedException is thrown if getter is used before the value has been set.
        /// </summary>
        public virtual int IdGeneration
        {
            get
            {
                if (_IdGeneration == null)
                {
                    if (this.NullCheckEnabled)
                        throw new NoNullAllowedException("GenerationEntity.get_IdGeneration: IdGeneration is not set yet.");
                    else
                        return default(int);
                }

                return _IdGeneration.Value;
            }
            set
            {
                _IdGeneration = value;
            }
        }

        /// <summary>
        /// Gets or sets the value which is mapped to the non-nullable field 'Active'.
        /// If null-check is enabled a NoNullAllowedException is thrown if getter is used before the value has been set.
        /// </summary>
        public virtual bool Active
        {
            get
            {
                if (_Active == null)
                {
                    if (this.NullCheckEnabled)
                        throw new NoNullAllowedException("GenerationEntity.get_Active: Active is not set yet.");
                    else
                        return default(bool);
                }

                return _Active.Value;
            }
            set
            {
                _Active = value;
            }
        }

        #endregion Public properties mapped to database columns.

        #region NewEntity static methods suitable for usage in EntityBuilder<T>.

        /// <summary>Creates new entity and initializes all members of with the given values.</summary>
        /// <param name="table">Metadata for table/view to which the entity belongs to.</param>
        /// <param name="entityState">Indicates the state of entity with regard to data-source.</param>
        /// <param name="values">Array which contains values for all properties mapped to database columns in the following order: IdGeneration, Active.</param>
        /// <remarks>This is the fastest method to initialize an entity as it directly initializes all members of base and derived class,
        /// skips all validation checks and doesn't attempt to convert provided value data types. The method is typically used in combination
        /// with IDataConverter objects which retrieve property values directly from IDataReader objects.</remarks>
        public static GenerationEntity NewEntity(IDbTable table, EntityState entityState, object[] values)
        {
            return new GenerationEntity(table, entityState, (int)values[0], (bool)values[1]);
        }

        /// <summary>Creates new entity and initializes members for which values are defined in the array.</summary>
        /// <param name="table">Metadata for table/view to which the entity belongs to.</param>
        /// <param name="entityState">Indicates the state of entity with regard to data-source.</param>
        /// <param name="values">Array which contains values or nulls for all properties mapped to database columns in the following order: IdGeneration, Active.</param>
        /// <remarks>This is the fastest method to initialize an entity as it directly initializes all members of base and derived class,
        /// skips all validation checks and doesn't attempt to convert provided value data types. The method is typically used in combination
        /// with IObjectFiller objects which retrieve property values directly from IDataReader objects.</remarks>
        public static GenerationEntity NewPartialEntity(IDbTable table, EntityState entityState, object[] values)
        {
            return new GenerationEntity(table, entityState, CastTo<int>(values[0]), CastTo<bool>(values[1]));
        }

        private static T? CastTo<T>(object val)
            where T : struct
        {
            if (IsNull(val))
                return null;
            else
                return (T)val;
        }

        private static bool IsNull(object val)
        {
            return (val == DBNull.Value || val == null);
        }

        private static object ReplaceDbNull(object dbValue)
        {
            return (dbValue != DBNull.Value) ? dbValue : null;
        }

        #endregion NewEntity static methods suitable for usage in EntityBuilder<T>.

        #region Private connection-transaction context.

        /// <summary>
        /// This member is only accessed and initialized through _ConnectionProvider getter.
        /// </summary>
        [NonSerialized]
        private IConnectionProvider conn;

        /// <summary>
        /// Connection provider used by data-access methods. May be shared between methods.
        /// Eg. validate and save business object using the same open connection.
        /// </summary>
        protected virtual IConnectionProvider _ConnectionProvider
        {
            get
            {
                if (this.conn == null)
                    this.conn = Table.Catalog.CreateConnectionProvider();
                return this.conn;
            }
            set { this.conn = value; }
        }

        #endregion Private connection-transaction context.

        #region IsNew.

        /// <summary>
        /// Gets the value which indicates whether the entity is new or existing, ie. retrieved from database.
        /// </summary>
        [JsonIgnore]
        public virtual bool IsNew
        {
            get
            {
                bool isNew = (this.EntityState == EntityState.New);
                return isNew;
            }
        }

        #endregion IsNew.
    }

    /// <summary>
    /// Typed IDbTable class for the table/view 'Generation'.
    /// </summary>
    [Serializable]
    public sealed class GenerationMeta : SealedDbTable
    {
        static GenerationMeta()
        {
            ReadSequenceOverrideFromConfig();
            ReadColumnNamesFromConfig();
            ImmutableColumnProperties = CreateImmutableColumnProperties();
            ImmutableTableProperties = CreateImmutableTableProperties();
        }

        #region Configuration.

        private static readonly string[] SequenceNameOverrides = new string[2];
        private static readonly bool?[] AutoIncrementOverrides = new bool?[2];

        private static void ReadSequenceOverrideFromConfig()
        {
            SequenceNameOverrides[0] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Generation.IdGeneration.SequenceName"];
            AutoIncrementOverrides[0] = (SequenceNameOverrides[0] != null) ? (bool?)true : null;
            SequenceNameOverrides[1] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Generation.Active.SequenceName"];
            AutoIncrementOverrides[1] = (SequenceNameOverrides[1] != null) ? (bool?)true : null;
        }

        private static readonly string[] ColumnNames = new string[2];

        private static void ReadColumnNamesFromConfig()
        {
            ColumnNames[0] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Generation", "IdGeneration") ?? "IdGeneration";
            ColumnNames[1] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Generation", "Active") ?? "Active";
        }

        #endregion Configuration.

        #region Singleton/immutable configuration objects.

        private static readonly DbColumnConfiguration[] ImmutableColumnProperties;
        private static readonly DbTableConfiguration ImmutableTableProperties;

        private static DbColumnConfiguration[] CreateImmutableColumnProperties()
        {
            return new DbColumnConfiguration[]
			{
				new DbColumnConfiguration(ColumnNames[0], DbType.Int32, typeof(int), false, 0, true, null, 0, true, false, false, "IdGeneration", int.MinValue, int.MaxValue, false, SequenceNameOverrides[0]),
				new DbColumnConfiguration(ColumnNames[1], DbType.Boolean, typeof(bool), false, 1, AutoIncrementOverrides[1] ?? false, null, 0, false, false, false, "Active", null, null, false, SequenceNameOverrides[1]),
			};
        }

        private static DbTableConfiguration CreateImmutableTableProperties()
        {
            return new DbTableConfiguration
            (
                Fistnet.FistBot.DAL.Catalog.GetTableNameOverride("Generation") ?? "Generation",
                new Fistnet.FistBot.DAL.Catalog(),
                ImmutableColumnProperties,
                new int[] { 0 },
                new string[] { }
            );
        }

        #endregion Singleton/immutable configuration objects.

        #region Constructors.

        /// <summary>
        /// Initializes a new instance of GenerationMeta class.
        /// </summary>
        public GenerationMeta()
            : base(ImmutableTableProperties, null, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of GenerationMeta class.
        /// </summary>
        /// <param name="alias">Object alias. If NULL then it will be equal to the table name.</param>
        public GenerationMeta(string alias)
            : base(ImmutableTableProperties, alias, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of GenerationMeta class.
        /// </summary>
        /// <param name="setPrefixedColumnAliases">Whether to change aliases of all columns so that they start with prefix (usually table name).</param>
        public GenerationMeta(bool setPrefixedColumnAliases)
            : base(ImmutableTableProperties, null, setPrefixedColumnAliases)
        {
        }

        /// <summary>
        /// Initializes a new instance of GenerationMeta class.
        /// </summary>
        /// <param name="alias">Object alias. If NULL then it will be equal to the table name.</param>
        /// <param name="setPrefixedColumnAliases">Whether to change aliases of all columns so that they start with prefix (usually table name).</param>
        public GenerationMeta(string alias, bool setPrefixedColumnAliases)
            : base(ImmutableTableProperties, alias, setPrefixedColumnAliases)
        {
        }

        #endregion Constructors.

        #region CreateForeignKeys.

        /// <summary>
        /// Initializes an array of relations used by foreign keys.
        /// Only relations to other generated IDbTable classes are created.
        /// </summary>
        protected override DbRelation[] CreateForeignKeys()
        {
            DbRelation[] foreignKeys = new DbRelation[0];

            return foreignKeys;
        }

        #endregion CreateForeignKeys.

        #region New* methods.

        /// <summary>
        /// Creates a new GenerationEntity object.
        /// </summary>
        /// <returns>New entity.</returns>
        public override IEntity NewEntity()
        {
            return new GenerationEntity(this);
        }

        /// <summary>
        /// Creates a new empty EntityCollection<GenerationEntity, GenerationMeta>.
        /// </summary>
        /// <returns>Empty collection.</returns>
        public override IEntityCollection NewEntityCollection()
        {
            return new EntityCollection<GenerationEntity, GenerationMeta>(this);
        }

        /// <summary>
        /// Creates a new EntityFiller&lt;GenerationEntity&gt; object.
        /// </summary>
        /// <returns>An instance of EntityFiller&lt;GenerationEntity&gt; class.</returns>
        public override IObjectFiller NewEntityFiller()
        {
            // Use default EntityFiller<T>() constructor when targeting SQLite database or when column types are compatible/convertible, but do not exactly match, entity property types.
            return new EntityFiller<GenerationEntity>(GenerationEntity.NewEntity);
        }

        #endregion New* methods.

        #region Clone.

        /// <summary>
        /// Creates another IDbTable object for the same table/view.
        /// </summary>
        /// <param name="cloneAlias">Clone alias.</param>
        /// <returns>Clone.</returns>
        public override IDbTable Clone(string cloneAlias)
        {
            return new GenerationMeta(cloneAlias);
        }

        /// <summary>
        /// Creates another IDbTable object for the same table/view.
        /// </summary>
        /// <param name="cloneAlias">Clone alias.</param>
        /// <param name="setPrefixedAliases">Specifies whether cloned columns will have prefixed aliases.</param>
        /// <returns>Clone.</returns>
        public override IDbTable Clone(string cloneAlias, bool setPrefixedAliases)
        {
            return new GenerationMeta(cloneAlias, setPrefixedAliases);
        }

        #endregion Clone.

        #region Columns.

        /// <summary>
        /// Gets metadata for 'IdGeneration' column.
        /// </summary>
        public IDbColumn IdGeneration
        {
            get { return this.Columns[0]; }
        }

        /// <summary>
        /// Gets metadata for 'Active' column.
        /// </summary>
        public IDbColumn Active
        {
            get { return this.Columns[1]; }
        }

        #endregion Columns.

        #region Foreign keys.

        #endregion Foreign keys.

        #region Parent entity property name getters.

        #endregion Parent entity property name getters.

        #region Children.

        /// <summary>
        /// Gets tables which reference the current table.
        /// </summary>
        /// <returns>Array of tables or empty array if the current table is not referenced by other objects.</returns>
        public override IDbTable[] GetChildTables()
        {
            return new IDbTable[]
			{
				new StrategyMeta()
			};
        }

        /// <summary>
        /// Gets relations where current table acts as a parent.
        /// </summary>
        /// <returns>Array of relations or empty array if the current table is not referenced by other objects.</returns>
        public override DbRelation[] GetChildRelations()
        {
            return new DbRelation[]
			{
				new StrategyMeta().FK_IdGeneration
			};
        }

        #endregion Children.
    }
}