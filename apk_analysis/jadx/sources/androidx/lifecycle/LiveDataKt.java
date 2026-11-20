package androidx.lifecycle;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: LiveData.kt */
/* JADX INFO: loaded from: classes.dex */
public final class LiveDataKt {
    public static final <T> Observer<T> observe(LiveData<T> liveData, LifecycleOwner owner, final Function1<? super T, Unit> onChanged) {
        Intrinsics.checkNotNullParameter(liveData, "<this>");
        Intrinsics.checkNotNullParameter(owner, "owner");
        Intrinsics.checkNotNullParameter(onChanged, "onChanged");
        Observer<T> observer = new Observer() { // from class: androidx.lifecycle.LiveDataKt$observe$wrappedObserver$1
            @Override // androidx.lifecycle.Observer
            public final void onChanged(T t) {
                onChanged.invoke(t);
            }
        };
        liveData.observe(owner, observer);
        return observer;
    }
}
