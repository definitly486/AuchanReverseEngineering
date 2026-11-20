package androidx.lifecycle;

import androidx.arch.core.util.Function;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Ref$BooleanRef;
import kotlin.jvm.internal.Ref$ObjectRef;

/* JADX INFO: compiled from: Transformations.kt */
/* JADX INFO: loaded from: classes.dex */
public final class Transformations {
    public static final <X, Y> LiveData<Y> map(LiveData<X> liveData, final Function1<X, Y> transform) {
        final MediatorLiveData mediatorLiveData;
        Intrinsics.checkNotNullParameter(liveData, "<this>");
        Intrinsics.checkNotNullParameter(transform, "transform");
        if (liveData.isInitialized()) {
            mediatorLiveData = new MediatorLiveData(transform.invoke(liveData.getValue()));
        } else {
            mediatorLiveData = new MediatorLiveData();
        }
        mediatorLiveData.addSource(liveData, new Transformations$sam$androidx_lifecycle_Observer$0(new Function1() { // from class: androidx.lifecycle.Transformations$$ExternalSyntheticLambda1
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return Transformations.map$lambda$0(mediatorLiveData, transform, obj);
            }
        }));
        return mediatorLiveData;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit map$lambda$0(MediatorLiveData mediatorLiveData, Function1 function1, Object obj) {
        mediatorLiveData.setValue(function1.invoke(obj));
        return Unit.INSTANCE;
    }

    public static final /* synthetic */ LiveData map(LiveData liveData, final Function mapFunction) {
        Intrinsics.checkNotNullParameter(liveData, "<this>");
        Intrinsics.checkNotNullParameter(mapFunction, "mapFunction");
        final MediatorLiveData mediatorLiveData = new MediatorLiveData();
        mediatorLiveData.addSource(liveData, new Transformations$sam$androidx_lifecycle_Observer$0(new Function1() { // from class: androidx.lifecycle.Transformations$$ExternalSyntheticLambda3
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return Transformations.map$lambda$1(mediatorLiveData, mapFunction, obj);
            }
        }));
        return mediatorLiveData;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit map$lambda$1(MediatorLiveData mediatorLiveData, Function function, Object obj) {
        mediatorLiveData.setValue(function.apply(obj));
        return Unit.INSTANCE;
    }

    public static final <X, Y> LiveData<Y> switchMap(LiveData<X> liveData, final Function1<X, LiveData<Y>> transform) {
        final MediatorLiveData mediatorLiveData;
        LiveData<Y> liveDataInvoke;
        Intrinsics.checkNotNullParameter(liveData, "<this>");
        Intrinsics.checkNotNullParameter(transform, "transform");
        final Ref$ObjectRef ref$ObjectRef = new Ref$ObjectRef();
        if (liveData.isInitialized() && (liveDataInvoke = transform.invoke(liveData.getValue())) != null && liveDataInvoke.isInitialized()) {
            mediatorLiveData = new MediatorLiveData(liveDataInvoke.getValue());
        } else {
            mediatorLiveData = new MediatorLiveData();
        }
        mediatorLiveData.addSource(liveData, new Transformations$sam$androidx_lifecycle_Observer$0(new Function1() { // from class: androidx.lifecycle.Transformations$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return Transformations.switchMap$lambda$3(transform, ref$ObjectRef, mediatorLiveData, obj);
            }
        }));
        return mediatorLiveData;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit switchMap$lambda$3(Function1 function1, Ref$ObjectRef ref$ObjectRef, final MediatorLiveData mediatorLiveData, Object obj) {
        LiveData liveData = (LiveData) function1.invoke(obj);
        Object obj2 = ref$ObjectRef.element;
        if (obj2 != liveData) {
            if (obj2 != null) {
                Intrinsics.checkNotNull(obj2);
                mediatorLiveData.removeSource((LiveData) obj2);
            }
            ref$ObjectRef.element = liveData;
            if (liveData != null) {
                Intrinsics.checkNotNull(liveData);
                mediatorLiveData.addSource(liveData, new Transformations$sam$androidx_lifecycle_Observer$0(new Function1() { // from class: androidx.lifecycle.Transformations$$ExternalSyntheticLambda4
                    @Override // kotlin.jvm.functions.Function1
                    public final Object invoke(Object obj3) {
                        return Transformations.switchMap$lambda$3$lambda$2(mediatorLiveData, obj3);
                    }
                }));
            }
        }
        return Unit.INSTANCE;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit switchMap$lambda$3$lambda$2(MediatorLiveData mediatorLiveData, Object obj) {
        mediatorLiveData.setValue(obj);
        return Unit.INSTANCE;
    }

    public static final /* synthetic */ LiveData switchMap(LiveData liveData, Function switchMapFunction) {
        Intrinsics.checkNotNullParameter(liveData, "<this>");
        Intrinsics.checkNotNullParameter(switchMapFunction, "switchMapFunction");
        MediatorLiveData mediatorLiveData = new MediatorLiveData();
        mediatorLiveData.addSource(liveData, new AnonymousClass2(switchMapFunction, mediatorLiveData));
        return mediatorLiveData;
    }

    /* JADX INFO: renamed from: androidx.lifecycle.Transformations$switchMap$2, reason: invalid class name */
    /* JADX INFO: compiled from: Transformations.kt */
    public static final class AnonymousClass2 implements Observer {
        final /* synthetic */ MediatorLiveData $result;
        final /* synthetic */ Function $switchMapFunction;
        private LiveData liveData;

        AnonymousClass2(Function function, MediatorLiveData mediatorLiveData) {
            this.$switchMapFunction = function;
            this.$result = mediatorLiveData;
        }

        public final LiveData getLiveData() {
            return this.liveData;
        }

        public final void setLiveData(LiveData liveData) {
            this.liveData = liveData;
        }

        @Override // androidx.lifecycle.Observer
        public void onChanged(Object obj) {
            LiveData liveData = (LiveData) this.$switchMapFunction.apply(obj);
            LiveData liveData2 = this.liveData;
            if (liveData2 == liveData) {
                return;
            }
            if (liveData2 != null) {
                MediatorLiveData mediatorLiveData = this.$result;
                Intrinsics.checkNotNull(liveData2);
                mediatorLiveData.removeSource(liveData2);
            }
            this.liveData = liveData;
            if (liveData != null) {
                MediatorLiveData mediatorLiveData2 = this.$result;
                Intrinsics.checkNotNull(liveData);
                final MediatorLiveData mediatorLiveData3 = this.$result;
                mediatorLiveData2.addSource(liveData, new Transformations$sam$androidx_lifecycle_Observer$0(new Function1() { // from class: androidx.lifecycle.Transformations$switchMap$2$$ExternalSyntheticLambda0
                    @Override // kotlin.jvm.functions.Function1
                    public final Object invoke(Object obj2) {
                        return Transformations.AnonymousClass2.onChanged$lambda$0(mediatorLiveData3, obj2);
                    }
                }));
            }
        }

        /* JADX INFO: Access modifiers changed from: private */
        public static final Unit onChanged$lambda$0(MediatorLiveData mediatorLiveData, Object obj) {
            mediatorLiveData.setValue(obj);
            return Unit.INSTANCE;
        }
    }

    public static final <X> LiveData<X> distinctUntilChanged(LiveData<X> liveData) {
        final MediatorLiveData mediatorLiveData;
        Intrinsics.checkNotNullParameter(liveData, "<this>");
        final Ref$BooleanRef ref$BooleanRef = new Ref$BooleanRef();
        ref$BooleanRef.element = true;
        if (liveData.isInitialized()) {
            ref$BooleanRef.element = false;
            mediatorLiveData = new MediatorLiveData(liveData.getValue());
        } else {
            mediatorLiveData = new MediatorLiveData();
        }
        mediatorLiveData.addSource(liveData, new Transformations$sam$androidx_lifecycle_Observer$0(new Function1() { // from class: androidx.lifecycle.Transformations$$ExternalSyntheticLambda2
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return Transformations.distinctUntilChanged$lambda$4(mediatorLiveData, ref$BooleanRef, obj);
            }
        }));
        return mediatorLiveData;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Unit distinctUntilChanged$lambda$4(MediatorLiveData mediatorLiveData, Ref$BooleanRef ref$BooleanRef, Object obj) {
        T value = mediatorLiveData.getValue();
        if (ref$BooleanRef.element || ((value == 0 && obj != null) || (value != 0 && !Intrinsics.areEqual(value, obj)))) {
            ref$BooleanRef.element = false;
            mediatorLiveData.setValue(obj);
        }
        return Unit.INSTANCE;
    }
}
