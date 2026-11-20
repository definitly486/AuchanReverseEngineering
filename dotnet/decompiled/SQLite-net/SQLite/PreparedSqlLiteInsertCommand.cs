using System;
using SQLitePCL;

namespace SQLite;

internal class PreparedSqlLiteInsertCommand : IDisposable
{
	private bool Initialized;

	private SQLiteConnection Connection;

	private string CommandText;

	private sqlite3_stmt Statement;

	private static readonly sqlite3_stmt NullStatement;

	public PreparedSqlLiteInsertCommand(SQLiteConnection conn, string commandText)
	{
		Connection = conn;
		CommandText = commandText;
	}

	public int ExecuteNonQuery(object[] source)
	{
		if (Initialized && Statement == NullStatement)
		{
			throw new ObjectDisposedException("PreparedSqlLiteInsertCommand");
		}
		if (Connection.Trace)
		{
			Connection.Tracer?.Invoke("Executing: " + CommandText);
		}
		SQLite3.Result result = SQLite3.Result.OK;
		if (!Initialized)
		{
			Statement = SQLite3.Prepare2(Connection.Handle, CommandText);
			Initialized = true;
		}
		if (source != null)
		{
			for (int i = 0; i < source.Length; i++)
			{
				SQLiteCommand.BindParameter(Statement, i + 1, source[i], Connection.StoreDateTimeAsTicks, Connection.DateTimeStringFormat, Connection.StoreTimeSpanAsTicks);
			}
		}
		result = SQLite3.Step(Statement);
		switch (result)
		{
		case SQLite3.Result.Done:
		{
			int result2 = SQLite3.Changes(Connection.Handle);
			SQLite3.Reset(Statement);
			return result2;
		}
		case SQLite3.Result.Error:
		{
			string errmsg = SQLite3.GetErrmsg(Connection.Handle);
			SQLite3.Reset(Statement);
			throw SQLiteException.New(result, errmsg);
		}
		case SQLite3.Result.Constraint:
			if (SQLite3.ExtendedErrCode(Connection.Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
			{
				SQLite3.Reset(Statement);
				throw NotNullConstraintViolationException.New(result, SQLite3.GetErrmsg(Connection.Handle));
			}
			break;
		}
		SQLite3.Reset(Statement);
		throw SQLiteException.New(result, SQLite3.GetErrmsg(Connection.Handle));
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		sqlite3_stmt statement = Statement;
		Statement = NullStatement;
		Connection = null;
		if (statement != NullStatement)
		{
			SQLite3.Finalize(statement);
		}
	}

	~PreparedSqlLiteInsertCommand()
	{
		Dispose(disposing: false);
	}
}
