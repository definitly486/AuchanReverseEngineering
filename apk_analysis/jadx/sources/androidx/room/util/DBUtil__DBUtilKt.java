package androidx.room.util;

import android.database.SQLException;
import androidx.room.InvalidationTracker;
import androidx.room.RoomDatabase;
import androidx.room.Transactor;
import androidx.sqlite.SQLite;
import androidx.sqlite.SQLiteConnection;
import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlin.jdk7.AutoCloseableKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: DBUtil.kt */
/* JADX INFO: loaded from: classes.dex */
abstract /* synthetic */ class DBUtil__DBUtilKt {

    /* JADX INFO: renamed from: androidx.room.util.DBUtil__DBUtilKt$internalPerform$2, reason: invalid class name */
    /* JADX INFO: compiled from: DBUtil.kt */
    public static final class AnonymousClass2 extends SuspendLambda implements Function2 {
        final /* synthetic */ Function2 $block;
        final /* synthetic */ boolean $inTransaction;
        final /* synthetic */ boolean $isReadOnly;
        final /* synthetic */ RoomDatabase $this_internalPerform;
        /* synthetic */ Object L$0;
        Object L$1;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        public AnonymousClass2(boolean z, boolean z2, RoomDatabase roomDatabase, Function2 function2, Continuation continuation) {
            super(2, continuation);
            this.$inTransaction = z;
            this.$isReadOnly = z2;
            this.$this_internalPerform = roomDatabase;
            this.$block = function2;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            AnonymousClass2 anonymousClass2 = new AnonymousClass2(this.$inTransaction, this.$isReadOnly, this.$this_internalPerform, this.$block, continuation);
            anonymousClass2.L$0 = obj;
            return anonymousClass2;
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(Transactor transactor, Continuation continuation) {
            return ((AnonymousClass2) create(transactor, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        /* JADX WARN: Code duplicated, block: B:38:0x00a8 A[PHI: r1 r9
          0x00a8: PHI (r1v11 androidx.room.Transactor) = (r1v8 androidx.room.Transactor), (r1v18 androidx.room.Transactor) binds: [B:36:0x00a5, B:14:0x002a] A[DONT_GENERATE, DONT_INLINE]
          0x00a8: PHI (r9v13 java.lang.Object) = (r9v12 java.lang.Object), (r9v0 java.lang.Object) binds: [B:36:0x00a5, B:14:0x002a] A[DONT_GENERATE, DONT_INLINE]] */
        /* JADX WARN: Code duplicated, block: B:40:0x00ac  */
        /* JADX WARN: Code duplicated, block: B:43:0x00b7  */
        /* JADX WARN: Code duplicated, block: B:46:0x00c1  */
        /* JADX WARN: Code duplicated, block: B:48:0x00cb A[RETURN] */
        /* JADX WARN: Code restructure failed: missing block: B:31:0x008b, code lost:
        
            if (r9.sync$room_runtime_release(r8) == r0) goto L51;
         */
        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        /*
            Code decompiled incorrectly, please refer to instructions dump.
        */
        public final Object invokeSuspend(Object obj) throws Throwable {
            Transactor.SQLiteTransactionType sQLiteTransactionType;
            Transactor transactor;
            Transactor transactor2;
            Transactor.SQLiteTransactionType sQLiteTransactionType2;
            Object objInTransaction;
            Object obj2;
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i = this.label;
            if (i == 0) {
                ResultKt.throwOnFailure(obj);
                Transactor transactor3 = (Transactor) this.L$0;
                if (this.$inTransaction) {
                    boolean z = this.$isReadOnly;
                    if (z) {
                        sQLiteTransactionType = Transactor.SQLiteTransactionType.DEFERRED;
                    } else {
                        sQLiteTransactionType = Transactor.SQLiteTransactionType.IMMEDIATE;
                    }
                    if (!z) {
                        this.L$0 = transactor3;
                        this.L$1 = sQLiteTransactionType;
                        this.label = 1;
                        Object objInTransaction2 = transactor3.inTransaction(this);
                        if (objInTransaction2 != coroutine_suspended) {
                            Transactor.SQLiteTransactionType sQLiteTransactionType3 = sQLiteTransactionType;
                            transactor2 = transactor3;
                            obj = objInTransaction2;
                            sQLiteTransactionType2 = sQLiteTransactionType3;
                        }
                    } else {
                        transactor = transactor3;
                        DBUtil__DBUtilKt$internalPerform$2$result$1 dBUtil__DBUtilKt$internalPerform$2$result$1 = new DBUtil__DBUtilKt$internalPerform$2$result$1(this.$block, null);
                        this.L$0 = transactor;
                        this.L$1 = null;
                        this.label = 3;
                        obj = transactor.withTransaction(sQLiteTransactionType, dBUtil__DBUtilKt$internalPerform$2$result$1, this);
                        if (obj != coroutine_suspended) {
                            if (!this.$isReadOnly) {
                                return obj;
                            }
                            this.L$0 = obj;
                            this.label = 4;
                            objInTransaction = transactor.inTransaction(this);
                            if (objInTransaction != coroutine_suspended) {
                                obj2 = obj;
                                obj = objInTransaction;
                                if (!((Boolean) obj).booleanValue()) {
                                    this.$this_internalPerform.getInvalidationTracker().refreshAsync();
                                }
                                return obj2;
                            }
                        }
                    }
                } else {
                    Function2 function2 = this.$block;
                    this.label = 5;
                    Object objInvoke = function2.invoke(transactor3, this);
                    if (objInvoke != coroutine_suspended) {
                        return objInvoke;
                    }
                }
                return coroutine_suspended;
            }
            if (i == 1) {
                sQLiteTransactionType2 = (Transactor.SQLiteTransactionType) this.L$1;
                transactor2 = (Transactor) this.L$0;
                ResultKt.throwOnFailure(obj);
            } else {
                if (i == 2) {
                    sQLiteTransactionType2 = (Transactor.SQLiteTransactionType) this.L$1;
                    transactor2 = (Transactor) this.L$0;
                    ResultKt.throwOnFailure(obj);
                    Transactor transactor4 = transactor2;
                    sQLiteTransactionType = sQLiteTransactionType2;
                    transactor = transactor4;
                    DBUtil__DBUtilKt$internalPerform$2$result$1 dBUtil__DBUtilKt$internalPerform$2$result$2 = new DBUtil__DBUtilKt$internalPerform$2$result$1(this.$block, null);
                    this.L$0 = transactor;
                    this.L$1 = null;
                    this.label = 3;
                    obj = transactor.withTransaction(sQLiteTransactionType, dBUtil__DBUtilKt$internalPerform$2$result$2, this);
                    if (obj != coroutine_suspended) {
                        if (!this.$isReadOnly) {
                            return obj;
                        }
                        this.L$0 = obj;
                        this.label = 4;
                        objInTransaction = transactor.inTransaction(this);
                        if (objInTransaction != coroutine_suspended) {
                            obj2 = obj;
                            obj = objInTransaction;
                        }
                    }
                    return coroutine_suspended;
                }
                if (i == 3) {
                    transactor = (Transactor) this.L$0;
                    ResultKt.throwOnFailure(obj);
                    if (!this.$isReadOnly) {
                        return obj;
                    }
                    this.L$0 = obj;
                    this.label = 4;
                    objInTransaction = transactor.inTransaction(this);
                    if (objInTransaction != coroutine_suspended) {
                        obj2 = obj;
                        obj = objInTransaction;
                    }
                    return coroutine_suspended;
                }
                if (i != 4) {
                    if (i != 5) {
                        throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                    }
                    ResultKt.throwOnFailure(obj);
                    return obj;
                }
                obj2 = this.L$0;
                ResultKt.throwOnFailure(obj);
            }
            if (!((Boolean) obj).booleanValue()) {
                this.$this_internalPerform.getInvalidationTracker().refreshAsync();
            }
            return obj2;
            if (!((Boolean) obj).booleanValue()) {
                InvalidationTracker invalidationTracker = this.$this_internalPerform.getInvalidationTracker();
                this.L$0 = transactor2;
                this.L$1 = sQLiteTransactionType2;
                this.label = 2;
            }
            Transactor transactor5 = transactor2;
            sQLiteTransactionType = sQLiteTransactionType2;
            transactor = transactor5;
            DBUtil__DBUtilKt$internalPerform$2$result$1 dBUtil__DBUtilKt$internalPerform$2$result$3 = new DBUtil__DBUtilKt$internalPerform$2$result$1(this.$block, null);
            this.L$0 = transactor;
            this.L$1 = null;
            this.label = 3;
            obj = transactor.withTransaction(sQLiteTransactionType, dBUtil__DBUtilKt$internalPerform$2$result$3, this);
            if (obj != coroutine_suspended) {
                if (!this.$isReadOnly) {
                    return obj;
                }
                this.L$0 = obj;
                this.label = 4;
                objInTransaction = transactor.inTransaction(this);
                if (objInTransaction != coroutine_suspended) {
                    obj2 = obj;
                    obj = objInTransaction;
                    if (!((Boolean) obj).booleanValue()) {
                        this.$this_internalPerform.getInvalidationTracker().refreshAsync();
                    }
                    return obj2;
                }
            }
            return coroutine_suspended;
        }
    }

    public static final Object internalPerform(RoomDatabase roomDatabase, boolean z, boolean z2, Function2 function2, Continuation continuation) {
        return roomDatabase.useConnection$room_runtime_release(z, new AnonymousClass2(z2, z, roomDatabase, function2, null), continuation);
    }

    public static final void dropFtsSyncTriggers(SQLiteConnection connection) {
        Intrinsics.checkNotNullParameter(connection, "connection");
        List listCreateListBuilder = CollectionsKt.createListBuilder();
        SQLiteStatement sQLiteStatementPrepare = connection.prepare("SELECT name FROM sqlite_master WHERE type = 'trigger'");
        while (sQLiteStatementPrepare.step()) {
            try {
                listCreateListBuilder.add(sQLiteStatementPrepare.getText(0));
            } catch (Throwable th) {
                try {
                    throw th;
                } catch (Throwable th2) {
                    AutoCloseableKt.closeFinally(sQLiteStatementPrepare, th);
                    throw th2;
                }
            }
        }
        Unit unit = Unit.INSTANCE;
        AutoCloseableKt.closeFinally(sQLiteStatementPrepare, null);
        for (String str : CollectionsKt.build(listCreateListBuilder)) {
            if (StringsKt.startsWith$default(str, "room_fts_content_sync_", false, 2, (Object) null)) {
                SQLite.execSQL(connection, "DROP TRIGGER IF EXISTS " + str);
            }
        }
    }

    public static final void foreignKeyCheck(SQLiteConnection db, String tableName) {
        Intrinsics.checkNotNullParameter(db, "db");
        Intrinsics.checkNotNullParameter(tableName, "tableName");
        SQLiteStatement sQLiteStatementPrepare = db.prepare("PRAGMA foreign_key_check(`" + tableName + "`)");
        try {
            if (sQLiteStatementPrepare.step()) {
                throw new SQLException(processForeignKeyCheckFailure$DBUtil__DBUtilKt(sQLiteStatementPrepare));
            }
            Unit unit = Unit.INSTANCE;
            AutoCloseableKt.closeFinally(sQLiteStatementPrepare, null);
        } catch (Throwable th) {
            try {
                throw th;
            } catch (Throwable th2) {
                AutoCloseableKt.closeFinally(sQLiteStatementPrepare, th);
                throw th2;
            }
        }
    }

    private static final String processForeignKeyCheckFailure$DBUtil__DBUtilKt(SQLiteStatement sQLiteStatement) {
        StringBuilder sb = new StringBuilder();
        LinkedHashMap linkedHashMap = new LinkedHashMap();
        int i = 0;
        do {
            if (i == 0) {
                sb.append("Foreign key violation(s) detected in '");
                sb.append(sQLiteStatement.getText(0));
                sb.append("'.\n");
            }
            String text = sQLiteStatement.getText(3);
            if (!linkedHashMap.containsKey(text)) {
                linkedHashMap.put(text, sQLiteStatement.getText(2));
            }
            i++;
        } while (sQLiteStatement.step());
        sb.append("Number of different violations discovered: ");
        sb.append(linkedHashMap.keySet().size());
        sb.append("\n");
        sb.append("Number of rows in violation: ");
        sb.append(i);
        sb.append("\n");
        sb.append("Violation(s) detected in the following constraint(s):\n");
        for (Map.Entry entry : linkedHashMap.entrySet()) {
            String str = (String) entry.getKey();
            String str2 = (String) entry.getValue();
            sb.append("\tParent Table = ");
            sb.append(str2);
            sb.append(", Foreign Key Constraint Index = ");
            sb.append(str);
            sb.append("\n");
        }
        return sb.toString();
    }
}
