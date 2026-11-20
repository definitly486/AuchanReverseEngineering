package com.scanflow.datacapture.barinternal.androidx.room.support;

import android.content.ContentValues;
import android.database.Cursor;
import android.os.CancellationSignal;
import androidx.room.RoomDatabase;
import androidx.sqlite.db.SupportSQLiteDatabase;
import androidx.sqlite.db.SupportSQLiteQuery;
import androidx.sqlite.db.SupportSQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import java.io.IOException;
import java.util.List;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class QueryInterceptorDatabase implements SupportSQLiteDatabase {
    private final SupportSQLiteDatabase delegate;
    private final RoomDatabase.QueryCallback queryCallback;
    private final CoroutineScope queryCallbackScope;

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void beginTransactionReadOnly() {
        this.delegate.beginTransactionReadOnly();
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public void close() throws IOException {
        this.delegate.close();
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public List getAttachedDbs() {
        return this.delegate.getAttachedDbs();
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public String getPath() {
        return this.delegate.getPath();
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public boolean inTransaction() {
        return this.delegate.inTransaction();
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public boolean isOpen() {
        return this.delegate.isOpen();
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public boolean isWriteAheadLoggingEnabled() {
        return this.delegate.isWriteAheadLoggingEnabled();
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void setVersion(int i) {
        this.delegate.setVersion(i);
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public int update(String table, int i, ContentValues values, String str, Object[] objArr) {
        Intrinsics.checkNotNullParameter(table, "table");
        Intrinsics.checkNotNullParameter(values, "values");
        return this.delegate.update(table, i, values, str, objArr);
    }

    public QueryInterceptorDatabase(SupportSQLiteDatabase delegate, CoroutineScope queryCallbackScope, RoomDatabase.QueryCallback queryCallback) {
        Intrinsics.checkNotNullParameter(delegate, "delegate");
        Intrinsics.checkNotNullParameter(queryCallbackScope, "queryCallbackScope");
        Intrinsics.checkNotNullParameter(queryCallback, "queryCallback");
        this.delegate = delegate;
        this.queryCallbackScope = queryCallbackScope;
        this.queryCallback = queryCallback;
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public SupportSQLiteStatement compileStatement(String sql) {
        Intrinsics.checkNotNullParameter(sql, "sql");
        return new QueryInterceptorStatement(this.delegate.compileStatement(sql), sql, this.queryCallbackScope, this.queryCallback);
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$beginTransaction$1, reason: invalid class name */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class AnonymousClass1 extends SuspendLambda implements Function2 {
        int label;

        AnonymousClass1(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new AnonymousClass1(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass1) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label == 0) {
                ResultKt.throwOnFailure(obj);
                QueryInterceptorDatabase.this.queryCallback.onQuery("BEGIN EXCLUSIVE TRANSACTION", CollectionsKt.emptyList());
                return Unit.INSTANCE;
            }
            throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void beginTransaction() {
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new AnonymousClass1(null), 3, null);
        this.delegate.beginTransaction();
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$beginTransactionNonExclusive$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class C00771 extends SuspendLambda implements Function2 {
        int label;

        C00771(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new C00771(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00771) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label == 0) {
                ResultKt.throwOnFailure(obj);
                QueryInterceptorDatabase.this.queryCallback.onQuery("BEGIN IMMEDIATE TRANSACTION", CollectionsKt.emptyList());
                return Unit.INSTANCE;
            }
            throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void beginTransactionNonExclusive() {
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new C00771(null), 3, null);
        this.delegate.beginTransactionNonExclusive();
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$endTransaction$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class C00781 extends SuspendLambda implements Function2 {
        int label;

        C00781(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new C00781(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00781) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label != 0) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
            QueryInterceptorDatabase.this.queryCallback.onQuery("END TRANSACTION", CollectionsKt.emptyList());
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void endTransaction() {
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new C00781(null), 3, null);
        this.delegate.endTransaction();
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$setTransactionSuccessful$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class C00811 extends SuspendLambda implements Function2 {
        int label;

        C00811(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new C00811(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00811) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label != 0) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
            QueryInterceptorDatabase.this.queryCallback.onQuery("TRANSACTION SUCCESSFUL", CollectionsKt.emptyList());
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void setTransactionSuccessful() {
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new C00811(null), 3, null);
        this.delegate.setTransactionSuccessful();
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$query$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class C00801 extends SuspendLambda implements Function2 {
        final /* synthetic */ String $query;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        C00801(String str, Continuation continuation) {
            super(2, continuation);
            this.$query = str;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new C00801(this.$query, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00801) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label != 0) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
            QueryInterceptorDatabase.this.queryCallback.onQuery(this.$query, CollectionsKt.emptyList());
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public Cursor query(String query) {
        Intrinsics.checkNotNullParameter(query, "query");
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new C00801(query, null), 3, null);
        return this.delegate.query(query);
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public Cursor query(SupportSQLiteQuery query) {
        Intrinsics.checkNotNullParameter(query, "query");
        QueryInterceptorProgram queryInterceptorProgram = new QueryInterceptorProgram();
        query.bindTo(queryInterceptorProgram);
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new AnonymousClass3(query, queryInterceptorProgram, null), 3, null);
        return this.delegate.query(query);
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$query$3, reason: invalid class name */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class AnonymousClass3 extends SuspendLambda implements Function2 {
        final /* synthetic */ SupportSQLiteQuery $query;
        final /* synthetic */ QueryInterceptorProgram $queryInterceptorProgram;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        AnonymousClass3(SupportSQLiteQuery supportSQLiteQuery, QueryInterceptorProgram queryInterceptorProgram, Continuation continuation) {
            super(2, continuation);
            this.$query = supportSQLiteQuery;
            this.$queryInterceptorProgram = queryInterceptorProgram;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new AnonymousClass3(this.$query, this.$queryInterceptorProgram, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass3) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label == 0) {
                ResultKt.throwOnFailure(obj);
                QueryInterceptorDatabase.this.queryCallback.onQuery(this.$query.getSql(), this.$queryInterceptorProgram.getBindArgsCache$room_runtime_release());
                return Unit.INSTANCE;
            }
            throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public Cursor query(SupportSQLiteQuery query, CancellationSignal cancellationSignal) {
        Intrinsics.checkNotNullParameter(query, "query");
        QueryInterceptorProgram queryInterceptorProgram = new QueryInterceptorProgram();
        query.bindTo(queryInterceptorProgram);
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new AnonymousClass4(query, queryInterceptorProgram, null), 3, null);
        return this.delegate.query(query);
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$query$4, reason: invalid class name */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class AnonymousClass4 extends SuspendLambda implements Function2 {
        final /* synthetic */ SupportSQLiteQuery $query;
        final /* synthetic */ QueryInterceptorProgram $queryInterceptorProgram;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        AnonymousClass4(SupportSQLiteQuery supportSQLiteQuery, QueryInterceptorProgram queryInterceptorProgram, Continuation continuation) {
            super(2, continuation);
            this.$query = supportSQLiteQuery;
            this.$queryInterceptorProgram = queryInterceptorProgram;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new AnonymousClass4(this.$query, this.$queryInterceptorProgram, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass4) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label == 0) {
                ResultKt.throwOnFailure(obj);
                QueryInterceptorDatabase.this.queryCallback.onQuery(this.$query.getSql(), this.$queryInterceptorProgram.getBindArgsCache$room_runtime_release());
                return Unit.INSTANCE;
            }
            throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
        }
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$execSQL$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class C00791 extends SuspendLambda implements Function2 {
        final /* synthetic */ String $sql;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        C00791(String str, Continuation continuation) {
            super(2, continuation);
            this.$sql = str;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new C00791(this.$sql, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00791) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label != 0) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
            QueryInterceptorDatabase.this.queryCallback.onQuery(this.$sql, CollectionsKt.emptyList());
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void execSQL(String sql) {
        Intrinsics.checkNotNullParameter(sql, "sql");
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new C00791(sql, null), 3, null);
        this.delegate.execSQL(sql);
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.androidx.room.support.QueryInterceptorDatabase$execSQL$2, reason: invalid class name */
    /* JADX INFO: compiled from: QueryInterceptorDatabase.android.kt */
    static final class AnonymousClass2 extends SuspendLambda implements Function2 {
        final /* synthetic */ List $argsCopy;
        final /* synthetic */ String $sql;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        AnonymousClass2(String str, List list, Continuation continuation) {
            super(2, continuation);
            this.$sql = str;
            this.$argsCopy = list;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return QueryInterceptorDatabase.this.new AnonymousClass2(this.$sql, this.$argsCopy, continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass2) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            IntrinsicsKt.getCOROUTINE_SUSPENDED();
            if (this.label != 0) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            ResultKt.throwOnFailure(obj);
            QueryInterceptorDatabase.this.queryCallback.onQuery(this.$sql, this.$argsCopy);
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.sqlite.db.SupportSQLiteDatabase
    public void execSQL(String sql, Object[] bindArgs) {
        Intrinsics.checkNotNullParameter(sql, "sql");
        Intrinsics.checkNotNullParameter(bindArgs, "bindArgs");
        BuildersKt__Builders_commonKt.launch$default(this.queryCallbackScope, null, null, new AnonymousClass2(sql, ArraysKt.toList(bindArgs), null), 3, null);
        this.delegate.execSQL(sql, bindArgs);
    }
}
