package androidx.room;

import androidx.lifecycle.LiveData;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import java.util.concurrent.atomic.AtomicBoolean;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.EmptyCoroutineContext;
import kotlin.coroutines.jvm.internal.ContinuationImpl;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: compiled from: RoomTrackingLiveData.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class RoomTrackingLiveData extends LiveData {
    private final AtomicBoolean computing;
    private final InvalidationLiveDataContainer container;
    private final RoomDatabase database;
    private final boolean inTransaction;
    private final AtomicBoolean invalid;
    private final CoroutineContext launchContext;
    private final InvalidationTracker.Observer observer;
    private final AtomicBoolean registeredObserver;

    /* JADX INFO: renamed from: androidx.room.RoomTrackingLiveData$refresh$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: RoomTrackingLiveData.android.kt */
    static final class C00541 extends ContinuationImpl {
        int I$0;
        Object L$0;
        int label;
        /* synthetic */ Object result;

        C00541(Continuation continuation) {
            super(continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) {
            this.result = obj;
            this.label |= Integer.MIN_VALUE;
            return RoomTrackingLiveData.this.refresh(this);
        }
    }

    public /* synthetic */ RoomTrackingLiveData(RoomDatabase roomDatabase, InvalidationLiveDataContainer invalidationLiveDataContainer, boolean z, String[] strArr, DefaultConstructorMarker defaultConstructorMarker) {
        this(roomDatabase, invalidationLiveDataContainer, z, strArr);
    }

    public abstract Object compute(Continuation continuation);

    private RoomTrackingLiveData(RoomDatabase roomDatabase, InvalidationLiveDataContainer invalidationLiveDataContainer, boolean z, String[] strArr) {
        CoroutineContext queryContext;
        this.database = roomDatabase;
        this.container = invalidationLiveDataContainer;
        this.inTransaction = z;
        this.observer = new RoomTrackingLiveData$observer$1(strArr, this);
        this.invalid = new AtomicBoolean(true);
        this.computing = new AtomicBoolean(false);
        this.registeredObserver = new AtomicBoolean(false);
        if (!roomDatabase.inCompatibilityMode$room_runtime_release()) {
            queryContext = EmptyCoroutineContext.INSTANCE;
        } else if (z) {
            queryContext = roomDatabase.getTransactionContext$room_runtime_release();
        } else {
            queryContext = roomDatabase.getQueryContext();
        }
        this.launchContext = queryContext;
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:26:0x005e  */
    /* JADX WARN: Code duplicated, block: B:29:0x0069 A[Catch: all -> 0x0033, Exception -> 0x0035, TRY_ENTER, TRY_LEAVE, TryCatch #1 {Exception -> 0x0035, blocks: (B:12:0x002c, B:29:0x0069), top: B:49:0x002c, outer: #0 }] */
    /* JADX WARN: Code duplicated, block: B:32:0x0076 A[LOOP:0: B:27:0x0061->B:32:0x0076, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:36:0x0083 A[Catch: all -> 0x0033, TRY_LEAVE, TryCatch #0 {all -> 0x0033, blocks: (B:12:0x002c, B:27:0x0061, B:29:0x0069, B:36:0x0083, B:33:0x0079, B:34:0x0080), top: B:48:0x0022, inners: #1 }] */
    /* JADX WARN: Code duplicated, block: B:40:0x0092  */
    /* JADX WARN: Code duplicated, block: B:42:0x0096  */
    /* JADX WARN: Code duplicated, block: B:52:0x0075 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:7:0x0013  */
    /* JADX WARN: Unsupported multi-entry loop pattern (BACK_EDGE: B:26:0x005e -> B:27:0x0061). Please report as a decompilation issue!!! */
    /* JADX WARN: Unsupported multi-entry loop pattern (BACK_EDGE: B:40:0x0092 -> B:41:0x0094). Please report as a decompilation issue!!! */
    public final Object refresh(Continuation continuation) throws Throwable {
        C00541 c00541;
        RoomTrackingLiveData roomTrackingLiveData;
        RoomTrackingLiveData roomTrackingLiveData2;
        int i;
        Object obj;
        Object objCompute;
        if (continuation instanceof C00541) {
            c00541 = (C00541) continuation;
            int i2 = c00541.label;
            if ((i2 & Integer.MIN_VALUE) != 0) {
                c00541.label = i2 - Integer.MIN_VALUE;
            } else {
                c00541 = new C00541(continuation);
            }
        } else {
            c00541 = new C00541(continuation);
        }
        Object obj2 = c00541.result;
        Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        int i3 = c00541.label;
        try {
            if (i3 == 0) {
                ResultKt.throwOnFailure(obj2);
                if (this.registeredObserver.compareAndSet(false, true)) {
                    this.database.getInvalidationTracker().addWeakObserver(this.observer);
                }
                roomTrackingLiveData2 = this;
                if (roomTrackingLiveData2.computing.compareAndSet(false, true)) {
                    obj = null;
                    roomTrackingLiveData = roomTrackingLiveData2;
                    i = 0;
                    while (roomTrackingLiveData.invalid.compareAndSet(true, false)) {
                        c00541.L$0 = roomTrackingLiveData;
                        c00541.I$0 = 1;
                        c00541.label = 1;
                        objCompute = roomTrackingLiveData.compute(c00541);
                        if (objCompute == coroutine_suspended) {
                            return coroutine_suspended;
                        }
                        obj = objCompute;
                        i = 1;
                    }
                    if (i != 0) {
                        roomTrackingLiveData.postValue(obj);
                    }
                    roomTrackingLiveData.computing.set(false);
                } else {
                    roomTrackingLiveData = roomTrackingLiveData2;
                    i = 0;
                }
                if (i == 0) {
                }
                return Unit.INSTANCE;
            }
            if (i3 != 1) {
                throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
            }
            int i4 = c00541.I$0;
            roomTrackingLiveData = (RoomTrackingLiveData) c00541.L$0;
            try {
                ResultKt.throwOnFailure(obj2);
                obj = obj2;
                i = i4;
                while (roomTrackingLiveData.invalid.compareAndSet(true, false)) {
                    c00541.L$0 = roomTrackingLiveData;
                    c00541.I$0 = 1;
                    c00541.label = 1;
                    objCompute = roomTrackingLiveData.compute(c00541);
                    if (objCompute == coroutine_suspended) {
                        return coroutine_suspended;
                    }
                    obj = objCompute;
                    i = 1;
                }
                if (i != 0) {
                    roomTrackingLiveData.postValue(obj);
                }
                roomTrackingLiveData.computing.set(false);
                if (i == 0 && roomTrackingLiveData.invalid.get()) {
                    roomTrackingLiveData2 = roomTrackingLiveData;
                    if (roomTrackingLiveData2.computing.compareAndSet(false, true)) {
                        obj = null;
                        roomTrackingLiveData = roomTrackingLiveData2;
                        i = 0;
                        while (roomTrackingLiveData.invalid.compareAndSet(true, false)) {
                            c00541.L$0 = roomTrackingLiveData;
                            c00541.I$0 = 1;
                            c00541.label = 1;
                            objCompute = roomTrackingLiveData.compute(c00541);
                            if (objCompute == coroutine_suspended) {
                                return coroutine_suspended;
                            }
                            obj = objCompute;
                            i = 1;
                        }
                        if (i != 0) {
                            roomTrackingLiveData.postValue(obj);
                        }
                        roomTrackingLiveData.computing.set(false);
                    } else {
                        roomTrackingLiveData = roomTrackingLiveData2;
                        i = 0;
                    }
                    if (i == 0) {
                    }
                    return Unit.INSTANCE;
                }
                return Unit.INSTANCE;
            } catch (Exception e) {
                throw new RuntimeException("Exception while computing database live data.", e);
            }
        } catch (Throwable th) {
            roomTrackingLiveData.computing.set(false);
            throw th;
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public final void invalidated() {
        boolean zHasActiveObservers = hasActiveObservers();
        if (this.invalid.compareAndSet(false, true) && zHasActiveObservers) {
            BuildersKt__Builders_commonKt.launch$default(this.database.getCoroutineScope(), this.launchContext, null, new AnonymousClass1(null), 2, null);
        }
    }

    /* JADX INFO: renamed from: androidx.room.RoomTrackingLiveData$invalidated$1, reason: invalid class name */
    /* JADX INFO: compiled from: RoomTrackingLiveData.android.kt */
    static final class AnonymousClass1 extends SuspendLambda implements Function2 {
        int label;

        AnonymousClass1(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return RoomTrackingLiveData.this.new AnonymousClass1(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((AnonymousClass1) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i = this.label;
            if (i == 0) {
                ResultKt.throwOnFailure(obj);
                RoomTrackingLiveData roomTrackingLiveData = RoomTrackingLiveData.this;
                this.label = 1;
                if (roomTrackingLiveData.refresh(this) == coroutine_suspended) {
                    return coroutine_suspended;
                }
            } else {
                if (i != 1) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(obj);
            }
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.lifecycle.LiveData
    protected void onActive() {
        super.onActive();
        this.container.onActive(this);
        BuildersKt__Builders_commonKt.launch$default(this.database.getCoroutineScope(), this.launchContext, null, new C00531(null), 2, null);
    }

    /* JADX INFO: renamed from: androidx.room.RoomTrackingLiveData$onActive$1, reason: invalid class name and case insensitive filesystem */
    /* JADX INFO: compiled from: RoomTrackingLiveData.android.kt */
    static final class C00531 extends SuspendLambda implements Function2 {
        int label;

        C00531(Continuation continuation) {
            super(2, continuation);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation create(Object obj, Continuation continuation) {
            return RoomTrackingLiveData.this.new C00531(continuation);
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation continuation) {
            return ((C00531) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i = this.label;
            if (i == 0) {
                ResultKt.throwOnFailure(obj);
                RoomTrackingLiveData roomTrackingLiveData = RoomTrackingLiveData.this;
                this.label = 1;
                if (roomTrackingLiveData.refresh(this) == coroutine_suspended) {
                    return coroutine_suspended;
                }
            } else {
                if (i != 1) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(obj);
            }
            return Unit.INSTANCE;
        }
    }

    @Override // androidx.lifecycle.LiveData
    protected void onInactive() {
        super.onInactive();
        this.container.onInactive(this);
    }
}
