package androidx.room;

import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RoomRawQuery.kt */
/* JADX INFO: loaded from: classes.dex */
public final class RoomRawQuery {
    private final Function1 bindingFunction;
    private final String sql;

    /* JADX WARN: 'this' call moved to the top of the method (can break code semantics) */
    /* JADX WARN: Multi-variable type inference failed */
    public RoomRawQuery(String sql) {
        this(sql, null, 2, 0 == true ? 1 : 0);
        Intrinsics.checkNotNullParameter(sql, "sql");
    }

    public RoomRawQuery(String sql, final Function1<? super SQLiteStatement, Unit> onBindStatement) {
        Intrinsics.checkNotNullParameter(sql, "sql");
        Intrinsics.checkNotNullParameter(onBindStatement, "onBindStatement");
        this.sql = sql;
        this.bindingFunction = new Function1() { // from class: androidx.room.RoomRawQuery$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return RoomRawQuery.bindingFunction$lambda$1(onBindStatement, (SQLiteStatement) obj);
            }
        };
    }

    public final String getSql() {
        return this.sql;
    }

    public /* synthetic */ RoomRawQuery(String str, Function1 function1, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(str, (i & 2) != 0 ? new Function1() { // from class: androidx.room.RoomRawQuery$$ExternalSyntheticLambda1
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return RoomRawQuery._init_$lambda$0((SQLiteStatement) obj);
            }
        } : function1);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit _init_$lambda$0(SQLiteStatement it) {
        Intrinsics.checkNotNullParameter(it, "it");
        return Unit.INSTANCE;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit bindingFunction$lambda$1(Function1 function1, SQLiteStatement it) {
        Intrinsics.checkNotNullParameter(it, "it");
        function1.invoke(new BindOnlySQLiteStatement(it));
        return Unit.INSTANCE;
    }

    public final Function1<SQLiteStatement, Unit> getBindingFunction() {
        return this.bindingFunction;
    }
}
