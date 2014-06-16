// FistCore generated entity and metadata classes for Strategy.
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
    /// Entity model class for the table/view 'Strategy'.
    /// </summary>
    [Serializable]
    public class StrategyEntity : EntityModelBase
    {
        #region Private members.

        // Members mapped to database columns.
        private int? id;

        private int? idGeneration;
        private string strategy;
        private bool? used;
        private decimal? fitness;

        // Members mapped to foreign keys.
        private GenerationEntity generationParent;

        #endregion Private members.

        #region Protected properties.

        // Properties mapped to database columns.
        protected int? _Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.EntityState == EntityState.Synchronized)
                {
                    if ((!value.HasValue != !this.id.HasValue) || (value.HasValue && (value.Value != this.id.Value)))
                    {
                        this.EntityState = EntityState.OutOfSync;
                        this.InvalidateJsonValue();
                    }
                }
                this.id = value;
            }
        }

        protected string _Strategy
        {
            get
            {
                return this.strategy;
            }
            set
            {
                if (this.EntityState == EntityState.Synchronized)
                {
                    if (value != this.strategy)
                    {
                        this.EntityState = EntityState.OutOfSync;
                        this.InvalidateJsonValue();
                    }
                }
                this.strategy = value;
            }
        }

        protected bool? _Used
        {
            get
            {
                return this.used;
            }
            set
            {
                if (this.EntityState == EntityState.Synchronized)
                {
                    if ((!value.HasValue != !this.used.HasValue) || (value.HasValue && (value.Value != this.used.Value)))
                    {
                        this.EntityState = EntityState.OutOfSync;
                        this.InvalidateJsonValue();
                    }
                }
                this.used = value;
            }
        }

        protected decimal? _Fitness
        {
            get
            {
                return this.fitness;
            }
            set
            {
                if (this.EntityState == EntityState.Synchronized)
                {
                    if ((!value.HasValue != !this.fitness.HasValue) || (value.HasValue && (value.Value != this.fitness.Value)))
                    {
                        this.EntityState = EntityState.OutOfSync;
                        this.InvalidateJsonValue();
                    }
                }
                this.fitness = value;
            }
        }

        // Properties mapped to foreign keys.
        protected int? _IdGeneration
        {
            get
            {
                return this.idGeneration;
            }
            set
            {
                bool hasChanged = (!value.HasValue != !_IdGeneration.HasValue) || (value.HasValue && (value.Value != _IdGeneration.Value));
                if (!hasChanged)
                    return;

                if (hasChanged && this.EntityState == EntityState.Synchronized)
                {
                    this.EntityState = EntityState.OutOfSync;
                    this.InvalidateJsonValue();
                }

                this.idGeneration = value;
                this.generationParent = null;
            }
        }

        #endregion Protected properties.

        #region Constructors.

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StrategyEntity()
            : base(new StrategyMeta())
        {
        }

        /// <summary>
        /// Constructor. Initalizes Table property with the specified (shared) instance.
        /// </summary>
        /// <param name="dbTable">Metadata for table/view to which the entity belongs to.</param>
        public StrategyEntity(StrategyMeta dbTable)
            : base(dbTable)
        {
        }

        /// <summary>
        /// Constructor. Initializes primary key. Useful for methods that don't require other values (eg. DeleteOne, SelectOne).
        /// </summary>
        public StrategyEntity(int id)
            : base(new StrategyMeta())
        {
            _Id = id;
        }

        /// <summary>
        /// Constructor. Initializes primary key. Useful for methods that don't require other values (eg. DeleteOne, SelectOne).
        /// </summary>
        public StrategyEntity(StrategyMeta dbTable, int id)
            : base(dbTable)
        {
            _Id = id;
        }

        /// <summary>
        /// Constructor. Initializes members with the values in the given DataRow.
        /// </summary>
        /// <param name="row">DataRow with required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public StrategyEntity(DataRow row)
            : base(new StrategyMeta())
        {
            FromDataRow(row);
        }

        /// <summary>
        /// Constructor. Initializes members with the values in the given DataRow.
        /// </summary>
        /// <param name="dbTable">Metadata for table/view to which the entity belongs to.</param>
        /// <param name="row">DataRow with required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public StrategyEntity(StrategyMeta dbTable, DataRow row)
            : base(dbTable)
        {
            FromDataRow(row);
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="existing">Instance of StrategyEntity.</param>
        public StrategyEntity(StrategyEntity existing)
            : base(existing.Table)
        {
            FromExistingEntity(existing);
        }

        private static readonly Type DbTableClass = typeof(StrategyMeta);

        /// <summary>
        /// Initializes all members of StrategyEntity and base EntityModelBase class. This is the fastest way to initialize entity with data from database.
        /// </summary>
        private StrategyEntity(IDbTable table, EntityState entityState, int? id, int? idGeneration, string strategy, bool? used, decimal? fitness)
            : base(table, DbTableClass, entityState)
        {
            this.id = id;
            this.idGeneration = idGeneration;
            this.strategy = strategy;
            this.used = used;
            this.fitness = fitness;
        }

        /// <summary>
        /// Initializes all members mapped to fields.
        /// </summary>
        protected void Init(int? id, int? idGeneration, string strategy, bool? used, decimal? fitness)
        {
            _Id = id;
            _IdGeneration = idGeneration;
            _Strategy = strategy;
            _Used = used;
            _Fitness = fitness;
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
            if (_Id != null)
                return new object[] { _Id.Value };
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

            currentColumnValue = TryGetColumnValue(row, "Id");
            _Id = (currentColumnValue != DBNull.Value) ? (int?)Convert.ToInt32(currentColumnValue) : null;

            currentColumnValue = TryGetColumnValue(row, "IdGeneration");
            _IdGeneration = (currentColumnValue != DBNull.Value) ? (int?)Convert.ToInt32(currentColumnValue) : null;

            currentColumnValue = TryGetColumnValue(row, "Strategy");
            _Strategy = (currentColumnValue != DBNull.Value) ? (string)Convert.ToString(currentColumnValue) : null;

            currentColumnValue = TryGetColumnValue(row, "Used");
            _Used = (currentColumnValue != DBNull.Value) ? (bool?)Convert.ToBoolean(currentColumnValue) : null;

            currentColumnValue = TryGetColumnValue(row, "Fitness");
            _Fitness = (currentColumnValue != DBNull.Value) ? (decimal?)Convert.ToDecimal(currentColumnValue) : null;

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

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Id.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _Id = (currentColumnValue != DBNull.Value) ? (int?)Convert.ToInt32(currentColumnValue) : null;

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.IdGeneration.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _IdGeneration = (currentColumnValue != DBNull.Value) ? (int?)Convert.ToInt32(currentColumnValue) : null;

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Strategy.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _Strategy = (currentColumnValue != DBNull.Value) ? (string)Convert.ToString(currentColumnValue) : null;

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Used.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _Used = (currentColumnValue != DBNull.Value) ? (bool?)Convert.ToBoolean(currentColumnValue) : null;

            currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Fitness.PropertyName);
            currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
            _Fitness = (currentColumnValue != DBNull.Value) ? (decimal?)Convert.ToDecimal(currentColumnValue) : null;

            bool setEntityStateToSynchronized = (row.RowState == DataRowState.Unchanged);
            if (setEntityStateToSynchronized)
                this.EntityState = EntityState.Synchronized;
        }

        /// <summary>
        /// Converts the given DataRow to StrategyEntity.
        /// </summary>
        /// <param name="row">DataRow with required columns.</param>
        /// <remarks>If row's state is <see cref="DataRowState.Unchanged"/> the entity's state will be set to <see cref="EntityState.Synchronized"/>. Other states are ignored.</remarks>
        public static explicit operator StrategyEntity(DataRow row)
        {
            return new StrategyEntity(row);
        }

        /// <summary>
        /// Creates an array of objects containing entity data.
        /// </summary>
        /// <returns>Entity values.</returns>
        public override object[] ToObjectArray()
        {
            object[] values = new object[5];

            values[0] = (_Id != null) ? (object)_Id.Value : null;
            values[1] = (_IdGeneration != null) ? (object)_IdGeneration.Value : null;
            values[2] = (_Strategy != null) ? (object)_Strategy : null;
            values[3] = (_Used != null) ? (object)_Used.Value : null;
            values[4] = (_Fitness != null) ? (object)_Fitness.Value : null;

            return values;
        }

        /// <summary>
        /// Initializes entity members with the given values.
        /// </summary>
        /// <param name="entityValues">Array with the required values.</param>
        public override void FromObjectArray(object[] entityValues)
        {
            _Id = (entityValues[0] != null) ? (int?)Convert.ToInt32(entityValues[0]) : null;
            _IdGeneration = (entityValues[1] != null) ? (int?)Convert.ToInt32(entityValues[1]) : null;
            _Strategy = (entityValues[2] != null) ? (string)Convert.ToString(entityValues[2]) : null;
            _Used = (entityValues[3] != null) ? (bool?)Convert.ToBoolean(entityValues[3]) : null;
            _Fitness = (entityValues[4] != null) ? (decimal?)Convert.ToDecimal(entityValues[4]) : null;
        }

        /// <summary>
        /// Gets the parent entity defined by the given foreign key.
        /// </summary>
        /// <param name="foreignKey">FK which must be defined in the StrategyMeta class or an exception is generated.</param>
        /// <returns>Parent entity. NULL if the FK fields haven't been set or if the entity with the given key values doesn't exist.</returns>
        public override IEntity GetParent(DbRelation foreignKey)
        {
            IEntity parent;
            if (foreignKey.HasEqualForeignKeyFieldsAs(this.Table.FK_IdGeneration))
                parent = this.GenerationParent;
            else
                throw new Exception("Provided FK doesn't match any FK defined in the StrategyMeta class.");

            return parent;
        }

        /// <summary>
        /// Sets the given value into the member that represents the parent entity defined by the foreign key.
        /// </summary>
        /// <param name="foreignKey">FK which must be defined in the CFunctionsMeta class or an exception is generated.</param>
        /// <param name="entity">Parent entity. May be NULL. Must be an instance of the CFunctionsEntity or a derived class.</param>
        public override void SetParent(DbRelation foreignKey, IEntity entity)
        {
            // Use public parent properties because setters set both the parent member and the members mapped to foreign key fields.
            if (foreignKey.HasEqualForeignKeyFieldsAs(this.Table.FK_IdGeneration))
                this.GenerationParent = (GenerationEntity)entity;
            else
                throw new Exception("Provided FK doesn't match any FK defined in the StrategyMeta class.");
        }

        #endregion Methods.

        /// <summary>
        /// Gets typed IDbTable object for the entity's table/view.
        /// </summary>
        [JsonIgnore]
        public StrategyMeta Table
        {
            get { return (StrategyMeta)_Table; }
        }

        #region Public properties mapped to database columns.

        /// <summary>
        /// Gets or sets the value which is mapped to the non-nullable field 'Id'.
        /// If null-check is enabled a NoNullAllowedException is thrown if getter is used before the value has been set.
        /// </summary>
        public virtual int Id
        {
            get
            {
                if (_Id == null)
                {
                    if (this.NullCheckEnabled)
                        throw new NoNullAllowedException("StrategyEntity.get_Id: Id is not set yet.");
                    else
                        return default(int);
                }

                return _Id.Value;
            }
            set
            {
                _Id = value;
            }
        }

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
                        throw new NoNullAllowedException("StrategyEntity.get_IdGeneration: IdGeneration is not set yet.");
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
        /// Gets or sets the value which is mapped to the non-nullable field 'Strategy'.
        /// </summary>
        public virtual string Strategy
        {
            get
            {
                return _Strategy;
            }
            set
            {
                _Strategy = value;
            }
        }

        /// <summary>
        /// Gets or sets the value which is mapped to the non-nullable field 'Used'.
        /// If null-check is enabled a NoNullAllowedException is thrown if getter is used before the value has been set.
        /// </summary>
        public virtual bool Used
        {
            get
            {
                if (_Used == null)
                {
                    if (this.NullCheckEnabled)
                        throw new NoNullAllowedException("StrategyEntity.get_Used: Used is not set yet.");
                    else
                        return default(bool);
                }

                return _Used.Value;
            }
            set
            {
                _Used = value;
            }
        }

        /// <summary>
        /// Gets or sets the value which is mapped to the nullable field 'Fitness'.
        /// </summary>
        public virtual decimal? Fitness
        {
            get
            {
                return _Fitness;
            }
            set
            {
                _Fitness = value;
            }
        }

        #endregion Public properties mapped to database columns.

        #region Foreign key properties.

        /// <summary>
        /// Gets or sets the parent GenerationEntity object defined by values stored in "IdGeneration" column(s).
        /// Parent object must be manually fetched. This class doesn't implement automatic database navigation through relations.
        /// </summary>
        [JsonIgnore]
        public virtual GenerationEntity GenerationParent
        {
            get
            {
                return this.generationParent;
            }
            set
            {
                if (value != null)
                {
                    _IdGeneration = value.IdGeneration;
                }
                else
                {
                    _IdGeneration = null;
                }
                this.generationParent = value;
            }
        }

        #endregion Foreign key properties.

        #region NewEntity static methods suitable for usage in EntityBuilder<T>.

        /// <summary>Creates new entity and initializes all members of with the given values.</summary>
        /// <param name="table">Metadata for table/view to which the entity belongs to.</param>
        /// <param name="entityState">Indicates the state of entity with regard to data-source.</param>
        /// <param name="values">Array which contains values for all properties mapped to database columns in the following order: Id, IdGeneration, Strategy, Used, Fitness.</param>
        /// <remarks>This is the fastest method to initialize an entity as it directly initializes all members of base and derived class,
        /// skips all validation checks and doesn't attempt to convert provided value data types. The method is typically used in combination
        /// with IDataConverter objects which retrieve property values directly from IDataReader objects.</remarks>
        public static StrategyEntity NewEntity(IDbTable table, EntityState entityState, object[] values)
        {
            return new StrategyEntity(table, entityState, (int)values[0], (int)values[1], (string)values[2], (bool)values[3], CastTo<decimal>(values[4]));
        }

        /// <summary>Creates new entity and initializes members for which values are defined in the array.</summary>
        /// <param name="table">Metadata for table/view to which the entity belongs to.</param>
        /// <param name="entityState">Indicates the state of entity with regard to data-source.</param>
        /// <param name="values">Array which contains values or nulls for all properties mapped to database columns in the following order: Id, IdGeneration, Strategy, Used, Fitness.</param>
        /// <remarks>This is the fastest method to initialize an entity as it directly initializes all members of base and derived class,
        /// skips all validation checks and doesn't attempt to convert provided value data types. The method is typically used in combination
        /// with IObjectFiller objects which retrieve property values directly from IDataReader objects.</remarks>
        public static StrategyEntity NewPartialEntity(IDbTable table, EntityState entityState, object[] values)
        {
            return new StrategyEntity(table, entityState, CastTo<int>(values[0]), CastTo<int>(values[1]), (string)ReplaceDbNull(values[2]), CastTo<bool>(values[3]), CastTo<decimal>(values[4]));
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
    /// Typed IDbTable class for the table/view 'Strategy'.
    /// </summary>
    [Serializable]
    public sealed class StrategyMeta : SealedDbTable
    {
        static StrategyMeta()
        {
            ReadSequenceOverrideFromConfig();
            ReadColumnNamesFromConfig();
            ImmutableColumnProperties = CreateImmutableColumnProperties();
            ImmutableTableProperties = CreateImmutableTableProperties();
        }

        #region Configuration.

        private static readonly string[] SequenceNameOverrides = new string[5];
        private static readonly bool?[] AutoIncrementOverrides = new bool?[5];

        private static void ReadSequenceOverrideFromConfig()
        {
            SequenceNameOverrides[0] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.Id.SequenceName"];
            AutoIncrementOverrides[0] = (SequenceNameOverrides[0] != null) ? (bool?)true : null;
            SequenceNameOverrides[1] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.IdGeneration.SequenceName"];
            AutoIncrementOverrides[1] = (SequenceNameOverrides[1] != null) ? (bool?)true : null;
            SequenceNameOverrides[2] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.Strategy.SequenceName"];
            AutoIncrementOverrides[2] = (SequenceNameOverrides[2] != null) ? (bool?)true : null;
            SequenceNameOverrides[3] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.Used.SequenceName"];
            AutoIncrementOverrides[3] = (SequenceNameOverrides[3] != null) ? (bool?)true : null;
            SequenceNameOverrides[4] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.Fitness.SequenceName"];
            AutoIncrementOverrides[4] = (SequenceNameOverrides[4] != null) ? (bool?)true : null;
        }

        private static readonly string[] ColumnNames = new string[5];

        private static void ReadColumnNamesFromConfig()
        {
            ColumnNames[0] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Id") ?? "Id";
            ColumnNames[1] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "IdGeneration") ?? "IdGeneration";
            ColumnNames[2] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Strategy") ?? "Strategy";
            ColumnNames[3] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Used") ?? "Used";
            ColumnNames[4] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Fitness") ?? "Fitness";
        }

        #endregion Configuration.

        #region Singleton/immutable configuration objects.

        private static readonly DbColumnConfiguration[] ImmutableColumnProperties;
        private static readonly DbTableConfiguration ImmutableTableProperties;

        private static DbColumnConfiguration[] CreateImmutableColumnProperties()
        {
            return new DbColumnConfiguration[]
			{
				new DbColumnConfiguration(ColumnNames[0], DbType.Int32, typeof(int), false, 0, true, null, 0, true, false, false, "Id", int.MinValue, int.MaxValue, false, SequenceNameOverrides[0]),
				new DbColumnConfiguration(ColumnNames[1], DbType.Int32, typeof(int), false, 1, AutoIncrementOverrides[1] ?? false, null, 0, false, true, false, "IdGeneration", int.MinValue, int.MaxValue, false, SequenceNameOverrides[1]),
				new DbColumnConfiguration(ColumnNames[2], DbType.String, typeof(string), false, 2, AutoIncrementOverrides[2] ?? false, null, 0, false, false, false, "Strategy", null, null, false, SequenceNameOverrides[2]),
				new DbColumnConfiguration(ColumnNames[3], DbType.Boolean, typeof(bool), false, 3, AutoIncrementOverrides[3] ?? false, null, 0, false, false, false, "Used", null, null, false, SequenceNameOverrides[3]),
				new DbColumnConfiguration(ColumnNames[4], DbType.Decimal, typeof(decimal), true, 4, AutoIncrementOverrides[4] ?? false, null, 0, false, false, false, "Fitness", -999999999999.999999, 999999999999.999999, false, SequenceNameOverrides[4]),
			};
        }

        private static DbTableConfiguration CreateImmutableTableProperties()
        {
            return new DbTableConfiguration
            (
                Fistnet.FistBot.DAL.Catalog.GetTableNameOverride("Strategy") ?? "Strategy",
                new Fistnet.FistBot.DAL.Catalog(),
                ImmutableColumnProperties,
                new int[] { 0 },
                new string[] { "GenerationParent" }
            );
        }

        #endregion Singleton/immutable configuration objects.

        #region Constructors.

        /// <summary>
        /// Initializes a new instance of StrategyMeta class.
        /// </summary>
        public StrategyMeta()
            : base(ImmutableTableProperties, null, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of StrategyMeta class.
        /// </summary>
        /// <param name="alias">Object alias. If NULL then it will be equal to the table name.</param>
        public StrategyMeta(string alias)
            : base(ImmutableTableProperties, alias, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of StrategyMeta class.
        /// </summary>
        /// <param name="setPrefixedColumnAliases">Whether to change aliases of all columns so that they start with prefix (usually table name).</param>
        public StrategyMeta(bool setPrefixedColumnAliases)
            : base(ImmutableTableProperties, null, setPrefixedColumnAliases)
        {
        }

        /// <summary>
        /// Initializes a new instance of StrategyMeta class.
        /// </summary>
        /// <param name="alias">Object alias. If NULL then it will be equal to the table name.</param>
        /// <param name="setPrefixedColumnAliases">Whether to change aliases of all columns so that they start with prefix (usually table name).</param>
        public StrategyMeta(string alias, bool setPrefixedColumnAliases)
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
            DbRelation[] foreignKeys = new DbRelation[1];

            GenerationMeta generationParent = new GenerationMeta();
            foreignKeys[0] = new DbRelation(generationParent, new IDbColumn[] { generationParent.IdGeneration }, this, new IDbColumn[] { this.IdGeneration }, "FK_Strategy_Generation");

            return foreignKeys;
        }

        #endregion CreateForeignKeys.

        #region New* methods.

        /// <summary>
        /// Creates an array of objects that contains primary key values in the order as defined by this class.
        /// </summary>
        public object[] NewPrimaryKeyValue(int id)
        {
            object[] pkValues = new object[1];
            pkValues[0] = id;

            return pkValues;
        }

        /// <summary>
        /// Creates a new StrategyEntity object.
        /// </summary>
        /// <returns>New entity.</returns>
        public override IEntity NewEntity()
        {
            return new StrategyEntity(this);
        }

        /// <summary>
        /// Creates a new empty EntityCollection<StrategyEntity, StrategyMeta>.
        /// </summary>
        /// <returns>Empty collection.</returns>
        public override IEntityCollection NewEntityCollection()
        {
            return new EntityCollection<StrategyEntity, StrategyMeta>(this);
        }

        /// <summary>
        /// Creates a new EntityFiller&lt;StrategyEntity&gt; object.
        /// </summary>
        /// <returns>An instance of EntityFiller&lt;StrategyEntity&gt; class.</returns>
        public override IObjectFiller NewEntityFiller()
        {
            // Use default EntityFiller<T>() constructor when targeting SQLite database or when column types are compatible/convertible, but do not exactly match, entity property types.
            return new EntityFiller<StrategyEntity>(StrategyEntity.NewEntity);
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
            return new StrategyMeta(cloneAlias);
        }

        /// <summary>
        /// Creates another IDbTable object for the same table/view.
        /// </summary>
        /// <param name="cloneAlias">Clone alias.</param>
        /// <param name="setPrefixedAliases">Specifies whether cloned columns will have prefixed aliases.</param>
        /// <returns>Clone.</returns>
        public override IDbTable Clone(string cloneAlias, bool setPrefixedAliases)
        {
            return new StrategyMeta(cloneAlias, setPrefixedAliases);
        }

        #endregion Clone.

        #region Columns.

        /// <summary>
        /// Gets metadata for 'Id' column.
        /// </summary>
        public IDbColumn Id
        {
            get { return this.Columns[0]; }
        }

        /// <summary>
        /// Gets metadata for 'IdGeneration' column.
        /// </summary>
        public IDbColumn IdGeneration
        {
            get { return this.Columns[1]; }
        }

        /// <summary>
        /// Gets metadata for 'Strategy' column.
        /// </summary>
        public IDbColumn Strategy
        {
            get { return this.Columns[2]; }
        }

        /// <summary>
        /// Gets metadata for 'Used' column.
        /// </summary>
        public IDbColumn Used
        {
            get { return this.Columns[3]; }
        }

        /// <summary>
        /// Gets metadata for 'Fitness' column.
        /// </summary>
        public IDbColumn Fitness
        {
            get { return this.Columns[4]; }
        }

        #endregion Columns.

        #region Foreign keys.

        /// <summary>
        /// Gets relation to Generation table established by "IdGeneration" column(s).
        /// </summary>
        [JsonIgnore]
        public DbRelation FK_IdGeneration
        {
            get { return this.ForeignKeys[0]; }
        }

        #endregion Foreign keys.

        #region Parent entity property name getters.

        /// <summary>
        /// Gets the full property path for fields which belong to the "GenerationParent" object. Eg: "GenerationParent.Id".
        /// </summary>
        /// <param name="parentColumn">Parent entity field. If null only "GenerationParent" is returned.</param>
        /// <returns>Parent entity property name followed by dot operator and parent field property name if <b>parentColumn</b> is defined; otherwise only parent entity property name.</returns>
        public string GetGenerationParentProperty(IDbColumn parentColumn)
        {
            return GetParentProperty(0, parentColumn);
        }

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
			};
        }

        #endregion Children.
    }
}