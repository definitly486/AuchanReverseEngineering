using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using SQLitePCL;

namespace SQLite;

[Preserve(AllMembers = true)]
public class SQLiteConnection : ISQLiteConnection, IDisposable
{
	private struct IndexedColumn
	{
		public int Order;

		public string ColumnName;
	}

	private struct IndexInfo
	{
		public string IndexName;

		public string TableName;

		public bool Unique;

		public List<IndexedColumn> Columns;
	}

	[Preserve(AllMembers = true)]
	public class ColumnInfo
	{
		[Column("name")]
		public string Name { get; set; }

		public int notnull { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

	private bool _open;

	private TimeSpan _busyTimeout;

	private static readonly Dictionary<string, TableMapping> _mappings;

	private Stopwatch _sw;

	private long _elapsedMilliseconds;

	private int _transactionDepth;

	private Random _rand = new Random();

	private static readonly sqlite3 NullHandle;

	private static readonly sqlite3_backup NullBackupHandle;

	private readonly Dictionary<Tuple<string, string>, PreparedSqlLiteInsertCommand> _insertCommandMap = new Dictionary<Tuple<string, string>, PreparedSqlLiteInsertCommand>();

	public sqlite3 Handle { get; private set; }

	public string DatabasePath { get; private set; }

	public int LibVersionNumber { get; private set; }

	public bool TimeExecution { get; set; }

	public bool Trace { get; set; }

	public Action<string> Tracer { get; set; }

	public bool StoreDateTimeAsTicks { get; private set; }

	public bool StoreTimeSpanAsTicks { get; private set; }

	public string DateTimeStringFormat { get; private set; }

	internal DateTimeStyles DateTimeStyle { get; private set; }

	public TimeSpan BusyTimeout
	{
		get
		{
			return _busyTimeout;
		}
		set
		{
			_busyTimeout = value;
			if (Handle != NullHandle)
			{
				SQLite3.BusyTimeout(Handle, (int)_busyTimeout.TotalMilliseconds);
			}
		}
	}

	public IEnumerable<TableMapping> TableMappings
	{
		get
		{
			lock (_mappings)
			{
				return new List<TableMapping>(_mappings.Values);
			}
		}
	}

	public bool IsInTransaction => _transactionDepth > 0;

	public event EventHandler<NotifyTableChangedEventArgs> TableChanged;

	static SQLiteConnection()
	{
		_mappings = new Dictionary<string, TableMapping>();
		NullHandle = null;
		NullBackupHandle = null;
		Batteries_V2.Init();
	}

	public SQLiteConnection(string databasePath, bool storeDateTimeAsTicks = true)
		: this(new SQLiteConnectionString(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, storeDateTimeAsTicks))
	{
	}

	public SQLiteConnection(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true)
		: this(new SQLiteConnectionString(databasePath, openFlags, storeDateTimeAsTicks))
	{
	}

	public SQLiteConnection(SQLiteConnectionString connectionString)
	{
		if (connectionString == null)
		{
			throw new ArgumentNullException("connectionString");
		}
		if (connectionString.DatabasePath == null)
		{
			throw new InvalidOperationException("DatabasePath must be specified");
		}
		DatabasePath = connectionString.DatabasePath;
		LibVersionNumber = SQLite3.LibVersionNumber();
		sqlite3 db;
		SQLite3.Result result = SQLite3.Open(connectionString.DatabasePath, out db, (int)connectionString.OpenFlags, connectionString.VfsName);
		Handle = db;
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, $"Could not open database file: {DatabasePath} ({result})");
		}
		_open = true;
		StoreDateTimeAsTicks = connectionString.StoreDateTimeAsTicks;
		StoreTimeSpanAsTicks = connectionString.StoreTimeSpanAsTicks;
		DateTimeStringFormat = connectionString.DateTimeStringFormat;
		DateTimeStyle = connectionString.DateTimeStyle;
		BusyTimeout = TimeSpan.FromSeconds(1.0);
		Tracer = delegate
		{
		};
		connectionString.PreKeyAction?.Invoke(this);
		if (connectionString.Key is string key)
		{
			SetKey(key);
		}
		else if (connectionString.Key is byte[] key2)
		{
			SetKey(key2);
		}
		else if (connectionString.Key != null)
		{
			throw new InvalidOperationException("Encryption keys must be strings or byte arrays");
		}
		connectionString.PostKeyAction?.Invoke(this);
	}

	public void EnableWriteAheadLogging()
	{
		ExecuteScalar<string>("PRAGMA journal_mode=WAL", Array.Empty<object>());
	}

	private static string Quote(string unsafeString)
	{
		if (unsafeString == null)
		{
			return "NULL";
		}
		string text = unsafeString.Replace("'", "''");
		return "'" + text + "'";
	}

	private void SetKey(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		string text = Quote(key);
		ExecuteScalar<string>("pragma key = " + text, Array.Empty<object>());
	}

	private void SetKey(byte[] key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (key.Length != 32 && key.Length != 48)
		{
			throw new ArgumentException("Key must be 32 bytes (256-bit) or 48 bytes (384-bit)", "key");
		}
		string text = string.Join("", key.Select((byte x) => x.ToString("X2")));
		ExecuteScalar<string>("pragma key = \"x'" + text + "'\"", Array.Empty<object>());
	}

	public void ReKey(string key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		string text = Quote(key);
		ExecuteScalar<string>("pragma rekey = " + text, Array.Empty<object>());
	}

	public void ReKey(byte[] key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (key.Length != 32 && key.Length != 48)
		{
			throw new ArgumentException("Key must be 32 bytes (256-bit) or 48 bytes (384-bit)", "key");
		}
		string text = string.Join("", key.Select((byte x) => x.ToString("X2")));
		ExecuteScalar<string>("pragma rekey = \"x'" + text + "'\"", Array.Empty<object>());
	}

	public void EnableLoadExtension(bool enabled)
	{
		SQLite3.Result result = SQLite3.EnableLoadExtension(Handle, enabled ? 1 : 0);
		if (result != SQLite3.Result.OK)
		{
			string errmsg = SQLite3.GetErrmsg(Handle);
			throw SQLiteException.New(result, errmsg);
		}
	}

	public TableMapping GetMapping(Type type, CreateFlags createFlags = CreateFlags.None)
	{
		string fullName = type.FullName;
		TableMapping value;
		lock (_mappings)
		{
			if (_mappings.TryGetValue(fullName, out value))
			{
				if (createFlags != CreateFlags.None && createFlags != value.CreateFlags)
				{
					value = new TableMapping(type, createFlags);
					_mappings[fullName] = value;
				}
			}
			else
			{
				value = new TableMapping(type, createFlags);
				_mappings.Add(fullName, value);
			}
		}
		return value;
	}

	public TableMapping GetMapping<T>(CreateFlags createFlags = CreateFlags.None)
	{
		return GetMapping(typeof(T), createFlags);
	}

	public int DropTable<T>()
	{
		return DropTable(GetMapping(typeof(T)));
	}

	public int DropTable(TableMapping map)
	{
		string query = $"drop table if exists \"{map.TableName}\"";
		return Execute(query);
	}

	public CreateTableResult CreateTable<T>(CreateFlags createFlags = CreateFlags.None)
	{
		return CreateTable(typeof(T), createFlags);
	}

	public CreateTableResult CreateTable(Type ty, CreateFlags createFlags = CreateFlags.None)
	{
		TableMapping mapping = GetMapping(ty, createFlags);
		if (mapping.Columns.Length == 0)
		{
			throw new Exception($"Cannot create a table without columns (does '{ty.FullName}' have public properties?)");
		}
		CreateTableResult result = CreateTableResult.Created;
		List<ColumnInfo> tableInfo = GetTableInfo(mapping.TableName);
		if (tableInfo.Count == 0)
		{
			bool num = (createFlags & CreateFlags.FullTextSearch3) != 0;
			bool flag = (createFlags & CreateFlags.FullTextSearch4) != 0;
			string text = ((num || flag) ? "virtual " : string.Empty);
			string text2 = (num ? "using fts3 " : (flag ? "using fts4 " : string.Empty));
			string text3 = "create " + text + "table if not exists \"" + mapping.TableName + "\" " + text2 + "(\n";
			IEnumerable<string> source = mapping.Columns.Select((TableMapping.Column p) => Orm.SqlDecl(p, StoreDateTimeAsTicks, StoreTimeSpanAsTicks));
			string text4 = string.Join(",\n", source.ToArray());
			text3 += text4;
			text3 += ")";
			if (mapping.WithoutRowId)
			{
				text3 += " without rowid";
			}
			Execute(text3);
		}
		else
		{
			result = CreateTableResult.Migrated;
			MigrateTable(mapping, tableInfo);
		}
		Dictionary<string, IndexInfo> dictionary = new Dictionary<string, IndexInfo>();
		TableMapping.Column[] columns = mapping.Columns;
		foreach (TableMapping.Column column in columns)
		{
			foreach (IndexedAttribute index in column.Indices)
			{
				string text5 = index.Name ?? (mapping.TableName + "_" + column.Name);
				if (!dictionary.TryGetValue(text5, out var value))
				{
					value = new IndexInfo
					{
						IndexName = text5,
						TableName = mapping.TableName,
						Unique = index.Unique,
						Columns = new List<IndexedColumn>()
					};
					dictionary.Add(text5, value);
				}
				if (index.Unique != value.Unique)
				{
					throw new Exception("All the columns in an index must have the same value for their Unique property");
				}
				value.Columns.Add(new IndexedColumn
				{
					Order = index.Order,
					ColumnName = column.Name
				});
			}
		}
		foreach (string key in dictionary.Keys)
		{
			IndexInfo indexInfo = dictionary[key];
			string[] columnNames = (from i in indexInfo.Columns
				orderby i.Order
				select i.ColumnName).ToArray();
			CreateIndex(key, indexInfo.TableName, columnNames, indexInfo.Unique);
		}
		return result;
	}

	public CreateTablesResult CreateTables<T, T2>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new()
	{
		return CreateTables(createFlags, typeof(T), typeof(T2));
	}

	public CreateTablesResult CreateTables<T, T2, T3>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new()
	{
		return CreateTables(createFlags, typeof(T), typeof(T2), typeof(T3));
	}

	public CreateTablesResult CreateTables<T, T2, T3, T4>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new()
	{
		return CreateTables(createFlags, typeof(T), typeof(T2), typeof(T3), typeof(T4));
	}

	public CreateTablesResult CreateTables<T, T2, T3, T4, T5>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new() where T5 : new()
	{
		return CreateTables(createFlags, typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
	}

	public CreateTablesResult CreateTables(CreateFlags createFlags = CreateFlags.None, params Type[] types)
	{
		CreateTablesResult createTablesResult = new CreateTablesResult();
		foreach (Type type in types)
		{
			CreateTableResult value = CreateTable(type, createFlags);
			createTablesResult.Results[type] = value;
		}
		return createTablesResult;
	}

	public int CreateIndex(string indexName, string tableName, string[] columnNames, bool unique = false)
	{
		string query = string.Format("create {2} index if not exists \"{3}\" on \"{0}\"(\"{1}\")", tableName, string.Join("\", \"", columnNames), unique ? "unique" : "", indexName);
		return Execute(query);
	}

	public int CreateIndex(string indexName, string tableName, string columnName, bool unique = false)
	{
		return CreateIndex(indexName, tableName, new string[1] { columnName }, unique);
	}

	public int CreateIndex(string tableName, string columnName, bool unique = false)
	{
		return CreateIndex(tableName + "_" + columnName, tableName, columnName, unique);
	}

	public int CreateIndex(string tableName, string[] columnNames, bool unique = false)
	{
		return CreateIndex(tableName + "_" + string.Join("_", columnNames), tableName, columnNames, unique);
	}

	public int CreateIndex<T>(Expression<Func<T, object>> property, bool unique = false)
	{
		MemberExpression memberExpression = ((property.Body.NodeType != ExpressionType.Convert) ? (property.Body as MemberExpression) : (((UnaryExpression)property.Body).Operand as MemberExpression));
		PropertyInfo obj = memberExpression.Member as PropertyInfo;
		if (obj == null)
		{
			throw new ArgumentException("The lambda expression 'property' should point to a valid Property");
		}
		string name = obj.Name;
		TableMapping mapping = GetMapping<T>();
		string name2 = mapping.FindColumnWithPropertyName(name).Name;
		return CreateIndex(mapping.TableName, name2, unique);
	}

	public List<ColumnInfo> GetTableInfo(string tableName)
	{
		string query = "pragma table_info(\"" + tableName + "\")";
		return Query<ColumnInfo>(query, Array.Empty<object>());
	}

	private void MigrateTable(TableMapping map, List<ColumnInfo> existingCols)
	{
		List<TableMapping.Column> list = new List<TableMapping.Column>();
		TableMapping.Column[] columns = map.Columns;
		foreach (TableMapping.Column column in columns)
		{
			bool flag = false;
			foreach (ColumnInfo existingCol in existingCols)
			{
				flag = string.Compare(column.Name, existingCol.Name, StringComparison.OrdinalIgnoreCase) == 0;
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				list.Add(column);
			}
		}
		foreach (TableMapping.Column item in list)
		{
			string query = "alter table \"" + map.TableName + "\" add column " + Orm.SqlDecl(item, StoreDateTimeAsTicks, StoreTimeSpanAsTicks);
			Execute(query);
		}
	}

	protected virtual SQLiteCommand NewCommand()
	{
		return new SQLiteCommand(this);
	}

	public SQLiteCommand CreateCommand(string cmdText, params object[] ps)
	{
		if (!_open)
		{
			throw SQLiteException.New(SQLite3.Result.Error, "Cannot create commands from unopened database");
		}
		SQLiteCommand sQLiteCommand = NewCommand();
		sQLiteCommand.CommandText = cmdText;
		foreach (object val in ps)
		{
			sQLiteCommand.Bind(val);
		}
		return sQLiteCommand;
	}

	public SQLiteCommand CreateCommand(string cmdText, Dictionary<string, object> args)
	{
		if (!_open)
		{
			throw SQLiteException.New(SQLite3.Result.Error, "Cannot create commands from unopened database");
		}
		SQLiteCommand sQLiteCommand = NewCommand();
		sQLiteCommand.CommandText = cmdText;
		foreach (KeyValuePair<string, object> arg in args)
		{
			sQLiteCommand.Bind(arg.Key, arg.Value);
		}
		return sQLiteCommand;
	}

	public int Execute(string query, params object[] args)
	{
		SQLiteCommand sQLiteCommand = CreateCommand(query, args);
		if (TimeExecution)
		{
			if (_sw == null)
			{
				_sw = new Stopwatch();
			}
			_sw.Reset();
			_sw.Start();
		}
		int result = sQLiteCommand.ExecuteNonQuery();
		if (TimeExecution)
		{
			_sw.Stop();
			_elapsedMilliseconds += _sw.ElapsedMilliseconds;
			Action<string> tracer = Tracer;
			if (tracer == null)
			{
				return result;
			}
			tracer($"Finished in {_sw.ElapsedMilliseconds} ms ({(double)_elapsedMilliseconds / 1000.0:0.0} s total)");
		}
		return result;
	}

	public T ExecuteScalar<T>(string query, params object[] args)
	{
		SQLiteCommand sQLiteCommand = CreateCommand(query, args);
		if (TimeExecution)
		{
			if (_sw == null)
			{
				_sw = new Stopwatch();
			}
			_sw.Reset();
			_sw.Start();
		}
		T result = sQLiteCommand.ExecuteScalar<T>();
		if (TimeExecution)
		{
			_sw.Stop();
			_elapsedMilliseconds += _sw.ElapsedMilliseconds;
			Action<string> tracer = Tracer;
			if (tracer == null)
			{
				return result;
			}
			tracer($"Finished in {_sw.ElapsedMilliseconds} ms ({(double)_elapsedMilliseconds / 1000.0:0.0} s total)");
		}
		return result;
	}

	public List<T> Query<T>(string query, params object[] args) where T : new()
	{
		return CreateCommand(query, args).ExecuteQuery<T>();
	}

	public List<T> QueryScalars<T>(string query, params object[] args)
	{
		return CreateCommand(query, args).ExecuteQueryScalars<T>().ToList();
	}

	public IEnumerable<T> DeferredQuery<T>(string query, params object[] args) where T : new()
	{
		return CreateCommand(query, args).ExecuteDeferredQuery<T>();
	}

	public List<object> Query(TableMapping map, string query, params object[] args)
	{
		return CreateCommand(query, args).ExecuteQuery<object>(map);
	}

	public IEnumerable<object> DeferredQuery(TableMapping map, string query, params object[] args)
	{
		return CreateCommand(query, args).ExecuteDeferredQuery<object>(map);
	}

	public TableQuery<T> Table<T>() where T : new()
	{
		return new TableQuery<T>(this);
	}

	public T Get<T>(object pk) where T : new()
	{
		TableMapping mapping = GetMapping(typeof(T));
		return Query<T>(mapping.GetByPrimaryKeySql, new object[1] { pk }).First();
	}

	public object Get(object pk, TableMapping map)
	{
		return Query(map, map.GetByPrimaryKeySql, pk).First();
	}

	public T Get<T>(Expression<Func<T, bool>> predicate) where T : new()
	{
		return Table<T>().Where(predicate).First();
	}

	public T Find<T>(object pk) where T : new()
	{
		TableMapping mapping = GetMapping(typeof(T));
		return Query<T>(mapping.GetByPrimaryKeySql, new object[1] { pk }).FirstOrDefault();
	}

	public object Find(object pk, TableMapping map)
	{
		return Query(map, map.GetByPrimaryKeySql, pk).FirstOrDefault();
	}

	public T Find<T>(Expression<Func<T, bool>> predicate) where T : new()
	{
		return Table<T>().Where(predicate).FirstOrDefault();
	}

	public T FindWithQuery<T>(string query, params object[] args) where T : new()
	{
		return Query<T>(query, args).FirstOrDefault();
	}

	public object FindWithQuery(TableMapping map, string query, params object[] args)
	{
		return Query(map, query, args).FirstOrDefault();
	}

	public void BeginTransaction()
	{
		if (Interlocked.CompareExchange(ref _transactionDepth, 1, 0) == 0)
		{
			try
			{
				Execute("begin transaction");
				return;
			}
			catch (Exception ex)
			{
				if (ex is SQLiteException ex2)
				{
					switch (ex2.Result)
					{
					case SQLite3.Result.Busy:
					case SQLite3.Result.NoMem:
					case SQLite3.Result.Interrupt:
					case SQLite3.Result.IOError:
					case SQLite3.Result.Full:
						RollbackTo(null, noThrow: true);
						break;
					}
				}
				else
				{
					Interlocked.Decrement(ref _transactionDepth);
				}
				throw;
			}
		}
		throw new InvalidOperationException("Cannot begin a transaction while already in a transaction.");
	}

	public string SaveTransactionPoint()
	{
		int num = Interlocked.Increment(ref _transactionDepth) - 1;
		string text = "S" + _rand.Next(32767) + "D" + num;
		try
		{
			Execute("savepoint " + text);
			return text;
		}
		catch (Exception ex)
		{
			if (ex is SQLiteException ex2)
			{
				switch (ex2.Result)
				{
				case SQLite3.Result.Busy:
				case SQLite3.Result.NoMem:
				case SQLite3.Result.Interrupt:
				case SQLite3.Result.IOError:
				case SQLite3.Result.Full:
					RollbackTo(null, noThrow: true);
					break;
				}
			}
			else
			{
				Interlocked.Decrement(ref _transactionDepth);
			}
			throw;
		}
	}

	public void Rollback()
	{
		RollbackTo(null, noThrow: false);
	}

	public void RollbackTo(string savepoint)
	{
		RollbackTo(savepoint, noThrow: false);
	}

	private void RollbackTo(string savepoint, bool noThrow)
	{
		try
		{
			if (string.IsNullOrEmpty(savepoint))
			{
				if (Interlocked.Exchange(ref _transactionDepth, 0) > 0)
				{
					Execute("rollback");
				}
			}
			else
			{
				DoSavePointExecute(savepoint, "rollback to ");
			}
		}
		catch (SQLiteException)
		{
			if (!noThrow)
			{
				throw;
			}
		}
	}

	public void Release(string savepoint)
	{
		try
		{
			DoSavePointExecute(savepoint, "release ");
		}
		catch (SQLiteException ex)
		{
			if (ex.Result == SQLite3.Result.Busy)
			{
				try
				{
					Execute("rollback");
				}
				catch
				{
				}
			}
			throw;
		}
	}

	private void DoSavePointExecute(string savepoint, string cmd)
	{
		int num = savepoint.IndexOf('D');
		if (num >= 2 && savepoint.Length > num + 1 && int.TryParse(savepoint.Substring(num + 1), out var result) && 0 <= result && result < _transactionDepth)
		{
			Volatile.Write(ref _transactionDepth, result);
			Execute(cmd + savepoint);
			return;
		}
		throw new ArgumentException("savePoint is not valid, and should be the result of a call to SaveTransactionPoint.", "savePoint");
	}

	public void Commit()
	{
		if (Interlocked.Exchange(ref _transactionDepth, 0) == 0)
		{
			return;
		}
		try
		{
			Execute("commit");
		}
		catch
		{
			try
			{
				Execute("rollback");
			}
			catch
			{
			}
			throw;
		}
	}

	public void RunInTransaction(Action action)
	{
		try
		{
			string savepoint = SaveTransactionPoint();
			action();
			Release(savepoint);
		}
		catch (Exception)
		{
			Rollback();
			throw;
		}
	}

	public int InsertAll(IEnumerable objects, bool runInTransaction = true)
	{
		int c = 0;
		if (runInTransaction)
		{
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Insert(@object);
				}
			});
		}
		else
		{
			foreach (object object2 in objects)
			{
				c += Insert(object2);
			}
		}
		return c;
	}

	public int InsertAll(IEnumerable objects, string extra, bool runInTransaction = true)
	{
		int c = 0;
		if (runInTransaction)
		{
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Insert(@object, extra);
				}
			});
		}
		else
		{
			foreach (object object2 in objects)
			{
				c += Insert(object2, extra);
			}
		}
		return c;
	}

	public int InsertAll(IEnumerable objects, Type objType, bool runInTransaction = true)
	{
		int c = 0;
		if (runInTransaction)
		{
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Insert(@object, objType);
				}
			});
		}
		else
		{
			foreach (object object2 in objects)
			{
				c += Insert(object2, objType);
			}
		}
		return c;
	}

	public int Insert(object obj)
	{
		if (obj == null)
		{
			return 0;
		}
		return Insert(obj, "", Orm.GetType(obj));
	}

	public int InsertOrReplace(object obj)
	{
		if (obj == null)
		{
			return 0;
		}
		return Insert(obj, "OR REPLACE", Orm.GetType(obj));
	}

	public int Insert(object obj, Type objType)
	{
		return Insert(obj, "", objType);
	}

	public int InsertOrReplace(object obj, Type objType)
	{
		return Insert(obj, "OR REPLACE", objType);
	}

	public int Insert(object obj, string extra)
	{
		if (obj == null)
		{
			return 0;
		}
		return Insert(obj, extra, Orm.GetType(obj));
	}

	public int Insert(object obj, string extra, Type objType)
	{
		if (obj == null || objType == null)
		{
			return 0;
		}
		TableMapping mapping = GetMapping(objType);
		if (mapping.PK != null && mapping.PK.IsAutoGuid && mapping.PK.GetValue(obj).Equals(Guid.Empty))
		{
			mapping.PK.SetValue(obj, Guid.NewGuid());
		}
		TableMapping.Column[] array = ((string.Compare(extra, "OR REPLACE", StringComparison.OrdinalIgnoreCase) == 0) ? mapping.InsertOrReplaceColumns : mapping.InsertColumns);
		object[] array2 = new object[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array[i].GetValue(obj);
		}
		PreparedSqlLiteInsertCommand insertCommand = GetInsertCommand(mapping, extra);
		int num;
		lock (insertCommand)
		{
			try
			{
				num = insertCommand.ExecuteNonQuery(array2);
			}
			catch (SQLiteException ex)
			{
				if (SQLite3.ExtendedErrCode(Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
				{
					throw NotNullConstraintViolationException.New(ex.Result, ex.Message, mapping, obj);
				}
				throw;
			}
			if (mapping.HasAutoIncPK)
			{
				long id = SQLite3.LastInsertRowid(Handle);
				mapping.SetAutoIncPK(obj, id);
			}
		}
		if (num > 0)
		{
			OnTableChanged(mapping, NotifyTableChangedAction.Insert);
		}
		return num;
	}

	private PreparedSqlLiteInsertCommand GetInsertCommand(TableMapping map, string extra)
	{
		Tuple<string, string> key = Tuple.Create(map.MappedType.FullName, extra);
		PreparedSqlLiteInsertCommand value;
		lock (_insertCommandMap)
		{
			if (_insertCommandMap.TryGetValue(key, out value))
			{
				return value;
			}
		}
		value = CreateInsertCommand(map, extra);
		lock (_insertCommandMap)
		{
			if (_insertCommandMap.TryGetValue(key, out var value2))
			{
				value.Dispose();
				return value2;
			}
			_insertCommandMap.Add(key, value);
			return value;
		}
	}

	private PreparedSqlLiteInsertCommand CreateInsertCommand(TableMapping map, string extra)
	{
		TableMapping.Column[] array = map.InsertColumns;
		string commandText;
		if (array.Length == 0 && map.Columns.Length == 1 && map.Columns[0].IsAutoInc)
		{
			commandText = string.Format("insert {1} into \"{0}\" default values", map.TableName, extra);
		}
		else
		{
			if (string.Compare(extra, "OR REPLACE", StringComparison.OrdinalIgnoreCase) == 0)
			{
				array = map.InsertOrReplaceColumns;
			}
			commandText = string.Format("insert {3} into \"{0}\"({1}) values ({2})", map.TableName, string.Join(",", array.Select((TableMapping.Column c) => "\"" + c.Name + "\"").ToArray()), string.Join(",", array.Select((TableMapping.Column c) => "?").ToArray()), extra);
		}
		return new PreparedSqlLiteInsertCommand(this, commandText);
	}

	public int Update(object obj)
	{
		if (obj == null)
		{
			return 0;
		}
		return Update(obj, Orm.GetType(obj));
	}

	public int Update(object obj, Type objType)
	{
		int num = 0;
		if (obj == null || objType == null)
		{
			return 0;
		}
		TableMapping mapping = GetMapping(objType);
		TableMapping.Column pk = mapping.PK;
		if (pk == null)
		{
			throw new NotSupportedException("Cannot update " + mapping.TableName + ": it has no PK");
		}
		IEnumerable<TableMapping.Column> source = mapping.Columns.Where((TableMapping.Column p) => p != pk);
		List<object> list = new List<object>(source.Select((TableMapping.Column c) => c.GetValue(obj)));
		if (list.Count == 0)
		{
			source = mapping.Columns;
			list = new List<object>(source.Select((TableMapping.Column c) => c.GetValue(obj)));
		}
		list.Add(pk.GetValue(obj));
		string query = string.Format("update \"{0}\" set {1} where \"{2}\" = ? ", mapping.TableName, string.Join(",", source.Select((TableMapping.Column c) => "\"" + c.Name + "\" = ? ").ToArray()), pk.Name);
		try
		{
			num = Execute(query, list.ToArray());
		}
		catch (SQLiteException ex)
		{
			if (ex.Result == SQLite3.Result.Constraint && SQLite3.ExtendedErrCode(Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
			{
				throw NotNullConstraintViolationException.New(ex, mapping, obj);
			}
			throw;
		}
		if (num > 0)
		{
			OnTableChanged(mapping, NotifyTableChangedAction.Update);
		}
		return num;
	}

	public int UpdateAll(IEnumerable objects, bool runInTransaction = true)
	{
		int c = 0;
		if (runInTransaction)
		{
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Update(@object);
				}
			});
		}
		else
		{
			foreach (object object2 in objects)
			{
				c += Update(object2);
			}
		}
		return c;
	}

	public int Delete(object objectToDelete)
	{
		TableMapping mapping = GetMapping(Orm.GetType(objectToDelete));
		TableMapping.Column pK = mapping.PK;
		if (pK == null)
		{
			throw new NotSupportedException("Cannot delete " + mapping.TableName + ": it has no PK");
		}
		string query = $"delete from \"{mapping.TableName}\" where \"{pK.Name}\" = ?";
		int num = Execute(query, pK.GetValue(objectToDelete));
		if (num > 0)
		{
			OnTableChanged(mapping, NotifyTableChangedAction.Delete);
		}
		return num;
	}

	public int Delete<T>(object primaryKey)
	{
		return Delete(primaryKey, GetMapping(typeof(T)));
	}

	public int Delete(object primaryKey, TableMapping map)
	{
		TableMapping.Column pK = map.PK;
		if (pK == null)
		{
			throw new NotSupportedException("Cannot delete " + map.TableName + ": it has no PK");
		}
		string query = $"delete from \"{map.TableName}\" where \"{pK.Name}\" = ?";
		int num = Execute(query, primaryKey);
		if (num > 0)
		{
			OnTableChanged(map, NotifyTableChangedAction.Delete);
		}
		return num;
	}

	public int DeleteAll<T>()
	{
		TableMapping mapping = GetMapping(typeof(T));
		return DeleteAll(mapping);
	}

	public int DeleteAll(TableMapping map)
	{
		string query = $"delete from \"{map.TableName}\"";
		int num = Execute(query);
		if (num > 0)
		{
			OnTableChanged(map, NotifyTableChangedAction.Delete);
		}
		return num;
	}

	public void Backup(string destinationDatabasePath, string databaseName = "main")
	{
		SQLite3.Result result = SQLite3.Open(destinationDatabasePath, out var db);
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, "Failed to open destination database");
		}
		sqlite3_backup sqlite3_backup = SQLite3.BackupInit(db, databaseName, Handle, databaseName);
		if (sqlite3_backup == NullBackupHandle)
		{
			SQLite3.Close(db);
			throw new Exception("Failed to create backup");
		}
		SQLite3.BackupStep(sqlite3_backup, -1);
		SQLite3.BackupFinish(sqlite3_backup);
		result = SQLite3.GetResult(db);
		string message = "";
		if (result != SQLite3.Result.OK)
		{
			message = SQLite3.GetErrmsg(db);
		}
		SQLite3.Close(db);
		if (result != SQLite3.Result.OK)
		{
			throw SQLiteException.New(result, message);
		}
	}

	~SQLiteConnection()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Close()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		bool flag = LibVersionNumber >= 3007014;
		if (!_open || Handle == NullHandle)
		{
			return;
		}
		try
		{
			if (disposing)
			{
				lock (_insertCommandMap)
				{
					foreach (PreparedSqlLiteInsertCommand value in _insertCommandMap.Values)
					{
						value.Dispose();
					}
					_insertCommandMap.Clear();
				}
				SQLite3.Result result = (flag ? SQLite3.Close2(Handle) : SQLite3.Close(Handle));
				if (result != SQLite3.Result.OK)
				{
					string errmsg = SQLite3.GetErrmsg(Handle);
					throw SQLiteException.New(result, errmsg);
				}
			}
			else if (!flag)
			{
				SQLite3.Close(Handle);
			}
			else
			{
				SQLite3.Close2(Handle);
			}
		}
		finally
		{
			Handle = NullHandle;
			_open = false;
		}
	}

	private void OnTableChanged(TableMapping table, NotifyTableChangedAction action)
	{
		this.TableChanged?.Invoke(this, new NotifyTableChangedEventArgs(table, action));
	}
}
