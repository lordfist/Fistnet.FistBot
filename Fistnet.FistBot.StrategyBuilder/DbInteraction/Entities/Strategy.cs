// FistCore generated entity and metadata classes for Strategy.
using System;
using System.Data;
using System.Configuration;
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
		private int? bulletHit;
		private int? bulletMiss;
		private int? victoryCount;
		private int? totalBulletDamage;
		private int? myBulletDamage;
		private int? totalRamDamage;
		private int? myRamDamage;
		private int? totalSurvivor;
		private int? mySurvivor;
		private int? totalScore;
		private int? myScore;
		private int? deathAfterTicks;
		private int? selfDamage;
		
		// Members mapped to foreign keys.
		private GenerationEntity generationParent;

		#endregion

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

		protected int? _BulletHit
		{
			get
			{
				return this.bulletHit;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.bulletHit.HasValue) || (value.HasValue && (value.Value != this.bulletHit.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.bulletHit = value;
			}
		}

		protected int? _BulletMiss
		{
			get
			{
				return this.bulletMiss;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.bulletMiss.HasValue) || (value.HasValue && (value.Value != this.bulletMiss.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.bulletMiss = value;
			}
		}

		protected int? _VictoryCount
		{
			get
			{
				return this.victoryCount;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.victoryCount.HasValue) || (value.HasValue && (value.Value != this.victoryCount.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.victoryCount = value;
			}
		}

		protected int? _TotalBulletDamage
		{
			get
			{
				return this.totalBulletDamage;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.totalBulletDamage.HasValue) || (value.HasValue && (value.Value != this.totalBulletDamage.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.totalBulletDamage = value;
			}
		}

		protected int? _MyBulletDamage
		{
			get
			{
				return this.myBulletDamage;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.myBulletDamage.HasValue) || (value.HasValue && (value.Value != this.myBulletDamage.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.myBulletDamage = value;
			}
		}

		protected int? _TotalRamDamage
		{
			get
			{
				return this.totalRamDamage;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.totalRamDamage.HasValue) || (value.HasValue && (value.Value != this.totalRamDamage.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.totalRamDamage = value;
			}
		}

		protected int? _MyRamDamage
		{
			get
			{
				return this.myRamDamage;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.myRamDamage.HasValue) || (value.HasValue && (value.Value != this.myRamDamage.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.myRamDamage = value;
			}
		}

		protected int? _TotalSurvivor
		{
			get
			{
				return this.totalSurvivor;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.totalSurvivor.HasValue) || (value.HasValue && (value.Value != this.totalSurvivor.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.totalSurvivor = value;
			}
		}

		protected int? _MySurvivor
		{
			get
			{
				return this.mySurvivor;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.mySurvivor.HasValue) || (value.HasValue && (value.Value != this.mySurvivor.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.mySurvivor = value;
			}
		}

		protected int? _TotalScore
		{
			get
			{
				return this.totalScore;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.totalScore.HasValue) || (value.HasValue && (value.Value != this.totalScore.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.totalScore = value;
			}
		}

		protected int? _MyScore
		{
			get
			{
				return this.myScore;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.myScore.HasValue) || (value.HasValue && (value.Value != this.myScore.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.myScore = value;
			}
		}

		protected int? _DeathAfterTicks
		{
			get
			{
				return this.deathAfterTicks;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.deathAfterTicks.HasValue) || (value.HasValue && (value.Value != this.deathAfterTicks.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.deathAfterTicks = value;
			}
		}

		protected int? _SelfDamage
		{
			get
			{
				return this.selfDamage;
			}
			set
			{
				if (this.EntityState == EntityState.Synchronized)
				{
					if ((!value.HasValue != !this.selfDamage.HasValue) || (value.HasValue && (value.Value != this.selfDamage.Value)))
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }
				}
				this.selfDamage = value;
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

				if (hasChanged  && this.EntityState == EntityState.Synchronized)
				  {
						this.EntityState = EntityState.OutOfSync;
				    this.InvalidateJsonValue();
				  }

				this.idGeneration = value;
				this.generationParent = null;
			}
		}
      
		#endregion

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

		static readonly Type DbTableClass = typeof(StrategyMeta);

		/// <summary>
		/// Initializes all members of StrategyEntity and base EntityModelBase class. This is the fastest way to initialize entity with data from database.
		/// </summary>
		private StrategyEntity(IDbTable table, EntityState entityState, int? id, int? idGeneration, string strategy, bool? used, decimal? fitness, int? bulletHit, int? bulletMiss, int? victoryCount, int? totalBulletDamage, int? myBulletDamage, int? totalRamDamage, int? myRamDamage, int? totalSurvivor, int? mySurvivor, int? totalScore, int? myScore, int? deathAfterTicks, int? selfDamage)
			 : base(table, DbTableClass, entityState)
		{
			this.id = id;
			this.idGeneration = idGeneration;
			this.strategy = strategy;
			this.used = used;
			this.fitness = fitness;
			this.bulletHit = bulletHit;
			this.bulletMiss = bulletMiss;
			this.victoryCount = victoryCount;
			this.totalBulletDamage = totalBulletDamage;
			this.myBulletDamage = myBulletDamage;
			this.totalRamDamage = totalRamDamage;
			this.myRamDamage = myRamDamage;
			this.totalSurvivor = totalSurvivor;
			this.mySurvivor = mySurvivor;
			this.totalScore = totalScore;
			this.myScore = myScore;
			this.deathAfterTicks = deathAfterTicks;
			this.selfDamage = selfDamage;
		}

		/// <summary>
		/// Initializes all members mapped to fields.
		/// </summary>
		protected void Init(int? id, int? idGeneration, string strategy, bool? used, decimal? fitness, int? bulletHit, int? bulletMiss, int? victoryCount, int? totalBulletDamage, int? myBulletDamage, int? totalRamDamage, int? myRamDamage, int? totalSurvivor, int? mySurvivor, int? totalScore, int? myScore, int? deathAfterTicks, int? selfDamage)
		{
			_Id = id;
			_IdGeneration = idGeneration;
			_Strategy = strategy;
			_Used = used;
			_Fitness = fitness;
			_BulletHit = bulletHit;
			_BulletMiss = bulletMiss;
			_VictoryCount = victoryCount;
			_TotalBulletDamage = totalBulletDamage;
			_MyBulletDamage = myBulletDamage;
			_TotalRamDamage = totalRamDamage;
			_MyRamDamage = myRamDamage;
			_TotalSurvivor = totalSurvivor;
			_MySurvivor = mySurvivor;
			_TotalScore = totalScore;
			_MyScore = myScore;
			_DeathAfterTicks = deathAfterTicks;
			_SelfDamage = selfDamage;
		}

		#endregion

		#region Methods.

		/// <summary>
		/// Gets the value(s) that uniquely identifiy an entity.
		/// In the order as specified in accompanying IDbTable metadata class.
		/// NULL if the parent table/view doesn't have a primary key constraint or the required fields are not set.
		/// </summary>
		public override object[] GetPrimaryKeyValue()
		{
			if (_Id != null)
				return new object[] {_Id.Value};
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
			_Id = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "IdGeneration");
			_IdGeneration = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "Strategy");
			_Strategy = (currentColumnValue != DBNull.Value) ? (string) Convert.ToString(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "Used");
			_Used = (currentColumnValue != DBNull.Value) ? (bool?) Convert.ToBoolean(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "Fitness");
			_Fitness = (currentColumnValue != DBNull.Value) ? (decimal?) Convert.ToDecimal(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "BulletHit");
			_BulletHit = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "BulletMiss");
			_BulletMiss = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "VictoryCount");
			_VictoryCount = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "TotalBulletDamage");
			_TotalBulletDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "MyBulletDamage");
			_MyBulletDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "TotalRamDamage");
			_TotalRamDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "MyRamDamage");
			_MyRamDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "TotalSurvivor");
			_TotalSurvivor = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "MySurvivor");
			_MySurvivor = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "TotalScore");
			_TotalScore = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "MyScore");
			_MyScore = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "DeathAfterTicks");
			_DeathAfterTicks = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumnValue = TryGetColumnValue(row, "SelfDamage");
			_SelfDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
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
			_Id = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.IdGeneration.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_IdGeneration = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Strategy.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_Strategy = (currentColumnValue != DBNull.Value) ? (string) Convert.ToString(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Used.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_Used = (currentColumnValue != DBNull.Value) ? (bool?) Convert.ToBoolean(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.Fitness.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_Fitness = (currentColumnValue != DBNull.Value) ? (decimal?) Convert.ToDecimal(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.BulletHit.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_BulletHit = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.BulletMiss.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_BulletMiss = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.VictoryCount.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_VictoryCount = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.TotalBulletDamage.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_TotalBulletDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.MyBulletDamage.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_MyBulletDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.TotalRamDamage.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_TotalRamDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.MyRamDamage.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_MyRamDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.TotalSurvivor.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_TotalSurvivor = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.MySurvivor.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_MySurvivor = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.TotalScore.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_TotalScore = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.MyScore.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_MyScore = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.DeathAfterTicks.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_DeathAfterTicks = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
			currentColumn = fieldMetaData.Columns.GetByPropertyName(this.Table.SelfDamage.PropertyName);
			currentColumnValue = (currentColumn != null) ? GetColumnValue(row, currentColumn) : DBNull.Value;
			_SelfDamage = (currentColumnValue != DBNull.Value) ? (int?) Convert.ToInt32(currentColumnValue) : null;
      
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
			object[] values = new object[18];

			values[0] = (_Id != null) ? (object) _Id.Value : null;
			values[1] = (_IdGeneration != null) ? (object) _IdGeneration.Value : null;
			values[2] = (_Strategy != null) ? (object) _Strategy : null;
			values[3] = (_Used != null) ? (object) _Used.Value : null;
			values[4] = (_Fitness != null) ? (object) _Fitness.Value : null;
			values[5] = (_BulletHit != null) ? (object) _BulletHit.Value : null;
			values[6] = (_BulletMiss != null) ? (object) _BulletMiss.Value : null;
			values[7] = (_VictoryCount != null) ? (object) _VictoryCount.Value : null;
			values[8] = (_TotalBulletDamage != null) ? (object) _TotalBulletDamage.Value : null;
			values[9] = (_MyBulletDamage != null) ? (object) _MyBulletDamage.Value : null;
			values[10] = (_TotalRamDamage != null) ? (object) _TotalRamDamage.Value : null;
			values[11] = (_MyRamDamage != null) ? (object) _MyRamDamage.Value : null;
			values[12] = (_TotalSurvivor != null) ? (object) _TotalSurvivor.Value : null;
			values[13] = (_MySurvivor != null) ? (object) _MySurvivor.Value : null;
			values[14] = (_TotalScore != null) ? (object) _TotalScore.Value : null;
			values[15] = (_MyScore != null) ? (object) _MyScore.Value : null;
			values[16] = (_DeathAfterTicks != null) ? (object) _DeathAfterTicks.Value : null;
			values[17] = (_SelfDamage != null) ? (object) _SelfDamage.Value : null;
			
			return values;
		}

		/// <summary>
		/// Initializes entity members with the given values.
		/// </summary>
		/// <param name="entityValues">Array with the required values.</param>
		public override void FromObjectArray(object[] entityValues)
		{
			_Id = (entityValues[0] != null) ? (int?) Convert.ToInt32(entityValues[0]) : null;
			_IdGeneration = (entityValues[1] != null) ? (int?) Convert.ToInt32(entityValues[1]) : null;
			_Strategy = (entityValues[2] != null) ? (string) Convert.ToString(entityValues[2]) : null;
			_Used = (entityValues[3] != null) ? (bool?) Convert.ToBoolean(entityValues[3]) : null;
			_Fitness = (entityValues[4] != null) ? (decimal?) Convert.ToDecimal(entityValues[4]) : null;
			_BulletHit = (entityValues[5] != null) ? (int?) Convert.ToInt32(entityValues[5]) : null;
			_BulletMiss = (entityValues[6] != null) ? (int?) Convert.ToInt32(entityValues[6]) : null;
			_VictoryCount = (entityValues[7] != null) ? (int?) Convert.ToInt32(entityValues[7]) : null;
			_TotalBulletDamage = (entityValues[8] != null) ? (int?) Convert.ToInt32(entityValues[8]) : null;
			_MyBulletDamage = (entityValues[9] != null) ? (int?) Convert.ToInt32(entityValues[9]) : null;
			_TotalRamDamage = (entityValues[10] != null) ? (int?) Convert.ToInt32(entityValues[10]) : null;
			_MyRamDamage = (entityValues[11] != null) ? (int?) Convert.ToInt32(entityValues[11]) : null;
			_TotalSurvivor = (entityValues[12] != null) ? (int?) Convert.ToInt32(entityValues[12]) : null;
			_MySurvivor = (entityValues[13] != null) ? (int?) Convert.ToInt32(entityValues[13]) : null;
			_TotalScore = (entityValues[14] != null) ? (int?) Convert.ToInt32(entityValues[14]) : null;
			_MyScore = (entityValues[15] != null) ? (int?) Convert.ToInt32(entityValues[15]) : null;
			_DeathAfterTicks = (entityValues[16] != null) ? (int?) Convert.ToInt32(entityValues[16]) : null;
			_SelfDamage = (entityValues[17] != null) ? (int?) Convert.ToInt32(entityValues[17]) : null;
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

		#endregion

		/// <summary>
		/// Gets typed IDbTable object for the entity's table/view.
		/// </summary>
    [JsonIgnore]
		public StrategyMeta Table
		{
			get {return (StrategyMeta) _Table;}
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
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'BulletHit'.
		/// </summary>
		public virtual int? BulletHit
		{
			get
			{
				return _BulletHit;
			}
			set
			{
				_BulletHit = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'BulletMiss'.
		/// </summary>
		public virtual int? BulletMiss
		{
			get
			{
				return _BulletMiss;
			}
			set
			{
				_BulletMiss = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'VictoryCount'.
		/// </summary>
		public virtual int? VictoryCount
		{
			get
			{
				return _VictoryCount;
			}
			set
			{
				_VictoryCount = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'TotalBulletDamage'.
		/// </summary>
		public virtual int? TotalBulletDamage
		{
			get
			{
				return _TotalBulletDamage;
			}
			set
			{
				_TotalBulletDamage = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'MyBulletDamage'.
		/// </summary>
		public virtual int? MyBulletDamage
		{
			get
			{
				return _MyBulletDamage;
			}
			set
			{
				_MyBulletDamage = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'TotalRamDamage'.
		/// </summary>
		public virtual int? TotalRamDamage
		{
			get
			{
				return _TotalRamDamage;
			}
			set
			{
				_TotalRamDamage = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'MyRamDamage'.
		/// </summary>
		public virtual int? MyRamDamage
		{
			get
			{
				return _MyRamDamage;
			}
			set
			{
				_MyRamDamage = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'TotalSurvivor'.
		/// </summary>
		public virtual int? TotalSurvivor
		{
			get
			{
				return _TotalSurvivor;
			}
			set
			{
				_TotalSurvivor = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'MySurvivor'.
		/// </summary>
		public virtual int? MySurvivor
		{
			get
			{
				return _MySurvivor;
			}
			set
			{
				_MySurvivor = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'TotalScore'.
		/// </summary>
		public virtual int? TotalScore
		{
			get
			{
				return _TotalScore;
			}
			set
			{
				_TotalScore = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'MyScore'.
		/// </summary>
		public virtual int? MyScore
		{
			get
			{
				return _MyScore;
			}
			set
			{
				_MyScore = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'DeathAfterTicks'.
		/// </summary>
		public virtual int? DeathAfterTicks
		{
			get
			{
				return _DeathAfterTicks;
			}
			set
			{
				_DeathAfterTicks = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the value which is mapped to the nullable field 'SelfDamage'.
		/// </summary>
		public virtual int? SelfDamage
		{
			get
			{
				return _SelfDamage;
			}
			set
			{
				_SelfDamage = value;
			}
		}
		
		#endregion

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
      
		#endregion

		#region NewEntity static methods suitable for usage in EntityBuilder<T>.

		/// <summary>Creates new entity and initializes all members of with the given values.</summary>
		/// <param name="table">Metadata for table/view to which the entity belongs to.</param>
		/// <param name="entityState">Indicates the state of entity with regard to data-source.</param>
		/// <param name="values">Array which contains values for all properties mapped to database columns in the following order: Id, IdGeneration, Strategy, Used, Fitness, BulletHit, BulletMiss, VictoryCount, TotalBulletDamage, MyBulletDamage, TotalRamDamage, MyRamDamage, TotalSurvivor, MySurvivor, TotalScore, MyScore, DeathAfterTicks, SelfDamage.</param>
		/// <remarks>This is the fastest method to initialize an entity as it directly initializes all members of base and derived class,
		/// skips all validation checks and doesn't attempt to convert provided value data types. The method is typically used in combination
		/// with IDataConverter objects which retrieve property values directly from IDataReader objects.</remarks>
		public static StrategyEntity NewEntity(IDbTable table, EntityState entityState, object[] values)
		{
			return new StrategyEntity(table, entityState, (int)values[0], (int)values[1], (string)values[2], (bool)values[3], CastTo<decimal>(values[4]), CastTo<int>(values[5]), CastTo<int>(values[6]), CastTo<int>(values[7]), CastTo<int>(values[8]), CastTo<int>(values[9]), CastTo<int>(values[10]), CastTo<int>(values[11]), CastTo<int>(values[12]), CastTo<int>(values[13]), CastTo<int>(values[14]), CastTo<int>(values[15]), CastTo<int>(values[16]), CastTo<int>(values[17]));
		}

		/// <summary>Creates new entity and initializes members for which values are defined in the array.</summary>
		/// <param name="table">Metadata for table/view to which the entity belongs to.</param>
		/// <param name="entityState">Indicates the state of entity with regard to data-source.</param>
		/// <param name="values">Array which contains values or nulls for all properties mapped to database columns in the following order: Id, IdGeneration, Strategy, Used, Fitness, BulletHit, BulletMiss, VictoryCount, TotalBulletDamage, MyBulletDamage, TotalRamDamage, MyRamDamage, TotalSurvivor, MySurvivor, TotalScore, MyScore, DeathAfterTicks, SelfDamage.</param>
		/// <remarks>This is the fastest method to initialize an entity as it directly initializes all members of base and derived class,
		/// skips all validation checks and doesn't attempt to convert provided value data types. The method is typically used in combination
		/// with IObjectFiller objects which retrieve property values directly from IDataReader objects.</remarks>
		public static StrategyEntity NewPartialEntity(IDbTable table, EntityState entityState, object[] values)
		{
			return new StrategyEntity(table, entityState, CastTo<int>(values[0]), CastTo<int>(values[1]), (string)ReplaceDbNull(values[2]), CastTo<bool>(values[3]), CastTo<decimal>(values[4]), CastTo<int>(values[5]), CastTo<int>(values[6]), CastTo<int>(values[7]), CastTo<int>(values[8]), CastTo<int>(values[9]), CastTo<int>(values[10]), CastTo<int>(values[11]), CastTo<int>(values[12]), CastTo<int>(values[13]), CastTo<int>(values[14]), CastTo<int>(values[15]), CastTo<int>(values[16]), CastTo<int>(values[17]));
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

		#endregion

		#region Private connection-transaction context.

		/// <summary>
		/// This member is only accessed and initialized through _ConnectionProvider getter.
		/// </summary>
		[NonSerialized]
		IConnectionProvider conn;

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

		#endregion

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

		#endregion

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

		static readonly string[] SequenceNameOverrides = new string[18];
		static readonly bool?[] AutoIncrementOverrides = new bool?[18];

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
			SequenceNameOverrides[5] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.BulletHit.SequenceName"];
			AutoIncrementOverrides[5] = (SequenceNameOverrides[5] != null) ? (bool?)true : null;
			SequenceNameOverrides[6] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.BulletMiss.SequenceName"];
			AutoIncrementOverrides[6] = (SequenceNameOverrides[6] != null) ? (bool?)true : null;
			SequenceNameOverrides[7] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.VictoryCount.SequenceName"];
			AutoIncrementOverrides[7] = (SequenceNameOverrides[7] != null) ? (bool?)true : null;
			SequenceNameOverrides[8] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.TotalBulletDamage.SequenceName"];
			AutoIncrementOverrides[8] = (SequenceNameOverrides[8] != null) ? (bool?)true : null;
			SequenceNameOverrides[9] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.MyBulletDamage.SequenceName"];
			AutoIncrementOverrides[9] = (SequenceNameOverrides[9] != null) ? (bool?)true : null;
			SequenceNameOverrides[10] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.TotalRamDamage.SequenceName"];
			AutoIncrementOverrides[10] = (SequenceNameOverrides[10] != null) ? (bool?)true : null;
			SequenceNameOverrides[11] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.MyRamDamage.SequenceName"];
			AutoIncrementOverrides[11] = (SequenceNameOverrides[11] != null) ? (bool?)true : null;
			SequenceNameOverrides[12] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.TotalSurvivor.SequenceName"];
			AutoIncrementOverrides[12] = (SequenceNameOverrides[12] != null) ? (bool?)true : null;
			SequenceNameOverrides[13] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.MySurvivor.SequenceName"];
			AutoIncrementOverrides[13] = (SequenceNameOverrides[13] != null) ? (bool?)true : null;
			SequenceNameOverrides[14] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.TotalScore.SequenceName"];
			AutoIncrementOverrides[14] = (SequenceNameOverrides[14] != null) ? (bool?)true : null;
			SequenceNameOverrides[15] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.MyScore.SequenceName"];
			AutoIncrementOverrides[15] = (SequenceNameOverrides[15] != null) ? (bool?)true : null;
			SequenceNameOverrides[16] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.DeathAfterTicks.SequenceName"];
			AutoIncrementOverrides[16] = (SequenceNameOverrides[16] != null) ? (bool?)true : null;
			SequenceNameOverrides[17] = ConfigurationManager.AppSettings["Fistnet.FistBot.DAL.Strategy.SelfDamage.SequenceName"];
			AutoIncrementOverrides[17] = (SequenceNameOverrides[17] != null) ? (bool?)true : null;
		}

		static readonly string[] ColumnNames = new string[18];

		private static void ReadColumnNamesFromConfig()
		{
			ColumnNames[0] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Id") ?? "Id";
			ColumnNames[1] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "IdGeneration") ?? "IdGeneration";
			ColumnNames[2] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Strategy") ?? "Strategy";
			ColumnNames[3] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Used") ?? "Used";
			ColumnNames[4] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "Fitness") ?? "Fitness";
			ColumnNames[5] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "BulletHit") ?? "BulletHit";
			ColumnNames[6] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "BulletMiss") ?? "BulletMiss";
			ColumnNames[7] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "VictoryCount") ?? "VictoryCount";
			ColumnNames[8] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "TotalBulletDamage") ?? "TotalBulletDamage";
			ColumnNames[9] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "MyBulletDamage") ?? "MyBulletDamage";
			ColumnNames[10] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "TotalRamDamage") ?? "TotalRamDamage";
			ColumnNames[11] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "MyRamDamage") ?? "MyRamDamage";
			ColumnNames[12] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "TotalSurvivor") ?? "TotalSurvivor";
			ColumnNames[13] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "MySurvivor") ?? "MySurvivor";
			ColumnNames[14] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "TotalScore") ?? "TotalScore";
			ColumnNames[15] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "MyScore") ?? "MyScore";
			ColumnNames[16] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "DeathAfterTicks") ?? "DeathAfterTicks";
			ColumnNames[17] = Fistnet.FistBot.DAL.Catalog.GetColumnNameOverride("Strategy", "SelfDamage") ?? "SelfDamage";
		}

		#endregion

		#region Singleton/immutable configuration objects.

		static readonly DbColumnConfiguration[] ImmutableColumnProperties;
		static readonly DbTableConfiguration ImmutableTableProperties;

		private static DbColumnConfiguration[] CreateImmutableColumnProperties()
		{
			return new DbColumnConfiguration[]
			{
				new DbColumnConfiguration(ColumnNames[0], DbType.Int32, typeof(int), false, 0, true, null, 0, true, false, false, "Id", int.MinValue, int.MaxValue, false, SequenceNameOverrides[0]),
				new DbColumnConfiguration(ColumnNames[1], DbType.Int32, typeof(int), false, 1, AutoIncrementOverrides[1] ?? false, null, 0, false, true, false, "IdGeneration", int.MinValue, int.MaxValue, false, SequenceNameOverrides[1]),
				new DbColumnConfiguration(ColumnNames[2], DbType.String, typeof(string), false, 2, AutoIncrementOverrides[2] ?? false, null, 0, false, false, false, "Strategy", null, null, false, SequenceNameOverrides[2]),
				new DbColumnConfiguration(ColumnNames[3], DbType.Boolean, typeof(bool), false, 3, AutoIncrementOverrides[3] ?? false, null, 0, false, false, false, "Used", null, null, false, SequenceNameOverrides[3]),
				new DbColumnConfiguration(ColumnNames[4], DbType.Decimal, typeof(decimal), true, 4, AutoIncrementOverrides[4] ?? false, null, 0, false, false, false, "Fitness", -999999999999.999999, 999999999999.999999, false, SequenceNameOverrides[4]),
				new DbColumnConfiguration(ColumnNames[5], DbType.Int32, typeof(int), true, 5, AutoIncrementOverrides[5] ?? false, null, 0, false, false, false, "BulletHit", int.MinValue, int.MaxValue, false, SequenceNameOverrides[5]),
				new DbColumnConfiguration(ColumnNames[6], DbType.Int32, typeof(int), true, 6, AutoIncrementOverrides[6] ?? false, null, 0, false, false, false, "BulletMiss", int.MinValue, int.MaxValue, false, SequenceNameOverrides[6]),
				new DbColumnConfiguration(ColumnNames[7], DbType.Int32, typeof(int), true, 7, AutoIncrementOverrides[7] ?? false, null, 0, false, false, false, "VictoryCount", int.MinValue, int.MaxValue, false, SequenceNameOverrides[7]),
				new DbColumnConfiguration(ColumnNames[8], DbType.Int32, typeof(int), true, 8, AutoIncrementOverrides[8] ?? false, null, 0, false, false, false, "TotalBulletDamage", int.MinValue, int.MaxValue, false, SequenceNameOverrides[8]),
				new DbColumnConfiguration(ColumnNames[9], DbType.Int32, typeof(int), true, 9, AutoIncrementOverrides[9] ?? false, null, 0, false, false, false, "MyBulletDamage", int.MinValue, int.MaxValue, false, SequenceNameOverrides[9]),
				new DbColumnConfiguration(ColumnNames[10], DbType.Int32, typeof(int), true, 10, AutoIncrementOverrides[10] ?? false, null, 0, false, false, false, "TotalRamDamage", int.MinValue, int.MaxValue, false, SequenceNameOverrides[10]),
				new DbColumnConfiguration(ColumnNames[11], DbType.Int32, typeof(int), true, 11, AutoIncrementOverrides[11] ?? false, null, 0, false, false, false, "MyRamDamage", int.MinValue, int.MaxValue, false, SequenceNameOverrides[11]),
				new DbColumnConfiguration(ColumnNames[12], DbType.Int32, typeof(int), true, 12, AutoIncrementOverrides[12] ?? false, null, 0, false, false, false, "TotalSurvivor", int.MinValue, int.MaxValue, false, SequenceNameOverrides[12]),
				new DbColumnConfiguration(ColumnNames[13], DbType.Int32, typeof(int), true, 13, AutoIncrementOverrides[13] ?? false, null, 0, false, false, false, "MySurvivor", int.MinValue, int.MaxValue, false, SequenceNameOverrides[13]),
				new DbColumnConfiguration(ColumnNames[14], DbType.Int32, typeof(int), true, 14, AutoIncrementOverrides[14] ?? false, null, 0, false, false, false, "TotalScore", int.MinValue, int.MaxValue, false, SequenceNameOverrides[14]),
				new DbColumnConfiguration(ColumnNames[15], DbType.Int32, typeof(int), true, 15, AutoIncrementOverrides[15] ?? false, null, 0, false, false, false, "MyScore", int.MinValue, int.MaxValue, false, SequenceNameOverrides[15]),
				new DbColumnConfiguration(ColumnNames[16], DbType.Int32, typeof(int), true, 16, AutoIncrementOverrides[16] ?? false, null, 0, false, false, false, "DeathAfterTicks", int.MinValue, int.MaxValue, false, SequenceNameOverrides[16]),
				new DbColumnConfiguration(ColumnNames[17], DbType.Int32, typeof(int), true, 17, AutoIncrementOverrides[17] ?? false, null, 0, false, false, false, "SelfDamage", int.MinValue, int.MaxValue, false, SequenceNameOverrides[17]),
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
				new string[] {"GenerationParent" }
			);
		}

		#endregion

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

		#endregion

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

		#endregion

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

		#endregion

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

		#endregion

		#region Columns.
    
		/// <summary>
		/// Gets metadata for 'Id' column.
		/// </summary>
		public IDbColumn Id
		{
			get {return this.Columns[0];}
		}
			
		/// <summary>
		/// Gets metadata for 'IdGeneration' column.
		/// </summary>
		public IDbColumn IdGeneration
		{
			get {return this.Columns[1];}
		}
			
		/// <summary>
		/// Gets metadata for 'Strategy' column.
		/// </summary>
		public IDbColumn Strategy
		{
			get {return this.Columns[2];}
		}
			
		/// <summary>
		/// Gets metadata for 'Used' column.
		/// </summary>
		public IDbColumn Used
		{
			get {return this.Columns[3];}
		}
			
		/// <summary>
		/// Gets metadata for 'Fitness' column.
		/// </summary>
		public IDbColumn Fitness
		{
			get {return this.Columns[4];}
		}
			
		/// <summary>
		/// Gets metadata for 'BulletHit' column.
		/// </summary>
		public IDbColumn BulletHit
		{
			get {return this.Columns[5];}
		}
			
		/// <summary>
		/// Gets metadata for 'BulletMiss' column.
		/// </summary>
		public IDbColumn BulletMiss
		{
			get {return this.Columns[6];}
		}
			
		/// <summary>
		/// Gets metadata for 'VictoryCount' column.
		/// </summary>
		public IDbColumn VictoryCount
		{
			get {return this.Columns[7];}
		}
			
		/// <summary>
		/// Gets metadata for 'TotalBulletDamage' column.
		/// </summary>
		public IDbColumn TotalBulletDamage
		{
			get {return this.Columns[8];}
		}
			
		/// <summary>
		/// Gets metadata for 'MyBulletDamage' column.
		/// </summary>
		public IDbColumn MyBulletDamage
		{
			get {return this.Columns[9];}
		}
			
		/// <summary>
		/// Gets metadata for 'TotalRamDamage' column.
		/// </summary>
		public IDbColumn TotalRamDamage
		{
			get {return this.Columns[10];}
		}
			
		/// <summary>
		/// Gets metadata for 'MyRamDamage' column.
		/// </summary>
		public IDbColumn MyRamDamage
		{
			get {return this.Columns[11];}
		}
			
		/// <summary>
		/// Gets metadata for 'TotalSurvivor' column.
		/// </summary>
		public IDbColumn TotalSurvivor
		{
			get {return this.Columns[12];}
		}
			
		/// <summary>
		/// Gets metadata for 'MySurvivor' column.
		/// </summary>
		public IDbColumn MySurvivor
		{
			get {return this.Columns[13];}
		}
			
		/// <summary>
		/// Gets metadata for 'TotalScore' column.
		/// </summary>
		public IDbColumn TotalScore
		{
			get {return this.Columns[14];}
		}
			
		/// <summary>
		/// Gets metadata for 'MyScore' column.
		/// </summary>
		public IDbColumn MyScore
		{
			get {return this.Columns[15];}
		}
			
		/// <summary>
		/// Gets metadata for 'DeathAfterTicks' column.
		/// </summary>
		public IDbColumn DeathAfterTicks
		{
			get {return this.Columns[16];}
		}
			
		/// <summary>
		/// Gets metadata for 'SelfDamage' column.
		/// </summary>
		public IDbColumn SelfDamage
		{
			get {return this.Columns[17];}
		}
			
		#endregion

		#region Foreign keys.
		
		/// <summary>
		/// Gets relation to Generation table established by "IdGeneration" column(s).
		/// </summary>
		[JsonIgnore]
		public DbRelation FK_IdGeneration
		{
			get {return this.ForeignKeys[0];}
		}
      
		#endregion

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
      
		#endregion

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

		#endregion
	}
}
