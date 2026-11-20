package androidx.room;

import java.util.concurrent.Callable;
import kotlin.coroutines.Continuation;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RoomTrackingLiveData.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class RoomCallableTrackingLiveData extends RoomTrackingLiveData {
    private final Callable callableFunction;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public RoomCallableTrackingLiveData(RoomDatabase database, InvalidationLiveDataContainer container, boolean z, String[] tableNames, Callable callableFunction) {
        super(database, container, z, tableNames, null);
        Intrinsics.checkNotNullParameter(database, "database");
        Intrinsics.checkNotNullParameter(container, "container");
        Intrinsics.checkNotNullParameter(tableNames, "tableNames");
        Intrinsics.checkNotNullParameter(callableFunction, "callableFunction");
        this.callableFunction = callableFunction;
    }

    @Override // androidx.room.RoomTrackingLiveData
    public Object compute(Continuation continuation) {
        return this.callableFunction.call();
    }
}
